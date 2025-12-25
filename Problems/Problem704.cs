using BeetCode.Framework;
using System.Collections.Generic;

namespace BeetCode.Problems
{
    public class Problem704 : Problem
    {
        public override int Number => 704;
        public override string Title => "Binary Search";
        public override string Difficulty => "Easy";
        public override string Description =>
            "Given an array of integers nums which is sorted in ascending order, and an integer target, write a function to search target in nums. If target exists, then return its index. Otherwise, return -1.\n\n" +
            "You must write an algorithm with O(log n) runtime complexity.\n\n" +
            "Example 1:\n" +
            "Input: nums = [-1,0,3,5,9,12], target = 9\n" +
            "Output: 4\n" +
            "Explanation: 9 exists in nums and its index is 4\n\n" +
            "Example 2:\n" +
            "Input: nums = [-1,0,3,5,9,12], target = 2\n" +
            "Output: -1\n" +
            "Explanation: 2 does not exist in nums so return -1\n\n" +
            "Constraints:\n" +
            "• 1 <= nums.length <= 10^4\n" +
            "• -10^4 < nums[i], target < 10^4\n" +
            "• All the integers in nums are unique\n" +
            "• nums is sorted in ascending order";

        public override List<TestCase> GetTestCases()
        {
            return new List<TestCase>
            {
                new TestCase("Example 1 - Target found",
                    new object[] { new int[] {-1, 0, 3, 5, 9, 12}, 9 },
                    4),

                new TestCase("Example 2 - Target not found",
                    new object[] { new int[] {-1, 0, 3, 5, 9, 12}, 2 },
                    -1),

                new TestCase("Single element - found",
                    new object[] { new int[] {5}, 5 },
                    0),

                new TestCase("Single element - not found",
                    new object[] { new int[] {5}, 3 },
                    -1),

                new TestCase("Target at beginning",
                    new object[] { new int[] {1, 2, 3, 4, 5}, 1 },
                    0),

                new TestCase("Target at end",
                    new object[] { new int[] {1, 2, 3, 4, 5}, 5 },
                    4),

                new TestCase("Target in middle",
                    new object[] { new int[] {1, 2, 3, 4, 5}, 3 },
                    2),

                new TestCase("Two elements - first",
                    new object[] { new int[] {1, 3}, 1 },
                    0),

                new TestCase("Two elements - second",
                    new object[] { new int[] {1, 3}, 3 },
                    1),

                new TestCase("Two elements - not found",
                    new object[] { new int[] {1, 3}, 2 },
                    -1),

                new TestCase("Negative numbers",
                    new object[] { new int[] {-100, -50, 0, 50, 100}, -50 },
                    1),

                new TestCase("Large array",
                    new object[] { new int[] {-10000, -5000, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 100, 1000, 5000, 10000}, 6 },
                    8)
            };
        }

        public override object ExecuteSolution(object[] inputs)
        {
            return Search((int[])inputs[0], (int)inputs[1]);
        }

        // YOUR SOLUTION GOES HERE
        public int Search(int[] nums, int target)
        {
            throw new System.NotImplementedException();
        }
    }
}
