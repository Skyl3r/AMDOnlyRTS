using System;
using AmdOnlyRts.Domain.Enums;
using AmdOnlyRts.Domain.Interfaces.Networking;

namespace AmdOnlyRts.Domain.Classes.Networking
{
  public class GameState
  {
    public Guid GameId { get; set; }
    public string Display { get; set; }
    public GamePhase GamePhase { get; set; }
    public ILobby Lobby { get; set; }
  }
}