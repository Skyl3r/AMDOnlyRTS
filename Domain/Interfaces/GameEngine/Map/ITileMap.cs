

namespace AmdOnlyRts.Domain.Interfaces.GameEngine.Map
{
	public interface ITileMap
	{
        int Width { get; set; }
        int Height { get; set; }

        ITile[,] Data { get; set; }

        
	}
}
