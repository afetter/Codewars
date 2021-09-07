using System;
namespace Codewars
{
    //We need to sum big numbers and we require your help.
    //Write a function that returns the sum of two numbers.The input numbers are strings and the function must return a string.
    //Example
    //add("123", "321"); -> "444"
    //add("11", "99");   -> "110"
    public static class SumBigNumber
    {
        public static string Add(string a, string b)
        {
            //return (BigInteger.Parse(a) + BigInteger.Parse(b)).ToString(); // Fix this!

            var result = string.Empty;
            var aux = 0;

            var maxLen = a.Length < b.Length ? b.Length : a.Length;

            for (int i = 1; i <= maxLen; i++)
            {
                var aChar = i < a.Length + 1 ? a[^i].ToString() : "0";
                var bChar = i < b.Length + 1 ? b[^i].ToString() : "0";

                var sum = Convert.ToInt32(aChar) + Convert.ToInt32(bChar) + aux;
                if (sum > 9)
                {
                    aux = Convert.ToInt32(sum.ToString()[0].ToString());
                    result = sum.ToString()[1] + result;
                }
                else
                {
                    aux = 0;
                    result = sum.ToString() + result;
                }

            }

            if (aux != 0)
            {
                result = aux.ToString() + result;
            }

            return result;

        }
    }

    //Best Solution
    //System.Numerics.BigInteger() + System.Numerics.BigInteger();
}
