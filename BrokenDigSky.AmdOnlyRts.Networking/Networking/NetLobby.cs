using BrokenDigSky.AmdOnlyRts.Domain.Interfaces.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrokenDigSky.AmdOnlyRts.Domain.Interfaces.GameEngine;

namespace BrokenDigSky.AmdOnlyRts.Networking
{
	public class NetLobby : ILobby
	{
		public List<IPlayer> Players
		{
			get
			{
				throw new NotImplementedException();
			}

			set
			{
				throw new NotImplementedException();
			}
		}
	}
}
