using System.Collections.Generic;
using HorseMarket.Core.Aggregate.Dtos;

namespace HorseMarket.Core.Aggregate.Interfaces.Services
{
    public interface ILoteService
    {
        IEnumerable<LoteRegisterDto> GetLotes(int idLeilao);
        LoteRegisterDto CreateLote(LoteRegisterDto loteRegisterDto);
    }
}
