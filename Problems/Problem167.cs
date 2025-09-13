using BeetCode.Framework;
using System.Collections.Generic;

namespace BeetCode.Problems
{
    public class Problem167 : Problem
    {
        public override int Number => 167;
        public override string Title => "Two Sum II - Input Array Is Sorted";
        public override string Difficulty => "Medium";
        public override string Description =>
            "Given a 1-indexed array of integers numbers that is already sorted in non-decreasing order, find two numbers such that they add up to a specific target number.\n\n" +
            "Let these two numbers be numbers[index1] and numbers[index2] where 1 <= index1 < index2 <= numbers.length.\n\n" +
            "Return the indices of the two numbers, index1 and index2, added by one as an integer array [index1, index2] of length 2.\n\n" +
            "The tests are generated such that there is exactly one solution. You may not use the same element twice.\n\n" +
            "Your solution must use only constant extra space.\n\n" +
            "Example 1:\n" +
            "Input: numbers = [2,7,11,15], target = 9\n" +
            "Output: [1,2]\n" +
            "Explanation: The sum of 2 and 7 is 9. Therefore index1 = 1, index2 = 2.\n\n" +
            "Example 2:\n" +
            "Input: numbers = [2,3,4], target = 6\n" +
            "Output: [1,3]\n" +
            "Explanation: The sum of 2 and 4 is 6. Therefore index1 = 1, index2 = 3.\n\n" +
            "Example 3:\n" +
            "Input: numbers = [-1,0], target = -1\n" +
            "Output: [1,2]\n" +
            "Explanation: The sum of -1 and 0 is -1. Therefore index1 = 1, index2 = 2.\n\n" +
            "Constraints:\n" +
            "• 2 <= numbers.length <= 3 * 10^4\n" +
            "• -1000 <= numbers[i] <= 1000\n" +
            "• numbers is sorted in non-decreasing order.\n" +
            "• -1000 <= target <= 2000\n" +
            "• The tests are generated such that there is exactly one solution.";

        public override List<TestCase> GetTestCases()
        {
            return new List<TestCase>
            {
                new TestCase("Example 1",
                    new object[] { new int[] {2, 7, 11, 15}, 9 },
                    new int[] {1, 2}),

                new TestCase("Example 2",
                    new object[] { new int[] {2, 3, 4}, 6 },
                    new int[] {1, 3}),

                new TestCase("Example 3",
                    new object[] { new int[] {-1, 0}, -1 },
                    new int[] {1, 2}),

                new TestCase("Edge Case - Two elements",
                    new object[] { new int[] {1, 2}, 3 },
                    new int[] {1, 2}),

                new TestCase("Large array",
                    new object[] { new int[] {1, 2, 3, 4, 4, 9, 56, 90}, 8 },
                    new int[] {4, 5})
            };
        }

        public override object ExecuteSolution(object[] inputs)
        {
            return TwoSum((int[])inputs[0], (int)inputs[1]);
        }

        // YOUR SOLUTION GOES HERE
        public int[] TwoSum(int[] numbers, int target)
        {
            throw new NotImplementedException();
        }
    }
}