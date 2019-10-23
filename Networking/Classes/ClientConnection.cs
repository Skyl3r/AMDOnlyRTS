using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using AmdOnlyRts.Domain.Classes.Networking;
using AmdOnlyRts.Domain.Interfaces.GameEngine.Game;
using AmdOnlyRts.Domain.Interfaces.Networking;
using AmdOnlyRts.Networking.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AmdOnlyRts.Networking.Classes
{
    public class ClientConnection : IConnection
    {
        private readonly string _address;
        private readonly int _port;
        private readonly GameClient _gameClient;
        private readonly ILogger<ClientConnection> _log;

        public ILobby CurrentLobby { get; private set; }

        public ClientConnection(string address, int port, IServiceProvider container)
        {
            _log = container.GetService<ILogger<ClientConnection>>();
            _address = address;
            _port = port;
            _gameClient = new GameClient(address, port);
        }

        public virtual Task DisconnectAsync()
        {
            _log.LogDebug("Stopping client connection");
            return _gameClient.StopAsync();
        }


        public Task<(long gameTime, IAction action)> GetNextAction()
        {
            throw new NotImplementedException();
        }

        public Task SendActionAsync(long gameTime, IAction action)
        {
            throw new NotImplementedException();
        }

        private void QueueAction(string name, string message)
        {
        }

        public virtual void Dispose()
        {
            _gameClient.Dispose();
        }

        public virtual Task ConnectAsync()
        {
            _gameClient.RegisterCallback(QueueAction);
            _gameClient.RegisterLobbyUpdateCallback(UpdateLobby);
            return _gameClient.StartAsync();
        }

        public Task JoinLobby(Guid gameId, IPlayer player)
        {
            return _gameClient.JoinLobby(gameId, player);
        }

        public Task CreateLobby(string name, IPlayer player)
        {
            return _gameClient.CreateLobby(name, player);
        }

        private void UpdateLobby(Guid gameId)
        {
            _log.LogDebug($"Updating lobby info for game: {gameId}");
            using var httpClient = new HttpClient();
            var response = httpClient.GetAsync($"http://{_address}/api/lobby/{gameId}").GetAwaiter().GetResult();

            if (response.IsSuccessStatusCode)
            {
                _log.LogDebug("Updated lobby successfully");
                var responseString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                CurrentLobby = JsonConvert.DeserializeObject<NetLobby>(responseString);
            }

            _log.LogError($"There was a problem updating the lobby for game: {gameId}. got {response.StatusCode}");
            throw new Exception("There was a problem when making the request");
        }

        public async Task<IEnumerable<NetLobby>> GetLobbyListing()
        {
            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"http://{_address}:{_port}/api/lobby");

            if (!response.IsSuccessStatusCode)
            {
                _log.LogError($"There was a problem getting the lobby listing. got {response.StatusCode}");
                throw new Exception("There was a problem when making the request");
            }
            
            var responseString = await response.Content.ReadAsStringAsync();
            var lobbies = JsonConvert.DeserializeObject<List<NetLobby>>(responseString);
            _log.LogDebug($"Successfully got the lobby listing, found {lobbies.Count} lobbies.");
            return lobbies;
        }
        
        public async Task<NetLobby> GetLocalLobby(int timeout = 0)
        {
            var lobby = (await GetLobbyListing()).FirstOrDefault();
            if(lobby == null)
            {
                if(timeout > 400)
                {
                    throw new Exception("Failed to get local lobby");
                }
                Thread.Sleep(timeout);
                return await GetLocalLobby(timeout+=100);
            }
            return lobby;
        }
    }
}