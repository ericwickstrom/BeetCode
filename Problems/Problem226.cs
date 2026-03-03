using BeetCode.Framework;
using System.Collections.Generic;

namespace BeetCode.Problems
{
	public class Problem226 : Problem
	{
		public override int Number => 226;
		public override string Title => "Invert Binary Tree";
		public override string Difficulty => "Easy";
		public override string Description =>
			"Given the root of a binary tree, invert the tree, and return its root.\n" +
			"\n" +
			" \n" +
			"\n" +
			"Example 1:\n" +
			"\n" +
			"Input: root = [4,2,7,1,3,6,9]\n" +
			"Output: [4,7,2,9,6,3,1]\n" +
			"\n" +
			"Example 2:\n" +
			"\n" +
			"Input: root = [2,1,3]\n" +
			"Output: [2,3,1]\n" +
			"\n" +
			"Example 3:\n" +
			"\n" +
			"Input: root = []\n" +
			"Output: []\n" +
			"\n" +
			" \n" +
			"\n" +
			"Constraints:\n" +
			"\n" +
			"\t• The number of nodes in the tree is in the range [0, 100].\n" +
			"\n" +
			"\t• -100 <= Node.val <= 100";

		public override List<TestCase> GetTestCases()
		{
			return new List<TestCase>
			{
				new TestCase("Example 1",
					new object[] { CreateTree(new int?[] { 4, 2, 7, 1, 3, 6, 9 }) },
					CreateTree(new int?[] { 4, 7, 2, 9, 6, 3, 1 })),

				new TestCase("Example 2",
					new object[] { CreateTree(new int?[] { 2, 1, 3 }) },
					CreateTree(new int?[] { 2, 3, 1 })),

				new TestCase("Example 3",
					new object[] { CreateTree(new int?[] { }) },
					CreateTree(new int?[] { })),

				// TODO: Add edge cases beyond LeetCode examples
			};
		}

		public override object ExecuteSolution(object[] inputs)
		{
			TreeNode root = (TreeNode)inputs[0];
			return InvertTree(root);
		}

		// YOUR SOLUTION GOES HERE
		public TreeNode InvertTree(TreeNode root)
		{
			if(root == null) return null;
			TreeNode temp = root.left;
			root.left = root.right;
			root.right = temp;

			InvertTree(root.left);
			InvertTree(root.right);

			return root;
		}
	}
}
