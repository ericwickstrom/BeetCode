using BeetCode.Framework;
using System.Collections.Generic;

namespace BeetCode.Problems
{
	public class Problem168 : Problem
	{
		public override int Number => 168;
		public override string Title => "Excel Sheet Column Title";
		public override string Difficulty => "Easy";
		public override string Description =>
			"Given an integer columnNumber, return its corresponding column title as it appears in an Excel sheet.\n" +
			"\n" +
			"For example:\n" +
			"\n" +
			"A -> 1\n" +
			"B -> 2\n" +
			"C -> 3\n" +
			"...\n" +
			"Z -> 26\n" +
			"AA -> 27\n" +
			"AB -> 28 \n" +
			"...\n" +
			"\n" +
			" \n" +
			"\n" +
			"Example 1:\n" +
			"\n" +
			"Input: columnNumber = 1\n" +
			"Output: \"A\"\n" +
			"\n" +
			"Example 2:\n" +
			"\n" +
			"Input: columnNumber = 28\n" +
			"Output: \"AB\"\n" +
			"\n" +
			"Example 3:\n" +
			"\n" +
			"Input: columnNumber = 701\n" +
			"Output: \"ZY\"\n" +
			"\n" +
			" \n" +
			"\n" +
			"Constraints:\n" +
			"\n" +
			"\t• 1 <= columnNumber <= 2^31 - 1";

		public override List<TestCase> GetTestCases()
		{
			return new List<TestCase>
			{
				new TestCase("Example 1",
					new object[] { /* TODO: 1 */ },
					null /* TODO: &quot;A&quot; */),

				new TestCase("Example 2",
					new object[] { /* TODO: 28 */ },
					null /* TODO: &quot;AB&quot; */),

				new TestCase("Example 3",
					new object[] { /* TODO: 701 */ },
					null /* TODO: &quot;ZY&quot; */),

				// TODO: Add edge cases beyond LeetCode examples
			};
		}

		public override object ExecuteSolution(object[] inputs)
		{
			int columnNumber = (int)inputs[0];
			return ConvertToTitle(columnNumber);
		}

		// YOUR SOLUTION GOES HERE
		public string ConvertToTitle(int columnNumber)
		{
			throw new NotImplementedException();
		}
	}
}
