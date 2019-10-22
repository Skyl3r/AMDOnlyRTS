using System;
using AmdOnlyRts.Domain.Interfaces.GameEngine.GameObject.Structure;

namespace AmdOnlyRts.Core.Classes.GameEngine.GameObject.Structure
{
	public class Structure : IStructure
	{
		public string Description { get; set; }

		public string Name { get; set; }

		public void OnSelected()
		{
			throw new NotImplementedException();
		}
	}
}
