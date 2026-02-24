using BeetCode.Framework;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace BeetCode.Problems
{
	public class Problem027 : Problem
	{
		public override int Number => 27;
		public override string Title => "Remove Element";
		public override string Difficulty => "Easy";
		public override string Description =>
			"Given an integer array nums and an integer val, remove all occurrences of val in nums in-place. The order of the elements may be changed. Then return the number of elements in nums which are not equal to val.\n\n" +
			"Consider the number of elements in nums which are not equal to val be k. To get accepted, you need to do the following things:\n" +
			"• Change the array nums such that the first k elements of nums contain the elements which are not equal to val.\n" +
			"• The remaining elements of nums are not important, nor is the size of nums.\n" +
			"• Return k.\n\n" +
			"Example 1:\n" +
			"Input: nums = [3,2,2,3], val = 3\n" +
			"Output: 2, nums = [2,2,_,_]\n" +
			"Explanation: Your function should return k = 2, with the first two elements of nums being 2.\n\n" +
			"Example 2:\n" +
			"Input: nums = [0,1,2,2,3,0,4,2], val = 2\n" +
			"Output: 5, nums = [0,1,4,0,3,_,_,_]\n" +
			"Explanation: Your function should return k = 5, with the first five elements of nums containing 0, 0, 1, 3, and 4 (order does not matter).\n\n" +
			"Constraints:\n" +
			"• 0 <= nums.length <= 100\n" +
			"• 0 <= nums[i] <= 50\n" +
			"• 0 <= val <= 100";

		public override List<TestCase> GetTestCases()
		{
			return new List<TestCase>
			{
				new TestCase("Example 1",
					new object[] { new int[] { 3, 2, 2, 3 }, 3 },
					new int[] { 2, 2 }),

				new TestCase("Example 2",
					new object[] { new int[] { 0, 1, 2, 2, 3, 0, 4, 2 }, 2 },
					new int[] { 0, 0, 1, 3, 4 }),

				new TestCase("Empty array",
					new object[] { new int[] { }, 1 },
					new int[] { }),

				new TestCase("All elements equal to val",
					new object[] { new int[] { 4, 4, 4 }, 4 },
					new int[] { }),

				new TestCase("No elements equal to val",
					new object[] { new int[] { 1, 2, 3, 4 }, 5 },
					new int[] { 1, 2, 3, 4 }),

				new TestCase("Single element - match",
					new object[] { new int[] { 1 }, 1 },
					new int[] { }),

				new TestCase("Single element - no match",
					new object[] { new int[] { 1 }, 2 },
					new int[] { 1 })
			};
		}

		public override object ExecuteSolution(object[] inputs)
		{
			int[] nums = (int[])inputs[0];
			int val = (int)inputs[1];
			int k = RemoveElement(nums, val);
			int[] result = nums[..k];
			Array.Sort(result);
			return result;
		}

		protected override bool AreEqual(object expected, object actual)
		{
			if (expected is int[] expectedArr && actual is int[] actualArr)
			{
				int[] sortedExpected = (int[])expectedArr.Clone();
				Array.Sort(sortedExpected);
				return sortedExpected.SequenceEqual(actualArr);
			}
			return base.AreEqual(expected, actual);
		}

		// YOUR SOLUTION GOES HERE
		public int RemoveElement(int[] nums, int val)
		{
			if(nums == null || nums.Length == 0) return 0;

			int l = 0;
			int r = 0;
			while(r < nums.Length)
			{
				if(nums[r] != val)
				{
					nums[l] = nums[r];
					l++;
				}
				r++;	
			}
			return l;
		}
	}
}
