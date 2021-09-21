using System;
using System.Collections.Generic;
using Educative;
using Newtonsoft.Json;
using Xunit;

namespace Tests.Educative
{
    public class BFSTests
    {
        [Fact]
        public void MinimumBinaryTreeDepth()
        {
            TreeNode root = new TreeNode(12,
                new TreeNode(7, new TreeNode(9, null, null), null),
                new TreeNode(1, new TreeNode(10, null, null), new TreeNode(5, null, null)));
            Assert.Equal(3, BFS.MinimumBinaryTreeDepth(root));

        }
        [Fact]
        public void ReverseLevelOrderTraversal()
        {
            TreeNode root = new TreeNode(12,
                new TreeNode(7, new TreeNode(9, null, null), null),
                new TreeNode(1, new TreeNode(10, null, null), new TreeNode(5, null, null)));
            List<List<int>> result = BFS.ReverseLevelOrderTraversal(root);

            var obj1Str = JsonConvert.SerializeObject(
                new List<List<int>> {
                    new List<int>() { 9,10,5 },
                    new List<int>() { 7,1 },
                    new List<int>() { 12 },
                    }
                );
            var obj2Str = JsonConvert.SerializeObject(result);
            Assert.Equal(obj1Str, obj2Str);
        }

        [Fact]
        public void LevelOrderTransversal()
        {
            TreeNode root = new TreeNode(12,
                new TreeNode(7, new TreeNode(9, null, null), null),
                new TreeNode(1, new TreeNode(10, null, null), new TreeNode(5, null, null)));
            List<List<int>> result = BFS.LevelOrderTranversal(root);

            var obj1Str = JsonConvert.SerializeObject(
                new List<List<int>> {
                    new List<int>() { 12 },
                    new List<int>() { 7,1 },
                    new List<int>() { 9,10,5 },
                    }
                );
            var obj2Str = JsonConvert.SerializeObject(result);
            Assert.Equal(obj1Str, obj2Str);
        }
    }
}
