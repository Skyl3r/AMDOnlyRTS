using AmdOnlyRts.Domain.Interfaces.GameObject;
using System;

namespace AMDOnlyRTS.Contracts.Data.Classes.GameEngine.GameObject
{
	public class GameObject : IGameObject
	{
		public string Description { get; set; }

		public string Name { get; set; }

		public void OnSelected()
		{
			throw new NotImplementedException();
		}
	}
}
