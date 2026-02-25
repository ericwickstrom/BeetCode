using BeetCode.Framework;
using System.Collections.Generic;

namespace BeetCode.Problems
{
	public class Problem414 : Problem
	{
		public override int Number => 414;
		public override string Title => "Third Maximum Number";
		public override string Difficulty => "Easy";
		public override string Description =>
			"Given an integer array nums, return the third distinct maximum number in this array.\n" +
			"If the third maximum does not exist, return the maximum number.\n\n" +
			"Example 1:\n" +
			"Input: nums = [3,2,1]\n" +
			"Output: 1\n" +
			"Explanation: The first distinct maximum is 3.\n" +
			"The second distinct maximum is 2.\n" +
			"The third distinct maximum is 1.\n\n" +
			"Example 2:\n" +
			"Input: nums = [1,2]\n" +
			"Output: 2\n" +
			"Explanation: The first distinct maximum is 2.\n" +
			"The second distinct maximum is 1.\n" +
			"The third distinct maximum does not exist, so the maximum (2) is returned.\n\n" +
			"Example 3:\n" +
			"Input: nums = [2,2,3,1]\n" +
			"Output: 1\n" +
			"Explanation: The first distinct maximum is 3.\n" +
			"The second distinct maximum is 2.\n" +
			"The third distinct maximum is 1.\n\n" +
			"Constraints:\n" +
			"• 1 <= nums.length <= 10^4\n" +
			"• -2^31 <= nums[i] <= 2^31 - 1";

		public override List<TestCase> GetTestCases()
		{
			return new List<TestCase>
			{
				new TestCase("Example 1",
					new object[] { new int[] { 3, 2, 1 } },
					1),

				new TestCase("Example 2",
					new object[] { new int[] { 1, 2 } },
					2),

				new TestCase("Example 3",
					new object[] { new int[] { 2, 2, 3, 1 } },
					1),

				new TestCase("All duplicates",
					new object[] { new int[] { 5, 5, 5 } },
					5),

				new TestCase("Negative numbers",
					new object[] { new int[] { 1, -2, -3 } },
					-3),
			};
		}

		public override object ExecuteSolution(object[] inputs)
		{
			int[] nums = (int[])inputs[0];
			return ThirdMax(nums);
		}

		// YOUR SOLUTION GOES HERE
		public int ThirdMax(int[] nums)
		{
			throw new System.NotImplementedException();
		}
	}
}
