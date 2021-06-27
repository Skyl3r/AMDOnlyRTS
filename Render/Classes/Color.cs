using AmdOnlyRts.Domain.Interfaces.Renderer;

namespace AmdOnlyRts.Renderer.Classes.LoveRenderer
{
    public class Color : IColor
    {
        public float r { get; set; }
        public float g { get; set; }
        public float b { get; set; }
        public float alpha { get; set; }

        public Color(float r, float g, float b, float alpha) {
            this.r = r;
            this.g = g;
            this.b = b;
            this.alpha = alpha;
        }

    }


}
