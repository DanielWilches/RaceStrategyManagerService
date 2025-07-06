using Application.Layer.Services;
using Domain.Layer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RaceStrategyManagerService.Controllers
{
    [Route("api/strategy/[controller]")]
    [ApiController]
    public class PilotsController : ControllerBase
    {
        private readonly PilotsService<PilotsEntity> _pilotsService;
        public PilotsController(PilotsService<PilotsEntity> PilotsService)
        {
            _pilotsService = PilotsService;
        }


        [HttpGet]
        public IActionResult GetPilots()
        {
            var result = _pilotsService.GetAll().Result;
            return Ok(result);

        }
    }
}
