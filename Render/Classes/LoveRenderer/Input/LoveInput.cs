using AmdOnlyRts.Domain.Interfaces.Renderer.Input;
using Love;

namespace AmdOnlyRts.Renderer.Classes.LoveRenderer.Input
{
    public class LoveInput : IInput
    {
        public event InputMouseClick InputMouseClick;
        public event InputSelectionBox InputSelectionBox;
        public event InputKeyPress InputKeyPress;

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
            mouseDownHistory[1] = mouseDownHistory[0];
            mouseDownHistory[0] = new LoveMouseState((int)Mouse.GetX(), (int)Mouse.GetY(), Mouse.IsPressed(mouseButton));

            //First frame of click
            if(mouseDownHistory[0].IsPressed && !mouseDownHistory[1].IsPressed) { 
                
            }

            //Mouse is being held
            if(mouseDownHistory[0].IsPressed && mouseDownHistory[1].IsPressed) {
                mouseHeld = true;
            }

            //Mouse was released
            if(!mouseDownHistory[0].IsPressed && mouseDownHistory[1].IsPressed) {

                //Mouse was clicked
                if(!mouseHeld) {
                    InputMouseClick(mouseDownHistory[0].X, mouseDownHistory[0].Y);
                }

                //Mouse was held
                if(mouseHeld) {
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
                    
                    InputSelectionBox(x, y, width, height);
                }

                mouseHeld = false;
            }
            
            
        }

    }
}