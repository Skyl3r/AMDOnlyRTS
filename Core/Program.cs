﻿
using System;
using System.IO;
using AmdOnlyRts.Core.GameEngine;
using AmdOnlyRts.Core.GameEngine.Map;
using AmdOnlyRts.Domain.Interfaces.GameEngine.Game;
using AmdOnlyRts.Domain.Interfaces.GameEngine.Map;
using AmdOnlyRts.Domain.Interfaces.Renderer;
using AmdOnlyRts.Domain.Interfaces.Renderer.Input;
using AmdOnlyRts.Renderer.Classes.LoveRenderer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AmdOnlyRts.Core
{
    public class Program
    {
        private IRenderer _renderer;
        private ILogger<Program> _log;
        private MapGenerator mapGenerator;
        private ICamera camera;
        private ITileMap tileMap;
        private ITileMapIndex tileMapIndex;


        int x = 0;
        int y = 0;

        int width = 0;
        int height = 0;

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
            
            //Inputs
            _renderer.Input.InputKeyPress += new InputKeyPress(OnKeyPress);
            _renderer.Input.InputSelectionBox += new InputSelectionBox(OnSelectionBox);
            _renderer.Input.InputMouseDown += new InputMouseDown(OnMouseDown);
            _renderer.Input.InputMouseClick += new InputMouseClick(OnClick);


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

            mapGenerator = new MapGenerator();

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
            DistributionMap distributionMap = new DistributionMap();
            distributionMap.addType(0, 10);
            distributionMap.addType(1, 15);
            distributionMap.addType(2, 25);
            distributionMap.addType(3, 25);

            //Create the tile map
            tileMap = mapGenerator.NewTileMap(noiseMap, distributionMap);

            Console.WriteLine("Current directory: " + Directory.GetCurrentDirectory());
            tileMapIndex = new TileMapIndex();
            tileMapIndex.Add(0, new Drawable("Core/Mod/Default/Tiles/dirt.png"));
            tileMapIndex.Add(1, new Drawable("Core/Mod/Default/Tiles/grass.png"));
            tileMapIndex.Add(2, new Drawable("Core/Mod/Default/Tiles/grass2.png"));
            tileMapIndex.Add(3, new Drawable("Core/Mod/Default/Tiles/rock.png"));

            _renderer.Graphics.LoadTiles(tileMapIndex);

        }

        public void OnRendererDraw()
        {
            
            _renderer.Graphics.DrawTileMap(camera, tileMap, tileMapIndex);
            _renderer.Graphics.DrawRect(width, height, x, y, new Color(0, 255, 0, 1f));
            _renderer.Graphics.FillRect(width, height, x, y, new Color(0, 255, 0, 0.5f));

            //Move the camera slowly to test scrolling
            //camera.SetPosition(camera.Position.X + 0.3f, camera.Position.Y + 0.3f);
            //camera.Zoom -= 0.001f;

            if(_renderer.Input.MouseState.X < 5) 
                camera.SetPosition(camera.Position.X - 0.3f, camera.Position.Y);
            if(_renderer.Input.MouseState.Y < 5) 
                camera.SetPosition(camera.Position.X, camera.Position.Y - 0.3f);
            if(_renderer.Input.MouseState.X > _renderer.width - 5)
                camera.SetPosition(camera.Position.X + 0.3f, camera.Position.Y);
            if(_renderer.Input.MouseState.Y > _renderer.height - 5)
                camera.SetPosition(camera.Position.X, camera.Position.Y + 0.3f);
            
        }

        public void OnRendererUpdate()
        {

        }
        
        public void OnKeyPress(string key) {
            Console.WriteLine("Key pressed: " + key);
        } 

        public void OnSelectionBox(int x, int y, int width, int height) {
            Console.WriteLine("Selection box: (" + x + ", " + y + ", " + width + ", " + height + ")");

            this.x = 0;
            this.y = 0;
            this.width = 0;
            this.height = 0;
        }

        public void OnClick(int x, int y) {
            Console.WriteLine("Click: (" + x + ", " + y + ")");

        }

        public void OnMouseDown(int x, int y, int width, int height) {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }
    }
}
