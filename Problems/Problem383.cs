using BeetCode.Framework;
using System.Collections.Generic;

namespace BeetCode.Problems
{
    public class Problem383 : Problem
    {
        public override int Number => 383;
        public override string Title => "Ransom Note";
        public override string Difficulty => "Easy";
        public override string Description => 
            "Given two strings ransomNote and magazine, return true if ransomNote can be constructed by using the letters from magazine and false otherwise.\n\n" +
            "Each letter in magazine can only be used once in ransomNote.\n\n" +
            "Example 1:\n" +
            "Input: ransomNote = \"a\", magazine = \"b\"\n" +
            "Output: false\n\n" +
            "Example 2:\n" +
            "Input: ransomNote = \"aa\", magazine = \"ab\"\n" +
            "Output: false\n\n" +
            "Example 3:\n" +
            "Input: ransomNote = \"aa\", magazine = \"aab\"\n" +
            "Output: true\n\n" +
            "Constraints:\n" +
            "• 1 <= ransomNote.length, magazine.length <= 10^5\n" +
            "• ransomNote and magazine consist of lowercase English letters.";

        public override List<TestCase> GetTestCases()
        {
            return new List<TestCase>
            {
                new TestCase("Example 1", 
                    new object[] { "a", "b" }, 
                    false),
                
                new TestCase("Example 2", 
                    new object[] { "aa", "ab" }, 
                    false),
                
                new TestCase("Example 3", 
                    new object[] { "aa", "aab" }, 
                    true),

                new TestCase("Empty ransom note", 
                    new object[] { "", "abc" }, 
                    true),

                new TestCase("Exact match", 
                    new object[] { "abc", "abc" }, 
                    true),

                new TestCase("Rearranged letters", 
                    new object[] { "abc", "bac" }, 
                    true),

                new TestCase("Not enough letters", 
                    new object[] { "aab", "baa" }, 
                    true),

                new TestCase("Missing letter", 
                    new object[] { "abc", "ab" }, 
                    false),

                new TestCase("Complex case", 
                    new object[] { "aabbc", "aaabbbbcc" }, 
                    true),

                new TestCase("Insufficient duplicates", 
                    new object[] { "aaa", "aa" }, 
                    false)
            };
        }

        public override object ExecuteSolution(object[] inputs)
        {
            return CanConstruct((string)inputs[0], (string)inputs[1]);
        }

        // YOUR SOLUTION GOES HERE
        public bool CanConstruct(string ransomNote, string magazine)
        {
            // TODO: Implement your solution
            throw new NotImplementedException();
        }
    }
}