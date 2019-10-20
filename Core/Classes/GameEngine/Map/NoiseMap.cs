using System;
using System.Threading.Tasks;
using AmdOnlyRts.Domain.Interfaces.Game;
using AmdOnlyRts.Domain.Interfaces.Renderer;
using Love;
using AmdOnlyRts.MathUtilities;
namespace AmdOnlyRts.Core.GameEngine.Map
{
    public class NoiseMap
    {
        private float[,] map;

        private int width;
        private int height;
        
        public NoiseMap(int w, int h){
            width = w;
            height = h;
            map = new float[width,height];
        }

        public float[,] Map { get => map; set => setMap(value);}

        private void setMap(float[,] valueMap){
            if(valueMap.GetLength(0) == width && valueMap.GetLength(1) == height)
            {
                map = valueMap;
            }
            else throw new Exception("NoiseMap.Map size does not match the array size given.");
        }

        public int Width => width;
        public int Height => height;
    }
}