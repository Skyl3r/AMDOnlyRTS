using BrokenDigSky.AmdOnlyRts.Domain.Interfaces.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrokenDigSky.AmdOnlyRts.Domain.Interfaces.GameEngine;

namespace BrokenDigSky.AmdOnlyRts.Networking
{
	class Lobby : ILobby
	{
		public List<IPlayer> Players { get; set; }


		public Lobby()
		{
			Players = new List<IPlayer>();
		}
	}
}
