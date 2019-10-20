using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AmdOnlyRts.Domain.Interfaces.Game;
using AmdOnlyRts.Domain.Interfaces.Networking;
using AmdOnlyRts.Networking.Client;
using Newtonsoft.Json;

namespace AmdOnlyRts.Networking.Classes
{
  public class ClientConnection : IConnection
  {
    private readonly string _address;
    private readonly GameClient _gameClient;

    public ILobby CurrentLobby { get; private set; }

    public ClientConnection(string address, int port)
    {
      _address = address;
      _gameClient = new GameClient(address, port);
    }
    
    public Task DisconnectAsync()
    {
      return _gameClient.StopAsync();
    }


    public Task<(long gameTime, IAction action)> GetNextAction()
    {
      throw new System.NotImplementedException();
    }

    public Task SendActionAsync(long gameTime, IAction action)
    {
      throw new NotImplementedException();
    }

    private void QueueAction(string name, string message)
    {

    }
    public void Dispose()
    {
      _gameClient.Dispose();
    }

    public async Task ConnectAsync(Guid gameId, IPlayer player)
    {
      _gameClient.RegisterCallback(QueueAction);
      _gameClient.RegisterLobbyUpdateCallback(UpdateLobby);
      await _gameClient.StartAsync();
      await _gameClient.JoinLobby(gameId, player);
    }

    public Task CreateLobby(string name, IPlayer player)
    {
      return _gameClient.CreateLobby(name, player);
    }

    private void UpdateLobby(Guid gameId)
    {
      using(var httpClient = new HttpClient())
      {
        var response = httpClient.GetAsync($"http://{_address}/api/lobby/{gameId}").GetAwaiter().GetResult();

        if(response.IsSuccessStatusCode)
        {
          var responseString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
          CurrentLobby = JsonConvert.DeserializeObject<ILobby>(responseString);
        }
        throw new Exception("There was a problem when making the request");
      }
    }

    public async Task<IEnumerable<ILobby>> GetLobbyListing()
    {
      using(var httpClient = new HttpClient())
      {
        var response = await httpClient.GetAsync($"http://{_address}/api/lobby");

        if(response.IsSuccessStatusCode)
        {
          var responseString = await response.Content.ReadAsStringAsync();
          return JsonConvert.DeserializeObject<IEnumerable<ILobby>>(responseString);
        }
        throw new Exception("There was a problem when making the request");
      }
    }
  }
}
