

namespace AmdOnlyRts.Domain.Interfaces.Renderer.Input
{
    //Values are in world space, not screen space
    public delegate void InputMouseClick(int x, int y); //Mouse pressed and released in the same location
    public delegate void InputSelectionBox(int x, int y, int width, int height); //Mouse pressed and released after dragging
    public delegate void InputMouseDown(int x, int y, int width, int height); //Mouse is down 
    public delegate void InputKeyPress(string key);

    public interface IInput
    {
        event InputMouseClick InputMouseClick;
        event InputSelectionBox InputSelectionBox;
        event InputKeyPress InputKeyPress;
        event InputMouseDown InputMouseDown;
        IMouseState MouseState { get; set; }

        void Update();
    }
}
