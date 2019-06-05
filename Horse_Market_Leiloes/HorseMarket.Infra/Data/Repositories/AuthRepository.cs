using HorseMarket.Core.Aggregate.Entities;
using HorseMarket.Core.AuthAggregate.Interfaces;

namespace HorseMarket.Infra.Data.Repositories
{
    public class AuthRepository : Repository<User>, IAuthRepository
    {
        public AuthRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
