

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

    IGraphics graphics { get; set; }
    void Start();
  }
}
