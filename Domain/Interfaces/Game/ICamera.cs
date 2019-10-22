using System.Numerics;

namespace AmdOnlyRts.Domain.Interfaces.Game
{
	public interface ICamera
	{
		Vector2 Position { get; set; }
		Vector2 Size { get; set; }

        float Zoom { get; set; }

        void SetPosition(float x, float y);
        void SetSize(float x, float y);
    }
}
