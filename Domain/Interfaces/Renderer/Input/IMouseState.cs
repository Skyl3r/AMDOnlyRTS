

namespace AmdOnlyRts.Domain.Interfaces.Renderer.Input
{

    public interface IMouseState
    {
        int X { get; set; }
        int Y { get; set; }

        bool IsPressed { get; set; }
    }
}
