using BeetCode.Framework;
using System.Collections.Generic;

namespace BeetCode.Problems
{
	public class Problem572 : Problem
	{
		public override int Number => 572;
		public override string Title => "Subtree of Another Tree";
		public override string Difficulty => "Easy";
		public override string Description =>
			"Given the roots of two binary trees root and subRoot, return true if there is a subtree of root with the same structure and node values of subRoot and false otherwise.\n" +
			"\n" +
			"A subtree of a binary tree tree is a tree that consists of a node in tree and all of this node's descendants. The tree tree could also be considered as a subtree of itself.\n" +
			"\n" +
			" \n" +
			"\n" +
			"Example 1:\n" +
			"\n" +
			"Input: root = [3,4,5,1,2], subRoot = [4,1,2]\n" +
			"Output: true\n" +
			"\n" +
			"Example 2:\n" +
			"\n" +
			"Input: root = [3,4,5,1,2,null,null,null,null,0], subRoot = [4,1,2]\n" +
			"Output: false\n" +
			"\n" +
			" \n" +
			"\n" +
			"Constraints:\n" +
			"\n" +
			"\t• The number of nodes in the root tree is in the range [1, 2000].\n" +
			"\n" +
			"\t• The number of nodes in the subRoot tree is in the range [1, 1000].\n" +
			"\n" +
			"\t• -10^4 <= root.val <= 10^4\n" +
			"\n" +
			"\t• -10^4 <= subRoot.val <= 10^4";

		public override List<TestCase> GetTestCases()
		{
			return new List<TestCase>
			{
				new TestCase("Example 1",
					new object[] { CreateTree(new int?[] { 3, 4, 5, 1, 2 }), CreateTree(new int?[] { 4, 1, 2 }) },
					true),

				new TestCase("Example 2",
					new object[] { CreateTree(new int?[] { 3, 4, 5, 1, 2, null, null, null, null, 0 }), CreateTree(new int?[] { 4, 1, 2 }) },
					false),

				new TestCase("Identical single node trees",
					new object[] { CreateTree(new int?[] { 1 }), CreateTree(new int?[] { 1 }) },
					true),

				new TestCase("subRoot larger than root",
					new object[] { CreateTree(new int?[] { 1 }), CreateTree(new int?[] { 1, 2 }) },
					false),

				new TestCase("Matching values but different structure",
					new object[] { CreateTree(new int?[] { 3, 4, 5, 1, 2 }), CreateTree(new int?[] { 4, 2, 1 }) },
					false),
			};
		}

		public override object ExecuteSolution(object[] inputs)
		{
			TreeNode? root = (TreeNode?)inputs[0];
			TreeNode? subRoot = (TreeNode?)inputs[1];
			return new Solution().IsSubtree(root, subRoot);
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
			public bool IsSubtree(TreeNode? root, TreeNode? subRoot)
			{
				throw new NotImplementedException();
			}
		}
	}
}
