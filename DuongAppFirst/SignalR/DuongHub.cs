using DuongAppFirst.Application.ViewModels.System;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuongAppFirst.SignalR
{
    public class DuongHub : Hub
    {
        public async Task SendMessage(AnnouncementUserViewModel message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
