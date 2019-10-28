using System.Collections.Generic;
using AmdOnlyRts.Domain.Interfaces.GameEngine.Game;
using AmdOnlyRts.Domain.Interfaces.GameEngine.Map;
using AmdOnlyRts.Domain.Interfaces.Renderer;
using Love;

namespace AmdOnlyRts.Renderer.Classes.LoveRenderer
{
    public class LoveGraphics : IGraphics
    {
        LoveTextureManager loveTextureManager;

        public LoveGraphics()
        {
            loveTextureManager = new LoveTextureManager();
        }

        public void Load(IDrawable drawable) {
            loveTextureManager.Load(drawable);
        }

        public void Draw(IDrawable drawable, int x, int y) {
            Love.Graphics.Draw(loveTextureManager.Get(drawable), x, y);
        }
        public void Draw(IDrawable drawable, int x, int y, float sx, float sy) {
            Love.Graphics.Draw(loveTextureManager.Get(drawable), x, y, 0, sx, sy);
        }

        public void LoadTiles(ITileMapIndex tileMapIndex) {
            foreach(KeyValuePair<int, IDrawable> item in tileMapIndex.Tiles) {
                Load(item.Value);
            }
        }

        public void DrawTileMap(ICamera camera, ITileMap tileMap, ITileMapIndex tileMapIndex)
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

                    Draw(tileMapIndex.GetTile(tile.TypeId), _x, _y, camera.Zoom, camera.Zoom);
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
