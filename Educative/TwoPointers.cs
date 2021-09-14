using System;
using System.Collections.Generic;

namespace Educative
{
    public static class TwoPointers
    {
        /// <summary>
        /// Given two strings containing backspaces (identified by the character ‘#’), check if the two strings are equal.
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public static bool BackspaceCompare(string str1, string str2)
        {
            var aux1 = string.Empty;
            for (int i = 0; i < str1.Length; i++)
            {
                if (str1[i] == '#')
                {
                    aux1 = aux1.Substring(0, aux1.Length - 1);
                } 
                else
                {
                    aux1 += str1[i];
                }
            }
            var aux2 = string.Empty;
            for (int i = 0; i < str2.Length; i++)
            {
                if (str2[i] == '#')
                {
                    aux2 = aux2.Substring(0, aux2.Length - 1);
                }
                else
                {
                    aux2 += str2[i];
                }
            }
            return aux1 == aux2;
        }

        /// <summary>
        /// Given an array of unsorted numbers and a target number, find all unique quadruplets in it, whose sum is equal to the target number.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static List<List<int>> QuadrupleSumToTarget(int[] arr, int target)
        {
            var result = new List<List<int>>();
            Array.Sort(arr);

            for (int i = 0; i < arr.Length - 3; i++)
            {
                if (i > 0 && arr[i] == arr[i - 1]) // skip same element to avoid duplicate quadruplets
                    continue;
                for (int j = i + 1; j < arr.Length - 2; j++)
                {
                    if (j > i + 1 && arr[j] == arr[j - 1]) // skip same element to avoid duplicate quadruplets
                        continue;

                    searchPair2(arr, target, i, j, result);
                }
            }

            return result;
        }

        private static void searchPair2(int[] arr, int targetSum, int first, int second, List<List<int>> result)
        {
            int left = second + 1;
            int right = arr.Length - 1;
            while (left < right)
            {
                int sum = arr[first] + arr[second] + arr[left] + arr[right];
                if (sum == targetSum)
                { // found the triplet
                    result.Add(new List<int> { arr[first], arr[second], arr[left], arr[right]});
                    left++;
                    right--;

                    while (left < right && arr[left] == arr[left - 1])
                        left++; // skip same element to avoid duplicate triplets
                    while (left < right && arr[right] == arr[right + 1])
                        right--; // skip same element to avoid duplicate triplets

                }
                else if (sum < targetSum)
                    left++; // we need a pair with a bigger sum
                else
                    right--; // we need a pair with a smaller sum
            }
        }


        /// <summary>
        /// Given an array containing 0s, 1s and 2s, sort the array in-place.
        /// You should treat numbers of the array as objects, hence,
        /// we can’t count 0s, 1s, and 2s to recreate the array.
        /// The flag of the Netherlands consists of three colors: red, white
        /// and blue; and since our input array also consists of three different
        /// numbers that is why it is called Dutch National Flag problem.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int[] DutchFlag(int[] arr)
        {
            // all elements < low are 0 and all elements > high are 2
            // all elements from >= low < i are 1
            int low = 0, high = arr.Length - 1;
            for (int i = 0; i <= high;)
            {
                if (arr[i] == 0)
                {
                    swap(arr, i, low);
                    // increment 'i' and 'low'
                    i++;
                    low++;
                }
                else if (arr[i] == 1)
                {
                    i++;
                }
                else
                { // the case for arr[i] == 2
                    swap(arr, i, high);
                    // decrement 'high' only, after the swap the number at index 'i' could be 0, 1 or 2
                    high--;
                }
            }
            return arr;
        }

        private static void swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        /// <summary>
        /// Given an array arr of unsorted numbers and a target sum, count all
        /// triplets in it such that arr[i] + arr[j] + arr[k] < target
        /// where i, j, and k are three different indices.
        /// Write a function to return the count of such triplets.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="targetSum"></param>
        /// <returns></returns>
        public static int TripletWithSmallerSum(int[] arr, int targetSum)
        {

            Array.Sort(arr);
            int count = 0;
            for (int i = 0; i < arr.Length - 2; i++)
            {
                count += searchPair1(arr, targetSum - arr[i], i);
            }
            return count;
        }

        private static int searchPair1(int[] arr, int targetSum, int first)
        {
            int count = 0;
            int left = first + 1, right = arr.Length - 1;
            while (left < right)
            {
                if (arr[left] + arr[right] < targetSum)
                { // found the triplet
                  // since arr[right] >= arr[left], therefore, we can replace arr[right] by any number between 
                  // left and right to get a sum less than the target sum
                    count += right - left;
                    left++;
                }
                else
                {
                    right--; // we need a pair with a smaller sum
                }
            }
            return count;
        }

        /// <summary>
        /// Given an array of unsorted numbers and a target number, find a
        /// triplet in the array whose sum is as close to the target number as
        /// possible, return the sum of the triplet. If there are more than one
        /// such triplet, return the sum of the triplet with the smallest sum.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="targetSum"></param>
        /// <returns></returns>
        public static int TripletSumCloseToTarget(int[] arr, int targetSum)
        { 

            Array.Sort(arr);
            int smallestDifference = int.MaxValue;
            for (int i = 0; i < arr.Length - 2; i++)
            {
                int left = i + 1, right = arr.Length - 1;
                while (left < right)
                {
                    // comparing the sum of three numbers to the 'targetSum' can cause overflow
                    // so, we will try to find a target difference
                    int targetDiff = targetSum - arr[i] - arr[left] - arr[right];
                    if (targetDiff == 0) //  we've found a triplet with an exact sum
                        return targetSum - targetDiff; // return sum of all the numbers

                    // the second part of the above 'if' is to handle the smallest sum when we have more than one solution
                    if (Math.Abs(targetDiff) < Math.Abs(smallestDifference)
                        || (Math.Abs(targetDiff) == Math.Abs(smallestDifference) && targetDiff > smallestDifference))
                        smallestDifference = targetDiff; // save the closest and the biggest difference  

                    if (targetDiff > 0)
                        left++; // we need a triplet with a bigger sum
                    else
                        right--; // we need a triplet with a smaller sum
                }
            }
            return targetSum - smallestDifference;
        }

        /// <summary>
        /// Given an array of unsorted numbers, find all unique triplets
        /// in it that add up to zero.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static List<List<int>> TripletSumToZero(int[] arr)
        {
            var result = new List<List<int>>();
            Array.Sort(arr);

            for (int i = 0; i < arr.Length - 2; i++)
            {
                if (i > 0 && arr[i] == arr[i - 1]) // skip same element to avoid duplicate triplets
                    continue;

                searchPair(arr, -arr[i], i + 1, result);
            }

            return result;
        }

        private static void searchPair(int[] arr, int targetSum, int left, List<List<int>> triplets)
        {
            int right = arr.Length - 1;
            while (left < right)
            {
                int currentSum = arr[left] + arr[right];
                if (currentSum == targetSum)
                { // found the triplet
                    triplets.Add(new List<int> { -targetSum, arr[left], arr[right] });
                    left++;
                    right--;
                    while (left < right && arr[left] == arr[left - 1])
                        left++; // skip same element to avoid duplicate triplets
                    while (left < right && arr[right] == arr[right + 1])
                        right--; // skip same element to avoid duplicate triplets
                }
                else if (targetSum > currentSum)
                    left++; // we need a pair with a bigger sum
                else
                    right--; // we need a pair with a smaller sum
            }
        }

        /// <summary>
        /// Given a sorted array, create a new array containing squares of all
        /// the numbers of the input array in the sorted order.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int[] SortedArraySquares(int[] arr)
        {
            var result = new int[arr.Length];
            int squareSt = 0, squareEnd = 0;

            int start = 0, end = arr.Length - 1, index = arr.Length - 1;
            while (start < end)
            {
                squareSt = arr[start] * arr[start];
                squareEnd = arr[end] * arr[end];

                if (squareSt > squareEnd)
                {
                    result[index--] = squareSt;
                    start++;
                }
                else
                {
                    result[index--] = squareEnd;
                    end--;
                }
            }
            return result;
        }
        /// <summary>
        /// Given an unsorted array of numbers and a target ‘key’, remove all
        /// instances of ‘key’ in-place and return the new length of the array.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int RemoveElement(int[] arr, int key)
        {
            var result = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != key)
                    result++;
            }
            return result;
        }

        /// <summary>
        /// Given an array of sorted numbers, remove all duplicates from it.
        /// You should not use any extra space; after removing the duplicates
        /// in-place return the length of the subarray that has no duplicate
        /// in it.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int RemoveDuplicates(int[] arr)
        {
            var result = 1;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] != arr[i + 1])
                    result++;
            }
            return result;
        }
        /// <summary>
        /// Given an array of sorted numbers and a target sum, find a pair in
        /// the array whose sum is equal to the given target.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="targetSum"></param>
        /// <returns></returns>
        public static int[] PairWithTargetSum(int[] arr, int targetSum)
        {
            var sum = 0;
            int start = 0, end = arr.Length - 1;
            while (start < end)
            {
                sum = arr[start] + arr[end];

                if (sum == targetSum)
                    return new int[] { start, end };

                if (sum > targetSum)
                    end--;
                else
                    start++;
            }

            return new int[] { -1, -1 };
        }

        public static int[] PairWithTargetSumWithDic(int[] arr, int targetSum)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (dic.ContainsKey(targetSum - arr[i]))
                {
                    return new int[] { dic[targetSum - arr[i]], i };
                } else
                {
                    dic.Add(arr[i], i);
                }
            }
            return new int[] { -1, -1 };
        }
    }
}
