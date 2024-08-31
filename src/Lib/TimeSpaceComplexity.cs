using System.Numerics;
using System.Text.RegularExpressions;

namespace Lib
{
    public class TimeSpaceComplexity
    {
        // - Calculate O from the pseudocode
        // - Verify with concrete code
        // - make a visual graph of the measurements
        // - conclude if your calculated time complexity matches your measurements

        // Calculate O from the pseudocode:
        //      O(n)
        // Verify with concrete code
        // make a visual graph of the measurements
        // conclude if your calculated time complexity matches your measurements
        public BigInteger SumOf(int[] arr)
        {
            BigInteger total = 0;
            foreach (var numb in arr)
            {
                total += numb;
            }

            return total;
        }
    }
}
