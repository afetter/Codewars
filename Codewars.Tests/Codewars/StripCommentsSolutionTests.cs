using System;
using Xunit;
using Codewars;


namespace Tests.Codewars
{
    public class StripCommentsSolutionTests
    {
        [Fact]
        public void StripComments()
        {
            Assert.Equal(
                    "apples, pears\ngrapes\nbananas",
                    StripCommentsSolution.StripComments("apples, pears # and bananas\ngrapes\nbananas !apples", new string[] { "#", "!" }));

            Assert.Equal("a\nc\nd", StripCommentsSolution.StripComments("a #b\nc\nd $e f g", new string[] { "#", "$" }));

        }
    }
}
