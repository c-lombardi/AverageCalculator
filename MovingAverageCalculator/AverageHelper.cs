using System;
using System.Collections.Generic;
using System.Linq;

namespace MovingAverageCalculator
{
    public class AverageHelper
    {
        public IEnumerable<Double> FindAllAverages(IList<double> values, int windowSize)
        {
            //Checking for errors
            if(windowSize > values.Count)
                throw new ValueCountLessThanWindowException();
            if (windowSize < 0)
                throw new BadWindowException();
            if (values.Count == 0)
                throw new ValuesCountException();
            var cumulativeAverageArray = new double[values.Count];
            var currentAverage = 0.0;
            for (var i = 0; i < values.Count; i++)
            {
                var convertedIndexToCounterFromIndex = i + 1;
                if (convertedIndexToCounterFromIndex <= windowSize && i != 0) // handles greater than 0, but less than window size
                {
                    currentAverage = (((currentAverage * i) + values[i]) / convertedIndexToCounterFromIndex);
                }
                else if (convertedIndexToCounterFromIndex <= windowSize) // handles 0 case
                {
                    currentAverage = (((currentAverage * i) + values[i]) / convertedIndexToCounterFromIndex);
                }
                else  // https://en.wikipedia.org/wiki/Moving_average //handles greater than 0 and greater than window size
                {
                    currentAverage = ((values.Skip(convertedIndexToCounterFromIndex - windowSize).Take(windowSize).Sum()) / windowSize);
                }
                cumulativeAverageArray[i] = currentAverage;
            }
            return cumulativeAverageArray;
        }
    }
}
