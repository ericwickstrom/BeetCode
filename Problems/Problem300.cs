using BeetCode.Framework;
using System.Collections.Generic;

namespace BeetCode.Problems
{
	public class Problem300 : Problem
	{
		public override int Number => 300;
		public override string Title => "Longest Increasing Subsequence";
		public override string Difficulty => "Medium";
		public override string Description =>
			"Given an integer array nums, return the length of the longest strictly increasing subsequence.\n" +
			"\n" +
			" \n" +
			"\n" +
			"Example 1:\n" +
			"\n" +
			"Input: nums = [10,9,2,5,3,7,101,18]\n" +
			"Output: 4\n" +
			"Explanation: The longest increasing subsequence is [2,3,7,101], therefore the length is 4.\n" +
			"\n" +
			"Example 2:\n" +
			"\n" +
			"Input: nums = [0,1,0,3,2,3]\n" +
			"Output: 4\n" +
			"\n" +
			"Example 3:\n" +
			"\n" +
			"Input: nums = [7,7,7,7,7,7,7]\n" +
			"Output: 1\n" +
			"\n" +
			" \n" +
			"\n" +
			"Constraints:\n" +
			"\n" +
			"\t• 1 <= nums.length <= 2500\n" +
			"\n" +
			"\t• -10^4 <= nums[i] <= 10^4\n" +
			"\n" +
			" \n" +
			"\n" +
			"Follow up: Can you come up with an algorithm that runs in O(n log(n)) time complexity?";

		public override List<TestCase> GetTestCases()
		{
			return new List<TestCase>
			{
				// Input: nums = [10,9,2,5,3,7,101,18]
				// Expected output: 4
				new TestCase("Example 1",
					new object[] { /* TODO */ },
					null /* TODO */),

				// Input: nums = [0,1,0,3,2,3]
				// Expected output: 4
				new TestCase("Example 2",
					new object[] { /* TODO */ },
					null /* TODO */),

				// Input: nums = [7,7,7,7,7,7,7]
				// Expected output: 1
				new TestCase("Example 3",
					new object[] { /* TODO */ },
					null /* TODO */),

				// TODO: Add edge cases beyond LeetCode examples
			};
		}

		public override object ExecuteSolution(object[] inputs)
		{
			// TODO: Cast inputs and call your solution method
			throw new NotImplementedException();
		}

		// YOUR SOLUTION GOES HERE
		// TODO: Add your solution method
		// public ReturnType MethodName(params)
		// {
		//     throw new NotImplementedException();
		// }
	}
}
