using AMDOnlyRTS.Contracts.Data.Implemetations.Networking;
using AMDOnlyRTS.Contracts.Data.Interfaces.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMDOnlyRTS.Networking
{
    public class Controller
    {
        public ILobby CreateLobby()
        {
            var lobby = new Lobby();
            lobby.Players.Add()

            return lobby;
        }
    }
}
