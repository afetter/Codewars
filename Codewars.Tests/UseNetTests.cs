using Xunit;

namespace Codewars.Tests
{
    public class UseNetTests
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal("ROT13 example.", UseNet.Rot13("EBG13 rknzcyr."));
        }
    }
}
