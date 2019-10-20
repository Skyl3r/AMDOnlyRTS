﻿using AmdOnlyRts.Domain.Interfaces.Game;
using System;
using System.Collections.Generic;

namespace AmdOnlyRts.Domain.Interfaces.Networking
{
	public interface ILobby
	{
		Dictionary<string, IPlayer> Players { get; set; }

		Guid GameId { get; set; }
		public string DisplayName { get; set; }
	}
}
