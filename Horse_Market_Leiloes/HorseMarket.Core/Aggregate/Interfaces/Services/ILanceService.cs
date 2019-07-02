using System.Threading.Tasks;
using HorseMarket.Core.Aggregate.Dtos;

namespace HorseMarket.Core.Aggregate.Interfaces.Services
{
    public interface ILanceService
    {
        Task<LanceDto> RealizarLance(LanceDto lanceDto);
    }
}
