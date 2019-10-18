

namespace AmdOnlyRts.Renderer.Classes
{
  public delegate void OnDraw();
  public delegate void OnUpdate();
  public delegate void OnLoad();
  public interface IRenderer {

    //Create Callbacks
    event OnDraw OnDraw;
    event OnUpdate OnUpdate;
    event OnLoad OnLoad;

    //Create renderer necessities
    Graphics graphics { get; set; }

  }
}
