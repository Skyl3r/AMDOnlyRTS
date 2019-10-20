using AmdOnlyRts.Domain.Enums;
using AmdOnlyRts.Domain.Interfaces.Game;

namespace AmdOnlyRts.Domain.Models
{
  public class CreateLobbyRequest
  {
    public GameType GameType { get; set; }
    public IPlayer Player { get; set;}
    public string Name { get; set; }
  }
}
