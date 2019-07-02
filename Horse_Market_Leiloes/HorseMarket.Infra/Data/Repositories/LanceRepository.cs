using HorseMarket.Core.Aggregate.Entities;
using HorseMarket.Core.Aggregate.Interfaces.Repositories;

namespace HorseMarket.Infra.Data.Repositories
{
    public class LanceRepository : Repository<Lance>, ILanceRepository
    {
        public LanceRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
