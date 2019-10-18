using Love;

namespace AmdOnlyRts.Renderer.Classes
{
  public class LoveGraphics : Graphics {


        public LoveGraphics() {

        }

        public override void DrawText(string text, int x, int y) {
            Love.Graphics.Print(text, x, y);
        }

    }

    
}
