using System;
using System.Threading.Tasks;
using AmdOnlyRts.Domain.Interfaces.Game;
using AmdOnlyRts.Domain.Interfaces.Renderer;
using Love;
using AmdOnlyRts.MathUtilities;

namespace AmdOnlyRts.Core.GameEngine.Map
{
    public class Map
    {
        public int Width;

        public int Height;

        private int[,] data;

        public Map(int width, int height) {
            data = new int[width, height];
            Width = width;
            Height = height;
        }

        public int getWidth() {
            return Width;
        }

        public int getHeight() {
            return Height;
        }
    }
}