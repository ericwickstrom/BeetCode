using BeetCode.Framework;
using System.Collections.Generic;

namespace BeetCode.Problems
{
	public class Problem070 : Problem
	{
		public override int Number => 70;
		public override string Title => "Climbing Stairs";
		public override string Difficulty => "Easy";
		public override string Description =>
			"You are climbing a staircase. It takes n steps to reach the top.\n" +
			"\n" +
			"Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?\n" +
			"\n" +
			" \n" +
			"\n" +
			"Example 1:\n" +
			"\n" +
			"Input: n = 2\n" +
			"Output: 2\n" +
			"Explanation: There are two ways to climb to the top.\n" +
			"1. 1 step + 1 step\n" +
			"2. 2 steps\n" +
			"\n" +
			"Example 2:\n" +
			"\n" +
			"Input: n = 3\n" +
			"Output: 3\n" +
			"Explanation: There are three ways to climb to the top.\n" +
			"1. 1 step + 1 step + 1 step\n" +
			"2. 1 step + 2 steps\n" +
			"3. 2 steps + 1 step\n" +
			"\n" +
			" \n" +
			"\n" +
			"Constraints:\n" +
			"\n" +
			"\t• 1 <= n <= 45";

		public override List<TestCase> GetTestCases()
		{
			return new List<TestCase>
			{
				new TestCase("Example 1",
					new object[] { 2 },
					2),

				new TestCase("Example 2",
					new object[] { 3 },
					3),

				new TestCase("Single step",
					new object[] { 1 },
					1),

				new TestCase("Larger n",
					new object[] { 10 },
					89),
			};
		}

		public override object ExecuteSolution(object[] inputs)
		{
			int n = (int)inputs[0];
			return new Solution().ClimbStairs(n);
		}

		public class Solution
		{
			// YOUR SOLUTION GOES HERE
			public int ClimbStairs(int n)
			{
				if(n <= 0) return 0;
				int prev = 0;
				int curr = 1;

				for(int i = 1; i <= n; i++)
				{
					int next = prev + curr;
					prev = curr;
					curr = next;
				}

				return curr;
			}
		}
	}
}
