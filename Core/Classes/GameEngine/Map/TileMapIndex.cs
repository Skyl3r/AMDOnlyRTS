using System;
using System.Collections.Generic;
using AmdOnlyRts.Domain.Interfaces.GameEngine.Map;
using AmdOnlyRts.Domain.Interfaces.Renderer;

namespace AmdOnlyRts.Core.GameEngine.Map
{
    public class TileMapIndex : ITileMapIndex
    {
        public Dictionary<int, IDrawable> Tiles { get; set; }

        public TileMapIndex() {
            Tiles = new Dictionary<int, IDrawable>();
        }

        public void Add(int id, IDrawable drawable)
        {
            Tiles.Add(id, drawable);
        }

        public IDrawable GetTile(int id)
        {
            return Tiles[id];
        }
    }
}