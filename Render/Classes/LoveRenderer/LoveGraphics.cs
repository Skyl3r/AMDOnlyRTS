using AmdOnlyRts.Domain.Interfaces.Renderer;
using Love;

namespace AmdOnlyRts.Renderer.Classes.LoveRenderer
{
  public class LoveGraphics : IGraphics {


        public LoveGraphics() {

        }

        public void DrawText(string text, int x, int y) {
            Love.Graphics.Print(text, x, y);
        }

    }

    
}
