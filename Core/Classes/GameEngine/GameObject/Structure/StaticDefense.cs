using AmdOnlyRts.Domain.Interfaces.GameObject.Structure;
using System;

namespace AmdOnlyRts.Core.Classes.GameEngine.GameObject.Structure
{
	public class StaticDefense : IStaticDefense
	{
		public string Description { get; set; }

		public string Name { get; set; }

		public void OnSelected()
		{
			throw new NotImplementedException();
		}
	}
}
