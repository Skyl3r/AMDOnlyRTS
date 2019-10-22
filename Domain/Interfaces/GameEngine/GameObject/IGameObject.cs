namespace AmdOnlyRts.Domain.Interfaces.GameEngine.GameObject
{
	public interface IGameObject
	{

		string Name { get; set; }
		string Description { get; set; } 

		void OnSelected();
    }
}
