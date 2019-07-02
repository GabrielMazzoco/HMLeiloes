using System;
using CloudinaryDotNet;
using HorseMarket.Api.Configuration;
using HorseMarket.Core.Aggregate.Dtos;
using HorseMarket.Core.Aggregate.Interfaces.Services;
using HorseMarket.Core.SharedKernel.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace HorseMarket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LotesController : ControllerBase
    {
        private readonly ILoteService _loteService;
        private readonly Cloudinary _cloudinary;

        public LotesController(ILoteService loteService, IOptions<CloudinarySettings> cloudinaryConfig)
        {
            _loteService = loteService;
            _cloudinary = new Cloudinary(new Account
            {
                ApiKey = cloudinaryConfig.Value.ApiKey,
                ApiSecret = cloudinaryConfig.Value.ApiSecret,
                Cloud = cloudinaryConfig.Value.CloudName
            });
        }

        [HttpGet("lotes/{idLeilao}")]
        public IActionResult GetAllLotesLeilao(int idLeilao)
        {
            try
            {
                return Ok(_loteService.GetLotes(idLeilao));
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }

        [HttpGet("lote/{idLote}")]
        public IActionResult GetLote(int idLote)
        {
            try
            {
                return Ok(_loteService.GetLote(idLote));
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }

        [HttpPost]
        public IActionResult CreateLote([FromBody] LoteRegisterDto loteRegisterDto)
        {
            try
            {
                return Created("", _loteService.CreateLote(loteRegisterDto));
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }

        [HttpPost("setFoto/{loteId}")]
        public IActionResult AddFotoCavalo([FromForm] FotoForCreationDto fotoForCreationDto, int loteId)
        {
            try
            {   
                if (_loteService.AddFotoCavalo(fotoForCreationDto, _cloudinary, loteId))
                    return Created("", new { });

                throw new Exception("Houve um Erro ao Salvar a Imagem do Leilao");
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }
    }
}