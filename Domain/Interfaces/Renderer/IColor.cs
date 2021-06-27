

using AmdOnlyRts.Domain.Interfaces.GameEngine.Game;
using AmdOnlyRts.Domain.Interfaces.GameEngine.Map;

namespace AmdOnlyRts.Domain.Interfaces.Renderer
{
  public interface IColor {

    float r { get; set; }
    float g { get; set; }
    float b { get; set; }
    float alpha { get; set; }

  }
}
