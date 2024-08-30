using System;
using System.Collections.Generic;
using System.Linq;

namespace Educative
{
    public static class DFS
    {
        public static int SumOfPathNumbers(TreeNode root)
        {
            return findPathsRecursive(root, 0);

            int findPathsRecursive(TreeNode currentNode, int sum)
            {
                if (currentNode == null)
                    return 0;

                // add the current node to the path
                sum += currentNode.Val;

                // if the current node is a leaf and its value is equal to sum, save the current path
                if (currentNode.Left == null && currentNode.Right == null)
                {
                    return sum;
                    //currentPath = new List<int>();
                }

                // traverse the left sub-tree
                return findPathsRecursive(currentNode.Left, sum) + findPathsRecursive(currentNode.Right, sum);

            }
        }
        /// <summary>
        /// Given a binary tree and a number ‘S’, find all paths from root-to-leaf 
        /// such that the sum of all the node values of each path equals ‘S’.
        /// </summary>
        /// <param name="root"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        public static List<List<int>> FindAllTreePaths(TreeNode root, int sum)
        {
            var result = new List<List<int>>();
            var current = new List<int>();
            findPathsRecursive(root, sum, current, result);
            return result;

            void findPathsRecursive(TreeNode currentNode, int sum, List<int> currentPath,
            List<List<int>> allPaths)
            {
                if (currentNode == null)
                    return;

                // add the current node to the path
                currentPath.Add(currentNode.Val);

                // if the current node is a leaf and its value is equal to sum, save the current path
                if (currentNode.Val == sum && currentNode.Left == null && currentNode.Right == null)
                {
                    allPaths.Add(currentPath);
                    //currentPath = new List<int>();
                }
                else
                {
                    // traverse the left sub-tree
                    findPathsRecursive(currentNode.Left, sum - currentNode.Val, currentPath, allPaths);
                    // traverse the right sub-tree
                    findPathsRecursive(currentNode.Right, sum - currentNode.Val, currentPath, allPaths);
                }

                currentPath.Remove(currentPath.Last());
            }
        }
        /// <summary>
        /// Given a binary tree and a number ‘S’, find if the tree has a path from root-to-leaf such that 
        /// the sum of all the node values of that path equals ‘S’.
        /// </summary>
        /// <param name="root"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
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

        // 8
      static int maxSum = 0;
     static void MaxFromRootToLeaf(Node node, int sum) {
        if (node == null) return;
		if (node.left == null && node.right == null)
		{
			maxSum = Math.Max(maxSum, sum + node.key);
		}
	   MaxFromRootToLeaf(node.left, sum + node.key);
	   MaxFromRootToLeaf(node.right, sum + node.key);
    }
	
	 static int MinValue = 1000;
	 static int MaxValue = 0;
     static void MinAndMaxValue(Node node) {
        if (node == null) return;

			MinValue = Math.Min(MinValue, node.key);
			MaxValue = Math.Max(MaxValue, node.key);
	
	   MinAndMaxValue(node.left);
	   MinAndMaxValue(node.right);
    }
	
	//   124
	// + 125
	// +  13
	// = 262
	static int sunRootToLeaf = 0;
	 static void SumRootToLeaf(Node node, int i) {
        if (node == null) return;
		if (node.left == null && node.right == null)
		{
			sunRootToLeaf += (i * 10 + node.key);
		}
	   SumRootToLeaf(node.left, i * 10 + node.key);
	   SumRootToLeaf(node.right, i * 10 + node.key);
    }

    public static void Main()
    {
        Node root = new Node(1);
        root.left = new Node(2);
        root.right = new Node(3);
        root.left.left = new Node(4);
        root.left.right = new Node(5);
		//root.left.left.left = new Node(4);
		//MaxFromRootToLeaf(root, 0);
        //Console.WriteLine(maxSum);
		//SumRootToLeaf(root, 0);
		MinAndMaxValue(root);
		Console.WriteLine(MinValue);
		Console.WriteLine(MaxValue);
    }
    }
}
