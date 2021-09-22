using Educative;
using Newtonsoft.Json;
using System.Collections.Generic;
using Xunit;

namespace Tests.Educative
{
    public class DFSTests
    {

        [Fact]
        public void SumOfPathNumbers()
        {
            TreeNode root = new TreeNode(1,
            new TreeNode(0, new TreeNode(1, null, null), null),
            new TreeNode(1, new TreeNode(6, null, null), new TreeNode(5, null, null)));
            var result = DFS.FindAllTreePaths(root, 23);

            Assert.Equal(332, DFS.SumOfPathNumbers(root));

        }

        [Fact]
        public void FindAllTreePaths()
        {
            TreeNode root = new TreeNode(12,
            new TreeNode(7, new TreeNode(4, null, null), null),
            new TreeNode(1, new TreeNode(10, null, null), new TreeNode(5, null, null)));
            var result = DFS.FindAllTreePaths(root, 23);

            var obj1Str = JsonConvert.SerializeObject(
               new List<List<int>> {
                    new List<int>() { 12, 7, 4 },
                    new List<int>() { 12, 1, 10 },
                   }
               );
            var obj2Str = JsonConvert.SerializeObject(result);
            Assert.Equal(obj1Str, obj2Str);

        }

        [Fact]
        public void TreePathSum()
        {
            TreeNode root = new TreeNode(12,
            new TreeNode(7, new TreeNode(9, null, null), null),
            new TreeNode(1, new TreeNode(10, null, null), new TreeNode(5, null, null)));
            Assert.True(DFS.TreePathSum(root, 23));
            Assert.False(DFS.TreePathSum(root, 16));

        }
    }
}
