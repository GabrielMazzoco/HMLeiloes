using HorseMarket.Core.Aggregate.Entities;
using HorseMarket.Core.AuthAggregate.Interfaces;
using HorseMarket.Core.SharedKernel.Entitites;

namespace HorseMarket.Infra.Data.Repositories
{
    public class AuthRepository : Repository<User>, IAuthRepository
    {
        public AuthRepository(DataContext dbContext) : base(dbContext)
        {
        }

        public void AddLocalidade(Localidade localidade)
        {
            _dbContext.Add(localidade);
        }
    }
}
