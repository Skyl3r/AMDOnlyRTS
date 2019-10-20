
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
    private Map map;
    

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
      map = new Map();
      map.initMapGeneration(500, 500);
    }

    public void OnRendererDraw()
    {
      map.Draw(_renderer);
    }

    public void OnRendererUpdate()
    {

    }
  }
}
