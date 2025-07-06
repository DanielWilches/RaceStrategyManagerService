using Application.Layer.Services;
using Domain.Layer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RaceStrategyManagerService.ModelRequest;

namespace RaceStrategyManagerService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class StrategyController : ControllerBase
    {
        private readonly StrategiesService<StrategiesEntity> _strategiesService;
        public StrategyController(StrategiesService<StrategiesEntity> StrategiesService)
        {
            _strategiesService = StrategiesService;
        }


        [HttpGet]
        public IActionResult GetStrategies()
        {
            var result = _strategiesService.GetAll().Result;
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateStrateg(CreateStrategyRequest Create)
        {
            var result = _strategiesService.CreateStrategy(Create.MaxLaps, Create.ClientId, Create.PilotId).Result;
            return Ok(result);
        }
    }
}
