
using System;
using System.Collections.Generic;
using AmdOnlyRts.Domain.Interfaces.GameEngine.Game;

namespace AmdOnlyRts.Domain.Interfaces.Networking
{
  public interface INetworkService
  {
    IConnection CreateLanGame(int port, IPlayer player);
    IConnection CreatePublicGame(IPlayer player);
    IConnection ConnectPublicGame(Guid gameId, string address, int port);
    IConnection JoinDirectGame(string address, int port);
    IEnumerable<ILobby> GetLobbyListing(string address, int port);
  }
}
