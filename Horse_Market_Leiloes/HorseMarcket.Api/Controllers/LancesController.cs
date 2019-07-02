using System;
using System.Security.Claims;
using System.Threading.Tasks;
using HorseMarket.Core.Aggregate.Dtos;
using HorseMarket.Core.Aggregate.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HorseMarket.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LancesController : ControllerBase
    {
        private readonly ILanceService _lanceService;

        public LancesController(ILanceService lanceService)
        {
            _lanceService = lanceService;
        }

        [HttpPost]
        public async Task<IActionResult> RealizarLance([FromBody] LanceDto lanceDto)
        {
            try
            {
                var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                lanceDto.UserId = userId;

                var result = await _lanceService.RealizarLance(lanceDto);

                return Created("", result);
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }
    }
}