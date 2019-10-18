using Microsoft.AspNetCore.SignalR;

namespace BrokenDigSky.AmdOnlyRts.Networking.Server.Hubs
{
    public class GameHub : Hub
    {
        public void Send(string name, string message)
        {
            Clients.All.SendAsync("broadcastMessage", name, message);
        }
    }
}