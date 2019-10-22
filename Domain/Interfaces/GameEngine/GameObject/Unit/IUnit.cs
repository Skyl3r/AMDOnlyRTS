

using System.Collections.Generic;
using AmdOnlyRts.Domain.Interfaces.GameEngine.Map;

namespace AmdOnlyRts.Domain.Interfaces.GameEngine.GameObject.Unit
{
	public interface IUnit : IGameObject
	{
		int MoveSpeed { get; set; }
		int TurnSpeed { get; set; }

		List<ITile> WalkableTiles { get; set; }

		//Unit specific actions
        void OnMove();
		void OnAttack();
		void OnAbility();

	}
}
