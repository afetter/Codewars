using System;
namespace Educative
{
    public static class DFS
    {
        public static bool TreePathSum(TreeNode root, int sum)
        {
            if (root == null)
                return false;

            // if the current node is a leaf and its value is equal to the sum, we've found a path
            if (root.Val == sum && root.Left == null && root.Right == null)
                return true;

            // recursively call to traverse the left and right sub-tree
            // return true if any of the two recursive call return true
            return TreePathSum(root.Left, sum - root.Val) || TreePathSum(root.Right, sum - root.Val);
        }
    }
}
