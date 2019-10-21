
using System;
using System.Threading.Tasks;
using AmdOnlyRts.Renderer.Classes.LoveRenderer;
using AmdOnlyRts.Core.GameEngine;
using AmdOnlyRts.Core.GameEngine.Map;
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
        private TileMap tileMap;


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
            // Everything in this method is just a test.
            
            MapGenerator mapGenerator = new MapGenerator();

            Random randomSeed = new Random();
            int seed = randomSeed.Next(0, 1000000);

            //Noise Map Generation Data
			float scale = 2000;
            //frequency increases each octave
            int octaves = 25;
            //amplitude decreases each octave
            float initialAmplitude = 1.5f;
            //higher frequency, farther apart sample points. So the values change more rapidly.
            float initialFrequency = 0.1f;
            //rate at which amplitude decreases
            float persistance = 0.75f;
            //rate at which frequency increases
            float lacunarity = 2f;
            
            NoiseMap noiseMap = mapGenerator.NewNoiseMap(100, 100, seed, scale, octaves, initialAmplitude, initialFrequency, persistance, lacunarity);

            //Create an even distribution map for tiles, for testing
            DistributionMap mapDistribution = new DistributionMap();
            mapDistribution.addType(0, 20);
            mapDistribution.addType(1, 20);
            mapDistribution.addType(2, 20);
            mapDistribution.addType(3, 20);
            mapDistribution.addType(4, 20);
            mapDistribution.calculate();  //Order distribution

            //Create the tile map
            tileMap = mapGenerator.NewTileMap(noiseMap, mapDistribution);

        }

        public void OnRendererDraw()
        {
            //Drawing should be done in the renderer
            //This is for testing purposes *ONLY*
            for(int x = 0; x < tileMap.Width; x ++) {
                for(int y = 0; y < tileMap.Height; y ++) {
                    Tile tile = tileMap.data[x,y];
                    switch(tile.TypeId) {
                        case 0:
                            Love.Graphics.SetColor(255, 0, 0);
                            break;
                        case 1:
                            Love.Graphics.SetColor(0, 255, 0);
                            break;
                        case 2:
                            Love.Graphics.SetColor(0, 0, 255);
                            break;
                        case 3:
                            Love.Graphics.SetColor(255, 255, 0);
                            break;
                        case 4:
                            Love.Graphics.SetColor(255, 255, 255);
                            break;
                    }

                    //2 is test tile size
                    Love.Graphics.Rectangle(DrawMode.Fill, x*2, y*2, 2, 2);
                }
            }
        }

        public void OnRendererUpdate()
        {

        }
    }
}
