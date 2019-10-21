using System;
using System.Threading.Tasks;
using AmdOnlyRts.Domain.Interfaces.Game;
using AmdOnlyRts.Domain.Interfaces.Renderer;
using Love;
using AmdOnlyRts.MathUtilities;

namespace AmdOnlyRts.Core.GameEngine.Map
{
    public class Tile : ITile
    {
        public int TypeId { get; set; }

        public Tile(int type)
        {
            this.TypeId = type;
        }
    }
}