using AmdOnlyRts.Domain.Interfaces.GameObject.Unit;
using System;

namespace AMDOnlyRTS.Contracts.Data.Classes.GameEngine.GameObject.Unit
{
	public class Unit : IUnit
	{
		public string Description { get; set; }

		public int MoveSpeed { get; set; }

		public string Name { get; set; }

		public int TurnSpeed { get; set; }

		public void OnSelected()
		{
			throw new NotImplementedException();
		}
	}
}
