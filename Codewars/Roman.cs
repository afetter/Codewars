using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codewars
{

    public static class Roman
    {
        static Dictionary<char, int> RomanNumberDictionary = new Dictionary<char, int>
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 },
        };

    static Dictionary<string, int> NumberRomanDictionary = new Dictionary<string, int>
        {
            {"M", 1000 },
            {"CM", 900},
            {"D", 500},
            {"CD", 400},
            {"C", 100},
            {"XC", 90},
            {"L", 50},
            {"XL", 40},
            {"X", 10},
            {"IX", 9},
            {"V", 5},
            {"IV", 4},
            {"I", 1}
        };

        //Create a RomanNumerals class that can convert a roman numeral to and from an integer value.It should
        //follow the API demonstrated in the examples below.Multiple roman numeral values will be tested for each helper method.
        //Modern Roman numerals are written by expressing each digit separately starting with the left most digit and
        //skipping any digit with a value of zero.In Roman numerals 1990 is rendered: 1000=M, 900=CM, 90=XC; resulting in MCMXC.
        //2008 is written as 2000=MM, 8=VIII; or MMVIII. 1666 uses each Roman symbol in descending order: MDCLXVI.
        //Input range : 1 <= n< 4000
        //In this kata 4 should be represented as IV, NOT as IIII (the "watchmaker's four").
        public static string ToRoman(int n)
        {
            var roman = new StringBuilder();

            foreach (var item in NumberRomanDictionary)
            {
                roman.Append(string.Join(string.Empty, Enumerable.Repeat(item.Key, n / item.Value)));
                n %= item.Value;
            }

            return roman.ToString();
        }

        public static int FromRoman(string romanNumeral)
        {
            int total = 0;

            int current, previous = 0;
            char currentRoman, previousRoman = '\0';

            for (int i = 0; i < romanNumeral.Length; i++)
            {
                currentRoman = romanNumeral[i];

                previous = previousRoman != '\0' ? RomanNumberDictionary[previousRoman] : '\0';
                current = RomanNumberDictionary[currentRoman];

                if (previous != 0 && current > previous)
                {
                    total = total - (2 * previous) + current;
                }
                else
                {
                    total += current;
                }

                previousRoman = currentRoman;
            }

            return total;
        }
    }
}
