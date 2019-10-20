using AmdOnlyRts.Networking.Client;
using AmdOnlyRts.Networking.Server;
using System;
using System.Threading.Tasks;

namespace AmdOnlyRts.Networking
{
    public class Program
    {
        public static void Main()
        {
          new Program().Run().Wait();
        }

        public async Task Run()
        {
          var server = new GameServer(25565);
          await server.StartAsync();

          var client = new GameClient("localhost", 25565);
          client.RegisterCallback((x,y)=> Console.WriteLine($"{x}: {y}"));
          await client.StartAsync();
            //await client.Send("Me James", "YEET");
          while(true)
          {
            //await client.Send("Me James", Console.ReadLine());
          }


        }

    }
}
