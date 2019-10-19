

namespace AmdOnlyRts.Domain.Interfaces.Renderer
{
  public interface IGraphics {

    void DrawText(string text, int x, int y);
    void DrawRect(float width, float height, float x, float y);
  }
}
