using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace GoodGuysCommunity.Web.Areas.Broadcast.Hubs
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            this.Clients.All.SendAsync("broadcastMessage", name, message);
        }
    }
}
