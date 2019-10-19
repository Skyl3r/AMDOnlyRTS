using System;
using System.Threading.Tasks;
using AmdOnlyRts.Domain.Interfaces.Networking;
using AmdOnlyRts.Domain.Models;
using Microsoft.AspNetCore.SignalR;

namespace AmdOnlyRts.Networking.Server.Hubs
{
    public class GameHub : Hub
    {
        public async Task Send(string name, string message)
        {
            await Clients.All.SendAsync("Send", name, message);
        }


        public async Task Action(Guid clientId, string message)
        {
            await Clients.All.SendAsync("Send", clientId, message);
        }

        public async Task Handshake(INetPlayer player)
        {
            await Clients.All.SendAsync("Rollcall");
        }

        public async Task CreateLobby(CreateLobbyRequest lobbyRequest)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, lobbyRequest.Name);
        }
    }
}