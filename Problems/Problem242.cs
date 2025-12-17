using BeetCode.Framework;
using System.Collections.Generic;

namespace BeetCode.Problems
{
    public class Problem242 : Problem
    {
        public override int Number => 242;
        public override string Title => "Valid Anagram";
        public override string Difficulty => "Easy";
        public override string Description =>
            "Given two strings s and t, return true if t is an anagram of s, and false otherwise.\n\n" +
            "An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, " +
            "typically using all the original letters exactly once.\n\n" +
            "Example 1:\n" +
            "Input: s = \"anagram\", t = \"nagaram\"\n" +
            "Output: true\n\n" +
            "Example 2:\n" +
            "Input: s = \"rat\", t = \"car\"\n" +
            "Output: false\n\n" +
            "Constraints:\n" +
            "• 1 <= s.length, t.length <= 5 * 10^4\n" +
            "• s and t consist of lowercase English letters.\n\n" +
            "Follow up: What if the inputs contain Unicode characters? How would you adapt your solution to such a case?";

        public override List<TestCase> GetTestCases()
        {
            return new List<TestCase>
            {
                new TestCase("Example 1 - Basic anagram",
                    new object[] { "anagram", "nagaram" },
                    true),

                new TestCase("Example 2 - Different letters",
                    new object[] { "rat", "car" },
                    false),

                new TestCase("Same string",
                    new object[] { "a", "a" },
                    true),

                new TestCase("Different lengths",
                    new object[] { "ab", "a" },
                    false),

                new TestCase("Empty strings",
                    new object[] { "", "" },
                    true),

                new TestCase("Single character - same",
                    new object[] { "z", "z" },
                    true),

                new TestCase("Single character - different",
                    new object[] { "a", "b" },
                    false),

                new TestCase("Multiple same characters",
                    new object[] { "aab", "aba" },
                    true),

                new TestCase("Multiple same characters - different counts",
                    new object[] { "aab", "aaa" },
                    false)
            };
        }

        public override object ExecuteSolution(object[] inputs)
        {
            return IsAnagram((string)inputs[0], (string)inputs[1]);
        }

        // YOUR SOLUTION GOES HERE
        public bool IsAnagram(string s, string t)
        {
            throw new NotImplementedException();
        }
    }
}