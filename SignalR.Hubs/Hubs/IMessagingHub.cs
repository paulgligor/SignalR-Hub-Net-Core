using SignalR.Hubs.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SignlarR.Hubs
{
    public interface IMessagingHub
    {
        Task BroadcastMessage(Message message);
    }
}
