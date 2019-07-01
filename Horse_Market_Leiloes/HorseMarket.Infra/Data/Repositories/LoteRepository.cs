using System.Collections.Generic;
using System.Linq;
using HorseMarket.Core.Aggregate.Entities;
using HorseMarket.Core.Aggregate.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HorseMarket.Infra.Data.Repositories
{
    public class LoteRepository : Repository<Lote>, ILoteRepository
    {
        public LoteRepository(DataContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Lote> GetLotes(int idLeilao)
        {
            return _dbContext.Set<Lote>()
                .AsNoTracking()
                .Include(x => x.Cavalo)
                .Where(x => x.LeilaoId == idLeilao)
                .ToList();
        }

        public void AddCavalo(Cavalo cavalo)
        {
            _dbContext.Set<Cavalo>().Add(cavalo);
        }
    }
}
