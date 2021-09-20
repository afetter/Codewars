using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educative
{
    public static class CyclicSort
    {
        /// <summary>
        /// We are given an unsorted array containing ‘n’ numbers taken from the range 1 to ‘n’. The array 
        /// originally contained all the numbers from 1 to ‘n’, but due to a data error, one of the 
        /// numbers got duplicated which also resulted in one number going missing. Find both these numbers.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int[] FindCorruptNums(int[] nums)
        {
            var result = new List<int>();
            int i = 0;
            while (i < nums.Length)
            {
                int j = nums[i] - 1;
                if (nums[i] != nums[j])
                    swap(nums, i, j);
                else
                    i++;
            }

            // find the first number missing from its index, that will be our required number
            for (i = 0; i < nums.Length; i++)
                if (nums[i] != i + 1)
                    return new int[] { nums[i], i + 1 };

            return new int[] { -1, -1 };
        }

        /// <summary>
        /// We are given an unsorted array containing ‘n+1’ numbers taken from the range 1 to ‘n’. 
        /// The array has only one duplicate but it can be repeated multiple times. Find that 
        /// duplicate number without using any extra space. You are, however, allowed to 
        /// modify the input array.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int FindDuplicate(int[] nums)
        {
            int i = 0;
            while (i < nums.Length)
            {
                int j = nums[i] - 1;
                if (nums[i] != nums[j])
                    swap(nums, i, j);
                else
                    i++;
            }

            // find the first number missing from its index, that will be our required number
            for (i = 0; i < nums.Length; i++)
                if (nums[i] != i + 1)
                    return nums[i];

            return -1;
        }

        /// <summary>
        /// We are given an unsorted array containing numbers taken from the range 1 to ‘n’. The array 
        /// can have duplicates, which means some numbers will be missing. Find all those missing numbers.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static List<int> AllMissingNumbers(int[] nums)
        {
            var result = new List<int>();
            int i = 0;
            while (i < nums.Length)
            {
                int j = nums[i] - 1;
                if (nums[i] != nums[j])
                    swap(nums, i, j);
                else
                    i++;
            }

            // find the first number missing from its index, that will be our required number
            for (i = 0; i < nums.Length; i++)
                if (nums[i] != i + 1)
                    result.Add(i + 1);

            return result;
        }

        /// <summary>
        /// We are given an array containing ‘n’ distinct numbers taken from the range 0 to ‘n’. 
        /// Since the array has only ‘n’ numbers out of the total ‘n+1’ numbers, find the missing number.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int MissingNumber(int[] nums)
        {
            int i = 0;
            while (i < nums.Length)
            {
                int j = nums[i] - 1;
                if (nums[i] != nums[j])
                    swap(nums, i, j);
                else
                    i++;
            }

            // find the first number missing from its index, that will be our required number
            for (i = 1; i < nums.Length; i++)
                if (nums[i] != i)
                    return i;

            return nums.Length;
        }
        /// <summary>
        /// We are given an array containing n objects. Each object, when created, was assigned a unique 
        /// number from the range 1 to n based on their creation sequence. This means that the object with 
        /// sequence number 3 was created just before the object with sequence number 4.
        /// Write a function to sort the objects in-place on their creation sequence number in O(n)O(n) 
        /// and without using any extra space.For simplicity, let’s assume we are passed an integer array 
        /// containing only the sequence numbers, though each number is actually an object.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int[] Sort(int[] nums)
        {
            int i = 0;
            while (i < nums.Length)
            {
                int j = nums[i] - 1;
                if (nums[i] != nums[j])
                    swap(nums, i, j);
                else
                    i++;
            }
            return nums;
        }

        private static void swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

    }
}
