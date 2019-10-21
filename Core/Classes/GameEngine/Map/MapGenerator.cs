using System;
using System.Threading.Tasks;
using AmdOnlyRts.Domain.Interfaces.Game;
using AmdOnlyRts.Domain.Interfaces.Renderer;
using Love;
using AmdOnlyRts.MathUtilities;
using System.Linq;

namespace AmdOnlyRts.Core.GameEngine.Map
{
	//We should consider moving this to domain
	public class MapGenerator
	{

		public TileMap NewTileMap(NoiseMap noiseMap, DistributionMap distribution){
			TileMap tileMap = new TileMap(noiseMap.Width, noiseMap.Height);

			float noiseMapMax = noiseMap.Data.Cast<float>().Max();
			float noiseMapMin = noiseMap.Data.Cast<float>().Min();

			int distributionHeight = distribution.sum();

			for(int x = 0; x < noiseMap.Width; x++){
				for(int y = 0; y < noiseMap.Height; y++){
					float currentNoiseValue = noiseMap.Data[x, y] - noiseMapMin;
					float distributionNoise = currentNoiseValue / (noiseMapMax - noiseMapMin);

					int tileDistribution = (int) ((float)distributionHeight * distributionNoise);

					int tileType = distribution.getTypeFromDistribution(tileDistribution);

					tileMap.setTile(x, y, new Tile(tileType));
				}
			}

			return tileMap;
		}

		public NoiseMap NewNoiseMap(int width, int height, int seed, float scale, int octaves, float initialAmplitude, float initialFrequency, float persistance, float lacunarity)
		{
			NoiseMap noiseMap = new NoiseMap(width, height);
			
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
					noiseMap.Data[x , y] = noiseHeight;
					
				}
			}
			
			for(int x = 1; x < width; x += 1)
			{
				for(int y = 1; y < height; y += 1)
				{
					noiseMap.Data[x , y] = Mathr.InverseLerp(minNoiseHeight, maxNoiseHeight, noiseMap.Data[x,y]);
				}
			}
			
			return noiseMap;
		}
		
	}
}
