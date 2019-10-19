using System;
using System.Threading.Tasks;
using AmdOnlyRts.Domain.Interfaces.Game;

namespace AmdOnlyRts.Core.GameEngine
{
	//We should consider moving this to domain
	public class Map : IMap
	{
		Map(){
			//Mathr.Noise(100.24f, 300.42f);
		}
		public static bool mapGenerated = false;
		public static float[,] generateNoiseMap(int width, int height, int seed, float scale, int octaves, float initialAmplitude, float initialFrequency, float persistance, float lacunarity){
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
			Map.mapGenerated = true;
			Console.WriteLine("done");
			return resultMap;
		}
	}
}
