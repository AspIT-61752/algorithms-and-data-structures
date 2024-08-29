using recursion;
using System.ComponentModel;
using System.Diagnostics;

namespace RunTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Recursion rec = new();
            string testName = "";
            // Arrange:
            int runs = 4;                                          // Number of measurements
            List<long> ticks = new();                          // Array to hold the measurements
            int elements = 10000000;                                // Number of elements

            // Generate data:
            for (int i = 0; i < runs; i++)                          // Loop for each run
            //for (int i = 10; i < 1000000000; i *= 10)
            {
                Random generator = new Random();                    // Random number generator
                int[] array = new int[elements];                    // Array to hold the generated numbers
                for (int j = 0; j < array.Length - 1; j++)          // Loop for each generated number
                {
                    array[j] = generator.Next(0, Int32.MaxValue);   // Save generated number to array entry  
                }

                Console.WriteLine($"\n=== Test : {i.ToString()}\n");

                // Measure:
                testName = $"Fibonacci Seq (20)";                 // The name of the file
                //testName = $"Fibonacci Sequence (20) [ {i} ]";                 // The name of the file
                Stopwatch stopwatch = new Stopwatch();              // Create stop watch
                stopwatch.Start();                                  // Start measurement
                //Array.Sort(array);                                  // PERFORM ALGORITHM
                rec.FibonacciSequence(20);
                //rec.FactorialSequence(100);
                stopwatch.Stop();                                   // Stop measurement

                // Measurement presentation:
                long measuredTicks = stopwatch.Elapsed.Ticks;       // Save measurement

                //TimeSpan interval = TimeSpan.FromTicks(measuredTicks);
                //string intervalString = interval.ToString();

                ticks.Add(measuredTicks);                           // Save measurements
                //string runResult = $"Run {i + 1}\t: {measuredTicks} : {intervalString}"; // Textual measurement
                //Console.WriteLine(runResult);                       // Print mesurement
            }

            // Displays the result at the end
            List<string> savedResults = new List<string>();
            savedResults.Add($"Test timestamp: {DateTime.Now.ToString()}");
            string topRow = $"{string.Format(" RUN COUNT").PadLeft(15, '=')} | {string
                .Format(" TICKS").PadLeft(20, '=')} | {string.Format(" TIME SPAN").PadLeft(16, '=')}";
            savedResults.Add(topRow);

            Console.WriteLine("\n\n========== TEST RESULTS ==========\n\n");
            Console.WriteLine(topRow);
            for (int i = 0; i < ticks.Count(); i++)
            {
                TimeSpan interval = TimeSpan.FromTicks(ticks[i]);
                string intervalString = interval.ToString();
                string runResult = $"Run {i + 1,11} : {ticks[i],20} : {intervalString}"; // Textual measurement
                savedResults.Add(runResult);
                Console.WriteLine(runResult);
            }

            // TODO: Open the file instead of creating a new file everytime 
            // Write data to file (WILL OVERWRITE THE EXISTING FILE)
            SaveToFile(testName, ticks, "csv");
            SaveToFile(testName, savedResults, "txt");

            // TODO: Write avg for ticks and time span. Make sure it lines up with the rest of the table
            Console.WriteLine($"Avg: {ticks.Average()}");           // Print average of measurements
            Console.ReadLine();                                     // Keep console open
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filename"></param>
        /// <param name="data"></param>
        /// <param name="format"></param>
        private static void SaveToFile<T>(string filename, IEnumerable<T> data, string format)
        {
            // I'm adding a timestamp so it doesn't overwrite or write more data to a file by accident
            filename = filename + $" {(DateTime.Now.ToString()).Replace(':', ';')}"; // You can't use : in filenames

            // Makes the filepath before checking the format
            string file = @$".\saved data\{filename}.{format}";
            FileInfo fInfo = new(file);
            fInfo.Directory.Create();

            switch (format.ToLower())
            {
                case "csv":
                    // Fallthrough is intentional
                    // Instead of writing a method or writing the same thing twice, I just removed the break; statement
                case "txt":
                    using (var stream = File.CreateText(file))
                    {
                        foreach (var row in data)
                        {
                            stream.WriteLine(row);
                        }
                        stream.Close();
                    }
                    break;
                default:
                    format = "txt";
                    // TODO: Write to .txt
                    break;
            }
        }
    }
}
