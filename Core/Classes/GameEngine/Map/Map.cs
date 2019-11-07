

namespace AmdOnlyRts.Core.GameEngine.Map
{
    public class Map
    {
        public int Width;

        public int Height;

        private int[,] data;

        public Map(int width, int height)
        {
            data = new int[width, height];
            Width = width;
            Height = height;
        }

        public int getWidth()
        {
            return Width;
        }

        public int getHeight()
        {
            return Height;
        }
    }
}
