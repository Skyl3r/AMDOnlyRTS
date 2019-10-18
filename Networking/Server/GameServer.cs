using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace BrokenDigSky.AmdOnlyRts.Networking.Server
{
  public class GameServer : IDisposable
  {
    private readonly IWebHost _webHost;
    private readonly int _port;
    public GameServer(int port)
    {
      _port = port;
      _webHost = CreateWebHostBuilder(new string[] { }).Build();
    }
    public Task Start()
    {
      return _webHost.StartAsync();
    }

    public Task Stop()
    {
      return _webHost.StopAsync();
    }

    private IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseUrls("http://localhost:" + _port)
            .UseStartup<Startup>();

    public void Dispose()
    {
        _webHost.Dispose();
    }
  }
}