using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MovingAverageCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int windowSize;
                Int32.TryParse(args[0], out windowSize); //https://msdn.microsoft.com/en-us/library/bb397679.aspx
                var valuesLengthWithoutWindowSize = args.Length - 1;
                //minus 1 because the first param of args is the windowsize
                var values = new double[valuesLengthWithoutWindowSize];
                for (var i = 0; i < (valuesLengthWithoutWindowSize); i++)
                {
                    double.TryParse(args[i + 1], out values[i]);
                }
                var ah = new AverageHelper();
                var cumulativeAverageArray = ah.FindAllAverages(values, windowSize);
                DisplayCumulativeAverageArray(cumulativeAverageArray);
            }
            catch (BadWindowException ex)
            {
                Trace.WriteLine("Your window must be a positive number!");
            }
            catch (ValueCountLessThanWindowException ex)
            {
                Trace.WriteLine("Your window cannot exceed your number of values inputted.");
            }
            catch (ValuesCountException ex)
            {
                Trace.WriteLine("In addition to the window, you must enter values to average.");
            }
            catch (Exception)
            {
                Trace.WriteLine("Make sure that there are at least two values in the command line (the (integer) window size, and at least one (float or integer) number to populate the array)");
            }
        }

        private static void DisplayCumulativeAverageArray(IEnumerable<Double> cumulativeAverageArray)
        {
            foreach (var cumulativeAverage in cumulativeAverageArray)
            {
                Trace.WriteLine(cumulativeAverage.ToString());
            }
        }
    }
}
