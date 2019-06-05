using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using HorseMarket.Core.Aggregate.Entities;
using HorseMarket.Core.AuthAggregate.Dtos;
using HorseMarket.Core.AuthAggregate.Interfaces;
using HorseMarket.Core.SharedKernel.Interfaces;
using HorseMarket.Core.SharedKernel.Service;
using Microsoft.IdentityModel.Tokens;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace HorseMarket.Application.Services
{
    public class AuthService : BaseService, IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public AuthService(IUnitOfWork unitOfWork, IAuthRepository authRepository, IMapper mapper,
            IConfiguration config) : base(unitOfWork)
        {
            _authRepository = authRepository;
            _mapper = mapper;
            _config = config;
        }

        public void Register(UserToCreateDto userToCreate)
        {
            userToCreate.Username = userToCreate.Username.ToLower();

            if (_authRepository.Any(x => x.Username == userToCreate.Username))
            {
                throw new Exception("Já existe alguem com esse Nome de Usuário.");
            }

            var userToAdd = _mapper.Map<User>(userToCreate);

            CreatePasswordHash(userToCreate.Password, out var passwordHash, out var passwordSalt);

            userToAdd.PasswordHash = passwordHash;
            userToAdd.PasswordSalt = passwordSalt;

            _authRepository.Add(userToAdd);
            
            if(!Commit())
                throw new Exception("Houve algum erro ao salvar no Banco de Dados.");
        }

        public string Login(UserForLoginDto userForLogin)
        {
            var userFromRepo = _authRepository.FindAsNoTracking(x => x.Username == userForLogin.Username.ToLower())
                .FirstOrDefault();

            if (userFromRepo == null || !VerifyPasswordHash(userForLogin.Password, userFromRepo.PasswordHash,
                    userFromRepo.PasswordSalt))
                throw new Exception("Usuario e/ou senha invalidos!");

            var token = GenerateToken(userFromRepo);

            return token;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                        return false;
                }
            }
            return true;
        }

        private string GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, value: user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
