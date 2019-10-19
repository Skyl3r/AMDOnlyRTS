
using System;
using System.Threading.Tasks;
using AmdOnlyRts.Renderer.Classes.LoveRenderer;
using AmdOnlyRts.Core.GameEngine;
using AmdOnlyRts.Domain.Interfaces.Renderer;
using Love;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AmdOnlyRts.Core
{
  public class Program : Scene
  {
    private IRenderer _renderer;
    private ILogger<Program> _log;
    float[,] data;
    
        int xlimit = 100;
        int ylimit = 100;

    public Program(IRenderer renderer, ILogger<Program> log)
    {
      _renderer = renderer;
      _log = log;
    }

    //Entry point
    static void Main(string[] args)
    {
      var serviceProvider = new ServiceCollection()
        .Bootstrap()
        .BuildServiceProvider();

      serviceProvider.GetService<Program>().Start();
    }

    public void Start()
    {
      _log.LogDebug("Starting application");

      _renderer.OnLoad += new OnLoad(OnRendererLoad);
      _renderer.OnDraw += new OnDraw(OnRendererDraw);
      _renderer.OnUpdate += new OnUpdate(OnRendererUpdate);
      _renderer.Start();

      _log.LogDebug("All done!");
    }

    public void OnRendererLoad()
    {
      int seed = 100;
      float scale = 100;
      int octaves = 1;
      float initialAmplitude = 5;
      float initialFrequency = 5;
      float persistance = 0.2f;
      float lacunarity = 1.5f;
      data = Map.generateNoiseMap(xlimit, ylimit, seed, scale, octaves,initialAmplitude, initialFrequency, persistance, lacunarity);
    }

    public void OnRendererDraw()
    {
      //_loveRenderer.graphics.DrawText("" + Mathr.Noise(Mathf.Random() * 100,Mathf.Random() * 100), 300, 400);
        //_loveRenderer.graphics.DrawRect(100, 100, 100, 100);
        
      for(int x = 1; x < xlimit; x += 1){
        for(int y = 1; y < ylimit; y += 1)
        {
          //Console.WriteLine(data[x * y]);
          if(data[x , y] < 0.3)
            Love.Graphics.SetColor(0, 0, data[x,y] * 3.3f);
          else if(data[x , y] < 0.4)
            Love.Graphics.SetColor(Color.Yellow);
          // else if(data[x , y] < 0.5)
          //   Love.Graphics.SetColor(Color.LightGreen);
          else if(data[x , y] < 1)
            Love.Graphics.SetColor(0, 1.25f - data[x,y], 0);
          else if(data[x , y] < 6)
            Love.Graphics.SetColor(Color.DarkGreen);
          else if(data[x , y] < 0.7)
            Love.Graphics.SetColor(Color.DarkSlateGray);
          else if(data[x , y] < 0.8)
            Love.Graphics.SetColor(Color.DarkSlateGray);
          else if(data[x , y] < 0.9)
            Love.Graphics.SetColor(Color.DarkSlateGray);
          else if(data[x , y] < 1)
            Love.Graphics.SetColor(Color.DarkSlateGray);
          var tileSize = xlimit/10;
          _renderer.graphics.DrawRect(tileSize, tileSize, -tileSize + x * tileSize, -tileSize + y * tileSize);
        }
      
      }
    }

    public void OnRendererUpdate()
    {

    }
  }
}
