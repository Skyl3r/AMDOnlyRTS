using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace AmdOnlyRts.Networking.Client
{
  public class GameClient
  {
    private readonly string _hostAddress;
    private readonly int _port;
    private readonly HubConnection _connection;
    private readonly Action<string, string> _callBack;
    
    public GameClient(string hostAddress, int port, Action<string, string> callBack)
    {
      _hostAddress = hostAddress;
      _port = port;
      _callBack = callBack;
      _connection = new HubConnectionBuilder()
        .WithUrl($"http://{hostAddress}:{_port}/game")
        .Build();
    }

    public Task Start()
    {
      _connection.On<string, string>("Send", _callBack);
      return _connection.StartAsync();
    }

    public Task Send(string name, string message)
    {
      return _connection.InvokeAsync("Send", name, message);
    }
  }
}