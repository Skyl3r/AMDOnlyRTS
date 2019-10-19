using Love;

namespace AmdOnlyRts.Renderer.Classes
{
  public class LoveGraphics : Graphics {


        public LoveGraphics() {

        }

        public override void DrawText(string text, int x, int y) {
            Love.Graphics.Print(text, x, y);
        }
        public override void DrawRect(float width, float height, float x, float y){
            //Love.Graphics.SetColor(new Color(0, 255, 0 , 255));
            Love.Graphics.Rectangle(DrawMode.Fill, x, y, width, height);
        }

    }

    
}
