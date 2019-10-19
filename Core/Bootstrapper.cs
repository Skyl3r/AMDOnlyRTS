using AmdOnlyRts.Domain.Interfaces.Networking;
using AmdOnlyRts.Networking;
using AmdOnlyRts.Renderer.Classes.LoveRenderer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AmdOnlyRts.Core
{
  public static class Bootstrapper
  {
    public static ServiceCollection Bootstrap(this ServiceCollection services)
    {
      services.AddSingleton(new LoveRenderer());
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