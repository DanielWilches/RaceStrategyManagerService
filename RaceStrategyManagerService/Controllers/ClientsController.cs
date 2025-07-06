using Application.Layer.Services;
using Domain.Layer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RaceStrategyManagerService.Controllers
{
    [Route("api/strategy/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {

        private readonly ClientsService<ClientsEntity> _ClientService;

        public ClientsController(ClientsService<ClientsEntity> ClientService)
        {
            _ClientService = ClientService;
        }

        [HttpPost("{id}")]
        public IActionResult GetClient(string id)
        {
            var result = _ClientService.GetById(id).Result;
            return Ok(result);
        }
    }
}
