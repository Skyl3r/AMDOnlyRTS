using AmdOnlyRts.Domain.Interfaces.Renderer.Input;

namespace AmdOnlyRts.Renderer.Classes.LoveRenderer.Input
{
    public class LoveMouseState : IMouseState
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsPressed { get; set; }

        public LoveMouseState() {
            X = 0;
            Y = 0;
            IsPressed = false;
        }

        public LoveMouseState(int x, int y, bool mouseState) {
            X = x;
            Y = y;
            IsPressed = mouseState;
        }
    }
}