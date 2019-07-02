using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using HorseMarket.Core.SharedKernel.Dtos;
using HorseMarket.Core.SharedKernel.Entitites;
using HorseMarket.Core.SharedKernel.Interfaces;
using HorseMarket.Core.SharedKernel.Service;

namespace HorseMarket.Application.Services
{
    public class FotoService : BaseService, IFotoService
    {
        private readonly IMapper _mapper;
        private readonly IFotoRepository _fotoRepository;

        public FotoService(IUnitOfWork unitOfWork, IMapper mapper, IFotoRepository fotoRepository) : base(unitOfWork)
        {
            _mapper = mapper;
            _fotoRepository = fotoRepository;
        }

        public int? AddFotoLeilao(FotoForCreationDto fotoForCreationDto, Cloudinary cloudinary)
        {
            var file = fotoForCreationDto.File;

            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams
                    {
                        File = new FileDescription(file.Name, stream)
                    };

                    uploadResult = cloudinary.Upload(uploadParams);
                }
            }

            fotoForCreationDto.Url = uploadResult.Uri.ToString();
            fotoForCreationDto.PublicId = uploadResult.PublicId;

            var foto = _mapper.Map<Foto>(fotoForCreationDto);
            foto.IsMain = true;

            _fotoRepository.Add(foto);

            return foto.Id;
        }

        public bool AddFotoCavalo(FotoForCreationDto fotoForCreationDto, Cloudinary cloudinary, int idCavalo)
        {
            var file = fotoForCreationDto.File;

            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams
                    {
                        File = new FileDescription(file.Name, stream)
                    };

                    uploadResult = cloudinary.Upload(uploadParams);
                }
            }

            fotoForCreationDto.Url = uploadResult.Uri.ToString();
            fotoForCreationDto.PublicId = uploadResult.PublicId;

            var foto = _mapper.Map<Foto>(fotoForCreationDto);
            foto.IsMain = true;
            foto.CavaloId = idCavalo;

            _fotoRepository.Add(foto);

            return true;
        }
    }
}
