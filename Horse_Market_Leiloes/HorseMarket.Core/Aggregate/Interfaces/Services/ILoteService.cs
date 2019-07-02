using System.Collections.Generic;
using CloudinaryDotNet;
using HorseMarket.Core.Aggregate.Dtos;
using HorseMarket.Core.SharedKernel.Dtos;

namespace HorseMarket.Core.Aggregate.Interfaces.Services
{
    public interface ILoteService
    {
        IEnumerable<LoteRegisterDto> GetLotes(int idLeilao);
        LoteRegisterDto GetLote(int idLote);
        LoteRegisterDto CreateLote(LoteRegisterDto loteRegisterDto);
        bool AddFotoCavalo(FotoForCreationDto fotoForCreationDto, Cloudinary cloudinary, int loteId);
    }
}
