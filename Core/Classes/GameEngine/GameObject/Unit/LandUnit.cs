using BrokenDigSky.AmdOnlyRts.Domain.Interfaces.GameEngine;
using System;

namespace AMDOnlyRTS.Contracts.Data.Classes.GameEngine.GameObject.Unit
{
	public class LandUnit : ILandUnit
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
