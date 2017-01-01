using AMDOnlyRTS.Contracts.Data.Interfaces.GameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMDOnlyRTS.Contracts.Data.Interfaces.Networking
{
    public interface ILobby
    {
        List<IPlayerController> Players { get; set; }
        int MaxPlayers { get; set; }
        string MapName { get; set; }
    }
}
