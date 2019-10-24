using AmdOnlyRts.Domain.Interfaces.Renderer;
using AmdOnlyRts.Domain.Interfaces.Renderer.Input;
using AmdOnlyRts.Renderer.Classes.LoveRenderer.Input;
using Love;

namespace AmdOnlyRts.Renderer.Classes.LoveRenderer
{
  public class LoveRenderer : Scene, IRenderer  {

        public event OnDraw OnDraw;
        public event OnUpdate OnUpdate;
        public event OnLoad OnLoad;

        public IGraphics Graphics { get; set; }
        public IInput Input { get; set; }

        public LoveRenderer() {
            Graphics = new LoveGraphics();
            Input = new LoveInput();
        }

        public void Start() {
            Boot.Init();
            Boot.Run(this);
        }

        public override void Draw() {
            OnDraw();
        }

        public override void Update(float dt) {
            Input.Update();
            OnUpdate();
        }

        public override void Load() {
            OnLoad();
        }

    }

    
}
