using BrokenDigSky.AmdOnlyRts.Domain.Interfaces.GameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
