
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
    
        int xlimit = 500;
        int ylimit = 500;

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
      int seed = 696969;
      float scale = 150;
      //amplitude decreases each octave
      //frequency increases each octave
      int octaves = 100;
      //
      float initialAmplitude = 1.5f;
      //higher frequency, farther apart sample points. So the values change more rapidly.
      float initialFrequency = 0.75f;
      //rate at which amplitude decreases
      float persistance = 0.75f;
      //rate at which frequency increases
      float lacunarity = 2f;

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
          if(data[x , y] < 0.31)
            Love.Graphics.SetColor(Color.Green);
          else if(data[x , y] < 0.35)
            Love.Graphics.SetColor(Color.LightGreen);
          else if(data[x , y] < 0.38)
            Love.Graphics.SetColor(Color.Yellow);
          // else if(data[x , y] < 1)
          //   Love.Graphics.SetColor(0, 1.25f - data[x,y], 0);
          // else if(data[x , y] < 0.7)
          //   Love.Graphics.SetColor(0, 0, data[x,y] * 1.3f);
          // else if(data[x , y] < 0.8)
          //   Love.Graphics.SetColor(Color.DarkBlue);
          // else if(data[x , y] < 0.85)
          //   Love.Graphics.SetColor(Color.DarkSlateBlue);
          // else if(data[x , y] < 0.9)
          //   Love.Graphics.SetColor(Color.DarkGray);
          else if(data[x , y] < 1)
            Love.Graphics.SetColor(0, 0, 1 - data[x,y]);
          float tileSize = (100.0f/xlimit * 10);
          _renderer.graphics.DrawRect(tileSize, tileSize, -tileSize + x * tileSize, -tileSize + y * tileSize);
        }
      
      }
    }

    public void OnRendererUpdate()
    {

    }
  }
}
