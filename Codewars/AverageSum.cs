using System;
using System.Collections.Generic;

namespace Codewars
{
    public static class AverageSum
    {
       public static List<double> GetAverage(int[] args, int k)
        {
            var result = new List<double>();
            int sum = 0;
            for (int i = 0; i < args.Length; i++)
            {
                sum += args[i];
                if (i >= k - 1)
                {
                    result.Add(sum / (double)k);
                    sum -= args[(i + 1) - k];
                }
            }

            return result;
        }
    }
}
