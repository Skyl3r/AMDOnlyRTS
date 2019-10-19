using AmdOnlyRts.Domain.Interfaces.GameObject.Unit;
using System;

namespace AmdOnlyRts.Core.Classes.GameEngine.GameObject.Unit
{
	public class NavalUnit : INavalUnit
	{

		public string Name { get; set; }
		public string Description { get; set; }

		public int TurnSpeed { get; set; }
		public int MoveSpeed { get; set; }

		public void OnSelected()
		{
			throw new NotImplementedException();
		}
	}
}
