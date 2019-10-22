using AmdOnlyRts.Domain.Interfaces.Networking;
using AmdOnlyRts.Domain.Interfaces.Renderer;
using AmdOnlyRts.Networking;
using AmdOnlyRts.Renderer.Classes.LoveRenderer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AmdOnlyRts.Core
{
  public static class Bootstrapper
  {
    public static IServiceCollection Bootstrap(this IServiceCollection services)
    {
      services.AddSingleton(services);
      services.AddSingleton<IRenderer, LoveRenderer>();
      services.AddTransient<Program>();
      services.AddTransient<INetworkService, SignalRNetworkService>();
      services.AddLogging(x =>
      {
        x.AddConsole();
        x.SetMinimumLevel(LogLevel.Debug);
      });

      return services;
    }
  }
}