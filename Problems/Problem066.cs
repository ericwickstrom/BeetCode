using BeetCode.Framework;
using System.Collections.Generic;

namespace BeetCode.Problems
{
	public class Problem066 : Problem
	{
		public override int Number => 66;
		public override string Title => "Plus One";
		public override string Difficulty => "Easy";
		public override string Description =>
			"You are given a large integer represented as an integer array digits, where each digits[i] is the i^th digit of the integer. The digits are ordered from most significant to least significant in left-to-right order. The large integer does not contain any leading 0's.\n" +
			"\n" +
			"Increment the large integer by one and return the resulting array of digits.\n" +
			"\n" +
			" \n" +
			"\n" +
			"Example 1:\n" +
			"\n" +
			"Input: digits = [1,2,3]\n" +
			"Output: [1,2,4]\n" +
			"Explanation: The array represents the integer 123.\n" +
			"Incrementing by one gives 123 + 1 = 124.\n" +
			"Thus, the result should be [1,2,4].\n" +
			"\n" +
			"Example 2:\n" +
			"\n" +
			"Input: digits = [4,3,2,1]\n" +
			"Output: [4,3,2,2]\n" +
			"Explanation: The array represents the integer 4321.\n" +
			"Incrementing by one gives 4321 + 1 = 4322.\n" +
			"Thus, the result should be [4,3,2,2].\n" +
			"\n" +
			"Example 3:\n" +
			"\n" +
			"Input: digits = [9]\n" +
			"Output: [1,0]\n" +
			"Explanation: The array represents the integer 9.\n" +
			"Incrementing by one gives 9 + 1 = 10.\n" +
			"Thus, the result should be [1,0].\n" +
			"\n" +
			" \n" +
			"\n" +
			"Constraints:\n" +
			"\n" +
			"\t• 1 <= digits.length <= 100\n" +
			"\n" +
			"\t• 0 <= digits[i] <= 9\n" +
			"\n" +
			"\t• digits does not contain any leading 0's.";

		public override List<TestCase> GetTestCases()
		{
			return new List<TestCase>
			{
				new TestCase("Example 1",
					new object[] { new int[] { 1, 2, 3 } },
					new int[] { 1, 2, 4 }),

				new TestCase("Example 2",
					new object[] { new int[] { 4, 3, 2, 1 } },
					new int[] { 4, 3, 2, 2 }),

				new TestCase("Example 3",
					new object[] { new int[] { 9 } },
					new int[] { 1, 0 }),

				// TODO: Add edge cases beyond LeetCode examples
			};
		}

		public override object ExecuteSolution(object[] inputs)
		{
			int[] digits = (int[])inputs[0];
			return PlusOne(digits);
		}

		// YOUR SOLUTION GOES HERE
		public int[] PlusOne(int[] digits)
		{
			throw new NotImplementedException();
		}
	}
}
