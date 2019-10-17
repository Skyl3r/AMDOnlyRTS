

namespace BrokenDigSky.AmdOnlyRts.Domain.Interfaces.GameEngine
{
	public interface IUnit : IGameObject
	{
		int MoveSpeed { get; set; }
		int TurnSpeed { get; set; }

	}
}
