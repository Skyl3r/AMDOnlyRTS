using System;
using System.Collections.Generic;
using AmdOnlyRts.Domain.Interfaces.Renderer;
using AmdOnlyRts.Domain.Interfaces.Renderer.Input;
using Love;

namespace AmdOnlyRts.Renderer.Classes.LoveRenderer.Input
{
    public class Input : IInput
    {
        bool downLastFrame = false;

        public Input()
        {

        }

        public void Update() {

            
        }

        public event InputMouseClick InputMouseClick;
        public event InputSelectionBox InputSelectionBox;
        public event InputKeyPress InputKeyPress;
    }
}