using AmdOnlyRts.Domain.Interfaces.Renderer;

namespace AmdOnlyRts.Renderer.Classes.LoveRenderer
{
    public class Drawable : IDrawable
    {
        public string texturePath { get; set; }

        public Drawable(string filePath) {
            texturePath = filePath;
        }
    }


}
