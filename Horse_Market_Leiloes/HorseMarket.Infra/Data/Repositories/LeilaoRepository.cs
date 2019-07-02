using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HorseMarket.Core.Aggregate;
using HorseMarket.Core.Aggregate.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HorseMarket.Infra.Data.Repositories
{
    public class LeilaoRepository : Repository<Leilao>, ILeilaoRepository
    {
        public LeilaoRepository(DataContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Leilao>> GetLeiloes()
        {
            return await _dbContext.Leiloes
                .Include(x => x.Foto)
                .AsNoTracking()
                .Where(x => x.Ativo)
                .ToListAsync();
        }

        public async Task<Leilao> GetLeilao(int idLeilao)
        {
            return await _dbContext.Leiloes
                .Include(x => x.Foto)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Ativo && x.Id == idLeilao);
        }
    }
}
