using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace BrokenDigSky.AmdOnlyRts.Networking.Client
{
  public class GameClient
  {
    private readonly IPAddress _hostAddress;
    private readonly int _port;
    private readonly HubConnection _connection;
    private readonly Action<string, string> _callBack;
    
    public GameClient(IPAddress hostAddress, int port, Action<string, string> callBack)
    {
      _hostAddress = hostAddress;
      _port = port;
      _callBack = callBack;
      _connection = new HubConnectionBuilder()
        .WithUrl($"{hostAddress.ToString()}:{_port}")
        .Build();
    }

    public Task Start()
    {
      _connection.On<string, string>("broadcastMessage", _callBack);
      return _connection.StartAsync();
    }
  }
}