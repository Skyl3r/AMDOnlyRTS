using AmdOnlyRts.Domain.Interfaces.GameEngine.Game;

namespace AmdOnlyRts.Domain.Interfaces.GameEngine.GameObject.PlayerObject.Structure
{
	public interface IStructure : IPlayerObject
	{
		IPlayer Owner { get; set; }
	}
}
