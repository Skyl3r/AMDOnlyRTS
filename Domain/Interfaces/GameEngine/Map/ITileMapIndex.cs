

using System.Collections.Generic;
using AmdOnlyRts.Domain.Interfaces.Renderer;

namespace AmdOnlyRts.Domain.Interfaces.GameEngine.Map
{
	public interface ITileMapIndex
	{
        Dictionary<int, IDrawable> Tiles { get; set; }
        
		IDrawable GetTile(int Id);
		void Add(int id, IDrawable drawable);
	}
}
