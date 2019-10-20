using System;
using System.Threading.Tasks;
using AmdOnlyRts.Domain.Interfaces.Game;
using AmdOnlyRts.Domain.Interfaces.Renderer;
using Love;
using AmdOnlyRts.MathUtilities;


namespace AmdOnlyRts.Core.GameEngine
{
	//We should consider moving this to domain
	public class Map : IMap
	{
		private int width = 500;
		private int height = 500;
		private float[,] noiseMap;

		public int Width {get => width;}
		public int Height {get => height;}
		public bool mapGenerated = false;

        public float[,] NoiseMap { get => noiseMap;}

        public float[,] TileMap => throw new NotImplementedException();

        public float[,] ChunkMap => throw new NotImplementedException();

        public void initMapGeneration(int width, int height){
				Random randomSeed = new Random();
				int seed = randomSeed.Next(0, 1000000);
				float scale = 150;

				//amplitude decreases each octave
				//frequency increases each octave
				int octaves = 100;
				//
				float initialAmplitude = 1.5f;
				//higher frequency, farther apart sample points. So the values change more rapidly.
				float initialFrequency = 0.75f;
				//rate at which amplitude decreases
				float persistance = 0.75f;
				//rate at which frequency increases
				float lacunarity = 2f;
      
      			generateNoiseMap(width, height, seed, scale, octaves,initialAmplitude, initialFrequency, persistance, lacunarity);
		}

		public void generateNoiseMap(int width, int height, int seed, float scale, int octaves, float initialAmplitude, float initialFrequency, float persistance, float lacunarity){
			float[,] resultMap = new float[width , height];
			//offsetX += 0.1f;
			Random random = new Random(seed);
			Vector2D[] octaveOffsets = new Vector2D[octaves];
			for(int i = 0; i < octaves; i++){
				float offsetX = random.Next(-100000, 100000);
				float offsetY = random.Next(-100000, 100000);
				octaveOffsets[i] = new Vector2D(offsetX, offsetY);
			}
			float maxNoiseHeight = float.MinValue;
			float minNoiseHeight = float.MaxValue;

			for(int x = 0; x < width; x += 1){
				for(int y = 0; y < height; y += 1)
				{
					float amplitude = initialAmplitude;
					float frequency = initialFrequency;
					float noiseHeight = 0;
					for(int octave=0; octave < octaves; octave++)
					{
					float sampleX = x / scale * frequency + octaveOffsets[octave].X;
					float sampleY = y / scale * frequency + octaveOffsets[octave].Y;


					float noiseValue = Love.Mathf.Noise(sampleX, sampleY) * 2 - 1;
					noiseHeight += noiseValue * amplitude;
					
					amplitude *= persistance;
					frequency *= lacunarity;

					}
					if(noiseHeight > maxNoiseHeight){
						maxNoiseHeight = noiseHeight;
					} else if(noiseHeight < minNoiseHeight){
						minNoiseHeight = noiseHeight;
					}
					resultMap[x , y] = noiseHeight;
					
				}
			}
			
			for(int x = 1; x < width; x += 1){
				for(int y = 1; y < height; y += 1)
				{
					resultMap[x , y] = Mathr.InverseLerp(minNoiseHeight, maxNoiseHeight, resultMap[x,y]);
				}
			}
			mapGenerated = true;
			Console.WriteLine("done");
			noiseMap = resultMap;
		}
		public void Draw(IRenderer renderer){
			for(int x = 1; x < noiseMap.GetLength(0); x += 1){
				for(int y = 1; y < noiseMap.GetLength(1); y += 1){
					//Console.WriteLine(Map.noiseMap[x * y]);
					if(noiseMap[x , y] < 0.31)
						Love.Graphics.SetColor(Color.Green);
					else if(noiseMap[x , y] < 0.35)
						Love.Graphics.SetColor(Color.LightGreen);
					else if(noiseMap[x , y] < 0.38)
						Love.Graphics.SetColor(Color.Yellow);
					// else if(map.noiseMap[x , y] < 1)
					//   Love.Graphics.SetColor(0, 1.25f - map.map[x,y], 0);
					// else if(map.noiseMap[x , y] < 0.7)
					//   Love.Graphics.SetColor(0, 0, map.noiseMap[x,y] * 1.3f);
					// else if(map.noiseMap[x , y] < 0.8)
					//   Love.Graphics.SetColor(Color.DarkBlue);
					// else if(map.noiseMap[x , y] < 0.85)
					//   Love.Graphics.SetColor(Color.DarkSlateBlue);
					// else if(map.noiseMap[x , y] < 0.9)
					//   Love.Graphics.SetColor(Color.DarkGray);
					else if(noiseMap[x , y] < 1)
						Love.Graphics.SetColor(0, 0, 1 - noiseMap[x,y]);
					float tileSize = (100.0f/noiseMap.GetLength(0) * 10);
					renderer.graphics.DrawRect(tileSize, tileSize, -tileSize + x * tileSize, -tileSize + y * tileSize);
				}
			}
		}
	}
}
