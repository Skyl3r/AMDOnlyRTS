using System;
using AmdOnlyRts.Renderer.Classes;
using Love;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AmdOnlyRts.Core
{
  public class Program : Scene
  {
    private LoveRenderer _loveRenderer;
    private ILogger<Program> _log;

    public Program(LoveRenderer loveRenderer, ILogger<Program> log)
    {
      _loveRenderer = loveRenderer;
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

      _loveRenderer = new LoveRenderer();
      _loveRenderer.OnLoad += new OnLoad(OnRendererLoad);
      _loveRenderer.OnDraw += new OnDraw(OnRendererDraw);
      _loveRenderer.OnUpdate += new OnUpdate(OnRendererUpdate);
      _loveRenderer.Start();

      _log.LogDebug("All done!");
    }

    public void OnRendererLoad()
    {

    }

    public void OnRendererDraw()
    {
      _loveRenderer.graphics.DrawText("Hello, World", 300, 400);
    }

    public void OnRendererUpdate()
    {

    }
  }
}
