using System;
using System.Threading.Tasks;
using AmdOnlyRts.Domain.Interfaces.Game;
using AmdOnlyRts.Domain.Interfaces.Renderer;
using Love;
using AmdOnlyRts.MathUtilities;


namespace AmdOnlyRts.Core.GameEngine.Map
{
	//We should consider moving this to domain
	public class MapGenerator
	{
		private int width = 32;
		private int height = 32;
		private NoiseMap noiseMap;
		private TileMap tileMap;

		public int Width {get => width;}
		public int Height {get => height;}

		public bool mapGenerated = false;

		public NoiseMap NoiseMap { get => noiseMap;}

		public TileMap TileMap => tileMap;

		public float[,] ChunkMap => throw new NotImplementedException();

		public void initMapGeneration(int width, int height)
			{
				Random randomSeed = new Random();
				int seed = randomSeed.Next(0, 1000000);
				float scale = 2000;

				//amplitude decreases each octave
				//frequency increases each octave
				int octaves = 25;
				//
				float initialAmplitude = 1.5f;
				//higher frequency, farther apart sample points. So the values change more rapidly.
				float initialFrequency = 0.1f;
				//rate at which amplitude decreases
				float persistance = 0.75f;
				//rate at which frequency increases
				float lacunarity = 2f;
				noiseMap = new NoiseMap(width, height);
				generateNoiseMap(width, height, seed, scale, octaves,initialAmplitude, initialFrequency, persistance, lacunarity);
				tileMap = new TileMap(width, height);
				generateTileMap();
		}
		private void generateTileMap(){
			tileMap.Map = new Tile[noiseMap.Map.GetLength(0),noiseMap.Map.GetLength(1)];
			for(int x = 0; x < noiseMap.Map.GetLength(0); x++){
				for(int y = 0; y < noiseMap.Map.GetLength(1); y++){
					tileMap.Map[x,y] = new Tile(x, y,100f/noiseMap.Map.GetLength(0)*10, noiseMap.Map[x,y]);
				}
			}
		}
		public void generateNoiseMap(int width, int height, int seed, float scale, int octaves, float initialAmplitude, float initialFrequency, float persistance, float lacunarity)
		{
			float[,] resultMap = new float[width , height];
			//offsetX += 0.1f;
			Random random = new Random(seed);
			Vector2D[] octaveOffsets = new Vector2D[octaves];
			for(int i = 0; i < octaves; i++)
			{
				float offsetX = random.Next(-100000, 100000);
				float offsetY = random.Next(-100000, 100000);
				octaveOffsets[i] = new Vector2D(offsetX, offsetY);
			}
			float maxNoiseHeight = float.MinValue;
			float minNoiseHeight = float.MaxValue;

			for(int x = 0; x < width; x += 1)
			{
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
					if(noiseHeight > maxNoiseHeight)
					{
						maxNoiseHeight = noiseHeight;
					} else if(noiseHeight < minNoiseHeight)
					{
						minNoiseHeight = noiseHeight;
					}
					resultMap[x , y] = noiseHeight;
					
				}
			}
			
			for(int x = 1; x < width; x += 1)
			{
				for(int y = 1; y < height; y += 1)
				{
					resultMap[x , y] = Mathr.InverseLerp(minNoiseHeight, maxNoiseHeight, resultMap[x,y]);
				}
			}
			mapGenerated = true;
			Console.WriteLine("done");
			noiseMap.Map = resultMap;
		}
		
	}
}
