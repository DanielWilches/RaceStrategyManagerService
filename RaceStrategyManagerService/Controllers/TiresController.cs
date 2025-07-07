using Application.Layer.Services;
using Domain.Layer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RaceStrategyManagerService.Controllers
{
    [Route("api/v1/strategy/[controller]")]
    [ApiController]
    public class TiresController : ControllerBase
    {
        private readonly TiresService<TiresEntity> _tiresService;
        public TiresController(TiresService<TiresEntity> tiresService) =>_tiresService = tiresService;

        [HttpGet]        
        public IActionResult GetTires()
        {
            var tires = _tiresService.GetAll().Result;   
            return Ok(tires);
        }
    }
}
