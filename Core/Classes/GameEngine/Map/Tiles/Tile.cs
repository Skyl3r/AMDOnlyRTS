using System;
using System.Threading.Tasks;
using AmdOnlyRts.Domain.Interfaces.Game;
using AmdOnlyRts.Domain.Interfaces.Renderer;
using Love;
using AmdOnlyRts.MathUtilities;

namespace AmdOnlyRts.Core.GameEngine.Map
{
    public class Tile : ITile
    {
        private int x;
        private int y;
        private int typeId;
        private float noiseValue;
        private float[] colorValue = new float[3];
        
        private float width;
        public float Width => width;
        
        
        public int X => x;
        public int Y => y;

        //ninja'd
        public int TypeId => typeId;
        public float NoiseValue {get => noiseValue; set => noiseValue = value;}

        public Tile(int x, int y, float width, float noiseValue){
            this.x = x;
            this.y = y;
            this.width = width;
            this.noiseValue = noiseValue;
            setColor();
        }

        private void setColor(){
                    colorValue[0] = 0;
                    colorValue[1] = 0;
                    colorValue[2] = 0;
                    if(noiseValue < 0.38)
						colorValue[1] = 1 - noiseValue;//Love.Graphics.SetColor(Color.Green);
					else if(noiseValue < 0.4)
						colorValue[1] = 1 - noiseValue;
					else if(noiseValue < 0.46)
                    {
						colorValue[0] = noiseValue * 2;
						colorValue[1] = noiseValue * 2;
                    }
					// else if(map.noiseMap[x , y] < 1)
					//   Love.Graphics.SetColor(0, 1.25f - map.map[x,y], 0);
					// else if(map.noiseMap[x , y] < 0.7)
					//   Love.Graphics.SetColor(0, 0, map.noiseMap[x,y] * 1.3f);
					// else if(map.noiseMap[x , y] < 0.8)
					//   Love.Graphics.SetColor(Color.DarkBlue);
					// else if(map.noiseMap[x , y] < 0.85)
					//   Love.Graphics.SetColor(Color.DarkSlateBlue);
					// else if(map.noiseMap[x , y] < 0.9)
					//   Love.Graphics.SetColor(Color.DarkGray);
					else if(noiseValue < 1)
					    colorValue[2] = 1 - noiseValue;
        }

        public void Draw(IRenderer renderer){
            Love.Graphics.SetColor(colorValue[0], colorValue[1], colorValue[2]);
            
            renderer.graphics.DrawRect(width, width, -width + x * width, -width + y * width);
        }

    /*dotnetcore3.0 supports virtual extension methods, I suggest we stay away from them (See multiple inheritance). 
      When this was added to ITile the syntax used was 'void Draw(){}' this will create a default implementation of the method on the interface itself.
      Since it was default it went unnoticed that Tile didnt have a Draw() implementation. It the future lets use 'void Draw();' :D
    */
    public void Draw()
    {
      throw new NotImplementedException();
    }
  }
}