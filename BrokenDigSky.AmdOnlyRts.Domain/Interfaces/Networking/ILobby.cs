using BrokenDigSky.AmdOnlyRts.Domain.Interfaces.GameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokenDigSky.AmdOnlyRts.Domain.Interfaces.Networking
{
	public interface ILobby
	{
		List<IPlayer> Players { get; set; }
	}
}
