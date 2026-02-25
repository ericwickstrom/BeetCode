using BeetCode.Framework;
using System.Collections.Generic;

namespace BeetCode.Problems
{
	public class Problem141 : Problem
	{
		public override int Number => 141;
		public override string Title => "Linked List Cycle";
		public override string Difficulty => "Easy";
		public override string Description =>
			"Given head, the head of a linked list, determine if the linked list has a cycle in it.\n\n" +
			"There is a cycle in a linked list if there is some node in the list that can be reached again " +
			"by continuously following the next pointer. Internally, pos is used to denote the index of the " +
			"node that tail's next pointer is connected to. Note that pos is not passed as a parameter.\n\n" +
			"Return true if there is a cycle in the linked list. Otherwise, return false.\n\n" +
			"Example 1:\n" +
			"Input: head = [3,2,0,-4], pos = 1\n" +
			"Output: true\n" +
			"Explanation: There is a cycle in the linked list, where the tail connects to the 1st node (0-indexed).\n\n" +
			"Example 2:\n" +
			"Input: head = [1,2], pos = 0\n" +
			"Output: true\n" +
			"Explanation: There is a cycle in the linked list, where the tail connects to the 0th node.\n\n" +
			"Example 3:\n" +
			"Input: head = [1], pos = -1\n" +
			"Output: false\n" +
			"Explanation: There is no cycle in the linked list.\n\n" +
			"Constraints:\n" +
			"• The number of the nodes in the list is in the range [0, 10^4].\n" +
			"• -10^5 <= Node.val <= 10^5\n" +
			"• pos is -1 or a valid index in the linked-list.\n\n" +
			"Follow up: Can you solve it using O(1) (i.e. constant) memory?";

		public override List<TestCase> GetTestCases()
		{
			return new List<TestCase>
			{
				new TestCase("Example 1: cycle to index 1",
					new object[] { new int[] { 3, 2, 0, -4 }, 1 },
					true),

				new TestCase("Example 2: cycle to index 0",
					new object[] { new int[] { 1, 2 }, 0 },
					true),

				new TestCase("Example 3: no cycle",
					new object[] { new int[] { 1 }, -1 },
					false),

				new TestCase("Empty list",
					new object[] { new int[] { }, -1 },
					false),

				new TestCase("Single node with self-cycle",
					new object[] { new int[] { 1 }, 0 },
					true),

				new TestCase("Long list no cycle",
					new object[] { new int[] { 1, 2, 3, 4, 5 }, -1 },
					false),

				new TestCase("Cycle to tail itself",
					new object[] { new int[] { 1, 2, 3 }, 2 },
					true)
			};
		}

		public override object ExecuteSolution(object[] inputs)
		{
			int[] values = (int[])inputs[0];
			int pos = (int)inputs[1];
			ListNode? head = CreateLinkedListWithCycle(values, pos);
			return HasCycle(head);
		}

		private ListNode? CreateLinkedListWithCycle(int[] values, int pos)
		{
			if (values.Length == 0) return null;

			ListNode head = new ListNode(values[0]);
			ListNode current = head;
			ListNode? cycleTarget = pos == 0 ? head : null;

			for (int i = 1; i < values.Length; i++)
			{
				current.next = new ListNode(values[i]);
				current = current.next;
				if (i == pos)
					cycleTarget = current;
			}

			if (pos >= 0 && cycleTarget != null)
				current.next = cycleTarget;

			return head;
		}

		// YOUR SOLUTION GOES HERE
		public bool HasCycle(ListNode? head)
		{
			if (head == null) return false;

			ListNode slow = head;
			ListNode fast = head;

			while (fast != null && fast.next != null)
			{
				slow = slow.next;
				fast = fast.next.next;

				if (slow == fast) return true;
			}

			return false;
		}
	}
}
