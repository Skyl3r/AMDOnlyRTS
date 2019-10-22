

using System.Collections.Generic;
using AmdOnlyRts.Domain.Interfaces.GameEngine.Map;

namespace AmdOnlyRts.Domain.Interfaces.GameEngine.GameObject.PlayerObject.Unit
{
	public interface IUnit : IPlayerObject
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
