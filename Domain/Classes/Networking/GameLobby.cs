using System;
using System.Collections.Generic;
using AmdOnlyRts.Domain.Interfaces.Game;
using AmdOnlyRts.Domain.Interfaces.Networking;

namespace AmdOnlyRts.Domain.Classes.Networking
{
	public class GameLobby : ILobby
	{
    public GameLobby()
		{
			Players = new Dictionary<string, IPlayer> ();
		}

    public Dictionary<string, IPlayer> Players { get; set; }
    public Guid GameId { get; set; }
    public string DisplayName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
	}
}
