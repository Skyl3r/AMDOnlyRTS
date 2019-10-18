using System.Collections.Generic;
using AmdOnlyRts.Domain.Interfaces.Game;

namespace AmdOnlyRts.Domain.Interfaces.Networking
{
	public interface IConnection
	{
		List<IPlayer> Players { get; set; }
	}
}
