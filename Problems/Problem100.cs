using BeetCode.Framework;
using System.Collections.Generic;

namespace BeetCode.Problems
{
	public class Problem100 : Problem
	{
		public override int Number => 100;
		public override string Title => "Same Tree";
		public override string Difficulty => "Easy";
		public override string Description =>
			"Given the roots of two binary trees p and q, write a function to check if they are the same or not.\n" +
			"\n" +
			"Two binary trees are considered the same if they are structurally identical, and the nodes have the same value.\n" +
			"\n" +
			"Example 1:\n" +
			"\n" +
			"Input: p = [1,2,3], q = [1,2,3]\n" +
			"Output: true\n" +
			"\n" +
			"Example 2:\n" +
			"\n" +
			"Input: p = [1,2], q = [1,null,2]\n" +
			"Output: false\n" +
			"\n" +
			"Example 3:\n" +
			"\n" +
			"Input: p = [1,2,1], q = [1,1,2]\n" +
			"Output: false\n" +
			"\n" +
			"Constraints:\n" +
			"\n" +
			"\t• The number of nodes in both trees is in the range [0, 100].\n" +
			"\t• -10^4 <= Node.val <= 10^4";

		public override List<TestCase> GetTestCases()
		{
			return new List<TestCase>
			{
				new TestCase("Example 1 - identical trees",
					new object[] { CreateTree(new int?[] { 1, 2, 3 }), CreateTree(new int?[] { 1, 2, 3 }) },
					true),

				new TestCase("Example 2 - different structure",
					new object[] { CreateTree(new int?[] { 1, 2 }), CreateTree(new int?[] { 1, null, 2 }) },
					false),

				new TestCase("Example 3 - different values",
					new object[] { CreateTree(new int?[] { 1, 2, 1 }), CreateTree(new int?[] { 1, 1, 2 }) },
					false),

				new TestCase("Both empty",
					new object[] { CreateTree(new int?[] { }), CreateTree(new int?[] { }) },
					true),

				new TestCase("One empty one not",
					new object[] { CreateTree(new int?[] { 1 }), CreateTree(new int?[] { }) },
					false),

				new TestCase("Single node same value",
					new object[] { CreateTree(new int?[] { 42 }), CreateTree(new int?[] { 42 }) },
					true),

				new TestCase("Single node different value",
					new object[] { CreateTree(new int?[] { 1 }), CreateTree(new int?[] { 2 }) },
					false),
			};
		}

		public override object ExecuteSolution(object[] inputs)
		{
			return IsSameTree((TreeNode?)inputs[0], (TreeNode?)inputs[1]);
		}

		// YOUR SOLUTION GOES HERE
		public bool IsSameTree(TreeNode? p, TreeNode? q)
		{
			if(p == null && q == null) return true;
			if((p == null && q != null) || (p != null && q == null))  return false;
			if(p.val != q.val) return false;

			return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
		}
	}
}
