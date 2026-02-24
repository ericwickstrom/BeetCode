using BeetCode.Framework;
using System.Collections.Generic;

namespace BeetCode.Problems
{
	public class Problem058 : Problem
	{
		public override int Number => 58;
		public override string Title => "Length of Last Word";
		public override string Difficulty => "Easy";
		public override string Description =>
			"Given a string s consisting of words and spaces, return the length of the last word in the string.\n\n" +
			"A word is a maximal substring consisting of non-space characters only.\n\n" +
			"Example 1:\n" +
			"Input: s = \"Hello World\"\n" +
			"Output: 5\n" +
			"Explanation: The last word is \"World\" with length 5.\n\n" +
			"Example 2:\n" +
			"Input: s = \"   fly me   to   the moon  \"\n" +
			"Output: 4\n" +
			"Explanation: The last word is \"moon\" with length 4.\n\n" +
			"Example 3:\n" +
			"Input: s = \"luffy is still joyboy\"\n" +
			"Output: 6\n" +
			"Explanation: The last word is \"joyboy\" with length 6.\n\n" +
			"Constraints:\n" +
			"• 1 <= s.length <= 10^4\n" +
			"• s consists of only English letters and spaces.\n" +
			"• There will be at least one word in s.";

		public override List<TestCase> GetTestCases()
		{
			return new List<TestCase>
			{
				new TestCase("Example 1",
					new object[] { "Hello World" },
					5),

				new TestCase("Example 2",
					new object[] { "   fly me   to   the moon  " },
					4),

				new TestCase("Example 3",
					new object[] { "luffy is still joyboy" },
					6),

				new TestCase("Single word",
					new object[] { "hello" },
					5),

				new TestCase("Single character",
					new object[] { "a" },
					1),

				new TestCase("Trailing spaces",
					new object[] { "day   " },
					3),

				new TestCase("Leading spaces single word",
					new object[] { "   word" },
					4)
			};
		}

		public override object ExecuteSolution(object[] inputs)
		{
			string s = (string)inputs[0];
			return LengthOfLastWord(s);
		}

		// YOUR SOLUTION GOES HERE
		public int LengthOfLastWord(string s)
		{
			// TODO: Implement your solution
			throw new NotImplementedException();
		}
	}
}
