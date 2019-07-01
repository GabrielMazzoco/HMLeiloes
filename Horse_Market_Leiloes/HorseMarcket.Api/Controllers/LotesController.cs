using System;
using HorseMarket.Core.Aggregate.Dtos;
using HorseMarket.Core.Aggregate.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace HorseMarket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LotesController : ControllerBase
    {
        private readonly ILoteService _loteService;

        public LotesController(ILoteService loteService)
        {
            _loteService = loteService;
        }

        [HttpGet("{idLeilao}")]
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
    }
}