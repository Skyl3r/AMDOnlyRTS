namespace AmdOnlyRts.Domain.Interfaces.Game
{
	public interface IMap
	{
		void Draw();
		
		float[,] Map{get;set;}
		int Width{get;}
		int Height{get;}
	}
}
