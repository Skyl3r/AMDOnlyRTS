using AmdOnlyRts.Domain.Interfaces.GameEngine.GameObject.Resource;

namespace AmdOnlyRts.Core.Classes.GameEngine.GameObject.Resource
{
	public class Resource : IResource
	{
		public string Description { get; set; }

		public string Name { get; set; }

		public void OnSelected()
		{
			
		}
	}
}
