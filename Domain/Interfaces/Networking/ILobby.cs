using AmdOnlyRts.Domain.Interfaces.GameEngine.Game;
using System;
using System.Collections.Generic;

namespace AmdOnlyRts.Domain.Interfaces.Networking
{
	public interface ILobby
	{
		Dictionary<string, IPlayer> Players { get; set; }

		Guid GameId { get; set; }
		string DisplayName { get; set; }
	}
}
