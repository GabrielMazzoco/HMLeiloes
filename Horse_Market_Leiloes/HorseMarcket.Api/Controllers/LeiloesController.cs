using System;
using System.Threading.Tasks;
using CloudinaryDotNet;
using HorseMarket.Api.Configuration;
using HorseMarket.Core.Aggregate.Dtos;
using HorseMarket.Core.Aggregate.Interfaces.Services;
using HorseMarket.Core.SharedKernel.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace HorseMarket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LeiloesController : ControllerBase
    {
        private readonly ILeilaoService _leilaoService;
        private readonly Cloudinary _cloudinary;

        public LeiloesController(ILeilaoService leilaoService, IOptions<CloudinarySettings> cloudinaryConfig)
        {
            _leilaoService = leilaoService;

            _cloudinary = new Cloudinary(new Account
            {
                ApiKey = cloudinaryConfig.Value.ApiKey,
                ApiSecret = cloudinaryConfig.Value.ApiSecret,
                Cloud = cloudinaryConfig.Value.CloudName
            });
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetLeiloes()
        {
            try
            {
                return Ok(await _leilaoService.GetLeiloes());
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }

        [HttpPost]
        public IActionResult CreateLeilao([FromBody] LeilaoToCreateDto leilaoToCreateDto)
        {
            try
            {
                var leilaoId = _leilaoService.CreateLeilao(leilaoToCreateDto);

                return Created("", leilaoId);
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }

        [HttpPost("setFoto/{leilaoId}")]
        public IActionResult AddFotoLeilao([FromForm] FotoForCreationDto fotoForCreationDto, int leilaoId)
        {
            try
            {
                fotoForCreationDto.LeilaoId = leilaoId;
                if (_leilaoService.AddFotoLeilao(fotoForCreationDto, _cloudinary))
                    return Created("", new {});
                
                throw new Exception("Houve um Erro ao Salvar a Imagem do Leilao");
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }
    }
}