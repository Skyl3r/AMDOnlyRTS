using System;
using System.Collections.Generic;
using AmdOnlyRts.Domain.Interfaces.Renderer;
using AmdOnlyRts.Domain.Interfaces.Renderer.Input;
using AmdOnlyRts.Renderer.Classes.LoveRenderer.Input;
using Love;

namespace AmdOnlyRts.Renderer.Classes.LoveRenderer
{
  public class LoveTextureManager  {
      Dictionary<IDrawable, Love.Image> Textures { get; set; }

      public LoveTextureManager() {
          Textures = new Dictionary<IDrawable, Image>();
      }

      public void Load(IDrawable drawable) {
          if(!Textures.ContainsKey(drawable)) {
              Textures.Add(drawable, Love.Graphics.NewImage(drawable.texturePath));
          }
      }

      public Love.Image Get(IDrawable drawable) {
          return Textures[drawable];
      }

    }
}
