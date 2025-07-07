using Application.Layer.Services;
using Domain.Layer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace RaceStrategyManagerService.Controllers
{
    [Route("api/v1/Strategy/[controller]")]
    [ApiController]
    public class PilotsController : ControllerBase
    {
        private readonly PilotsService<PilotsEntity> _pilotsService;
        public PilotsController(PilotsService<PilotsEntity> PilotsService) =>_pilotsService = PilotsService;
        

        [HttpGet]
        public IActionResult GetPilots()
        {
            var result = _pilotsService.GetAll().Result;
            return Ok(result);
        }


        [HttpPost("{id}")]
        public IActionResult GetById(string id) 
        {
            var result  = _pilotsService.GetById(id).Result;

            return Ok(result);
        }

    }
}
