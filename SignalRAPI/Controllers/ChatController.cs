using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRAPI.Services;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {

        private readonly ChatHub _services;

        public ChatController(ChatHub services) 
        {
            _services = services;
        }

        [HttpGet]
        [Route("ChatSignal")]
        public async Task ChatSignal(string message)
        {
            await _services.SendMessageToAll(message).ConfigureAwait(false);
        }
    }
}
