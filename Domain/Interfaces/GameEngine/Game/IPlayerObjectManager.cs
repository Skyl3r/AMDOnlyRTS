using System.Collections.Generic;
using AmdOnlyRts.Domain.Interfaces.GameEngine.GameObject.PlayerObject;

namespace AmdOnlyRts.Domain.Interfaces.GameEngine.Game
{
	public interface IPlayerObjectManager
	{
		List<IPlayerObject> PlayerObjects { get; set; }
	}
}
