using BrokenDigSky.AmdOnlyRts.Domain.Interfaces.Networking;
using BrokenDigSky.AmdOnlyRts.Networking.Client;
using BrokenDigSky.AmdOnlyRts.Networking.Server;
using System;
using System.Net;
using System.Threading.Tasks;

namespace BrokenDigSky.AmdOnlyRts.Networking
{
    public class Program
    {
        public static void Main()
        {
          new Program().Run().Wait();
        }

        public async Task Run()
        {
          // var server = new GameServer(25565);
          // await server.Start();

          var client = new GameClient("192.168.0.2", 8000, (x,y)=> Console.WriteLine($"{x}: {y}"));
          await client.Start();
          while(true)
          {
            await client.Send("Me James", Console.ReadLine());
          }


        }

    }
}
