
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AmdOnlyRts.Domain.Interfaces.GameEngine.Game;

namespace AmdOnlyRts.Domain.Interfaces.Networking
{
  public interface INetworkService
  {
    Task<IConnection> CreateLanGame(int port, IPlayer player);
    Task<IConnection> JoinLanGame(string address, int port, IPlayer player);
    Task<IConnection> CreatePublicGame(IPlayer player);
    Task<IConnection> ConnectPublicGame(Guid gameId, string address, int port);
    Task<IEnumerable<ILobby>> GetLobbyListing(string address, int port);
  }
}
