using System;
using AmdOnlyRts.Domain.Enums;

namespace AmdOnlyRts.Networking.Classes
{
  public class GameState
  {
    public Guid GameId { get; set; }
    public GamePhase GamePhase { get; set; }
    public NetLobby Lobby { get; set; }
  }
}