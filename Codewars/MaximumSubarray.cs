﻿using System;
namespace Codewars
{
    /// <summary>
    /// The maximum sum subarray problem consists in finding the maximum sum of a contiguous subsequence in an array or list of integers:

    /// maxSequence [-2, 1, -3, 4, -1, 2, 1, -5, 4]
    /// -- should be 6: [4, -1, 2, 1]
    /// Easy case is when the list is made up of only positive numbers and the maximum sum is the sum of the whole array.If the list is made up of only negative numbers, return 0 instead.

    /// Empty list is considered to have zero greatest sum. Note that the empty list or array is also a valid sublist/subarray.
    /// </summary>
    public static class MaximumSubarray
    {
        public static int MaxSequence(int[] arr)
        {
            if (arr.Length == 0) return 0;

            var maxCurrent = arr[0];
            var maxGlobal = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                maxCurrent = Math.Max(arr[i], maxCurrent + arr[i]);
                if (maxCurrent > maxGlobal)
                    maxGlobal = maxCurrent;
            }
            return maxGlobal;
        }
    }
}
