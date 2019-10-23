## Render
This project defines renderers to be used by the scene for drawing. It is purposefully abstracted from the actual graphics framework to allow additional at a later time.



-------------------------

### Callbacks

Currently the Renderers consist of _all_ draw code as well as _all_ input code. Draw events and input events are accessed through the following callbacks:

**IRender Callbacks**
- ```C#
  IRenderer.OnLoad()
  ```
  - This is called once when the renderer is initially loaded
- ```C#
  IRenderer.OnDraw()
  ```
  - This is called everytime the renderer draws to the screen. All draw code must be placed here.
- ```C#
  IRenderer.OnUpdate()
  ```
  - This is called on every update. Draw code cannot be placed here.
  
**IRenderer.IInput Callbacks**
- ```C#
  IRenderer.IInput.InputMouseClick(int x, int y)
  ```
  - This is called when the mouse is clicked. Arguments `x` and `y` are in world coordinates, not screen coordinates
- ```C#
  IRenderer.IInput.InputSelectionBox(int x, int y, int width, int height)
  ```
  - This is called when a selection box is dragged with the mouse. Arugments `x` and `y` are the position in world coordinates and `width` and `height` are the size of the selection box in world coordinates
- ```C#
  IRenderer.IInput.InputKeyPress(string key)
  ```
  - This is called when a keyboard key is pressed. The argument `key` is the value of the key that was pressed (IE. the 'A' key would return "A").
