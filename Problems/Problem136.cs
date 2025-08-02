using BeetCode.Framework;
using System.Collections.Generic;

namespace BeetCode.Problems
{
    public class Problem136 : Problem
    {
        public override int Number => 136;
        public override string Title => "Single Number";
        public override string Difficulty => "Easy";
        public override string Description => 
            "Given a non-empty array of integers nums, every element appears twice except for one. Find that single one.\n\n" +
            "You must implement a solution with a linear runtime complexity and use only constant extra space.\n\n" +
            "Example 1:\n" +
            "Input: nums = [2,2,1]\n" +
            "Output: 1\n\n" +
            "Example 2:\n" +
            "Input: nums = [4,1,2,1,2]\n" +
            "Output: 4\n\n" +
            "Example 3:\n" +
            "Input: nums = [1]\n" +
            "Output: 1\n\n" +
            "Constraints:\n" +
            "• 1 <= nums.length <= 3 * 10^4\n" +
            "• -3 * 10^4 <= nums[i] <= 3 * 10^4\n" +
            "• Each element in the array appears twice except for one element which appears only once.";

        public override List<TestCase> GetTestCases()
        {
            return new List<TestCase>
            {
                new TestCase("Example 1", 
                    new object[] { new int[] { 2, 2, 1 } }, 
                    1),
                
                new TestCase("Example 2", 
                    new object[] { new int[] { 4, 1, 2, 1, 2 } }, 
                    4),
                
                new TestCase("Example 3", 
                    new object[] { new int[] { 1 } }, 
                    1),

                new TestCase("Negative numbers", 
                    new object[] { new int[] { -1, -1, 0, 0, 2 } }, 
                    2),

                new TestCase("Larger array", 
                    new object[] { new int[] { 5, 7, 5, 4, 7, 4, 3 } }, 
                    3),

                new TestCase("Single negative", 
                    new object[] { new int[] { 10, 10, -5 } }, 
                    -5)
            };
        }

        public override object ExecuteSolution(object[] inputs)
        {
            return SingleNumber((int[])inputs[0]);
        }

        // YOUR SOLUTION GOES HERE
        public int SingleNumber(int[] nums)
        {
            var numDict = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                // check if dict has it
                if (numDict.TryGetValue(num, out int value))
                {
                    numDict[num] = value + 1;
                }
                else
                {
                    numDict.Add(num, 1);
                }
            }
            var val = numDict.Where(w => w.Value == 1).FirstOrDefault();
            return val.Key;
        }
    }
}