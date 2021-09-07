using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //"1,3-5,7-11"
            Console.WriteLine(RangeExtraction.Extract(new[] { 1, 3, 4, 5, 7, 8, 9, 10, 11}));
        }


       

        ////        Some numbers have funny properties.For example:
        ////89 --> 8¹ + 9² = 89 * 1
        ////695 --> 6² + 9³ + 5⁴= 1390 = 695 * 2
        ////46288 --> 4³ + 6⁴+ 2⁵ + 8⁶ + 8⁷ = 2360688 = 46288 * 51
        ////Given a positive integer n written as abcd... (a, b, c, d...being digits) and a positive integer p
        ////we want to find a positive integer k, if it exists, such as the sum of the digits of n taken to the successive powers of p is equal to k* n.
        ////In other words:
        ////Is there an integer k such as : (a ^ p + b ^ (p+1) + c ^(p+2) + d ^ (p+3) + ...) = n* k
        ////If it is the case we will return k, if not return -1.
        ////Note: n and p will always be given as strictly positive integers.
        public static long digPow(int n, int p)
        {
            // your code
            var mult = 0d;

            foreach (char item in n.ToString())
            {
                mult += Math.Pow(Convert.ToInt32(item.ToString()), p);
                p++;
            }

            if (mult % n != 0) return -1;

            return (long)mult / n;
        }

        ////        Given an array of integers, find the one that appears an odd number of times.
        ////There will always be only one integer that appears an odd number of times.
        ////Examples
        ////[7] should return 7, because it occurs 1 time (which is odd).
        ////[0] should return 0, because it occurs 1 time(which is odd).
        ////[1,1,2] should return 2, because it occurs 1 time(which is odd).
        ////[0,1,0,1,0] should return 0, because it occurs 3 times(which is odd).
        ////[1,2,2,3,3,3,4,3,3,3,2,2,1] shold return 4, because it appears 1 time(which is odd).
        public static int find_it(int[] seq)
        {
            //Solution 1.
            //Shows knowleged about Framework
            //var group = seq.GroupBy(s => s).FirstOrDefault(n => n.Count() % 2 != 0);
            //return group.Key;

            //Solution 2.
            //Shows knowleged about logic
            Dictionary<int, int> dic = new Dictionary<int, int>();
            foreach (var item in seq)
            {
                if (!dic.ContainsKey(item))
                {
                    dic.Add(item, 1);
                }
                else
                {
                    dic[item] = dic[item] + 1;
                }
            }

            foreach (var item in dic)
            {
                if (item.Value % 2 != 0)
                    return item.Key;
            }

            return -1;
        }



        /// <summary>
        /// 
        ///Write a function, which takes a non-negative integer(seconds) as input and returns the time in a
        ///human-readable format(HH:MM:SS)
        //HH = hours, padded to 2 digits, range: 00 - 99
        //MM = minutes, padded to 2 digits, range: 00 - 59
        //SS = seconds, padded to 2 digits, range: 00 - 59
        //The maximum time never exceeds 359999 (99:59:59)
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static string GetReadableTime(int seconds)
        {
            if (seconds == 0)
                return "00:00:00";

            var fullHour = seconds / 3600m;
            var fullMin = (fullHour % 1.0m);
            var minute = fullMin * 60;
            var fullSec = (minute % 1.0m);
            var sec = Math.Round(fullSec * 60m);

            return $"{((int)fullHour).ToString().PadLeft(2, '0')}:{((int)minute).ToString().PadLeft(2, '0')}:{((int)sec).ToString().PadLeft(2, '0')}";

        }

        /// <summary>
        /// Write an algorithm that takes an array and moves all of the zeros to the end, 
        /// preserving the order of the other elements.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns>
        /// Kata.MoveZeroes(new int[] {1, 2, 0, 1, 0, 1, 0, 3, 0, 1}) => new int[] {1, 2, 1, 1, 3, 1, 0, 0, 0, 0}
        /// </returns>
        public static int[] MoveZeroes(int[] arr)
        {
            var totalOfZeros = arr.Count(i => i == 0);
            var auxList = arr.Where(n => n != 0);
            auxList = auxList.Concat(Enumerable.Repeat(0, totalOfZeros));

            return auxList.ToArray();
        }

        /// <summary>
        /// Simple, given a string of words, return the length of the shortest word(s).
        /// String will never be empty and you do not need to account for different data types.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int FindShort(string s)
        {
            var array = s.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int smallString = int.MaxValue;

            foreach (var item in array)
            {
                if (item.Length == 1)
                    return 1;
                if (item.Length < smallString)
                    smallString = item.Length;
            }
            return smallString;
        }

        /// <summary>
        /// In a small town the population is p0 = 1000 at the beginning of a year. The population regularly increases by 2 
        /// percent per year and moreover 50 new inhabitants per year come to live in the town. How many years does the town 
        /// need to see its population greater or equal to p = 1200 inhabitants?
        /// </summary>
        /// <param name="p0"></param>
        /// <param name="percent"></param>
        /// <param name="aug"></param>
        /// <param name="p"></param>
        /// <returns>
        /// nb_year(1500, 5, 100, 5000) -> 15
        /// nb_year(1500000, 2.5, 10000, 2000000) -> 10
        /// 
        /// </returns>
        public static int NbYear(int p0, double percent, int aug, int p)
        {
            int years = 0;
            while (p0 < p)
            {
                p0 = (int)(p0 + p0 * (percent / 100) + aug);
                years++;
            }
            return years;
        }
        /// <summary>
        /// Write a function, persistence, that takes in a positive parameter num and returns its multiplicative persistence, 
        /// which is the number of times you must multiply 
        /// the digits in num until you reach a single digit.
        /// </summary>
        /// <param name="n"></param>
        /// <returns>
        /// persistence(39) == 3 // because 3*9 = 27, 2*7 = 14, 1*4=4 and 4 has only one digit
        /// persistence(999) == 4 // because 9*9*9 = 729, 7*2*9 = 126, // 1*2*6 = 12, and finally 1*2 = 2
        /// </returns>
        public static int Persistence(long n)
        {
            var mult = 1;
            int count = 1;

            if (n < 10) return 0;

            while (n > 0)
            {
                mult *= (int)n % 10;
                n /= 10;

                if (n == 0 && mult < 10)
                {
                    break;
                }

                if (n <= 0)
                {
                    count++;
                    n = mult;
                    mult = 1;
                }


            }

            return count;
        }

        /// <summary>
        /// Implement the function unique_in_order which takes as argument a sequence and returns a list of items 
        /// without any elements with the same value next to each other and preserving the original order of elements.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="iterable"></param>
        /// <returns>
        /// uniqueInOrder("AAAABBBCCDAABBB") == {'A', 'B', 'C', 'D', 'A', 'B'}
        /// uniqueInOrder("ABBCcAD")         == {'A', 'B', 'C', 'c', 'A', 'D'}
        /// uniqueInOrder([1,2,2,3,3])       == {1,2,3}
        /// </returns>
        public static IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> iterable)
        {
            var result = new List<T>();
            T lastItem = default(T);

            foreach (var item in iterable)
            {
                if (!item.Equals(lastItem))
                {
                    result.Add(item);
                }
                lastItem = item;
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cc"></param>
        /// <returns></returns>
        public static string Maskify(string cc)
        {

            if (string.IsNullOrEmpty(cc))
                return string.Empty;

            if (cc.Length == 1)
            {
                return cc;
            }

            return cc.Substring(cc.Length - 4);
        }
    }
}
