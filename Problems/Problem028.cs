using BeetCode.Framework;
using System.Collections.Generic;

namespace BeetCode.Problems
{
	public class Problem028 : Problem
	{
		public override int Number => 28;
		public override string Title => "Find the Index of the First Occurrence in a String";
		public override string Difficulty => "Easy";
		public override string Description =>
			"Given two strings needle and haystack, return the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack.\n\n" +
			"Example 1:\n" +
			"Input: haystack = \"sadbutsad\", needle = \"sad\"\n" +
			"Output: 0\n" +
			"Explanation: \"sad\" occurs at index 0 and 6. The first occurrence is at index 0, so we return 0.\n\n" +
			"Example 2:\n" +
			"Input: haystack = \"leetcode\", needle = \"leeto\"\n" +
			"Output: -1\n" +
			"Explanation: \"leeto\" did not occur in \"leetcode\", so we return -1.\n\n" +
			"Constraints:\n" +
			"• 1 <= haystack.length, needle.length <= 10^4\n" +
			"• haystack and needle consist of only lowercase English characters.";

		public override List<TestCase> GetTestCases()
		{
			return new List<TestCase>
			{
				new TestCase("Example 1",
					new object[] { "sadbutsad", "sad" },
					0),

				new TestCase("Example 2",
					new object[] { "leetcode", "leeto" },
					-1),

				new TestCase("Needle at end",
					new object[] { "hello", "lo" },
					3),

				new TestCase("Exact match",
					new object[] { "abc", "abc" },
					0),

				new TestCase("Single character match",
					new object[] { "a", "a" },
					0),

				new TestCase("Single character no match",
					new object[] { "a", "b" },
					-1),

				new TestCase("Needle longer than haystack",
					new object[] { "ab", "abc" },
					-1)
			};
		}

		public override object ExecuteSolution(object[] inputs)
		{
			string haystack = (string)inputs[0];
			string needle = (string)inputs[1];
			return StrStr(haystack, needle);
		}

		// YOUR SOLUTION GOES HERE
		public int StrStr(string haystack, string needle)
		{
			return -1;
		}
	}
}
