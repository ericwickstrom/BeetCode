using BeetCode.Framework;
using System.Collections.Generic;

namespace BeetCode.Problems
{
	public class Problem104 : Problem
	{
		public override int Number => 104;
		public override string Title => "Maximum Depth of Binary Tree";
		public override string Difficulty => "Easy";
		public override string Description =>
			"Given the root of a binary tree, return its maximum depth.\n" +
			"\n" +
			"A binary tree's maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.\n" +
			"\n" +
			"Example 1:\n" +
			"\n" +
			"Input: root = [3,9,20,null,null,15,7]\n" +
			"Output: 3\n" +
			"\n" +
			"Example 2:\n" +
			"\n" +
			"Input: root = [1,null,2]\n" +
			"Output: 2\n" +
			"\n" +
			" \n" +
			"\n" +
			"Constraints:\n" +
			"\n" +
			"\t• The number of nodes in the tree is in the range [0, 10^4].\n" +
			"\n" +
			"\t• -100 <= Node.val <= 100";

		public override List<TestCase> GetTestCases()
		{
			return new List<TestCase>
			{
				new TestCase("Example 1",
					new object[] { CreateTree(new int?[] { 3, 9, 20, null, null, 15, 7 }) },
					3),

				new TestCase("Example 2",
					new object[] { CreateTree(new int?[] { 1, null, 2 }) },
					2),

				new TestCase("Empty tree",
					new object[] { CreateTree(new int?[] { }) },
					0),

				new TestCase("Single node",
					new object[] { CreateTree(new int?[] { 1 }) },
					1),

				// TODO: Add edge cases beyond LeetCode examples
			};
		}

		public override object ExecuteSolution(object[] inputs)
		{
			TreeNode? root = (TreeNode?)inputs[0];
			return new Solution().MaxDepth(root);
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
			public int MaxDepth(TreeNode? root)
			{
				if(root == null) return 0;
				int l = 1 + MaxDepth(root.left);
				int r = 1 + MaxDepth(root.right);
				return l > r ? l : r;
			}
		}
	}
}
