using System;
using System.Threading.Tasks;
using AmdOnlyRts.Domain.Interfaces.Networking;
using AmdOnlyRts.Networking.Client;

namespace AmdOnlyRts.Networking.Classes
{
  public class ClientConnection : IConnection
  {
    private readonly GameClient _gameClient;
    public Guid ConnectionId { get; private set; }


    public ClientConnection(string address, int port)
    {
      _gameClient = new GameClient(address, port);
      ConnectionId = Guid.NewGuid();
    }
    
    public Task ConnectAsync()
    {
      _gameClient.RegisterCallback(QueueAction);
      return _gameClient.StartAsync();
    }

    public Task DisconnectAsync()
    {
      return _gameClient.StopAsync();
    }


    public Task<(long gameTime, IAction action)> GetNextAction()
    {
      throw new System.NotImplementedException();
    }

    public Task<long> PingAsync()
    {
      throw new System.NotImplementedException();
    }

    public Task SendActionAsync(long gameTime, IAction action)
    {
      throw new NotImplementedException();
    }

    public Task SyncronizeAsync(long gameTime)
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

    public Task ConnectLocalAsync()
    {
      _gameClient.RegisterCallback(QueueAction);
      return _gameClient.StartAsync();
    }

    public Task ConnectDedicatedAsync()
    {
      throw new NotImplementedException();
    }
  }
}
