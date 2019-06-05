using System;
using HorseMarket.Core.AuthAggregate.Dtos;
using HorseMarket.Core.AuthAggregate.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HorseMarket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register(UserToCreateDto userToCreate)
        {
            try
            {
                _authService.Register(userToCreate);

                return Created("", new {username = userToCreate.Username});
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }

        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto userForLogin)
        {
            try
            {
                var token = _authService.Login(userForLogin);

                return Ok(new {token = token, username = userForLogin.Username});
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }
    }
}