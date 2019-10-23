using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AmdOnlyRts.Networking.Classes;
using Microsoft.AspNetCore.SignalR;

namespace AmdOnlyRts.Networking.Server.Hubs
{
  public class GameHub : Hub
  {
    private readonly GameStateContainer _gameStateContainer;
    public GameHub(GameStateContainer gameStateContainer)
    {
      _gameStateContainer = gameStateContainer;
    }

    public async Task Chat(string name, string message)
    {
      await Clients.All.SendAsync("Chat", name, message);
    }

    public async Task JoinLobby(Guid gameId, NetPlayer player)
    {
      _gameStateContainer.GameStates[gameId].Lobby.NetPlayers.Add(Context.ConnectionId, player);
      await Clients.Group(gameId.ToString()).SendAsync("PlayerJoin", gameId);
    }

    public async Task CreateLobby(string name, NetPlayer player)
    {
      var gameId = Guid.NewGuid();
      _gameStateContainer.GameStates.Add(gameId, 
        new GameState
        {
          GameId = gameId,
          GamePhase= Domain.Enums.GamePhase.Lobby,
          Lobby = new NetLobby
          {
            DisplayName = name,
            GameId = gameId
          }

        });

        await Groups.AddToGroupAsync(Context.ConnectionId, gameId.ToString());
    }

    public override Task OnDisconnectedAsync(Exception e)
    {
      var gameId = _gameStateContainer.PlayerLeave(Context.ConnectionId);
      if (gameId != null)
      {
        Clients.Group(gameId).SendAsync("PlayerLeave");
      }
      return base.OnDisconnectedAsync(e);
    }
  }
}