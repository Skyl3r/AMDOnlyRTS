

namespace BrokenDigSky.AmdOnlyRts.Domain.Interfaces.GameEngine
{
	public interface IGameObject
	{

		string Name { get; set; }
		string Description { get; set; } 

		void OnSelected();

	}
}
