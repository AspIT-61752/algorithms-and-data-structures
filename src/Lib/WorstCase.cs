using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lib
{
    public class WorstCase
    {
        public int[] FillWithRandom(int arraySize)
        {
            int[] arr = new int[arraySize];
            Random random = new Random();
            for (int i = 0; i < arraySize - 1; i++)
            {
                arr[i] = random.Next(0, Int32.MaxValue);
            }

            return arr;
        }

        public int[] Linear(int arraySize)
        {
            int[] arr = new int[arraySize];
            Random random = new Random();

            for (int i = arraySize - 1; i >= 0; i--)
            {
                // i = 50
                // arraySize = 75
                // arr[i] = 75 - 50 = 25
                // arr[50] = 25
                // arr[49] = 75 - 49 = 26
                // arr[48] = 75 - 48 = 27
                arr[i] = arraySize-i;
            }

            return arr;
        }
    }
}
