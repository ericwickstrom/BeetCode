using BeetCode.Framework;
using System.Collections.Generic;

namespace BeetCode.Problems
{
	public class Problem746 : Problem
	{
		public override int Number => 746;
		public override string Title => "Min Cost Climbing Stairs";
		public override string Difficulty => "Easy";
		public override string Description =>
			"You are given an integer array cost where cost[i] is the cost of i^th step on a staircase. Once you pay the cost, you can either climb one or two steps.\n" +
			"\n" +
			"You can either start from the step with index 0, or the step with index 1.\n" +
			"\n" +
			"Return the minimum cost to reach the top of the floor.\n" +
			"\n" +
			" \n" +
			"\n" +
			"Example 1:\n" +
			"\n" +
			"Input: cost = [10,15,20]\n" +
			"Output: 15\n" +
			"Explanation: You will start at index 1.\n" +
			"- Pay 15 and climb two steps to reach the top.\n" +
			"The total cost is 15.\n" +
			"\n" +
			"Example 2:\n" +
			"\n" +
			"Input: cost = [1,100,1,1,1,100,1,1,100,1]\n" +
			"Output: 6\n" +
			"Explanation: You will start at index 0.\n" +
			"- Pay 1 and climb two steps to reach index 2.\n" +
			"- Pay 1 and climb two steps to reach index 4.\n" +
			"- Pay 1 and climb two steps to reach index 6.\n" +
			"- Pay 1 and climb one step to reach index 7.\n" +
			"- Pay 1 and climb two steps to reach index 9.\n" +
			"- Pay 1 and climb one step to reach the top.\n" +
			"The total cost is 6.\n" +
			"\n" +
			" \n" +
			"\n" +
			"Constraints:\n" +
			"\n" +
			"\t• 2 <= cost.length <= 1000\n" +
			"\n" +
			"\t• 0 <= cost[i] <= 999";

		public override List<TestCase> GetTestCases()
		{
			return new List<TestCase>
			{
				new TestCase("Example 1",
					new object[] { new int[] { 10, 15, 20 } },
					15),

				new TestCase("Example 2",
					new object[] { new int[] { 1, 100, 1, 1, 1, 100, 1, 1, 100, 1 } },
					6),

				new TestCase("Minimum length two",
					new object[] { new int[] { 0, 0 } },
					0),

				new TestCase("All zeros",
					new object[] { new int[] { 0, 0, 0, 0 } },
					0),

				new TestCase("In: [1,100] Out: 1",
					new object[] { new int[] {1,100} },
					1)
			};
		}

		public override object ExecuteSolution(object[] inputs)
		{
			int[] cost = (int[])inputs[0];
			return new Solution().MinCostClimbingStairs(cost);
		}

		public class Solution
		{
			// YOUR SOLUTION GOES HERE
			public int MinCostClimbingStairs(int[] cost)
			{
				if(cost == null || cost.Length == 0) return 0;
				if(cost.Length == 1) return cost[0];
				if(cost.Length == 2) return Math.Min(cost[0], cost[1]);

				int[] dp = new int[cost.Length];
				dp[0] = cost[0];
				dp[1] = cost[1];

				for(int i = 2; i < dp.Length; i++){
					dp[i] = cost[i] + Math.Min(dp[i-1], dp[i-2]);
				}

				return Math.Min(dp[dp.Length-1], dp[dp.Length-2]);
			}
		}
	}
}
