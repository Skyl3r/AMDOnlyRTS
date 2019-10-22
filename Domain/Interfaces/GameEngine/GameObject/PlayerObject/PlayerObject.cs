
using AmdOnlyRts.Domain.Interfaces.GameEngine.Game;

namespace AmdOnlyRts.Domain.Interfaces.GameEngine.GameObject.PlayerObject
{
	public interface IPlayerObject: IGameObject
	{
		IPlayer Owner { get; set; }

	}
}
