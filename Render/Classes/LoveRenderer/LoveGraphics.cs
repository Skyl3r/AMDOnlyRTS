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
        public void DrawRect(float width, float height, float x, float y){
            //Love.Graphics.SetColor(new Color(0, 255, 0 , 255));
            Love.Graphics.Rectangle(DrawMode.Fill, x, y, width, height);
        }

    }

    
}
