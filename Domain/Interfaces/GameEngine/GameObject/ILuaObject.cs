namespace AmdOnlyRts.Domain.Interfaces.GameEngine.GameObject
{
	public interface ILuaObject
	{

		string Name { get; set; }
		string Description { get; set; } 

		void OnSelected();

	}
}
