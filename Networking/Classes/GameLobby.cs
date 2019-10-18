using BrokenDigSky.AmdOnlyRts.Domain.Interfaces.Networking;
using System.Collections.Generic;
using BrokenDigSky.AmdOnlyRts.Domain.Interfaces.GameEngine;

namespace BrokenDigSky.AmdOnlyRts.Classes
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
