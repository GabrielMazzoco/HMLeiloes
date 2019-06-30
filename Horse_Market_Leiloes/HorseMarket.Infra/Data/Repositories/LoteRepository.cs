using HorseMarket.Core.Aggregate.Entities;
using HorseMarket.Core.Aggregate.Interfaces.Repositories;

namespace HorseMarket.Infra.Data.Repositories
{
    public class LoteRepository : Repository<Lote>, ILoteRepository
    {
        public LoteRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
