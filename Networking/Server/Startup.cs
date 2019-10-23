using AmdOnlyRts.Networking.Server.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace AmdOnlyRts.Networking.Server
{
  public class Startup
  {
    public void ConfigureServices(IServiceCollection services)
    {
      services.Bootstrap();
      services.AddSignalR();
      services.AddMvc();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      app.UseFileServer();
      app.UseRouting();
      app.UseEndpoints(cfg =>
      {
        cfg.MapControllers();
        cfg.MapHub<GameHub>("/game");
      });
    }
  }
}
