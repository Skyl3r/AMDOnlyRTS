using System;
using System.Threading.Tasks;
using AmdOnlyRts.Domain.Interfaces.Networking;
using AmdOnlyRts.Networking.Server;
using System.Linq;
using System.Threading;
using AmdOnlyRts.Domain.Interfaces.GameEngine.Game;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AmdOnlyRts.Networking.Classes
{
  public class HostConnection : ClientConnection, IConnection
  {
    private readonly GameServer _gameServer;
    private readonly ILogger<HostConnection> _log;

    public HostConnection(int port, IServiceProvider container) : base("localhost", port, container)
    {
      _log = container.GetService<ILogger<HostConnection>>();
      _gameServer = new GameServer(port);
    }

    public override Task DisconnectAsync()
    { 
      _log.LogDebug("Disconnecting HostConnection");
      _gameServer.StopAsync();
      return base.DisconnectAsync();
    }

    public override void Dispose()
    {
      _gameServer.Dispose();
      base.Dispose();
    }

    public async Task ConnectAsync(Guid gameId, IPlayer player)
    {
      _log.LogDebug($"Creating server for player {player.DisplayName}");
      await _gameServer.StartAsync();
      _log.LogDebug($"Connecting to local server");
      await base.ConnectAsync();
      _log.LogDebug("Creating lobby");
      await base.CreateLobby($"{player.DisplayName}'s local game", player);
      var lobby = await GetLocalLobby();
      _log.LogDebug($"Lobby created with ID {lobby.GameId}");
      await base.JoinLobby(lobby.GameId, player);
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
