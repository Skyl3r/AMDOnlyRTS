

namespace AmdOnlyRts.Domain.Interfaces.Renderer.Input
{
    //Values are in world space, not screen space
    public delegate void InputMouseClick(int x, int y);
    public delegate void InputSelectionBox(int x, int y, int width, int height
);
    public delegate void InputKeyPress();

    public interface IInput
    {
        event InputMouseClick InputMouseClick;
        event InputSelectionBox InputSelectionBox;
        event InputKeyPress InputKeyPress;

        void Update();
    }
}
