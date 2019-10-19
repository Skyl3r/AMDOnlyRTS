using AmdOnlyRts.Domain.Classes.Networking;
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