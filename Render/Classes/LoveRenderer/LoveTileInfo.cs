using System;
using System.Collections.Generic;
using AmdOnlyRts.Domain.Interfaces.Renderer;
using Love;

namespace AmdOnlyRts.Renderer.Classes.LoveRenderer
{
  public class LoveTileInfo {
    Dictionary<int, Love.Image> Images { get; set; }

    public LoveTileInfo() {
        Images = new Dictionary<int, Image>();


        //Some images for testing:
        Console.WriteLine(Environment.CurrentDirectory);
        AddImage(0, "Mod/Default/Tiles/dirt.png");
        AddImage(1, "Mod/Default/Tiles/grass.png");
        AddImage(2, "Mod/Default/Tiles/grass2.png");
        AddImage(3, "Mod/Default/Tiles/rock.png");
        

    }

    public void AddImage(int id, Love.Image image) {
        Images.Add(id, image);
    }
    public void AddImage(int id, string pathToImage) {
        Images.Add(id, Resource.NewImage(pathToImage));
    }

    public Love.Image GetImage(int id) {
        return Images[id];
    }
  }
}