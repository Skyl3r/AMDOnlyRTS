using System;
using System.Collections.Generic;
using AmdOnlyRts.Domain.Interfaces.GameEngine.Game;
using AmdOnlyRts.Domain.Interfaces.Networking;

namespace AmdOnlyRts.Domain.Classes.Networking
{
    public class GameLobby : ILobby
    {
        public GameLobby()
        {
            Players = new List<IPlayer>();
        }

        public IEnumerable<IPlayer> Players { get; }
        public string DisplayName { get; set; }
    }
}
