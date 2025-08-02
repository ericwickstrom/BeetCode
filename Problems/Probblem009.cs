using BeetCode.Framework;
using System.Collections.Generic;

namespace BeetCode.Problems
{
    public class Problem009 : Problem
    {
        public override int Number => 9;
        public override string Title => "Palindrome Number";
        public override string Difficulty => "Easy";
        public override string Description =>
            "Given an integer x, return true if x is a palindrome, and false otherwise.\n\n" +
            "An integer is a palindrome when it reads the same backward as forward.\n\n" +
            "For example, 121 is a palindrome while 123 is not.\n\n" +
            "Example 1:\n" +
            "Input: x = 121\n" +
            "Output: true\n" +
            "Explanation: 121 reads as 121 from left to right and from right to left.\n\n" +
            "Example 2:\n" +
            "Input: x = -121\n" +
            "Output: false\n" +
            "Explanation: From left to right, it reads -121. From right to left, it becomes 121-. Therefore it is not a palindrome.\n\n" +
            "Example 3:\n" +
            "Input: x = 10\n" +
            "Output: false\n" +
            "Explanation: Reads 01 from right to left. Therefore it is not a palindrome.\n\n" +
            "Constraints:\n" +
            "• -2^31 <= x <= 2^31 - 1\n\n" +
            "Follow up: Could you solve it without converting the integer to a string?";

        public override List<TestCase> GetTestCases()
        {
            return new List<TestCase>
            {
                new TestCase("Example 1",
                    new object[] { 121 },
                    true),

                new TestCase("Example 2",
                    new object[] { -121 },
                    false),

                new TestCase("Example 3",
                    new object[] { 10 },
                    false),

                new TestCase("Single digit",
                    new object[] { 7 },
                    true),

                new TestCase("Zero",
                    new object[] { 0 },
                    true),

                new TestCase("Large palindrome",
                    new object[] { 12321 },
                    true),

                new TestCase("Large non-palindrome",
                    new object[] { 12345 },
                    false)
            };
        }

        public override object ExecuteSolution(object[] inputs)
        {
            return IsPalindrome((int)inputs[0]);
        }

        // YOUR SOLUTION GOES HERE
        public bool IsPalindrome(int x)
        {
            if (x < 0) return false;
            var numberString = x.ToString();
            int start = 0;
            int end = numberString.Length - 1;
            while (start < end)
            {
                if (numberString[start] != numberString[end]) return false;
                start++;
                end--;
            }
            return true;
        }
    }
}