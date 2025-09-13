using BeetCode.Framework;
using System.Collections.Generic;

namespace BeetCode.Problems
{
    public class Problem020 : Problem
    {
        public override int Number => 20;
        public override string Title => "Valid Parentheses";
        public override string Difficulty => "Easy";
        public override string Description => 
            "Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.\n\n" +
            "An input string is valid if:\n" +
            "1. Open brackets must be closed by the same type of brackets.\n" +
            "2. Open brackets must be closed in the correct order.\n" +
            "3. Every close bracket has a corresponding open bracket of the same type.\n\n" +
            "Example 1:\n" +
            "Input: s = \"()\"\n" +
            "Output: true\n\n" +
            "Example 2:\n" +
            "Input: s = \"()[]{}\"\n" +
            "Output: true\n\n" +
            "Example 3:\n" +
            "Input: s = \"(]\"\n" +
            "Output: false\n\n" +
            "Constraints:\n" +
            "• 1 <= s.length <= 10^4\n" +
            "• s consists of parentheses only '()[]{}'.";

        public override List<TestCase> GetTestCases()
        {
            return new List<TestCase>
            {
                new TestCase("Example 1 - Simple pair", 
                    new object[] { "()" }, 
                    true),
                
                new TestCase("Example 2 - Multiple types", 
                    new object[] { "()[]{}" }, 
                    true),
                
                new TestCase("Example 3 - Wrong order", 
                    new object[] { "(]" }, 
                    false),

                new TestCase("Nested brackets", 
                    new object[] { "([{}])" }, 
                    true),

                new TestCase("Wrong closing", 
                    new object[] { "([)]" }, 
                    false),

                new TestCase("Only opening", 
                    new object[] { "(((" }, 
                    false),

                new TestCase("Only closing", 
                    new object[] { ")))" }, 
                    false),

                new TestCase("Empty string", 
                    new object[] { "" }, 
                    true),

                new TestCase("Complex valid", 
                    new object[] { "()[]{}(())" }, 
                    true),

                new TestCase("Complex invalid", 
                    new object[] { "()[]{}(()" }, 
                    false),

                new TestCase("Single opening", 
                    new object[] { "(" }, 
                    false),

                new TestCase("Single closing", 
                    new object[] { ")" }, 
                    false)
            };
        }

        public override object ExecuteSolution(object[] inputs)
        {
            return IsValid((string)inputs[0]);
        }

        // YOUR SOLUTION GOES HERE
        public bool IsValid(string s)
        {
            throw new NotImplementedException();
            return false;
        }
    }
}