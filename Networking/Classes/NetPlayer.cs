using AmdOnlyRts.Domain.Interfaces.GameEngine.Game;

namespace AmdOnlyRts.Networking.Classes
{
    public class NetPlayer:IPlayer
    {
        public string DisplayName { get; set; }
        public string TeamName { get; set; }
    }
}