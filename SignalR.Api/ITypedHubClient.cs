using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR.Api
{
    public interface ITypedHubClient
    {
        Task BroadcastMessage(string type, string payload);
    }
}
