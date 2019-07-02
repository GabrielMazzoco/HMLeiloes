using System.Collections.Generic;
using System.Threading.Tasks;
using HorseMarket.Core.Aggregate.Entities;
using HorseMarket.Core.SharedKernel.Interfaces;

namespace HorseMarket.Core.Aggregate.Interfaces.Repositories
{
    public interface ILoteRepository : IRepository<Lote>
    {
        IEnumerable<Lote> GetLotes(int idLeilao);
        Lote GetLote(int idLote);
        void AddCavalo(Cavalo cavalo);
        Task<decimal> GetValorLanceAtual(int idLote);
        Task<Lote> GetLoteWithTracking(int idLote);
    }
}
