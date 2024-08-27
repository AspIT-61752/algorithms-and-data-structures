using System.Diagnostics;

namespace RunTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Arrange:
            int runs = 10;                                          // Number of measurements
            long[] ticks = new long[runs];                          // Array to hold the measurements
            int elements = 10000000;                                // Number of elements

            // Generate data:
            for (int i = 0; i < runs; i++)                          // Loop for each run
            {
                Random generator = new Random();                    // Random number generator
                int[] array = new int[elements];                    // Array to hold the generated numbers
                for (int j = 0; j < array.Length - 1; j++)          // Loop for each generated number
                {
                    array[j] = generator.Next(0, Int32.MaxValue);   // Save generated number to array entry  
                }

                // Measure:
                Stopwatch stopwatch = new Stopwatch();              // Create stop watch
                stopwatch.Start();                                  // Start measurement
                Array.Sort(array);                                  // PERFORM ALGORITHM
                stopwatch.Stop();                                   // Stop measurement

                // Measurement presentation:
                long measuredTicks = stopwatch.Elapsed.Ticks;       // Save measurement

                TimeSpan interval = TimeSpan.FromTicks(measuredTicks);
                string intervalString = interval.ToString();

                ticks[i] = measuredTicks;                           // Save measurements
                string runResult = $"Run {i + 1}\t: {measuredTicks} : {intervalString}"; // Textual measurement
                Console.WriteLine(runResult);                       // Print mesurement
            }

            Console.WriteLine($"Avg: {ticks.Average()}");           // Print average of measurements
            Console.ReadLine();                                     // Keep console open
        }
    }
}
