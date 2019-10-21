
using AmdOnlyRts.MathUtilities;

namespace AmdOnlyRts.Domain.Interfaces.Game
{
	public interface ICamera
	{
		Vector2D Position { get; set; }
		Vector2D Size { get; set; }

        float Zoom { get; set; }

        void SetPosition(float x, float y);
        void SetSize(float x, float y);
    }
}
