using System;
using System.Collections.Generic;
using AmdOnlyRts.Domain.Interfaces.GameEngine.Game;
using AmdOnlyRts.Domain.Interfaces.Networking;
using AmdOnlyRts.Networking.Classes;
using Microsoft.Extensions.DependencyInjection;

namespace AmdOnlyRts.Networking
{
  public class SignalRNetworkService : INetworkService
  {
    private readonly IServiceCollection _services;
    public SignalRNetworkService(IServiceCollection services)
    {
        _services = services;
    }

    public IConnection ConnectPublicGame(Guid gameId, string address, int port)
    {
      throw new NotImplementedException();
    }

    public IConnection CreateLanGame(int port, IPlayer player)
    {
      var host = new HostConnection(port, _services);
      host.ConnectAsync(Guid.Empty, player).GetAwaiter().GetResult();
      return host;
    }

    public IConnection CreatePublicGame(IPlayer player)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<ILobby> GetLobbyListing(string address, int port)
    {
      var client = new ClientConnection(address, port, _services);
      return client.GetLobbyListing().GetAwaiter().GetResult();
    }

    public IConnection JoinDirectGame(string address, int port)
    {
      var client = new ClientConnection(address, port, _services);
      var lobbys = client.GetLobbyListing().GetAwaiter().GetResult();

      return client;
    }
  }
}