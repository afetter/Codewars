using System;
namespace Codewars
{
    //For a given string s find the character c(or C) with longest consecutive repetition and return:
    //Tuple<char?, int>(c, l)
    //where l(or L) is the length of the repetition.If there are two or more characters with the same l
    //return the first in order of appearance.
    public static class Longest
    {
        public static Tuple<char?, int> LongestRepetition(string input)
        {
            if (input == String.Empty)
            {
                return new Tuple<char?, int>(null, 0);
            }

            char rchar = input[0];
            int rcount = 1;
            int currentCount = 0;
            char previousChar = char.MinValue;

            foreach (char character in input)
            {
                if (character != previousChar)
                {
                    currentCount = 1;
                }
                else
                {
                    currentCount++;
                }
                if (currentCount > rcount)
                {
                    rchar = character;
                    rcount = currentCount;
                }
                previousChar = character;
            }
            return new Tuple<char?, int>(rchar, rcount);
        }
    }
}
