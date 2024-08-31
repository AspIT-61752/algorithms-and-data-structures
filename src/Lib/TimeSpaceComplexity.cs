﻿using System.Numerics;
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
        // TODO: TEST THIS
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
        // TODO: TEST THIS
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
        // TODO: TEST THIS
        public T[] RemoveAt<T>(T[] arr, int indexToRemove)
        {
            // Because this is an array and not something like a List, I have to make a new array that's smaller to completly remove it.
            T[] temp = new T[arr.Length-1];
            for (int i = 0; i < arr.Length; i++)
            {
                if (i == indexToRemove)
                {
                    temp[i] = arr[i];
                }
                else
                {
                    temp[i-1] = arr[i];
                }
            }

            return temp;
        }
    }
}
