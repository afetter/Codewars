using System;
using Codewars;
using Xunit;

namespace Tests.Codewars
{
    public class AverageSumTests
    {
        [Fact]
        public void Test1()
        {
            var x = AverageSum.GetAverage(new int[] {1,3,2,6,-1,4,1,8,2 }, 5);
            Assert.Equal("2.2,2.8,2.4,3.6,2.8", string.Join(",", x));
        }
    }
}
