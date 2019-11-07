using System;
using System.Linq;
using System.Collections.Generic;

namespace AmdOnlyRts.Networking.Classes
{
  public class GameStateContainer
  {
    public Dictionary<Guid, GameState> GameStates { get; }

    public GameStateContainer()
    {
        GameStates = new Dictionary<Guid, GameState>();
    }

    public string PlayerLeave(string connectionId)
    {
      var gameState = GameStates.Values
        .SingleOrDefault(x => x.Lobby.NetPlayers.ContainsKey(connectionId));
      if (gameState != null)
      {
        gameState.Lobby.NetPlayers.Remove(connectionId);
        return gameState.GameId.ToString();
      }
      return null;
    }
  }
}
