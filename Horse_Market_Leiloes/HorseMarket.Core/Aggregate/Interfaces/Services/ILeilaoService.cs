using System.Collections.Generic;
using System.Threading.Tasks;
using CloudinaryDotNet;
using HorseMarket.Core.Aggregate.Dtos;
using HorseMarket.Core.SharedKernel.Dtos;

namespace HorseMarket.Core.Aggregate.Interfaces.Services
{
    public interface ILeilaoService
    {
        int CreateLeilao(LeilaoToCreateDto leilaoToCreateDto);
        bool AddFotoLeilao(FotoForCreationDto fotoForCreationDto, Cloudinary cloudinary);
        Task<IEnumerable<LeilaoDto>> GetLeiloes();
        Task<LeilaoDto> GetLeilao(int idLeilao);
    }
}
