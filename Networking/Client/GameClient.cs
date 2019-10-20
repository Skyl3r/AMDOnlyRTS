using System;
using System.Threading.Tasks;
using AmdOnlyRts.Domain.Interfaces.Game;
using Microsoft.AspNetCore.SignalR.Client;

namespace AmdOnlyRts.Networking.Client
{
  public class GameClient : IDisposable
  {
    private readonly string _hostAddress;
    private readonly int _port;
    private readonly HubConnection _connection;
    
    public GameClient(string hostAddress, int port)
    {
      _hostAddress = hostAddress;
      _port = port;
      _connection = new HubConnectionBuilder()
        .WithUrl($"http://{hostAddress}:{_port}/game")
        .Build();
    }

    public Task StartAsync()
    {
      return _connection.StartAsync();
    }

    public Task StopAsync()
    {
      return _connection.StopAsync();
    }

    public Task Chat(string name, string message)
    {
      return _connection.InvokeAsync("Send", name, message);
    }
    
    public Task JoinLobby(Guid lobbyId, IPlayer player)
    {
      return _connection.InvokeAsync("JoinLobby", lobbyId, player);
    }

    public Task CreateLobby(string name, IPlayer player)
    {
      return _connection.InvokeAsync("CreateLobby", name, player);
    }

    public void RegisterCallback(Action<string, string> callBack)
    {
      _connection.On<string, string>("Send", callBack);
    }

    public void RegisterLobbyUpdateCallback(Action<Guid> callBack)
    {
      _connection.On("PlayerJoin", callBack);
      _connection.On("PlayerLeave", callBack);
    }

    public void Dispose()
    {
      _connection.StopAsync().Wait();
      _connection.DisposeAsync().Wait();
    }
  }
}