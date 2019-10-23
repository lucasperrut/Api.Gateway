using MicroService.User.App.Interfaces;
using MicroServices.User.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MicroServices.User.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private IClientApplicationService _clientApplicationService;

        public ClientController(IClientApplicationService clientApplicationService)
        {
            _clientApplicationService = clientApplicationService;
        }

        [HttpGet("{id}", Name = "GetClient")]
        public async Task<IActionResult> GetClient(int id)
        {
            var client = await _clientApplicationService.GetClient(id);

            return Ok(client);
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient(Client client)
        {
            await _clientApplicationService.CreateClient(client);

            var link = Url.Link("GetClient", new { client.Id });

            return Created(link, client);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditClient(int id, Client client)
        {
            await _clientApplicationService.EditClient(id, client);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            await _clientApplicationService.DeleteClient(id);

            return NoContent();
        }
    }
}