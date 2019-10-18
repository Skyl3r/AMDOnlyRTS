using AmdOnlyRts.Domain.Interfaces.Game;
using System.Collections.Generic;

namespace AmdOnlyRts.Domain.Interfaces.Networking
{
	public interface ILobby
	{
		List<IPlayer> Players { get; set; }
	}
}
