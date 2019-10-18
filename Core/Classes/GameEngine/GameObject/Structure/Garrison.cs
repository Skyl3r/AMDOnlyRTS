using System;
using AmdOnlyRts.Domain.Interfaces.GameObject.Structure;

namespace AMDOnlyRTS.Contracts.Data.Classes.GameEngine.GameObject.Structure
{
	public class Garrison : IGarrison
	{
		public string Description { get; set; }

		public string Name { get; set; }

		public void OnSelected()
		{
			throw new NotImplementedException();
		}
	}
}
