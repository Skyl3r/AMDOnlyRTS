using System;
using AmdOnlyRts.Domain.Interfaces.Game;
using AmdOnlyRts.Domain.Interfaces.GameEngine.Map;
using AmdOnlyRts.Domain.Interfaces.Renderer;
using Love;

namespace AmdOnlyRts.Renderer.Classes.LoveRenderer
{
  public class LoveGraphics : IGraphics {


        public LoveGraphics() {

        }

        public void DrawTileMap(ICamera camera, ITileMap tileMap) {
            
            int tileSize = 8; //Temporary

            //Zoom needs implemented
            //we can render everything to a canvas and zoom the canvas in and out.
            
            //Identify camera view:
            float minX = camera.Position.X - camera.Size.X / 2; //X is center of view
            float minY = camera.Position.Y - camera.Size.Y / 2;
            
            float maxX = camera.Position.X + camera.Size.X / 2;
            float maxY = camera.Position.Y + camera.Size.Y / 2;

            //Identify viewable tiles:
            int minTileX = (int)(minX / tileSize);
            int minTileY = (int)(minY / tileSize);

            int maxTileX = Mathf.CeilToInt(maxX / tileSize);
            int maxTileY = Mathf.CeilToInt(maxY / tileSize);


            for(int x = minTileX; x < maxTileX; x ++) {
                for(int y = minTileY; y < maxTileY; y ++) {
                    if(x >= tileMap.Width || x < 0) break;
                    if(y >= tileMap.Height || y < 0) break;

                    ITile tile = tileMap.Data[x,y];


                    //This data should be gotten from LoveTileInfo
                    //This is here only to test the camera class temporarily
                    switch(tile.TypeId) {
                        case 0:
                            Love.Graphics.SetColor(255, 0, 0);
                            break;
                        case 1:
                            Love.Graphics.SetColor(0, 255, 0);
                            break;
                        case 2:
                            Love.Graphics.SetColor(0, 0, 255);
                            break;
                        case 3:
                            Love.Graphics.SetColor(255, 255, 0);
                            break;
                        case 4:
                            Love.Graphics.SetColor(255, 255, 255);
                            break;
                    }

                    //Position data for tile
                    //Camera offset since the minimum viewable tile will likely be partly off screen
                    int cameraOffsetX = minTileX * tileSize - (int)minX;
                    int cameraOffsetY = minTileY * tileSize - (int)minY;

                    
                    int _x = cameraOffsetX + (x - minTileX) * tileSize;
                    int _y = cameraOffsetY + (y - minTileY) * tileSize;

                    Love.Graphics.Rectangle(DrawMode.Fill, _x, _y, tileSize, tileSize);
                }
            }
        }

        public void DrawText(string text, int x, int y) {
            Love.Graphics.Print(text, x, y);
        }
        public void DrawRect(float width, float height, float x, float y){
            //Love.Graphics.SetColor(new Color(0, 255, 0 , 255));
            Love.Graphics.Rectangle(DrawMode.Fill, x, y, width, height);
        }

    }

    
}
