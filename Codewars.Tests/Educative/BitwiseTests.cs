using Educative;
using Xunit;

namespace Tests.Educative
{
    public class BitwiseTests
    {
        [Fact]
        public void FindSingleNumber()
        {
            Assert.Equal(4, Bitwise.FindSingleNumber(new int[] { 1, 2, 1 }));
        }
    }
}
