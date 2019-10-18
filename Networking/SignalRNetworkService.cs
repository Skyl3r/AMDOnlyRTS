using AmdOnlyRts.Domain.Interfaces.Networking;
using AmdOnlyRts.Networking.Classes;

namespace AmdOnlyRts.Networking
{
  public class SignalRNetworkService : INetworkService
  {
    public IConnection CreateLanGame(int port)
    {
      return new HostConnection(port);
    }

    public IConnection JoinDirectGame(string address, int port)
    {
      return new ClientConnection(address, port);
    }
  }
}