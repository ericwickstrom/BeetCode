using BeetCode.Framework;
using System.Collections.Generic;

namespace BeetCode.Problems
{
    public class Problem202 : Problem
    {
        public override int Number => 202;
        public override string Title => "Happy Number";
        public override string Difficulty => "Easy";
        public override string Description => 
            "Write an algorithm to determine if a number n is happy.\n\n" +
            "A happy number is a number defined by the following process:\n" +
            "• Starting with any positive integer, replace the number by the sum of the squares of its digits.\n" +
            "• Repeat the process until the number equals 1 (where it will stay), or it loops endlessly in a cycle which does not include 1.\n" +
            "• Those numbers for which this process ends in 1 are happy.\n\n" +
            "Return true if n is a happy number, and false if not.\n\n" +
            "Example 1:\n" +
            "Input: n = 19\n" +
            "Output: true\n" +
            "Explanation:\n" +
            "1² + 9² = 1 + 81 = 82\n" +
            "8² + 2² = 64 + 4 = 68\n" +
            "6² + 8² = 36 + 64 = 100\n" +
            "1² + 0² + 0² = 1 + 0 + 0 = 1\n\n" +
            "Example 2:\n" +
            "Input: n = 2\n" +
            "Output: false\n\n" +
            "Constraints:\n" +
            "• 1 <= n <= 2^31 - 1";

        public override List<TestCase> GetTestCases()
        {
            return new List<TestCase>
            {
                new TestCase("Example 1 - Happy number", 
                    new object[] { 19 }, 
                    true),
                
                new TestCase("Example 2 - Unhappy number", 
                    new object[] { 2 }, 
                    false),
                
                new TestCase("Single digit happy", 
                    new object[] { 1 }, 
                    true),

                new TestCase("Single digit happy", 
                    new object[] { 7 }, 
                    true),

                new TestCase("Single digit unhappy", 
                    new object[] { 4 }, 
                    false),

                new TestCase("Another happy number", 
                    new object[] { 10 }, 
                    true),

                new TestCase("Three digit unhappy", 
                    new object[] { 145 }, 
                    false),

                new TestCase("Large happy number", 
                    new object[] { 23 }, 
                    true)
            };
        }

        public override object ExecuteSolution(object[] inputs)
        {
            return IsHappy((int)inputs[0]);
        }

        // YOUR SOLUTION GOES HERE
        public bool IsHappy(int n)
        {
            // TODO: Implement your solution
            throw new NotImplementedException();
        }
    }
}