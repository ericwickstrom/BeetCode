using BeetCode.Framework;
using System.Collections.Generic;

namespace BeetCode.Problems
{
	public class Problem412 : Problem
	{
		public override int Number => 412;
		public override string Title => "Fizz Buzz";
		public override string Difficulty => "Easy";
		public override string Description =>
			"Given an integer n, return a string array answer (1-indexed) where:\n\n" +
			"• answer[i] == \"FizzBuzz\" if i is divisible by 3 and 5.\n" +
			"• answer[i] == \"Fizz\" if i is divisible by 3.\n" +
			"• answer[i] == \"Buzz\" if i is divisible by 5.\n" +
			"• answer[i] == i (as a string) if none of the above conditions are true.\n\n" +
			"Example 1:\n" +
			"Input: n = 3\n" +
			"Output: [\"1\",\"2\",\"Fizz\"]\n\n" +
			"Example 2:\n" +
			"Input: n = 5\n" +
			"Output: [\"1\",\"2\",\"Fizz\",\"4\",\"Buzz\"]\n\n" +
			"Example 3:\n" +
			"Input: n = 15\n" +
			"Output: [\"1\",\"2\",\"Fizz\",\"4\",\"Buzz\",\"Fizz\",\"7\",\"8\",\"Fizz\",\"Buzz\",\"11\",\"Fizz\",\"13\",\"14\",\"FizzBuzz\"]\n\n" +
			"Constraints:\n" +
			"• 1 <= n <= 10^4";

		public override List<TestCase> GetTestCases()
		{
			return new List<TestCase>
			{
				new TestCase("Example 1",
					new object[] { 3 },
					new string[] { "1", "2", "Fizz" }),

				new TestCase("Example 2",
					new object[] { 5 },
					new string[] { "1", "2", "Fizz", "4", "Buzz" }),

				new TestCase("Example 3",
					new object[] { 15 },
					new string[] { "1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz", "11", "Fizz", "13", "14", "FizzBuzz" }),

				new TestCase("Single element",
					new object[] { 1 },
					new string[] { "1" }),

				new TestCase("Includes second FizzBuzz",
					new object[] { 30 },
					new string[] { "1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz", "11", "Fizz", "13", "14", "FizzBuzz", "16", "17", "Fizz", "19", "Buzz", "Fizz", "22", "23", "Fizz", "Buzz", "26", "Fizz", "28", "29", "FizzBuzz" })
			};
		}

		public override object ExecuteSolution(object[] inputs)
		{
			int n = (int)inputs[0];
			return FizzBuzz(n);
		}

		// YOUR SOLUTION GOES HERE
		public string[] FizzBuzz(int n)
		{
			// TODO: Implement your solution
			throw new NotImplementedException();
		}
	}
}
