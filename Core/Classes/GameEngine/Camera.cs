using System.Numerics;
using AmdOnlyRts.Domain.Interfaces.Game;
using AmdOnlyRts.MathUtilities;

namespace AmdOnlyRts.Core.GameEngine
{
    public class Camera : ICamera
    {
        public Vector2 Position { get; set; }
        public Vector2 Size { get; set; }
        public float Zoom { get; set; }

        public Camera() {
            Zoom = 1.00f; //No zoom
        }

        public void SetPosition(float x, float y) {
            Position = new Vector2(x, y);
        }

        public void SetSize(float x, float y) {
            Size = new Vector2(x, y);
        }
    }
}
