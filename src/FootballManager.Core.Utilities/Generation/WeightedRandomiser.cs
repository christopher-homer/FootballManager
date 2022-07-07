using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballManager.Core.Utilities.Generation
{
    public class WeightedRandomiser<T>
    {
        private static Random _rnd = new Random();

        public static T GetValue(List<WeightedValue<T>> weightedValues)
        {
            // totalWeight is the sum of all brokers' weight
            int totalWeight = weightedValues.Sum(wv => wv.Weight);

            int randomNumber = _rnd.Next(0, totalWeight);

            WeightedValue<T> selectedWeightedValue = null;
            foreach (WeightedValue<T> weightedValue in weightedValues)
            {
                if (randomNumber < weightedValue.Weight)
                {
                    selectedWeightedValue = weightedValue;
                    break;
                }

                randomNumber = randomNumber - weightedValue.Weight;
            }

            return selectedWeightedValue.Value;
        }
    }
}
