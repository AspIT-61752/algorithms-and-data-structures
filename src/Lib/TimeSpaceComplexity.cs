using System.Collections;
using System.Numerics;
using System.Text.RegularExpressions;

namespace Lib
{
    public class TimeSpaceComplexity
    {
        // - Calculate O from the pseudocode
        //      TC: Time Complexity
        //      SC: Space Complexity
        // - Verify with concrete code
        // - make a visual graph of the measurements
        // - conclude if your calculated time complexity matches your measurements

        // Calculate O from the pseudocode:
        //      TC: O(n)
        //      SC: O(n Log(n))
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

        // Calculate O from the pseudocode:
        //      TC: O(1)
        //      SC: O(1)
        // Verify with concrete code
        // make a visual graph of the measurements
        // conclude if your calculated time complexity matches your measurements
        public T Find<T>(T[] arr, int index)
        {
            return arr[index];
        }

        // Calculate O from the pseudocode:
        //      TC: O(n)
        //      SC: O(1) or O(2)
        // Verify with concrete code
        // make a visual graph of the measurements
        // conclude if your calculated time complexity matches your measurements
        public bool Contains<T>(T[] arr, T value)
        {
            foreach (var item in arr)
            {
                if (value.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        // Calculate O from the pseudocode:
        //      TC: O(n)
        //      SC: O(1) or O(2)
        // Verify with concrete code
        // make a visual graph of the measurements
        // conclude if your calculated time complexity matches your measurements
        public T[] RemoveAt<T>(T[] arr, int indexToRemove)
        {
            // Because this is an array and not something like a List, I have to make a new array that's smaller to completly remove it.
            T[] res = new T[arr.Length-1];
            for (int i = 0; i < res.Length; i++)
            {
                if (i < indexToRemove)
                {
                    res[i] = arr[i];
                }
                else
                {
                    res[i] = arr[i+1];
                }
            }

            return res;
        }

        // Calculate O from the pseudocode:
        //      TC: O(n) or O(n log(n))
        //      SC: O(1) or O(2)
        // Verify with concrete code
        // make a visual graph of the measurements
        // conclude if your calculated time complexity matches your measurements
        public T[] RemoveByValue<T>(T[] arr, T value)
        {
            List<T> temp = new();
            for (int i = 0; i < arr.Length; i++)
            {
                if (!value.Equals(arr[i]))
                {
                    temp.Add(arr[i]);
                }
            }

            T[] res = temp.ToArray();
            return res;
        }

        // Calculate O from the pseudocode:
        //      TC: O(2^n)
        //      SC: O(1)
        // Verify with concrete code
        // make a visual graph of the measurements
        // conclude if your calculated time complexity matches your measurements
        public T[] Matching<T>(T[] arr, T[] arr2)
        {
            //List<T> res = new();

            // Split the arrays in 4
            // Do this but 4 times faster
            // Add to 1 list at the end
            // Profit?
            List<T> res;

            List<T> arrList1 = arr.ToList();
            List<T> arr2List1 = arr2.ToList();

            if (arr.Length > 1 && arr2.Length > 1)
            {
                int chunkSize = (int)Math.Ceiling(arrList1.Count / 4.0);

                List<T> arrListChunk1 = arrList1.GetRange(0, chunkSize);
                List<T> arrListChunk2 = arrList1.GetRange(chunkSize, Math.Min(chunkSize, arrList1.Count - chunkSize));
                List<T> arrListChunk3 = arrList1.GetRange(chunkSize * 2, Math.Min(chunkSize, arrList1.Count - chunkSize * 2));
                List<T> arrListChunk4 = arrList1.GetRange(chunkSize * 3, Math.Min(chunkSize, arrList1.Count - chunkSize * 3));

                List<T> arr2ListChunk1 = arr2List1.GetRange(0, chunkSize);
                List<T> arr2ListChunk2 = arr2List1.GetRange(chunkSize, Math.Min(chunkSize, arr2List1.Count - chunkSize));
                List<T> arr2ListChunk3 = arr2List1.GetRange(chunkSize * 2, Math.Min(chunkSize, arr2List1.Count - chunkSize * 2));
                List<T> arr2ListChunk4 = arr2List1.GetRange(chunkSize * 3, Math.Min(chunkSize, arr2List1.Count - chunkSize * 3));

                var mChunkTask1 = Task.Run(() => arrListChunk1 = MatchingChunk(arrListChunk1, arr2ListChunk1));
                var mChunkTask2 = Task.Run(() => arrListChunk2 = MatchingChunk(arrListChunk2, arr2ListChunk2));
                var mChunkTask3 = Task.Run(() => arrListChunk3 = MatchingChunk(arrListChunk3, arr2ListChunk3));
                var mChunkTask4 = Task.Run(() => arrListChunk4 = MatchingChunk(arrListChunk4, arr2ListChunk4));

                Task.WaitAll(mChunkTask1, mChunkTask2, mChunkTask3, mChunkTask4);

                // Combine the lists
                res = new List<T>(arrListChunk1.Count + arrListChunk2.Count + arrListChunk3.Count + arrListChunk4.Count);
                res.AddRange(arrListChunk1);
                res.AddRange(arrListChunk2);
                res.AddRange(arrListChunk3);
                res.AddRange(arrListChunk4);
            }
            else
            {
                res = MatchingChunk(arr.ToList(), arr2.ToList());
            }

            return res.ToArray();
        }

        private List<T> MatchingChunk<T>(List<T> arr, List<T> arr2)
        {
            List<T> res = new();

            foreach (var item in arr)
            {
                for (int i = 0; i < arr2.Count; i++)
                {
                    if (arr2[i].Equals(item))
                    {
                        res.Add(item);
                    }
                }
            }
            return res;
        }
    }
}
