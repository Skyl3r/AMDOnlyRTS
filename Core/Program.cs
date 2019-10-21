
using System;
using AmdOnlyRts.Core.GameEngine;
using AmdOnlyRts.Core.GameEngine.Map;
using AmdOnlyRts.Domain.Interfaces.Game;
using AmdOnlyRts.Domain.Interfaces.GameEngine.Map;
using AmdOnlyRts.Domain.Interfaces.Renderer;
using Love;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AmdOnlyRts.Core
{
    public class Program : Scene
    {
        private IRenderer _renderer;
        private ILogger<Program> _log;
        private MapGenerator mapGenerator;
        private ICamera camera;
        private ITileMap tileMap;


        public Program(IRenderer renderer, ILogger<Program> log)
        {
            _renderer = renderer;
            _log = log;
        }

        //Entry point
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
              .Bootstrap()
              .BuildServiceProvider();

            serviceProvider.GetService<Program>().Start();
        }

        public void Start()
        {
            _log.LogDebug("Starting application");

            _renderer.OnLoad += new OnLoad(OnRendererLoad);
            _renderer.OnDraw += new OnDraw(OnRendererDraw);
            _renderer.OnUpdate += new OnUpdate(OnRendererUpdate);
            _renderer.Start();


            _log.LogDebug("All done!");
        }

        public void OnRendererLoad()
        {

            // This should be done based on input from lua through a Mod pack.
            // Everything in this method is just a test
            camera = new Camera();
            camera.SetPosition(500, 299);
            camera.SetSize(1000, 600);

            MapGenerator mapGenerator = new MapGenerator();

            Random randomSeed = new Random();
            int seed = 696969;//randomSeed.Next(0, 1000000);

            //Noise Map Generation Data
			float scale = 150;
            //frequency increases each octave
            //amplitude decreases each octave
            int octaves = 15;
            //amplitude increases the height of the noise values
            float initialAmplitude = 1.5f;
            //higher frequency, farther apart sample points. So the values change more rapidly.
            float initialFrequency = 0.75f;
            //rate at which amplitude decreases
            float persistance = 0.35f;
            //rate at which frequency increases
            float lacunarity = 3f;
            
            NoiseMap noiseMap = mapGenerator.NewNoiseMap(1000, 1000, seed, scale, octaves, initialAmplitude, initialFrequency, persistance, lacunarity);

            //Create an even distribution map for tiles, for testing
            DistributionMap mapDistribution = new DistributionMap();
            mapDistribution.addType(0, 10);
            mapDistribution.addType(1, 15);
            mapDistribution.addType(2, 25);
            //mapDistribution.calculate();  //Order distribution

            //Create the tile map

            tileMap = mapGenerator.NewTileMap(noiseMap, mapDistribution);

        }

        public void OnRendererDraw()
        {
            
            _renderer.graphics.DrawTileMap(camera, tileMap);

            //Move the camera slowly to test scrolling
            camera.SetPosition(camera.Position.X + 0.3f, camera.Position.Y + 0.3f);
            camera.Zoom -= 0.001f;
        }

        public void OnRendererUpdate()
        {

        }
    }
}
