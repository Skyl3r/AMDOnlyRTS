

using AmdOnlyRts.Domain.Interfaces.GameEngine.Game;
using AmdOnlyRts.Domain.Interfaces.GameEngine.Map;

namespace AmdOnlyRts.Domain.Interfaces.Renderer
{
  public interface IDrawable {

    string texturePath { get; set; }
    
  }
}
