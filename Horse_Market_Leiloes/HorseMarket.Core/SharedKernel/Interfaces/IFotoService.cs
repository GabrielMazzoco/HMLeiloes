using CloudinaryDotNet;
using HorseMarket.Core.SharedKernel.Dtos;

namespace HorseMarket.Core.SharedKernel.Interfaces
{
    public interface IFotoService
    {
        int? AddFotoLeilao(FotoForCreationDto fotoForCreationDto, Cloudinary cloudinary);
    }
}
