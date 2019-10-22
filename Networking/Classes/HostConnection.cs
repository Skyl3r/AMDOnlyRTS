using System;
using System.Threading.Tasks;
using AmdOnlyRts.Domain.Interfaces.Networking;
using AmdOnlyRts.Networking.Server;
using System.Linq;
using System.Threading;
using AmdOnlyRts.Domain.Interfaces.GameEngine.Game;

namespace AmdOnlyRts.Networking.Classes
{
  public class HostConnection : ClientConnection, IConnection
  {
    private readonly GameServer _gameServer;

    public HostConnection(int port) : base("localhost", port)
    {

      _gameServer = new GameServer(port);
    }

    public async new Task DisconnectAsync()
    {
      await _gameServer.StopAsync();
      await base.DisconnectAsync();
    }

    public new void Dispose()
    {
      _gameServer.Dispose();
    }

    public async new Task ConnectAsync(Guid gameId, IPlayer player)
    {
      await _gameServer.StartAsync();
      await base.CreateLobby($"{player.DisplayName}'s local game", player);
      var lobby = await GetLocalLobby();
      await base.ConnectAsync(lobby.GameId, player);
    }

    private async Task<ILobby> GetLocalLobby(int timeout = 0)
    {
      var lobby = (await base.GetLobbyListing()).FirstOrDefault();
      if(lobby == null)
      {
        if(timeout > 400)
        {
          throw new Exception("Failed to get local lobby");
        }
        Thread.Sleep(timeout);
        return await GetLocalLobby(timeout+=100);
      }
      return lobby;
    }

    public Task ConnectDedicatedAsync()
    {
      throw new InvalidOperationException();
    }
  }
}
