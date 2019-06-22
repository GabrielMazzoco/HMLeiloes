using HorseMarket.Core.SharedKernel.Entitites;
using HorseMarket.Core.SharedKernel.Interfaces;

namespace HorseMarket.Infra.Data.Repositories
{
    public class FotoRepository : Repository<Foto>, IFotoRepository
    {
        public FotoRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
