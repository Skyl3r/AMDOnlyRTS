
namespace AmdOnlyRts.Renderer.Classes
{
  public abstract class Graphics  {

        public Graphics() {

        }
        
        public abstract void DrawText(string text, int x, int y);
        public abstract void DrawRect(float width, float height, float x, float y);

    }

    
}
