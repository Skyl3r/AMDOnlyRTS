using System;
using AmdOnlyRts.Domain.Interfaces.Renderer.Input;
using Love;

namespace AmdOnlyRts.Renderer.Classes.LoveRenderer.Input
{
    public class LoveInput : IInput
    {
        public event InputMouseClick InputMouseClick;
        public event InputSelectionBox InputSelectionBox;
        public event InputMouseDown InputMouseDown;
        public event InputKeyPress InputKeyPress;

        public IMouseState MouseState { get; set; }

        //represents previous frame mouse state
        LoveMouseState[] mouseDownHistory;
        bool mouseHeld;
        int mouseButton;

        public LoveInput()
        {
            mouseDownHistory = new LoveMouseState[2] { new LoveMouseState(), new LoveMouseState() };
            
            mouseHeld = false; //Remember if the mouse is being held
            mouseButton = Mouse.LeftButton;
        }

        public void Update() {
            //Update public mouse state
            MouseState = new LoveMouseState((int)Mouse.GetX(), (int)Mouse.GetY(), Mouse.IsDown(mouseButton));

            mouseDownHistory[0] = new LoveMouseState((int)Mouse.GetX(), (int)Mouse.GetY(), Mouse.IsDown(mouseButton));

            //On initial click, save click history:
            if(mouseDownHistory[0].IsPressed && !mouseDownHistory[1].IsPressed) {
                mouseDownHistory[1].X = mouseDownHistory[0].X;
                mouseDownHistory[1].Y = mouseDownHistory[0].Y;
                mouseDownHistory[1].IsPressed = mouseDownHistory[0].IsPressed;
            }

            //Mouse was released
            if(!mouseDownHistory[0].IsPressed && mouseDownHistory[1].IsPressed) {
                int x, y, width, height;
                if(mouseDownHistory[0].X > mouseDownHistory[1].X) {
                    x       = mouseDownHistory[1].X;
                    width   = mouseDownHistory[0].X - x;
                } else {
                    x       = mouseDownHistory[0].X;
                    width   = mouseDownHistory[1].X - x;
                }
                
                if(mouseDownHistory[0].Y > mouseDownHistory[1].Y) {
                    y       = mouseDownHistory[1].Y;
                    height  = mouseDownHistory[0].Y - y;
                } else {
                    y       = mouseDownHistory[0].Y;
                    height  = mouseDownHistory[1].Y - y;
                }

                //If they didn't mouse the mouse, treat it as a click
                if(width < 2 && height < 2)
                    InputMouseClick?.Invoke(x, y);
                else
                    InputSelectionBox?.Invoke(x, y, width, height);

                //Reset click state of mouse history
                mouseDownHistory[1].IsPressed = false;
            }

            //Mouse down
            if(mouseDownHistory[1].IsPressed) {
                int x, y, width, height;
                if(mouseDownHistory[0].X > mouseDownHistory[1].X) {
                    x       = mouseDownHistory[1].X;
                    width   = mouseDownHistory[0].X - x;
                } else {
                    x       = mouseDownHistory[0].X;
                    width   = mouseDownHistory[1].X - x;
                }
                
                if(mouseDownHistory[0].Y > mouseDownHistory[1].Y) {
                    y       = mouseDownHistory[1].Y;
                    height  = mouseDownHistory[0].Y - y;
                } else {
                    y       = mouseDownHistory[0].Y;
                    height  = mouseDownHistory[1].Y - y;
                }

                InputMouseDown?.Invoke(x, y, width, height);
            }
            
            //Check Key Presses
            foreach(KeyConstant key in Enum.GetValues(typeof(KeyConstant))) {
                if(Keyboard.IsDown(key)) {
                    string keyName = Enum.GetName(typeof(KeyConstant), key)
                                    .Replace("Number", "")
                                    .Replace("Keypad", "")
                                    .Replace("Divide", "/")
                                    .Replace("Multiply", "*")
                                    .Replace("Minus", "-")
                                    .Replace("Plus", "+");
                    
                    InputKeyPress?.Invoke(keyName);
                }
            }
        }

    }
}
