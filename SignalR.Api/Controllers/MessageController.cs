using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignlarR.Hubs;
using System.Threading.Tasks;
using SignalR.Hubs.Models;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    public class MessageController : Controller
    {
        private IHubContext<MessagingHub> messageHub;

        public MessageController(IHubContext<MessagingHub> messageHub)
        {
            this.messageHub = messageHub;
        }

        [HttpPost]
        public async Task<IActionResult> Send([FromBody]Message message)
        {
            try
            {
                await messageHub.Clients.All.SendAsync("BroadcastMessage", message);
                return Ok();
            }
            catch (Exception e)
            {
                return Ok(e.ToString());
            }
        }
    }
}