using BeetCode.Framework;
using System.Collections.Generic;

namespace BeetCode.Problems
{
	public class Problem543 : Problem
	{
		public override int Number => 543;
		public override string Title => "Diameter of Binary Tree";
		public override string Difficulty => "Easy";
		public override string Description =>
			"Given the root of a binary tree, return the length of the diameter of the tree.\n" +
			"\n" +
			"The diameter of a binary tree is the length of the longest path between any two nodes in a tree. This path may or may not pass through the root.\n" +
			"\n" +
			"The length of a path between two nodes is represented by the number of edges between them.\n" +
			"\n" +
			" \n" +
			"\n" +
			"Example 1:\n" +
			"\n" +
			"Input: root = [1,2,3,4,5]\n" +
			"Output: 3\n" +
			"Explanation: 3 is the length of the path [4,2,1,3] or [5,2,1,3].\n" +
			"\n" +
			"Example 2:\n" +
			"\n" +
			"Input: root = [1,2]\n" +
			"Output: 1\n" +
			"\n" +
			" \n" +
			"\n" +
			"Constraints:\n" +
			"\n" +
			"\t• The number of nodes in the tree is in the range [1, 10^4].\n" +
			"\n" +
			"\t• -100 <= Node.val <= 100";

		public override List<TestCase> GetTestCases()
		{
			return new List<TestCase>
			{
				new TestCase("Example 1",
					new object[] { CreateTree(new int?[] { 1, 2, 3, 4, 5 }) },
					3),

				new TestCase("Example 2",
					new object[] { CreateTree(new int?[] { 1, 2 }) },
					1),

				new TestCase("Single node",
					new object[] { CreateTree(new int?[] { 1 }) },
					0),

				// TODO: Add edge cases beyond LeetCode examples
			};
		}

		public override object ExecuteSolution(object[] inputs)
		{
			TreeNode? root = (TreeNode?)inputs[0];
			return new Solution().DiameterOfBinaryTree(root);
		}

		/**
		 * Definition for a binary tree node.
		 * public class TreeNode {
		 *     public int val;
		 *     public TreeNode left;
		 *     public TreeNode right;
		 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
		 *         this.val = val;
		 *         this.left = left;
		 *         this.right = right;
		 *     }
		 * }
		 */
		public class Solution
		{
			// YOUR SOLUTION GOES HERE
			public int DiameterOfBinaryTree(TreeNode? root)
			{
				throw new NotImplementedException();
			}
		}
	}
}
