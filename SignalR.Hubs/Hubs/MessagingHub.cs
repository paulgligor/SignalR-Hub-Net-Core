using Microsoft.AspNetCore.SignalR;
using SignalR.Hubs.Models;
using System;
using System.Threading.Tasks;

namespace SignlarR.Hubs
{
    public class MessagingHub : Hub, IMessagingHub
    {
        public override async Task OnConnectedAsync()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "SignalRUsers");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "SignalRUsers");
            await base.OnDisconnectedAsync(exception);
        }

        public async Task BroadcastMessage(Message message)
        {
            await Clients.All.SendAsync("BroadcastMessage", message);
        }
    }
}
