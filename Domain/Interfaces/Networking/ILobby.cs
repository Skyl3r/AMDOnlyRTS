using BrokenDigSky.AmdOnlyRts.Domain.Interfaces.GameEngine;
using System.Collections.Generic;

namespace BrokenDigSky.AmdOnlyRts.Domain.Interfaces.Networking
{
	public interface ILobby
	{
		List<IPlayer> Players { get; set; }
	}
}
