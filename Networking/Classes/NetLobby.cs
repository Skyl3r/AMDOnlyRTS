using System;
using System.Collections.Generic;
using System.Linq;
using AmdOnlyRts.Domain.Interfaces.GameEngine.Game;
using AmdOnlyRts.Domain.Interfaces.Networking;

namespace AmdOnlyRts.Networking.Classes
{
    public class NetLobby : ILobby
    {
        public Dictionary<string, IPlayer> Players { get; set; }

        public Dictionary<string, NetPlayer> NetPlayers { get; set; }
        public Guid GameId { get; set; }
        public string DisplayName { get; set; }
    }
}