using System;
using AmdOnlyRts.Domain.Interfaces.GameEngine.Map;

namespace AmdOnlyRts.Core.GameEngine.Map
{
    public class TileMap : ITileMap
    {
        public ITile[,] Data { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public TileMap(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            Data = new Tile[width, height];
        }

        public void setTile(int x, int y, Tile tile)
        {
            Data[x, y] = tile;
        }

        public void setTiles(Tile[,] valueMap)
        {

            if (valueMap.GetLength(0) == Width && valueMap.GetLength(1) == Height)
            {
                Data = valueMap;
            }
            else throw new Exception("NoiseMap.Map size does not match the array size given.");
        }
    }
}