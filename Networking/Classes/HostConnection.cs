using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AmdOnlyRts.Domain.Interfaces.Networking;
using AmdOnlyRts.Networking.Client;
using AmdOnlyRts.Networking.Server;

namespace AmdOnlyRts.Networking.Classes
{
  public class HostConnection : IConnection
  {
    private readonly GameServer _gameServer;
    private readonly GameClient _gameClient;
    public Guid ConnectionId { get; private set; }


    public HostConnection(int port)
    {

      _gameServer = new GameServer(port);
      _gameClient = new GameClient("localhost", port);
      ConnectionId = Guid.NewGuid();
    }

    public async Task DisconnectAsync()
    {
      await _gameServer.StopAsync();
      await _gameClient.StopAsync();
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
      _gameServer.Dispose();
    }

    

    public async Task ConnectLocalAsync()
    {
      await _gameServer.StopAsync();
      //We may need a thread sleep here
      _gameClient.RegisterCallback(QueueAction);
      await _gameClient.StartAsync();
    }

    public Task ConnectDedicatedAsync()
    {
      throw new InvalidOperationException();
    }

    public Task<IEnumerable<ILobby>> GetLobbyListing()
    {
      throw new NotImplementedException();
    }
  }
}
