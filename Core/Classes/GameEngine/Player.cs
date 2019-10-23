using AmdOnlyRts.Domain.Interfaces.GameEngine.Game;

namespace AmdOnlyRts.Core.GameEngine
{
  public class Player : IPlayer
  {
    public string DisplayName { get; set; }
    public string TeamName { get; set; }
  }
}
