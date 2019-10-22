using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace AmdOnlyRts.Networking.Server
{
  public class GameServer : IDisposable
  {
    private readonly IWebHost _webHost;
    private readonly int _port;
    private readonly ILogger<GameServer> _log;
    public GameServer(int port, IServiceProvider container)
    {
      _log = container.GetService<ILogger<GameServer>>();
      _log.LogDebug($"Starting game server on port: {port}");
      _port = port;
      _webHost = CreateWebHostBuilder(new string[] { }).Build();
    }
    public Task StartAsync()
    {
      return _webHost.StartAsync();
    }

    public Task StopAsync()
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