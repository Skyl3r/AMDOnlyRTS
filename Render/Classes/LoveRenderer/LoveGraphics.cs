using System;
using AmdOnlyRts.Domain.Interfaces.Game;
using AmdOnlyRts.Domain.Interfaces.GameEngine.Map;
using AmdOnlyRts.Domain.Interfaces.Renderer;
using Love;

namespace AmdOnlyRts.Renderer.Classes.LoveRenderer
{
    public class LoveGraphics : IGraphics
    {

        LoveTileInfo tileInfo;

        public LoveGraphics()
        {

        }

        public void LoadTiles() {

            tileInfo = new LoveTileInfo();
        }

        public void DrawTileMap(ICamera camera, ITileMap tileMap)
        {
            int defaultTileSize = 32; //Temporary
            float tileSize = camera.Zoom * (float)defaultTileSize;

            //Zoom needs implemented
            //we can render everything to a canvas and zoom the canvas in and out.

            //Identify camera view:
            float minX = (camera.Position.X - camera.Size.X / 2); //X is center of view
            float minY = (camera.Position.Y - camera.Size.Y / 2);

            float maxX = camera.Position.X + camera.Size.X / 2;
            float maxY = camera.Position.Y + camera.Size.Y / 2;

            //Identify viewable tiles:
            int minTileX = (int)(minX / tileSize);
            int minTileY = (int)(minY / tileSize);

            int maxTileX = Mathf.CeilToInt(maxX / tileSize);
            int maxTileY = Mathf.CeilToInt(maxY / tileSize);


            for (int x = minTileX; x < maxTileX; x++)
            {
                for (int y = minTileY; y < maxTileY; y++)
                {
                    if (x >= tileMap.Width || x < 0) break;
                    if (y >= tileMap.Height || y < 0) break;

                    ITile tile = tileMap.Data[x, y];
                    Love.Image image = tileInfo.GetImage(tile.TypeId);

                    //Position data for tile
                    //Camera offset since the minimum viewable tile will likely be partly off screen
                    int cameraOffsetX = minTileX * (int)tileSize - (int)minX;
                    int cameraOffsetY = minTileY * (int)tileSize - (int)minY;


                    //Get tile location
                    int _x = cameraOffsetX + (x - minTileX) * (int)tileSize;
                    int _y = cameraOffsetY + (y - minTileY) * (int)tileSize;

                    //Account for zoom
                    _x -= (int)((defaultTileSize - tileSize)/2);
                    _y -= (int)((defaultTileSize - tileSize)/2);

                    Love.Graphics.Draw(image, _x, _y, 0, camera.Zoom, camera.Zoom);
                }
            }
        }

        public void DrawText(string text, int x, int y)
        {
            Love.Graphics.Print(text, x, y);
        }
        public void DrawRect(float width, float height, float x, float y)
        {
            //Love.Graphics.SetColor(new Color(0, 255, 0 , 255));
            Love.Graphics.Rectangle(DrawMode.Fill, x, y, width, height);
        }

    }


}
