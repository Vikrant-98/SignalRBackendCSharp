
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.AspNetCore.SignalR;
using Abp.Dependency;
using Abp.Runtime.Session;

namespace SignalRAPI.Services
{
    public class ChatHub : Hub , ITransientDependency
    {
        public IAbpSession AbpSession { get; set; }
        protected IHubContext<ChatHub> _context;
        public ChatHub(IHubContext<ChatHub> context) 
        {
            _context = context;
        }

        public async Task SendMessageToAll(string message)
        {
            await _context.Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
