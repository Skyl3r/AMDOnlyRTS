using AmdOnlyRts.Domain.Interfaces.Renderer;
using AmdOnlyRts.Domain.Interfaces.Renderer.Input;
using AmdOnlyRts.Renderer.Classes.LoveRenderer.Input;
using Love;

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
