

namespace AmdOnlyRts.Domain.Interfaces.GameObject.Unit
{
	public interface IUnit : IGameObject
	{
		int MoveSpeed { get; set; }
		int TurnSpeed { get; set; }

	}
}
