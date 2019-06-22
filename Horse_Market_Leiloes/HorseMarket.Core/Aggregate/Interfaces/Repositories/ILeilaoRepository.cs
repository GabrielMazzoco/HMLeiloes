using System.Collections.Generic;
using System.Threading.Tasks;
using HorseMarket.Core.SharedKernel.Interfaces;

namespace HorseMarket.Core.Aggregate.Interfaces.Repositories
{
    public interface ILeilaoRepository : IRepository<Leilao>
    {
        Task<IEnumerable<Leilao>> GetLeiloes();
    }
}
