

using AmdOnlyRts.Domain.Interfaces.Renderer.Input;

namespace AmdOnlyRts.Domain.Interfaces.Renderer
{
  public delegate void OnDraw();
  public delegate void OnUpdate();
  public delegate void OnLoad();
  public interface IRenderer {

    //Create Callbacks
    event OnDraw OnDraw;
    event OnUpdate OnUpdate;
    event OnLoad OnLoad;

    IInput Input { get; set; }
    IGraphics Graphics { get; set; }

    int width { get; set; }
    int height { get; set; }

    void setSize(int width, int height);
    void Start();
    
  }
}
