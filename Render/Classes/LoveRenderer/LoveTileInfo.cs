using System.Collections.Generic;
using AmdOnlyRts.Domain.Interfaces.Renderer;
using Love;

namespace AmdOnlyRts.Renderer.Classes.LoveRenderer
{
  public class LoveTileInfo {
    Dictionary<int, Love.Image> Images { get; set; }

    public LoveTileInfo() {

        //Some images for testing:
        
        

    }

    public void AddImage(int id, Love.Image image) {
        Images.Add(id, image);
    }

    public Love.Image GetImage(int id) {
        return Images[id];
    }
  }
}