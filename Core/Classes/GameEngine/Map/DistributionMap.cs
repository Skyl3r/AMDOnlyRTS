using System.Collections.Generic;
using System.Linq;

namespace AmdOnlyRts.Core.GameEngine.Map
{
    public class DistributionMap
    {
        //Distribution will be a list of ints where each int represents the frequency of appearance
        public Dictionary<int, int> Distribution;

        public DistributionMap()
        {
            Distribution = new Dictionary<int, int>();
        }

        public void addType(int tileTypeId, int distribution)
        {
            Distribution.Add(tileTypeId, distribution);
        }

        public int getTypeFromDistribution(int distribution)
        {
            if (distribution > this.sum())
            {
                return Distribution.Last().Key;
            }
            if (distribution < 0)
            {
                return Distribution.First().Key;
            }

            int typeId = 0;
            int currentSum = 0;
            foreach (KeyValuePair<int, int> entry in Distribution)
            {
                if (distribution > currentSum && distribution < currentSum + entry.Value)
                {
                    typeId = entry.Key;
                    break;
                }
                currentSum += entry.Value;
            }

            return typeId;
        }

        public void calculate()
        {
            Distribution = Distribution.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        }

        public int sum()
        {
            int sum = 0;
            foreach (KeyValuePair<int, int> typeId in Distribution)
            {
                sum += typeId.Value;
            }

            return sum;
        }
    }
}