using AmdOnlyRts.Domain.Enums;
using AmdOnlyRts.Domain.Interfaces.GameEngine.Game;

namespace AmdOnlyRts.Domain.Models
{
  public class CreateLobbyRequest
  {
    public GameType GameType { get; set; }
    public IPlayer Player { get; set;}
    public string Name { get; set; }
  }
}
