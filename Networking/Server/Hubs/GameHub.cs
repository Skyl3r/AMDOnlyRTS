using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace AmdOnlyRts.Networking.Server.Hubs
{
    public class GameHub : Hub
    {
        public async Task Send(string name, string message)
        {
            await Clients.All.SendAsync("Send", name, message);
        }
    }
}