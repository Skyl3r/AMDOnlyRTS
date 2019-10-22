using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace AmdOnlyRts.Networking.Server
{
  public class GameServer : IDisposable
  {
    private readonly IWebHost _webHost;
    private readonly int _port;
    private readonly IServiceCollection _services;
    public GameServer(int port, IServiceCollection services)
    {
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