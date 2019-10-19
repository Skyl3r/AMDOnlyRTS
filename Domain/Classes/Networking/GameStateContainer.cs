using System;
using System.Collections.Generic;

namespace AmdOnlyRts.Domain.Classes.Networking
{
  public class GameStateContainer
  {
    public Dictionary<Guid, GameState> GameStates { get; set; }
  }
}