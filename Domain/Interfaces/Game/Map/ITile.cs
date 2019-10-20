using AmdOnlyRts.MathUtilities;

namespace AmdOnlyRts.Domain.Interfaces.Game
{
    public interface ITile
	{
		void Draw(){}
        Vector2D Position{get;}
		int X{get;}
		int Y{get;}
		
	}
}
