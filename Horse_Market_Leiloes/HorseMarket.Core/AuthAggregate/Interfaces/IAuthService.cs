using HorseMarket.Core.AuthAggregate.Dtos;

namespace HorseMarket.Core.AuthAggregate.Interfaces
{
    public interface IAuthService
    {
        void Register(UserToCreateDto userToCreate);
        string Login(UserForLoginDto userForLogin);
    }
}
