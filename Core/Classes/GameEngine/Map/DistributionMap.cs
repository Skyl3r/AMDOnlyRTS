using System.Collections.Generic;
using System.Linq;

namespace AmdOnlyRts.Core.GameEngine.Map
{
    public class DistributionMap
    {
        //Distribution will be a list of ints where each int represents the frequency of appearance
        public List<int[]> Distribution;

        public DistributionMap()
        {
            Distribution = new List<int[]>();
        }

        public void addType(int tileTypeId, int distribution)
        {
            Distribution.Add(new int[2]{tileTypeId, distribution});
        }

        public int getTypeFromDistribution(int distribution)
        {
            if (distribution > this.sum())
            {
                return Distribution.Last()[0];
            }
            if (distribution < 0)
            {
                return Distribution.First()[0];
            }

            int typeId = 0;
            int currentSum = 0;
            foreach (var entry in Distribution)
            {
                if (distribution >= currentSum && distribution < currentSum + entry[1])
                {
                    typeId = entry[0];
                    break;
                }
                currentSum += entry[1];
            }

            return typeId;
        }

        public int sum()
        {
            int sum = 0;
            foreach (var entry in Distribution)
            {
                sum += entry[1];
            }

            return sum;
        }
    }
}
