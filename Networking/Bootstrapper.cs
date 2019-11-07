using AmdOnlyRts.Networking.Classes;
using Microsoft.Extensions.DependencyInjection;

namespace AmdOnlyRts.Networking
{  
  public static class Bootstrapper
  {
    public static IServiceCollection Bootstrap(this IServiceCollection services)
    {
      services.AddSingleton<GameStateContainer>();

      return services;
    }
  }
}
