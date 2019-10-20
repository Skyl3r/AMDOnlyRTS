
using System;
using AmdOnlyRts.Domain.Interfaces.Game;

namespace AmdOnlyRts.Domain.Interfaces.Game
{
	public interface IPlayer
	{
		string DisplayName { get; set; }
		string TeamName { get; set; }
	}
}
