using System;
using System.Threading.Tasks;
using AmdOnlyRts.Domain.Interfaces.Game;
using AmdOnlyRts.Domain.Interfaces.Renderer;
using Love;
using AmdOnlyRts.MathUtilities;

namespace AmdOnlyRts.Core.GameEngine.Map
{
    public class ChunkMap
    {
        public int Width => throw new NotImplementedException();

        public int Height => throw new NotImplementedException();

        public float[,] Map { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}