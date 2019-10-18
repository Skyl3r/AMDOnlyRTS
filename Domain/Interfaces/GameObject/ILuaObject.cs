namespace AmdOnlyRts.Domain.Interfaces.GameObject
{
	public interface ILuaObject
	{

		string Name { get; set; }
		string Description { get; set; } 

		void OnSelected();

	}
}
