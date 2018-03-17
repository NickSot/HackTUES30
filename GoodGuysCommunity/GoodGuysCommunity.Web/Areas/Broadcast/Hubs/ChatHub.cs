using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using GoodGuysCommunity.Web.Areas.Broadcast.Hubs.Details;

namespace GoodGuysCommunity.Web.Areas.Broadcast.Hubs
{
    public class ChatHub : Hub
    {

        public void Send(string name, string message, string room)
        {
            // Call the broadcastMessage method to update clients.

            this.Clients.All.SendAsync("broadcastMessage", name, message, room);
        }
    }
}

