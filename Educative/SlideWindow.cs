using System;
using System.Collections.Generic;

namespace Educative
{
    public static class SlideWindow
    {

        /// <summary>
        /// Given a string and a pattern, find the smallest substring in the
        /// given string which has all the characters of the given pattern.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        ///
        public static string MinimumWindowSubstring(string str, string pattern)
        {
            int windowStart = 0, matched = 0, minLength = str.Length + 1, subStrStart = 0;
            Dictionary<char, int> charFrequencyMap = new Dictionary<char, int>();
            foreach (var item in pattern)
            {
                charFrequencyMap.UpInsert(item, 1);
            }

            // try to extend the range [windowStart, windowEnd]
            for (int windowEnd = 0; windowEnd < str.Length; windowEnd++)
            {
                char rightChar = str[windowEnd];
                if (charFrequencyMap.ContainsKey(rightChar))
                {
                    charFrequencyMap.UpInsert(rightChar, -1);
                    if (charFrequencyMap[rightChar] >= 0) // count every matching of a character
                        matched++;
                }

                // shrink the window if we can, finish as soon as we remove a matched character
                while (matched == pattern.Length)
                {
                    if (minLength > windowEnd - windowStart + 1)
                    {
                        minLength = windowEnd - windowStart + 1;
                        subStrStart = windowStart;
                    }

                    char leftChar = str[windowStart++];
                    if (charFrequencyMap.ContainsKey(leftChar))
                    {
                        // note that we could have redundant matching characters, therefore we'll decrement the
                        // matched count only when a useful occurrence of a matched character is going out of the window
                        if (charFrequencyMap[leftChar] == 0)
                            matched--;

                        charFrequencyMap.UpInsert(leftChar, 1);
                    }
                }
            }

            return minLength > str.Length ? "" : str.Substring(subStrStart);//, subStrStart + minLength);
        }
        

        /// <summary>
        /// Given a string and a pattern, find all anagrams of the pattern in
        /// the given string.
        /// Every anagram is a permutation of a string. As we know, when we
        /// are not allowed to repeat characters while finding permutations
        /// of a string, we get N!N! permutations(or anagrams) of a string
        /// having NN characters.For example, here are the six anagrams of the string “abc”:
        /// </summary>
        /// <param name="str"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static List<int> StringAnagrams(string str, string pattern)
        {
            int windowStart = 0, matched = 0;
            Dictionary<char, int> charFrequencyMap = new Dictionary<char, int>();
            foreach (var item in pattern)
            {
                charFrequencyMap.UpInsert(item, 1);
            }

            List<int> resultIndices = new List<int>();
            // our goal is to match all the characters from the 'charFrequencyMap' with the current window
            // try to extend the range [windowStart, windowEnd]
            for (int windowEnd = 0; windowEnd < str.Length; windowEnd++)
            {
                char rightChar = str[windowEnd];
                if (charFrequencyMap.ContainsKey(rightChar))
                {
                    // decrement the frequency of the matched character
                    charFrequencyMap.UpInsert(rightChar, -1);
                    if (charFrequencyMap[rightChar] == 0) // character is completely matched
                        matched++;
                }

                if (matched == charFrequencyMap.Count)
                    resultIndices.Add(windowStart);

                if (windowEnd >= pattern.Length - 1)
                { // shrink the window by one character
                    char leftChar = str[windowStart++];
                    if (charFrequencyMap.ContainsKey(leftChar))
                    {
                        if (charFrequencyMap[leftChar] == 0)
                            matched--; // before putting the character back, decrement the matched count
                                       // put the character back for matching
                        charFrequencyMap.UpInsert(leftChar, 1);
                    }
                }
            }

            return resultIndices;
        }

        /// <summary>
        /// Given a string and a pattern, find out if the string contains any
        /// permutation of the pattern.
        /// Permutation is defined as the re-arranging of the characters of
        /// the string. For example, “abc” has the following six permutations:
        /// </summary>
        /// <param name="str"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static bool StringPermutation(string str, string pattern)
        {
            int windowStart = 0, matched = 0;
            Dictionary<char, int> charFrequencyMap = new Dictionary<char, int>();
            foreach (var item in pattern)
            {
                charFrequencyMap.UpInsert(item, 1);
            }

            // our goal is to match all the characters from the 'charFrequencyMap' with the current window
            // try to extend the range [windowStart, windowEnd]
            for (int windowEnd = 0; windowEnd < str.Length; windowEnd++)
            {
                char rightChar = str[windowEnd];
                if (charFrequencyMap.ContainsKey(rightChar))
                {
                    // decrement the frequency of the matched character
                    charFrequencyMap.UpInsert(rightChar, -1);
                    if (charFrequencyMap[rightChar] == 0) // character is completely matched
                        matched++;
                }

                if (matched == charFrequencyMap.Count)
                    return true;

                if (windowEnd >= pattern.Length - 1)
                { // shrink the window by one character
                    char leftChar = str[windowStart++];
                    if (charFrequencyMap.ContainsKey(leftChar))
                    {
                        if (charFrequencyMap[leftChar] == 0)
                            matched--; // before putting the character back, decrement the matched count
                                       // put the character back for matching
                        charFrequencyMap.UpInsert(leftChar, 1);
                    }
                }
            }

            return false;
        }

        private static Dictionary<char, int> UpInsert(this Dictionary<char, int> dic, char c, int f)
        {
            if (dic.ContainsKey(c))
            {
                dic[c] = dic[c] + f;
            } else
            {
                dic.Add(c, f);
            }

            return dic;
        }

        /// <summary>
        /// Given an array containing 0s and 1s, if you are allowed to replace
        /// no more than ‘k’ 0s with 1s, find the length of the longest
        /// contiguous subarray having all 1s.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int ReplacingOnes(int[] arr, int k)
        {
            int start = 0, maxLen = 0, maxOnesCount = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 1) maxOnesCount++;

                // current window size is from windowStart to windowEnd, overall we have a maximum of 1s
                // repeating a maximum of 'maxOnesCount' times, this means that we can have a window with
                // 'maxOnesCount' 1s and the remaining are 0s which should replace with 1s.
                // now, if the remaining 0s are more than 'k', it is the time to shrink the window as we
                // are not allowed to replace more than 'k' Os
                if (i - start + 1 - maxOnesCount > k)
                {
                    if (arr[start] == 1)
                        maxOnesCount--;

                    start++;
                }
                maxLen = Math.Max(maxLen, i - start + 1);
            }

            return maxLen;
        }
        /// <summary>
        /// Given a string with lowercase letters only, if you are allowed to
        /// replace no more than ‘k’ letters with any letter, find the length
        /// of the longest substring having the same letters after replacement.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int CharacterReplacement(string str, int k)
        {
            int start = 0, maxLen = 0, maxRepeatLetter = 0;
            Dictionary<char, int> dic = new Dictionary<char, int>();
            for (int i = 0; i < str.Length; i++)
            {
                char rightChar = str[i];
                if (dic.ContainsKey(rightChar))
                {
                    dic[rightChar] = dic[rightChar] + 1;
                } else
                {
                    dic.Add(rightChar, 1);
                }

                maxRepeatLetter = Math.Max(maxRepeatLetter, dic[rightChar]);

                if(i - start + 1 - maxRepeatLetter > k)
                {
                    var leftChar = str[start];
                    if (dic.ContainsKey(leftChar))
                    {
                        dic[leftChar] = dic[leftChar] - 1;
                    }
                    else
                    {
                        dic.Add(leftChar, 1);
                    }
                    start++;
                }

                maxLen = Math.Max(maxLen, i - start + 1);

            }

            return maxLen;
        }

        /// <summary>
        /// Given a string, find the length of the longest substring, which has no repeating characters.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int NoRepeatSubstring(string str)
        {
            int start = 0;
            int maxLen = 0;
            Dictionary<char, int> dic = new Dictionary<char, int>();
            for (int i = 0; i < str.Length; i++)
            {
                char rightChar = str[i];
                // if the map already contains the 'rightChar', shrink the window from the beginning so that
                // we have only one occurrence of 'rightChar'
                if (dic.ContainsKey(rightChar))
                {
                    // this is tricky; in the current window, we will not have any 'rightChar' after its previous index
                    // and if 'start' is already ahead of the last index of 'rightChar', we'll keep 'windowStart'
                    start = Math.Max(start, dic[rightChar] + 1);
                }

                if (dic.ContainsKey(str[i]))
                    dic[str[i]] = i;
                else
                    dic.Add(str[i], i);

                maxLen = Math.Max(maxLen, i - start + 1);

            }
            return maxLen;
        }

        /// <summary>
        /// Given an array of characters where each character represents a
        /// fruit tree, you are given two baskets, and your goal is to put
        /// maximum number of fruits in each basket. The only restriction is
        /// that each basket can have only one type of fruit.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int MaxFruitCountOf2Types(char[] str)
        {
            int start = 0;
            int maxLen = 0;
            Dictionary<char, int> dic = new Dictionary<char, int>();
            for (int i = 0; i < str.Length; i++)
            {
                if (dic.ContainsKey(str[i]))
                    dic[str[i]] = dic[str[i]] + 1;
                else
                    dic.Add(str[i], 1);

                while (dic.Count > 2)
                {
                    char left = str[start];
                    dic[left] = dic[left] - 1;
                    if (dic[left] == 0)
                        dic.Remove(left);

                    start++;
                }
                maxLen = Math.Max(maxLen, i - start + 1);
            }
            return maxLen;
        }

        /// <summary>
        /// Given a string, find the length of the longest substring in it
        /// with no more than K distinct characters.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int LongestSubstringKDistinct(string str, int k)
        {
            int start = 0;
            int maxLen = 0;
            Dictionary<char, int> dic = new Dictionary<char, int>();
            for (int i = 0; i < str.Length; i++)
            {
                if (dic.ContainsKey(str[i]))
                    dic[str[i]] = dic[str[i]] + 1;
                else
                    dic.Add(str[i], 1);

                while(dic.Count > k)
                {
                    char left = str[start];
                    dic[left] = dic[left] - 1;
                    if (dic[left] == 0)
                        dic.Remove(left);

                    start++;
                }
                maxLen = Math.Max(maxLen, i - start + 1);
            }
            return maxLen;
        }


        /// <summary>
        /// Given an array of positive numbers and a positive number ‘S,’
        /// find the length of the smallest contiguous subarray whose sum is
        /// greater than or equal to ‘S’. Return 0 if no such subarray exists.
        /// </summary>
        /// <param name="S"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static int MinSubArray(int S, int[] args)
        {
            var currentSum = 0;
            var minLen = 0;
            var windowStart = 0;
            var result = int.MaxValue;
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] >= S) return 1;

                currentSum += args[i];
                minLen++;

                while (currentSum >= S)
                {
                    result = Math.Min(result, minLen);
                    minLen--;
                    currentSum -= args[windowStart];
                }
            }

            return result;
        }

        /// <summary>
        /// Given an array of positive numbers and a positive number ‘k,’
        /// find the maximum sum of any contiguous subarray of size ‘k’.
        /// </summary>
        /// <param name="args"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int MaxSumSubArray(int[] args, int k)
        {
            var currentSum = 0;
            var globalSum = 0;
            for (int i = 0; i < args.Length; i++)
            {
                currentSum += args[i];
                if (i >= k - 1)
                {
                    globalSum = Math.Max(globalSum, currentSum);

                    currentSum -= args[(i + 1) - k];

                }
            }

            return globalSum;
        }

        
    }
}
