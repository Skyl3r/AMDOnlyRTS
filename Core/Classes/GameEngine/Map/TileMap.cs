using System;

namespace AmdOnlyRts.Core.GameEngine.Map
{
    public class TileMap
    {
        public Tile[,] data;
        public int Width;
        public int Height;

        public TileMap(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            data = new Tile[width, height];
        }

        public void setTile(int x, int y, Tile tile)
        {
            data[x, y] = tile;
        }

        public void setMap(Tile[,] valueMap)
        {

            if (valueMap.GetLength(0) == Width && valueMap.GetLength(1) == Height)
            {
                data = valueMap;
            }
            else throw new Exception("NoiseMap.Map size does not match the array size given.");
        }
    }
}