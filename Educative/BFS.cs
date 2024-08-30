using System;
using System.Collections.Generic;
using System.Linq;

namespace Educative
{
    public static class BFS
    {
        /// <summary>
        /// Find the minimum depth of a binary tree. The minimum depth is the
        /// number of nodes along the shortest path from the root node to the
        /// nearest leaf node.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static int MinimumBinaryTreeDepth(TreeNode root)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            var level = 0;
            while (queue.Count != 0)
            {
                level++;
                int levelSize = queue.Count;
                for (int i = 0; i < levelSize; i++)
                {
                    TreeNode currentNode = queue.Dequeue();

                    if (currentNode.Left == null && currentNode.Right == null)
                        return level;

                    if (currentNode.Left != null)
                        queue.Enqueue(currentNode.Left);
                    if (currentNode.Right != null)
                        queue.Enqueue(currentNode.Right);


                }
            }

            return level;
        }

        /// <summary>
        /// Given a binary tree, populate an array to represent its level-by-level
        /// traversal in reverse order, i.e., the lowest level comes first.
        /// You should populate the values of all nodes in each level from left
        /// to right in separate sub-arrays.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static List<List<int>> ReverseLevelOrderTraversal(TreeNode root)
        {
            var result = new List<List<int>>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while(queue.Count != 0)
            {
                int levelSize = queue.Count;
                List<int> currentLevel = new List<int>();
                for (int i = 0; i < levelSize; i++)
                {
                    TreeNode currentNode = queue.Dequeue();
                    // add the node to the current level
                    currentLevel.Add(currentNode.Val);
                    // insert the children of current node in the queue
                    if (currentNode.Left != null)
                        queue.Enqueue(currentNode.Left);
                    if (currentNode.Right != null)
                        queue.Enqueue(currentNode.Right);
                }
                result.Insert(0, currentLevel);
            }

            return result;
        }
        /// <summary>
        /// Given a binary tree, populate an array to represent its level-by-level
        /// traversal. You should populate the values of all nodes of each level
        /// from left to right in separate sub-arrays.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static List<List<int>> LevelOrderTranversal(TreeNode root)
        {
            var result = new List<List<int>>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while(queue.Count != 0)
            {
                int levelSize = queue.Count;
                List<int> currentLevel = new List<int>();
                for (int i = 0; i < levelSize; i++)
                {
                    TreeNode currentNode = queue.Dequeue();
                    // add the node to the current level
                    currentLevel.Add(currentNode.Val);
                    // insert the children of current node in the queue
                    if (currentNode.Left != null)
                        queue.Enqueue(currentNode.Left);
                    if (currentNode.Right != null)
                        queue.Enqueue(currentNode.Right);
                }
                result.Add(currentLevel);
            }

            return result;
        }
    }

    
    public class TreeNode
    {
        public int Val { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }

        public TreeNode(int val, TreeNode left, TreeNode right)
        {
            Val = val;
            Left = left;
            Right = right;
        }
    }
}
