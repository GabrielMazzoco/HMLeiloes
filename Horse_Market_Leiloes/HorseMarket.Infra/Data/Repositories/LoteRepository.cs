using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                    .ThenInclude(x => x.Fotos)
                .Where(x => x.LeilaoId == idLeilao)
                .ToList();
        }

        public Lote GetLote(int idLote)
        {
            return _dbContext.Set<Lote>()
                .AsNoTracking()
                .Include(x => x.Cavalo)
                    .ThenInclude(x => x.Fotos)
                .FirstOrDefault(x => x.Ativo && x.Id == idLote);
        }

        public void AddCavalo(Cavalo cavalo)
        {
            _dbContext.Set<Cavalo>().Add(cavalo);
        }

        public async Task<decimal> GetValorLanceAtual(int idLote)
        {
            var lote = await _dbContext.Set<Lote>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Ativo && x.Id == idLote);

            if (lote.LanceAtualId != null)
            {
                var lance = await _dbContext.Set<Lance>()
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == lote.LanceAtualId);

                return lance.Valor + lote.Incremento;
            }

            return lote.LanceMinimo + lote.Incremento;
        }

        public async Task<Lote> GetLoteWithTracking(int idLote)
        {
            var lote = await _dbContext.Set<Lote>()
                .AsTracking()
                .FirstOrDefaultAsync(x => x.Id == idLote);

            return lote;
        }
    }
}
