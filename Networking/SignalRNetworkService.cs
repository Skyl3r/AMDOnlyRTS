using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AmdOnlyRts.Domain.Interfaces.GameEngine.Game;
using AmdOnlyRts.Domain.Interfaces.Networking;
using AmdOnlyRts.Networking.Classes;
using Microsoft.Extensions.DependencyInjection;

namespace AmdOnlyRts.Networking
{
    public class SignalRNetworkService : INetworkService
    {
        private readonly IServiceProvider _container;

        public SignalRNetworkService(IServiceProvider container)
        {
            _container = container;
        }

        public Task<IConnection> ConnectPublicGame(Guid gameId, string address, int port)
        {
            throw new NotImplementedException();
        }

        public async Task<IConnection> CreateLanGame(int port, IPlayer player)
        {
            var host = new HostConnection(port, _container);
            await host.ConnectAsync(Guid.Empty, player);
            return host;
        }

        public Task<IConnection> CreatePublicGame(IPlayer player)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ILobby>> GetLobbyListing(string address, int port)
        {
            var client = new ClientConnection(address, port, _container);
            return await client.GetLobbyListing();
        }

        public async Task<IConnection> JoinLanGame(string address, int port, IPlayer player)
        {
            var client = new ClientConnection(address, port, _container);
            var lobby = await client.GetLocalLobby();
            await client.JoinLobby(lobby.GameId, player);

            return client;
        }
    }
}