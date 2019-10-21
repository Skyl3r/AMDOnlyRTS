using System;

namespace AmdOnlyRts.Core.GameEngine.Map
{
    public class NoiseMap
    {

        public int Width;
        public int Height;
        public float[,] Data;

        public NoiseMap(int w, int h)
        {
            Width = w;
            Height = h;
            Data = new float[Width, Height];
        }

        private void setMap(float[,] valueMap)
        {
            if (valueMap.GetLength(0) == Width && valueMap.GetLength(1) == Height)
            {
                Data = valueMap;
            }
            else throw new Exception("NoiseMap.Map size does not match the array size given.");
        }
    }
}