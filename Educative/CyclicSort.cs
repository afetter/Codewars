using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educative
{
    public static class CyclicSort
    {

        public static int[] AllMissingNumbers(int[] nums)
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
                if (nums[i] != i)
                    result.Add(i);

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
