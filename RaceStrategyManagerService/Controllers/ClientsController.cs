using Application.Layer.Services;
using Domain.Layer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace RaceStrategyManagerService.Controllers
{
    [Route("api/v1/Strategy/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ClientsService<ClientsEntity> _ClientService;
        public ClientsController(ClientsService<ClientsEntity> ClientService) =>_ClientService = ClientService;

        [HttpGet("{id}")]
        //[HttpPost("{id}")]
        public IActionResult GetClient(string id)
        {
            var result = _ClientService.GetById(id).Result;
            return Ok(result);
        }
    }
}
