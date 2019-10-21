using System;
using AmdOnlyRts.MathUtilities;
using System.Linq;

namespace AmdOnlyRts.Core.GameEngine.Map
{
    //We should consider moving this to domain
    public class MapGenerator
    {

        public TileMap NewTileMap(NoiseMap noiseMap, DistributionMap distribution)
        {
            TileMap tileMap = new TileMap(noiseMap.Width, noiseMap.Height);

            float noiseMapMax = noiseMap.Data.Cast<float>().Max();
            float noiseMapMin = noiseMap.Data.Cast<float>().Min();
            //Console.WriteLine(noiseMapMax);
            int distributionHeight = distribution.sum();
            //Console.WriteLine(distributionHeight);
            for (int x = 0; x < noiseMap.Width; x++)
            {
                for (int y = 0; y < noiseMap.Height; y++)
                {
                    float distributionNoise = Mathr.InverseLerp(noiseMapMin, noiseMapMax, noiseMap.Data[x, y]);

                    int tileDistribution = (int)((float)distributionHeight * distributionNoise);
                    
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
            for (int i = 0; i < octaves; i++)
            {
                float offsetX = random.Next(-100000, 100000);
                float offsetY = random.Next(-100000, 100000);
                octaveOffsets[i] = new Vector2D(offsetX, offsetY);
            }

            for (int x = 0; x < width; x += 1)
            {
                for (int y = 0; y < height; y += 1)
                {
                    float amplitude = initialAmplitude;
                    float frequency = initialFrequency;
                    float noiseHeight = 0;
                    for (int octave = 0; octave < octaves; octave++)
                    {
                        float sampleX = x / scale * frequency + octaveOffsets[octave].X;
                        float sampleY = y / scale * frequency + octaveOffsets[octave].Y;


                        float noiseValue = Love.Mathf.Noise(sampleX, sampleY);
                        noiseHeight += noiseValue * amplitude;

                        amplitude *= persistance;
                        frequency *= lacunarity;

                    }
                    noiseMap.Data[x, y] = noiseHeight;

                }
            }

            float noiseMapMax = noiseMap.Data.Cast<float>().Max();
            float noiseMapMin = noiseMap.Data.Cast<float>().Min();
            for (int x = 0; x < width; x += 1)
            {
                for (int y = 0; y < height; y += 1)
                {
                    noiseMap.Data[x, y] = Mathr.InverseLerp(noiseMapMin, noiseMapMax, noiseMap.Data[x, y]);
                }
            }
            return noiseMap;
        }

    }
}
