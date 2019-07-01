using System.Collections.Generic;
using HorseMarket.Core.Aggregate.Entities;
using HorseMarket.Core.SharedKernel.Interfaces;

namespace HorseMarket.Core.Aggregate.Interfaces.Repositories
{
    public interface ILoteRepository : IRepository<Lote>
    {
        IEnumerable<Lote> GetLotes(int idLeilao);
        void AddCavalo(Cavalo cavalo);
    }
}
