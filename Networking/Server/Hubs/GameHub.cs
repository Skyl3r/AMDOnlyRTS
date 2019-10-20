using System;
using System.Threading.Tasks;
using AmdOnlyRts.Domain.Classes.Networking;
using AmdOnlyRts.Domain.Interfaces.Networking;
using AmdOnlyRts.Domain.Models;
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

    public async Task JoinLobby(Guid lobbyId, INetPlayer player)
    {
      await Clients.All.SendAsync("PlayerJoin");
    }

    public override Task OnDisconnectedAsync(Exception e)
    {
      var gameId = _gameStateContainer.PlayerLeave(Context.ConnectionId);
      if(gameId !=null)
      {
          Clients.Group(gameId).SendAsync("PlayerLeave");
      }
      return base.OnDisconnectedAsync(e);
    }
  }
}