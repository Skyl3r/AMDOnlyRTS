using System;
using AmdOnlyRts.Core;
using AmdOnlyRts.Core.GameEngine;
using AmdOnlyRts.Domain.Interfaces.Networking;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AmdOnlyRts.Test
{
    class Program
    {
        private readonly INetworkService _networkService;
        private readonly ILogger<Program> _log;
        public Program(INetworkService networkService, ILogger<Program> log)
        {
            _networkService = networkService;
            _log = log;
        }

        //Entry point
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .Bootstrap()
                .AddTransient<Program>()
                .BuildServiceProvider();

            serviceProvider.GetService<Program>().Start();
        }

        private void Start()
        {
            var host = _networkService.CreateLanGame(25565, new Player
            {
                DisplayName = "Test",
                TeamName = "GoTeam"
            });
            Console.ReadKey();
        }
    }
}
