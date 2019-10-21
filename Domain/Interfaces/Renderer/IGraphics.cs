

using AmdOnlyRts.Domain.Interfaces.Game;
using AmdOnlyRts.Domain.Interfaces.GameEngine.Map;

namespace AmdOnlyRts.Domain.Interfaces.Renderer
{
  public interface IGraphics {

    void DrawText(string text, int x, int y);
    void DrawRect(float width, float height, float x, float y);
    void DrawTileMap(ICamera camera, ITileMap tileMap);
  }
}
