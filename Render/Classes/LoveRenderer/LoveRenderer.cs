using Love;

namespace AmdOnlyRts.Renderer.Classes
{
  public class LoveRenderer : Scene, IRenderer  {

        public event OnDraw OnDraw;
        public event OnUpdate OnUpdate;
        public event OnLoad OnLoad;

        public Graphics graphics { get; set; }


        public LoveRenderer() {
            graphics = new LoveGraphics();
        }

        public void Start() {
            Boot.Init();
            Boot.Run(this);
        }

        public override void Draw() {
            OnDraw();
        }

        public override void Update(float dt) {
            OnUpdate();
        }

        public override void Load() {
            OnLoad();
        }

    }

    
}
