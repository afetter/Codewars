using System.Collections.Generic;
using System.Linq;

namespace Codewars
{
    public static class RangeExtraction
    {
        //solution([-6, -3, -2, -1, 0, 1, 3, 4, 5, 7, 8, 9, 10, 11, 14, 15, 17, 18, 19, 20]);
        // returns "-6,-3-1,3-5,7-11,14,15,17-20"

        //        A format for expressing an ordered list of integers is to use a comma separated list of either

        //individual integers
        //or a range of integers denoted by the starting integer separated from the end integer in the range by a dash, '-'. The range includes all integers in the interval including both endpoints.It is not considered a range unless it spans at least 3 numbers.For example "12,13,15-17"
        //Complete the solution so that it takes a list of integers in increasing order and returns a correctly formatted string in the range format.
        public static string Extract(int[] args)
        {
            var result = string.Empty;
            var group = ExtractTo(args);
            foreach (var item in group)
            {
                if (item.Count == 1)
                {
                    result += $"{item.Max()},";
                }
                else if (item.Count == 2)
                {
                    result += $"{item.Min()},{item.Max()},";
                } else
                {
                    result += $"{item.Min()}-{item.Max()},";
                }
            }
            return result.TrimEnd(',');
        }
        private static List<List<int>> ExtractTo(int[] args)
        {
            var result = new List<List<int>>();
            var subSet = new List<int>();
            foreach (var item in args)
            {
                if (subSet.Count == 0)
                {
                    subSet.Add(item);
                } 
                else if (subSet.Max() + 1 == item)
                {
                    subSet.Add(item);
                } else
                {
                    result.Add(subSet);
                    subSet = new List<int>();
                    subSet.Add(item);
                }
            }
            result.Add(subSet);
            return result;
        }
    }
}
