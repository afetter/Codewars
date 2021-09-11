using Xunit;
using Codewars;


namespace Tests.Codewars
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
