using HorseMarket.Core.Aggregate.Entities;
using HorseMarket.Core.SharedKernel.Interfaces;

namespace HorseMarket.Core.AuthAggregate.Interfaces
{
    public interface IAuthRepository : IRepository<User>
    {
    }
}
