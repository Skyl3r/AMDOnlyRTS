using System;
using System.Linq;
using System.Collections.Generic;

namespace AmdOnlyRts.Domain.Classes.Networking
{
  public class GameStateContainer
  {
    public Dictionary<Guid, GameState> GameStates { get; set; }

    public string PlayerLeave(string connectionId)
    {
      var gameState = GameStates.Values
        .SingleOrDefault(x => x.Lobby.Players.ContainsKey(connectionId));
      if (gameState != null)
      {
        gameState.Lobby.Players.Remove(connectionId);
        return gameState.GameId.ToString();
      }
      return null;
    }
  }
}