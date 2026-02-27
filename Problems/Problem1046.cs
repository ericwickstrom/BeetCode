using BeetCode.Framework;
using System.Collections.Generic;

namespace BeetCode.Problems
{
	public class Problem1046 : Problem
	{
		public override int Number => 1046;
		public override string Title => "Last Stone Weight";
		public override string Difficulty => "Easy";
		public override string Description =>
			"You are given an array of integers stones where stones[i] is the weight of the i^th stone.\n" +
			"\n" +
			"We are playing a game with the stones. On each turn, we choose the heaviest two stones and smash them together. Suppose the heaviest two stones have weights x and y with x <= y. The result of this smash is:\n" +
			"\n" +
			"\t• If x == y, both stones are destroyed, and\n" +
			"\n" +
			"\t• If x != y, the stone of weight x is destroyed, and the stone of weight y has new weight y - x.\n" +
			"\n" +
			"At the end of the game, there is at most one stone left.\n" +
			"\n" +
			"Return the weight of the last remaining stone. If there are no stones left, return 0.\n" +
			"\n" +
			" \n" +
			"\n" +
			"Example 1:\n" +
			"\n" +
			"Input: stones = [2,7,4,1,8,1]\n" +
			"Output: 1\n" +
			"Explanation: \n" +
			"We combine 7 and 8 to get 1 so the array converts to [2,4,1,1,1] then,\n" +
			"we combine 2 and 4 to get 2 so the array converts to [2,1,1,1] then,\n" +
			"we combine 2 and 1 to get 1 so the array converts to [1,1,1] then,\n" +
			"we combine 1 and 1 to get 0 so the array converts to [1] then that's the value of the last stone.\n" +
			"\n" +
			"Example 2:\n" +
			"\n" +
			"Input: stones = [1]\n" +
			"Output: 1\n" +
			"\n" +
			" \n" +
			"\n" +
			"Constraints:\n" +
			"\n" +
			"\t• 1 <= stones.length <= 30\n" +
			"\n" +
			"\t• 1 <= stones[i] <= 1000";

		public override List<TestCase> GetTestCases()
		{
			return new List<TestCase>
			{
				new TestCase("Example 1",
					new object[] { new int[] { 2, 7, 4, 1, 8, 1 } },
					1),

				new TestCase("Example 2",
					new object[] { new int[] { 1 } },
					1),

				// TODO: Add edge cases beyond LeetCode examples
			};
		}

		public override object ExecuteSolution(object[] inputs)
		{
			int[] stones = (int[])inputs[0];
			return LastStoneWeight(stones);
		}

		// YOUR SOLUTION GOES HERE
		public int LastStoneWeight(int[] stones)
		{
			PriorityQueue<int,int> pq = new PriorityQueue<int, int>();
			foreach(int stone in stones)
			{
				pq.Enqueue(stone, -1 * stone);
			}

			while(pq.Count > 1)
			{
				int stone1 = pq.Dequeue();
				int stone2 = pq.Dequeue();

				if(stone1 != stone2)
				{
					int stone3 = Math.Abs(stone1 - stone2);
					pq.Enqueue(stone3, -1 * stone3);
				}
			}

			if(pq.Count == 0) return 0;
			return pq.Peek();
		}
	}
}
