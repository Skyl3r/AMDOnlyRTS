using AmdOnlyRts.Domain.Interfaces.Game;

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