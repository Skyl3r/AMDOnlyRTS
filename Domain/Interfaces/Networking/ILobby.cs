using AmdOnlyRts.Domain.Interfaces.GameEngine.Game;
using System;
using System.Collections.Generic;

namespace AmdOnlyRts.Domain.Interfaces.Networking
{
	public interface ILobby
	{
		IEnumerable<IPlayer> Players { get; }
		string DisplayName { get; }
	}
}
