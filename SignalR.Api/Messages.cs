using System;
using System.Collections.Generic;
using System.Text;

namespace SignalR.Api
{
    public class Message
    {
        public string Type { get; set; }
        public string Payload { get; set; }
    }
}
