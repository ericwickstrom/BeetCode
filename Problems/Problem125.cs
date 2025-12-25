using BeetCode.Framework;
using System.Collections.Generic;

namespace BeetCode.Problems
{
    public class Problem125 : Problem
    {
        public override int Number => 125;
        public override string Title => "Valid Palindrome";
        public override string Difficulty => "Easy";
        public override string Description =>
            "A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and removing all non-alphanumeric characters, it reads the same forward and backward.\n\n" +
            "Alphanumeric characters include letters and numbers.\n\n" +
            "Given a string s, return true if it is a palindrome, or false otherwise.\n\n" +
            "Example 1:\n" +
            "Input: s = \"A man, a plan, a canal: Panama\"\n" +
            "Output: true\n" +
            "Explanation: \"amanaplanacanalpanama\" is a palindrome.\n\n" +
            "Example 2:\n" +
            "Input: s = \"race a car\"\n" +
            "Output: false\n" +
            "Explanation: \"raceacar\" is not a palindrome.\n\n" +
            "Example 3:\n" +
            "Input: s = \" \"\n" +
            "Output: true\n" +
            "Explanation: s is an empty string \"\" after removing non-alphanumeric characters.\n" +
            "Since an empty string reads the same forward and backward, it is a palindrome.\n\n" +
            "Constraints:\n" +
            "• 1 <= s.length <= 2 * 10^5\n" +
            "• s consists only of printable ASCII characters.";

        public override List<TestCase> GetTestCases()
        {
            return new List<TestCase>
            {
                new TestCase("Example 1 - Valid palindrome",
                    new object[] { "A man, a plan, a canal: Panama" },
                    true),

                new TestCase("Example 2 - Invalid palindrome",
                    new object[] { "race a car" },
                    false),

                new TestCase("Example 3 - Empty after cleaning",
                    new object[] { " " },
                    true),

                new TestCase("Single character",
                    new object[] { "a" },
                    true),

                new TestCase("Empty string",
                    new object[] { "" },
                    true),

                new TestCase("Only non-alphanumeric",
                    new object[] { ".,!@#$%^&*()_+" },
                    true),

                new TestCase("Mixed case valid",
                    new object[] { "Was it a car or a cat I saw?" },
                    true),

                new TestCase("Numbers included",
                    new object[] { "A1B2b1a" },
                    true),

                new TestCase("Simple valid",
                    new object[] { "racecar" },
                    true),

                new TestCase("Simple invalid",
                    new object[] { "hello" },
                    false),

                new TestCase("Mixed alphanumeric invalid",
                    new object[] { "0P" },
                    false)
            };
        }

        public override object ExecuteSolution(object[] inputs)
        {
            return IsPalindrome((string)inputs[0]);
        }

        // YOUR SOLUTION GOES HERE
        public bool IsPalindrome(string s)
        {
            if(s == null || s.Length == 0) return true;
            if(s.Length == 1) return true;

            int l = 0;
            int r = s.Length - 1;

            while(l <= r)
            {
                while(!Char.IsLetterOrDigit(s[l]) && l < r)
                {
                    l++;
                }
                while(!Char.IsLetterOrDigit(s[r]) && l < r)
                {
                    r--;
                }
                if(Char.ToLower(s[l]) != Char.ToLower(s[r])) return false;
                l++;
                r--;         
            }

            return true;
        }
    }
}