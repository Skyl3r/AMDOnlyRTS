using System.Collections.Generic;
using AmdOnlyRts.Domain.Interfaces.Game;
using AmdOnlyRts.Domain.Interfaces.Networking;

namespace AmdOnlyRts.Networking.Classes
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
