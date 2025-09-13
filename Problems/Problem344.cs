using BeetCode.Framework;
using System.Collections.Generic;

namespace BeetCode.Problems
{
    public class Problem344 : Problem
    {
        public override int Number => 344;
        public override string Title => "Reverse String";
        public override string Difficulty => "Easy";
        public override string Description => 
            "Write a function that reverses a string. The input string is given as an array of characters s.\n\n" +
            "You must do this by modifying the input array in-place with O(1) extra memory.\n\n" +
            "Example 1:\n" +
            "Input: s = [\"h\",\"e\",\"l\",\"l\",\"o\"]\n" +
            "Output: [\"o\",\"l\",\"l\",\"e\",\"h\"]\n\n" +
            "Example 2:\n" +
            "Input: s = [\"H\",\"a\",\"n\",\"n\",\"a\",\"h\"]\n" +
            "Output: [\"h\",\"a\",\"n\",\"n\",\"a\",\"H\"]\n\n" +
            "Constraints:\n" +
            "• 1 <= s.length <= 10^5\n" +
            "• s[i] is a printable ascii character.\n\n" +
            "Follow up: Do not allocate extra space for another array. You must do this by modifying the input array in-place with O(1) extra memory.";

        public override List<TestCase> GetTestCases()
        {
            return new List<TestCase>
            {
                new TestCase("Example 1", 
                    new object[] { new char[] { 'h', 'e', 'l', 'l', 'o' } }, 
                    new char[] { 'o', 'l', 'l', 'e', 'h' }),
                
                new TestCase("Example 2", 
                    new object[] { new char[] { 'H', 'a', 'n', 'n', 'a', 'h' } }, 
                    new char[] { 'h', 'a', 'n', 'n', 'a', 'H' }),
                
                new TestCase("Single character", 
                    new object[] { new char[] { 'A' } }, 
                    new char[] { 'A' }),

                new TestCase("Two characters", 
                    new object[] { new char[] { 'a', 'b' } }, 
                    new char[] { 'b', 'a' }),

                new TestCase("Empty-like case", 
                    new object[] { new char[] { ' ' } }, 
                    new char[] { ' ' }),

                new TestCase("Numbers and symbols", 
                    new object[] { new char[] { '1', '2', '3', '!', '@' } }, 
                    new char[] { '@', '!', '3', '2', '1' }),

                new TestCase("Palindrome", 
                    new object[] { new char[] { 'a', 'b', 'a' } }, 
                    new char[] { 'a', 'b', 'a' })
            };
        }

        public override object ExecuteSolution(object[] inputs)
        {
            var inputArray = (char[])inputs[0];
            // Create a copy since we need to return the result for comparison
            var result = new char[inputArray.Length];
            Array.Copy(inputArray, result, inputArray.Length);
            
            ReverseString(result);
            return result;
        }

        // YOUR SOLUTION GOES HERE
        public void ReverseString(char[] s)
        {
            throw new NotImplementedException();
        }
    }
}