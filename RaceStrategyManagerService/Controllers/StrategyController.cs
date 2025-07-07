using Application.Layer.Services;
using Domain.Layer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RaceStrategyManagerService.ModelRequest;

namespace RaceStrategyManagerService.Controllers
{
    
    [ApiController]
    public class StrategyController : ControllerBase
    {
        private readonly StrategiesService<StrategiesEntity> _strategiesService;
        public StrategyController(StrategiesService<StrategiesEntity> StrategiesService) => _strategiesService = StrategiesService;

        [HttpGet("api/v1/[controller]/")]
        public IActionResult GetStrategies()
        {
            var result = _strategiesService.GetAll().Result;
            return Ok(result);
        }

        [HttpPost("api/v1/[controller]/optimal")]
        public IActionResult CreateStrateg([FromQuery] string maxLaps, [FromQuery] string ClientId, [FromQuery] string PilotId)
        {
            var result = _strategiesService.CreateStrategy(maxLaps, ClientId, PilotId).Result;
            return Ok(result);
        }
    }
}
