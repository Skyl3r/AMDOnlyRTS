using System;
using System.Threading.Tasks;
using AmdOnlyRts.Domain.Interfaces.Game;
using AmdOnlyRts.Domain.Interfaces.Renderer;
using Love;
using AmdOnlyRts.MathUtilities;

namespace AmdOnlyRts.Core.GameEngine.Map
{
    public class TileMap
    {
        private Tile[,] map;
        private int width;
        private int height;
        public float TileWidth;

        public Tile[,] Map { get =>map; set => setMap(value); }

        public int Width => width;

        public int Height => width;

        public TileMap(int width, int height){
            this.width = width;
            this.height = height;
            map = new Tile[width,height];
            TileWidth = 100.0f/width * 10;
        }

        public void setMap(Tile[,] valueMap){
            
            if(valueMap.GetLength(0) == width && valueMap.GetLength(1) == height)
            {
                map = valueMap;
            }
            else throw new Exception("NoiseMap.Map size does not match the array size given.");
        }
        		public void Draw(IRenderer renderer)
		{
			for(int x = 1; x < Map.GetLength(0); x += 1)
			{
				for(int y = 1; y < Map.GetLength(1); y += 1)
				{
                    map[x,y].Draw(renderer);
				}
			}
        }
    }
}