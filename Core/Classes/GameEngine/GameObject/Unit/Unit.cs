using AmdOnlyRts.Domain.Interfaces.GameEngine.GameObject.Unit;
using AmdOnlyRts.Domain.Interfaces.GameEngine.Map;
using System;
using System.Collections.Generic;

namespace AmdOnlyRts.Core.Classes.GameEngine.GameObject.Unit
{
	public class Unit : IUnit
	{
		public string Name { get; set; }
		public string Description { get; set; }

		public int TurnSpeed { get; set; }
		public int MoveSpeed { get; set; }

		public List<ITile> WalkableTiles { get; set; }

        public void OnAbility()
        {
			
        }

        public void OnAttack()
        {

        }

        public void OnMove()
        {

        }

        public void OnSelected()
		{

		}

		
	}
}
