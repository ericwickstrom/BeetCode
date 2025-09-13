using BeetCode.Framework;
using System.Collections.Generic;
using System.Data;

namespace BeetCode.Problems
{
    public class Problem001 : Problem
    {
        public override int Number => 1;
        public override string Title => "Two Sum";
        public override string Difficulty => "Easy";
        public override string Description =>
            "Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.\n\n" +
            "You may assume that each input would have exactly one solution, and you may not use the same element twice.\n\n" +
            "You can return the answer in any order.\n\n" +
            "Example 1:\n" +
            "Input: nums = [2,7,11,15], target = 9\n" +
            "Output: [0,1]\n" +
            "Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].\n\n" +
            "Example 2:\n" +
            "Input: nums = [3,2,4], target = 6\n" +
            "Output: [1,2]\n\n" +
            "Example 3:\n" +
            "Input: nums = [3,3], target = 6\n" +
            "Output: [0,1]";

        public override List<TestCase> GetTestCases()
        {
            return new List<TestCase>
            {
                new TestCase("Example 1",
                    new object[] { new int[] {2, 7, 11, 15}, 9 },
                    new int[] {0, 1}),

                new TestCase("Example 2",
                    new object[] { new int[] {3, 2, 4}, 6 },
                    new int[] {1, 2}),

                new TestCase("Example 3",
                    new object[] { new int[] {3, 3}, 6 },
                    new int[] {0, 1})
            };
        }

        public override object ExecuteSolution(object[] inputs)
        {
            return TwoSum((int[])inputs[0], (int)inputs[1]);
        }

        // YOUR SOLUTION GOES HERE
        public int[] TwoSum(int[] nums, int target)
        {
            throw new NotImplementedException();
        }
    }
}