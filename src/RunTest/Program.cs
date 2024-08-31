using Lib;
using System.ComponentModel;
using System.Diagnostics;
using System.Numerics;

namespace RunTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Recursion rec = new();
            TimeSpaceComplexity tsComplex = new();
            string testName = "";

            // Arrange:
            int runs = 1;                                          // Number of measurements
            List<long> ticks = new();                          // Array to hold the measurements
            List<string> runCount = new();

            // Generate data:
            //for (int i = 0; i < runs; i++)                          // Loop for each run
            for (int i = 1; i < 1000000000; i *= 10)               // 10, 100, 1000, etc.
            {

                WorstCase testData = new();

                int[] arr = testData.Linear(i);

                Console.WriteLine($"\n=== Test : {i.ToString()}\n");

                // Measure:
                testName = $"TimeSpaceComplexity";                 // The name of the file

                Stopwatch stopwatch = new Stopwatch();              // Create stop watch
                stopwatch.Start();                                  // Start measurement
                //Array.Sort(array);                                  // PERFORM ALGORITHM
                //rec.FibonacciSequence(20);
                //rec.FactorialSequence(2);
                //Console.WriteLine($"Sum of arr[{i}]: {tsComplex.SumOf(arr)}");
                tsComplex.SumOf(arr);
                stopwatch.Stop();                                   // Stop measurement

                // Save mesurements
                long measuredTicks = stopwatch.Elapsed.Ticks;
                ticks.Add(measuredTicks);
                runCount.Add(i.ToString());
            }

            // Displays the result at the end
            List<string> savedResults = new List<string>();
            savedResults.Add($"Test timestamp: {DateTime.Now.ToString()}");
            string topRow = $"{string.Format(" RUN").PadLeft(15, '=')} | {string
                .Format(" TICKS").PadLeft(20, '=')} | {string.Format(" TIME SPAN").PadLeft(16, '=')}";
            savedResults.Add(topRow);

            Console.WriteLine("\n\n========== TEST RESULTS ==========\n\n");
            Console.WriteLine(topRow);
            for (int i = 0; i < ticks.Count(); i++)
            {
                TimeSpan interval = TimeSpan.FromTicks(ticks[i]);
                string intervalString = interval.ToString();
                string runResult = $"Run {runCount[i],11} : {ticks[i],20} : {intervalString}"; // Textual measurement
                savedResults.Add(runResult);
                Console.WriteLine(runResult);
            }

            // TODO: Open the file instead of creating a new file everytime 
            // Write data to file (WILL OVERWRITE THE EXISTING FILE)
            SaveToFile(testName, ticks, "csv", runCount);
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

        private static void SaveToFile<T>(string filename, List<T> data, string format, List<string> dataRowTwo)
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
                        for (int i = 0; i < data.Count(); i++)
                        {
                            stream.WriteLine($"{data[i]};{dataRowTwo[i]}");
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
