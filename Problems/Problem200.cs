using BeetCode.Framework;
using System.Collections.Generic;

namespace BeetCode.Problems
{
	public class Problem200 : Problem
	{
		public override int Number => 200;
		public override string Title => "Number of Islands";
		public override string Difficulty => "Medium";
		public override string Description =>
			"Given an m x n 2D binary grid grid which represents a map of '1's (land) and '0's (water), return the number of islands.\n" +
			"\n" +
			"An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. You may assume all four edges of the grid are all surrounded by water.\n" +
			"\n" +
			" \n" +
			"\n" +
			"Example 1:\n" +
			"\n" +
			"Input: grid = [\n" +
			"  [\"1\",\"1\",\"1\",\"1\",\"0\"],\n" +
			"  [\"1\",\"1\",\"0\",\"1\",\"0\"],\n" +
			"  [\"1\",\"1\",\"0\",\"0\",\"0\"],\n" +
			"  [\"0\",\"0\",\"0\",\"0\",\"0\"]\n" +
			"]\n" +
			"Output: 1\n" +
			"\n" +
			"Example 2:\n" +
			"\n" +
			"Input: grid = [\n" +
			"  [\"1\",\"1\",\"0\",\"0\",\"0\"],\n" +
			"  [\"1\",\"1\",\"0\",\"0\",\"0\"],\n" +
			"  [\"0\",\"0\",\"1\",\"0\",\"0\"],\n" +
			"  [\"0\",\"0\",\"0\",\"1\",\"1\"]\n" +
			"]\n" +
			"Output: 3\n" +
			"\n" +
			" \n" +
			"\n" +
			"Constraints:\n" +
			"\n" +
			"\t• m == grid.length\n" +
			"\n" +
			"\t• n == grid[i].length\n" +
			"\n" +
			"\t• 1 <= m, n <= 300\n" +
			"\n" +
			"\t• grid[i][j] is '0' or '1'.";

		public override List<TestCase> GetTestCases()
		{
			return new List<TestCase>
			{
				new TestCase("Example 1",
					new object[] { new char[][]
					{
						new char[] { '1', '1', '1', '1', '0' },
						new char[] { '1', '1', '0', '1', '0' },
						new char[] { '1', '1', '0', '0', '0' },
						new char[] { '0', '0', '0', '0', '0' }
					} },
					1),

				new TestCase("Example 2",
					new object[] { new char[][]
					{
						new char[] { '1', '1', '0', '0', '0' },
						new char[] { '1', '1', '0', '0', '0' },
						new char[] { '0', '0', '1', '0', '0' },
						new char[] { '0', '0', '0', '1', '1' }
					} },
					3),
			};
		}

		public override object ExecuteSolution(object[] inputs)
		{
			char[][] grid = (char[][])inputs[0];
			return new Solution().NumIslands(grid);
		}

		public class Solution
		{
			// YOUR SOLUTION GOES HERE
			public int NumIslands(char[][] grid)
			{
				// TODO: Implement your solution
				throw new NotImplementedException();
			}
		}
	}
}
