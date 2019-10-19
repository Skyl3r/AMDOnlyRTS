using AmdOnlyRts.Domain.Classes.Networking;
using Microsoft.Extensions.DependencyInjection;

namespace AmdOnlyRts.Networking
{  
  public static class Bootstrapper
  {
    public static ServiceCollection Bootstrap(this ServiceCollection services)
    {
      services.AddSingleton<GameState>();

      return services;
    }
  }
}