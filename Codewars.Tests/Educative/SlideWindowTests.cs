using System;
using Educative;
using Xunit;

namespace Tests.Educative
{
    public class SlideWindowTests
    {
        [Fact]
        public void MinimumWindowSubstring()
        {
            Assert.Equal("abdec", SlideWindow.MinimumWindowSubstring("aabdec", "abc"));
            Assert.Equal("bca", SlideWindow.MinimumWindowSubstring("abdbca", "abc"));
            Assert.Equal("", SlideWindow.MinimumWindowSubstring("adcad", "abc"));
        }

        [Fact]
        public void StringAnagrams()
        {
            Assert.Equal("1,2", string.Join(",", SlideWindow.StringAnagrams("ppqp", "pq")));
            Assert.Equal("2,3,4", string.Join(",", SlideWindow.StringAnagrams("abbcabc", "abc")));
        }

        [Fact]
        public void StringPermutation()
        {
            Assert.True(SlideWindow.StringPermutation("oidbcaf", "abc"));
            Assert.False(SlideWindow.StringPermutation("odicf", "dc"));
            Assert.True(SlideWindow.StringPermutation("bcdxabcdy", "bcdyabcdx"));
            Assert.True(SlideWindow.StringPermutation("aaacb", "abc"));
        }

        [Fact]
        public void ReplacingOnes()
        {
            Assert.Equal(6, SlideWindow.ReplacingOnes(new int[] { 0, 1, 1, 0, 0, 0, 1, 1, 0, 1, 1 }, 2));
            Assert.Equal(9, SlideWindow.ReplacingOnes(new int[] { 0, 1, 0, 0, 1, 1, 0, 1, 1, 0, 0, 1, 1 }, 3));
        }

        [Fact]
        public void CharacterReplacement()
        {
            Assert.Equal(5, SlideWindow.CharacterReplacement("aabccbb", 2));
            Assert.Equal(4, SlideWindow.CharacterReplacement("abbcb", 1));
            Assert.Equal(3, SlideWindow.CharacterReplacement("abccde", 1));
        }

        [Fact]
        public void NoRepeatSubstring()
        {
            Assert.Equal(3, SlideWindow.NoRepeatSubstring("aabccbb"));
            Assert.Equal(2, SlideWindow.NoRepeatSubstring("abbbb"));
            Assert.Equal(3, SlideWindow.NoRepeatSubstring("abccde"));

        }

        [Fact]
        public void MaxFruitCountOf2Types()
        {
            Assert.Equal(3, SlideWindow.MaxFruitCountOf2Types(new char[] { 'A', 'B', 'C', 'A', 'C' }));
            Assert.Equal(5, SlideWindow.MaxFruitCountOf2Types(new char[] { 'A', 'B', 'C', 'B', 'B', 'C' }));

        }

        [Fact]
        public void LongestSubstringKDistinct()
        {
            Assert.Equal(4, SlideWindow.LongestSubstringKDistinct("araaci", 2));
            Assert.Equal(2, SlideWindow.LongestSubstringKDistinct("araaci", 1));
            Assert.Equal(5, SlideWindow.LongestSubstringKDistinct("cbbebi", 3));
            Assert.Equal(6, SlideWindow.LongestSubstringKDistinct("cbbebi", 10));

        }

        [Fact]
        public void MaxSumSubArray()
        {
            Assert.Equal(9, SlideWindow.MaxSumSubArray(new int[] { 2, 1, 5, 1, 3, 2 }, 3));
            Assert.Equal(7, SlideWindow.MaxSumSubArray(new int[] { 2, 3, 4, 1, 5 }, 2));

        }

        [Fact]
        public void MinSubArray()
        {
            Assert.Equal(2, SlideWindow.MinSubArray(7, new int[] { 2, 1, 5, 2, 3, 2 }));
            Assert.Equal(1, SlideWindow.MinSubArray(7, new int[] { 2, 1, 5, 2, 8 }));

        }
    }
}
