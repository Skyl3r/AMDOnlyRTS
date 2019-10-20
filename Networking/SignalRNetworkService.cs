using System;
using AmdOnlyRts.Domain.Interfaces.Networking;
using AmdOnlyRts.Networking.Classes;

namespace AmdOnlyRts.Networking
{
  public class SignalRNetworkService : INetworkService
  {
    public IConnection ConnectToServer(string address, int port)
    {
      throw new NotImplementedException();
    }

    public IConnection CreateLanGame(int port)
    {
      return new HostConnection(port);
    }

    public IConnection CreatePublicGame()
    {
      throw new NotImplementedException();
    }

    public IConnection JoinDirectGame(string address, int port)
    {
      var client = new ClientConnection(address, port);
      var lobbys = client.GetLobbyListing().GetAwaiter().GetResult();

      return client;
    }
  }
}