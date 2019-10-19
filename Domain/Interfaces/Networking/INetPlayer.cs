
using System;
using AmdOnlyRts.Domain.Interfaces.Game;

namespace AmdOnlyRts.Domain.Interfaces.Networking
{
	public interface INetPlayer : IPlayer
	{
		string DisplayName { get; set; }
		Guid PlayerId { get; set; }
	}
}
