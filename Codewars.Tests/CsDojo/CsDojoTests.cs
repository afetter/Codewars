using Others;
using Xunit;

namespace Tests.CsDojo
{
    public class CsDojoTests
    {
        [Fact]
        public void CountNodes()
        {
            Node head = new Node(1, new Node(3, new Node(10, null)));
            Assert.Equal(3, Others.CsDojo.CountNodes(head));
        }
    }
}
