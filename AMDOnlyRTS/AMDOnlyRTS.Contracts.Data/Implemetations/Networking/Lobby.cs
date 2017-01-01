using AMDOnlyRTS.Contracts.Data.Interfaces.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMDOnlyRTS.Contracts.Data.Interfaces.GameEngine;

namespace AMDOnlyRTS.Contracts.Data.Implemetations.Networking
{
    public class Lobby : ILobby
    {
        public string MapName{ get; set; }

        public int MaxPlayers { get; set; }

        public List<IPlayerController> Players { get; set; }
    }
}
