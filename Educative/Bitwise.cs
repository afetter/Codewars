using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educative
{
    public static class Bitwise
    {
        /// <summary>
        /// In a non-empty array of integers, every number appears twice except for one, find that single number.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int FindSingleNumber(int[] arr)
        {
            int num = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(ToBinary(num));
                Console.WriteLine(ToBinary(arr[i]));
                Console.WriteLine(ToBinary(num ^ arr[i]));
                num = num ^ arr[i];
            }
            return num;
        }

        private static string ToBinary(int i)
        {
            return Convert.ToString(i, 2).PadLeft(8, '0');
        }

    }
}
