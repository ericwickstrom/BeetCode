using BeetCode.Framework;
using System.Collections.Generic;

namespace BeetCode.Problems
{
	public class Problem026 : Problem
	{
		public override int Number => 26;
		public override string Title => "Remove Duplicates from Sorted Array";
		public override string Difficulty => "Easy";
		public override string Description =>
			"Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. The relative order of the elements should be kept the same. Then return the number of unique elements.\n\n" +
			"Consider the number of unique elements of nums to be k. To get accepted, you need to do the following things:\n" +
			"• Change the array nums such that the first k elements of nums contain the unique elements in the order they were present in nums initially.\n" +
			"• The remaining elements of nums are not important, nor is the size of nums.\n" +
			"• Return k.\n\n" +
			"Example 1:\n" +
			"Input: nums = [1,1,2]\n" +
			"Output: 2, nums = [1,2,_]\n\n" +
			"Example 2:\n" +
			"Input: nums = [0,0,1,1,1,2,2,3,3,4]\n" +
			"Output: 5, nums = [0,1,2,3,4,_,_,_,_,_]\n\n" +
			"Constraints:\n" +
			"• 0 <= nums.length <= 3 * 10^4\n" +
			"• -100 <= nums[i] <= 100\n" +
			"• nums is sorted in non-decreasing order.";

		public override List<TestCase> GetTestCases()
		{
			return new List<TestCase>
			{
				new TestCase("Example 1",
					new object[] { new int[] { 1, 1, 2 } },
					new int[] { 1, 2 }),

				new TestCase("Example 2",
					new object[] { new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 } },
					new int[] { 0, 1, 2, 3, 4 }),

				new TestCase("Single element",
					new object[] { new int[] { 1 } },
					new int[] { 1 }),

				new TestCase("All duplicates",
					new object[] { new int[] { 3, 3, 3, 3 } },
					new int[] { 3 }),

				new TestCase("No duplicates",
					new object[] { new int[] { 1, 2, 3, 4, 5 } },
					new int[] { 1, 2, 3, 4, 5 }),

				new TestCase("Negative numbers",
					new object[] { new int[] { -3, -1, -1, 0, 0, 2 } },
					new int[] { -3, -1, 0, 2 })
			};
		}

		public override object ExecuteSolution(object[] inputs)
		{
			int[] nums = (int[])inputs[0];
			int k = RemoveDuplicates(nums);
			return nums[..k];
		}

		// YOUR SOLUTION GOES HERE
		public int RemoveDuplicates(int[] nums)
		{
			throw new NotImplementedException();
		}
	}
}
