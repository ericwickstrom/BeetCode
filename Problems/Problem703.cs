using BeetCode.Framework;
using System.Collections.Generic;

namespace BeetCode.Problems
{
	public class Problem703 : Problem
	{
		public override int Number => 703;
		public override string Title => "Kth Largest Element in a Stream";
		public override string Difficulty => "Easy";
		public override string Description =>
			"You are part of a university admissions office and need to keep track of the kth highest test score from applicants in real-time. This helps to determine cut-off marks for interviews and admissions dynamically as new applicants submit their scores.\n" +
			"\n" +
			"You are tasked to implement a class which, for a given integer k, maintains a stream of test scores and continuously returns the kth highest test score after a new score has been submitted. More specifically, we are looking for the kth highest score in the sorted list of all scores.\n" +
			"\n" +
			"Implement the KthLargest class:\n" +
			"\n" +
			"\t• KthLargest(int k, int[] nums) Initializes the object with the integer k and the stream of test scores nums.\n" +
			"\n" +
			"\t• int add(int val) Adds a new test score val to the stream and returns the element representing the k^th largest element in the pool of test scores so far.\n" +
			"\n" +
			" \n" +
			"\n" +
			"Example 1:\n" +
			"\n" +
			"Input:\n" +
			"\n" +
			"[\"KthLargest\", \"add\", \"add\", \"add\", \"add\", \"add\"]\n" +
			"\n" +
			"[[3, [4, 5, 8, 2]], [3], [5], [10], [9], [4]]\n" +
			"\n" +
			"Output: [null, 4, 5, 5, 8, 8]\n" +
			"\n" +
			"Explanation:\n" +
			"\n" +
			"KthLargest kthLargest = new KthLargest(3, [4, 5, 8, 2]);\n" +
			"\n" +
			"kthLargest.add(3); // return 4\n" +
			"\n" +
			"kthLargest.add(5); // return 5\n" +
			"\n" +
			"kthLargest.add(10); // return 5\n" +
			"\n" +
			"kthLargest.add(9); // return 8\n" +
			"\n" +
			"kthLargest.add(4); // return 8\n" +
			"\n" +
			"Example 2:\n" +
			"\n" +
			"Input:\n" +
			"\n" +
			"[\"KthLargest\", \"add\", \"add\", \"add\", \"add\"]\n" +
			"\n" +
			"[[4, [7, 7, 7, 7, 8, 3]], [2], [10], [9], [9]]\n" +
			"\n" +
			"Output: [null, 7, 7, 7, 8]\n" +
			"\n" +
			"Explanation:\n" +
			"\n" +
			"KthLargest kthLargest = new KthLargest(4, [7, 7, 7, 7, 8, 3]);\n" +
			"\n" +
			"kthLargest.add(2); // return 7\n" +
			"\n" +
			"kthLargest.add(10); // return 7\n" +
			"\n" +
			"kthLargest.add(9); // return 7\n" +
			"\n" +
			"kthLargest.add(9); // return 8\n" +
			"\n" +
			" \n" +
			"\n" +
			"Constraints:\n" +
			"\n" +
			"\t• 0 <= nums.length <= 10^4\n" +
			"\n" +
			"\t• 1 <= k <= nums.length + 1\n" +
			"\n" +
			"\t• -10^4 <= nums[i] <= 10^4\n" +
			"\n" +
			"\t• -10^4 <= val <= 10^4\n" +
			"\n" +
			"\t• At most 10^4 calls will be made to add.";

		public override List<TestCase> GetTestCases()
		{
			return new List<TestCase>
			{
				// Input: 
				// Expected output: [null, 4, 5, 5, 8, 8]
				new TestCase("Example 1",
					new object[] { /* TODO */ },
					null /* TODO */),

				// Input: 
				// Expected output: [null, 7, 7, 7, 8]
				new TestCase("Example 2",
					new object[] { /* TODO */ },
					null /* TODO */),

				// TODO: Add edge cases beyond LeetCode examples
			};
		}

		public override object ExecuteSolution(object[] inputs)
		{
			// TODO: Cast inputs and call your solution method
			throw new NotImplementedException();
		}

		// YOUR SOLUTION GOES HERE
		// TODO: Add your solution method
		// public ReturnType MethodName(params)
		// {
		//     throw new NotImplementedException();
		// }
	}
}
