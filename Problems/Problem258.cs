using BeetCode.Framework;
using System.Collections.Generic;

namespace BeetCode.Problems
{
    public class Problem258 : Problem
    {
        public override int Number => 258;
        public override string Title => "Add Digits";
        public override string Difficulty => "Easy";
        public override string Description => 
            "Given an integer num, repeatedly add all its digits until the result has only one digit, and return it.\n\n" +
            "Example 1:\n" +
            "Input: num = 38\n" +
            "Output: 2\n" +
            "Explanation: The process is\n" +
            "38 --> 3 + 8 --> 11\n" +
            "11 --> 1 + 1 --> 2\n" +
            "Since 2 has only one digit, return it.\n\n" +
            "Example 2:\n" +
            "Input: num = 0\n" +
            "Output: 0\n\n" +
            "Constraints:\n" +
            "• 0 <= num <= 2^31 - 1\n\n" +
            "Follow up: Could you do it without any loop/recursion in O(1) runtime?";

        public override List<TestCase> GetTestCases()
        {
            return new List<TestCase>
            {
                new TestCase("Example 1", 
                    new object[] { 38 }, 
                    2),
                
                new TestCase("Example 2", 
                    new object[] { 0 }, 
                    0),
                
                new TestCase("Single digit", 
                    new object[] { 5 }, 
                    5),

                new TestCase("Double digits", 
                    new object[] { 99 }, 
                    9),

                new TestCase("Large number", 
                    new object[] { 12345 }, 
                    6),

                new TestCase("Another case", 
                    new object[] { 999 }, 
                    9),

                new TestCase("Power of 10", 
                    new object[] { 1000 }, 
                    1),

                new TestCase("Medium number", 
                    new object[] { 199 }, 
                    1)
            };
        }

        public override object ExecuteSolution(object[] inputs)
        {
            return AddDigits((int)inputs[0]);
        }

        // YOUR SOLUTION GOES HERE
        public int AddDigits(int num)
        {
            // TODO: Implement your solution
            throw new NotImplementedException();
        }
    }
}