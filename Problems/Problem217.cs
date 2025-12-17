using BeetCode.Framework;
using System.Collections.Generic;

namespace BeetCode.Problems
{
    public class Problem217 : Problem
    {
        public override int Number => 217;
        public override string Title => "Contains Duplicate";
        public override string Difficulty => "Easy";
        public override string Description =>
            "Given an integer array nums, return true if any value appears at least twice in the array, and return false if every element is distinct.\n\n" +
            "Example 1:\n" +
            "Input: nums = [1,2,3,1]\n" +
            "Output: true\n" +
            "Explanation: The element 1 occurs at index 0 and 3.\n\n" +
            "Example 2:\n" +
            "Input: nums = [1,2,3,4]\n" +
            "Output: false\n" +
            "Explanation: All elements are distinct.\n\n" +
            "Example 3:\n" +
            "Input: nums = [1,1,1,3,3,4,3,2,4,2]\n" +
            "Output: true\n\n" +
            "Constraints:\n" +
            "• 1 <= nums.length <= 10^5\n" +
            "• -10^9 <= nums[i] <= 10^9";

        public override List<TestCase> GetTestCases()
        {
            return new List<TestCase>
            {
                new TestCase("Example 1",
                    new object[] { new int[] {1, 2, 3, 1} },
                    true),

                new TestCase("Example 2",
                    new object[] { new int[] {1, 2, 3, 4} },
                    false),

                new TestCase("Example 3",
                    new object[] { new int[] {1, 1, 1, 3, 3, 4, 3, 2, 4, 2} },
                    true),

                new TestCase("Single element",
                    new object[] { new int[] {1} },
                    false),

                new TestCase("Two identical elements",
                    new object[] { new int[] {1, 1} },
                    true),

                new TestCase("Empty array edge case",
                    new object[] { new int[] {} },
                    false)
            };
        }

        public override object ExecuteSolution(object[] inputs)
        {
            return ContainsDuplicate((int[])inputs[0]);
        }

        // YOUR SOLUTION GOES HERE
        public bool ContainsDuplicate(int[] nums)
        {
            if(nums == null || nums.Length < 2) return false;
            HashSet<int> set = new HashSet<int>();
            foreach(int i in nums)
            {
                if(set.Contains(i)) return true;
                set.Add(i);
            }

            return false;
        }
    }
}