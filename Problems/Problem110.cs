using BeetCode.Framework;
using System.Collections.Generic;

namespace BeetCode.Problems
{
	public class Problem110 : Problem
	{
		public override int Number => 110;
		public override string Title => "Balanced Binary Tree";
		public override string Difficulty => "Easy";
		public override string Description =>
			"Given a binary tree, determine if it is height-balanced.\n" +
			"\n" +
			" \n" +
			"\n" +
			"Example 1:\n" +
			"\n" +
			"Input: root = [3,9,20,null,null,15,7]\n" +
			"Output: true\n" +
			"\n" +
			"Example 2:\n" +
			"\n" +
			"Input: root = [1,2,2,3,3,null,null,4,4]\n" +
			"Output: false\n" +
			"\n" +
			"Example 3:\n" +
			"\n" +
			"Input: root = []\n" +
			"Output: true\n" +
			"\n" +
			" \n" +
			"\n" +
			"Constraints:\n" +
			"\n" +
			"\t• The number of nodes in the tree is in the range [0, 5000].\n" +
			"\n" +
			"\t• -10^4 <= Node.val <= 10^4";

		public override List<TestCase> GetTestCases()
		{
			return new List<TestCase>
			{
				new TestCase("Example 1",
					new object[] { CreateTree(new int?[] { 3, 9, 20, null, null, 15, 7 }) },
					true),

				new TestCase("Example 2",
					new object[] { CreateTree(new int?[] { 1, 2, 2, 3, 3, null, null, 4, 4 }) },
					false),

				new TestCase("Example 3",
					new object[] { CreateTree(new int?[] {  }) },
					true),

				// TODO: Add edge cases beyond LeetCode examples
			};
		}

		public override object ExecuteSolution(object[] inputs)
		{
			TreeNode? root = (TreeNode?)inputs[0];
			return new Solution().IsBalanced(root);
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
			public bool IsBalanced(TreeNode? root)
			{
				throw new NotImplementedException();
			}
		}
	}
}
