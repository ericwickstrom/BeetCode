using BeetCode.Framework;
using System.Collections.Generic;

namespace BeetCode.Problems
{
    public class Problem014 : Problem
    {
        public override int Number => 14;
        public override string Title => "Longest Common Prefix";
        public override string Difficulty => "Easy";
        public override string Description => 
            "Write a function to find the longest common prefix string amongst an array of strings.\n\n" +
            "If there is no common prefix, return an empty string \"\".\n\n" +
            "Example 1:\n" +
            "Input: strs = [\"flower\",\"flow\",\"flight\"]\n" +
            "Output: \"fl\"\n\n" +
            "Example 2:\n" +
            "Input: strs = [\"dog\",\"racecar\",\"car\"]\n" +
            "Output: \"\"\n" +
            "Explanation: There is no common prefix among the input strings.\n\n" +
            "Constraints:\n" +
            "• 1 <= strs.length <= 200\n" +
            "• 0 <= strs[i].length <= 200\n" +
            "• strs[i] consists of only lowercase English letters.";

        public override List<TestCase> GetTestCases()
        {
            return new List<TestCase>
            {
                new TestCase("Example 1 - Common prefix", 
                    new object[] { new string[] { "flower", "flow", "flight" } }, 
                    "fl"),
                
                new TestCase("Example 2 - No common prefix", 
                    new object[] { new string[] { "dog", "racecar", "car" } }, 
                    ""),
                
                new TestCase("Single string", 
                    new object[] { new string[] { "single" } }, 
                    "single"),

                new TestCase("All same strings", 
                    new object[] { new string[] { "test", "test", "test" } }, 
                    "test"),

                new TestCase("Empty string in array", 
                    new object[] { new string[] { "abc", "", "ab" } }, 
                    ""),

                new TestCase("One character common", 
                    new object[] { new string[] { "a", "ab", "abc" } }, 
                    "a"),

                new TestCase("No common at all", 
                    new object[] { new string[] { "abc", "def", "ghi" } }, 
                    ""),

                new TestCase("Two identical strings", 
                    new object[] { new string[] { "hello", "hello" } }, 
                    "hello"),

                new TestCase("Prefix is shortest string", 
                    new object[] { new string[] { "ab", "abc", "abcd" } }, 
                    "ab"),

                new TestCase("Long common prefix", 
                    new object[] { new string[] { "interview", "internet", "internal" } }, 
                    "inte"),

                new TestCase("Single character strings", 
                    new object[] { new string[] { "a", "a", "a" } }, 
                    "a"),

                new TestCase("Mixed case sensitivity", 
                    new object[] { new string[] { "abcd", "abce", "abcf" } }, 
                    "abc")
            };
        }

        public override object ExecuteSolution(object[] inputs)
        {
            return LongestCommonPrefix((string[])inputs[0]);
        }

        // YOUR SOLUTION GOES HERE
        public string LongestCommonPrefix(string[] strs)
        {
            throw new NotImplementedException();
        }
    }
}