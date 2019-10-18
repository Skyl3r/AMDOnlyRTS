using System;
using AmdOnlyRts.Renderer.Classes;
using Love;

namespace AmdOnlyRts.Core
{
    class Program: Scene
    {

        static LoveRenderer loveRenderer;
        
        //Example using Love Renderer
        static void Main(string[] args)
        {
            loveRenderer = new LoveRenderer();
            loveRenderer.OnLoad += new OnLoad(OnRendererLoad);
            loveRenderer.OnDraw += new OnDraw(OnRendererDraw);
            loveRenderer.OnUpdate += new OnUpdate(OnRendererUpdate);
            loveRenderer.Start();

        }

        public static void OnRendererLoad() {

        }

        public static void OnRendererDraw() {
            loveRenderer.graphics.DrawText("Hello, World", 300, 400);
        }

        public static void OnRendererUpdate() {

        }
    }
}
