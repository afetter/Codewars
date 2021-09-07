using System;
using Xunit;

namespace Codewars.Tests
{
    public class MaximumSubarrayTests
    {
        [Fact]
        public void Test0()
        {
            Assert.Equal(0, MaximumSubarray.MaxSequence(new int[0]));
        }

        [Fact]
        public void Test1()
        {
            Assert.Equal(6, MaximumSubarray.MaxSequence(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }));
        }
    }
}
