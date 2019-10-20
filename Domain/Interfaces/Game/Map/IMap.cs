namespace AmdOnlyRts.Domain.Interfaces.Game
{
	public interface IMap
	{
		void Draw(){}
		
		float[,] TileMap{get;}
		float[,] ChunkMap{get;}
		int Width{get;}
		int Height{get;}
	}
}
