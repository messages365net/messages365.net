using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignalR.Hubs
{
    public class PresenceHub : Hub
    {
        public static int Views { get; set; } = 0;

        public async Task OnLoad()
        {
            Views++;

            await Clients.All.SendAsync("getViews", Views);
        }
    }
}