using BeetCode.Framework;
using System.Collections.Generic;

namespace BeetCode.Problems
{
    public class Problem206 : Problem
    {
        public override int Number => 206;
        public override string Title => "Reverse Linked List";
        public override string Difficulty => "Easy";
        public override string Description =>
            "Given the head of a singly linked list, reverse the list, and return the reversed list.\n\n" +
            "Example 1:\n" +
            "Input: head = [1,2,3,4,5]\n" +
            "Output: [5,4,3,2,1]\n\n" +
            "Example 2:\n" +
            "Input: head = [1,2]\n" +
            "Output: [2,1]\n\n" +
            "Example 3:\n" +
            "Input: head = []\n" +
            "Output: []\n\n" +
            "Constraints:\n" +
            "- The number of nodes in the list is the range [0, 5000].\n" +
            "- -5000 <= Node.val <= 5000\n\n" +
            "Follow up: A linked list can be reversed either iteratively or recursively. Could you implement both?";

        public override List<TestCase> GetTestCases()
        {
            return new List<TestCase>
            {
                new TestCase("Example 1: [1,2,3,4,5] -> [5,4,3,2,1]",
                    new object[] { CreateLinkedList(new int[] {1, 2, 3, 4, 5}) },
                    new int[] {5, 4, 3, 2, 1}),

                new TestCase("Example 2: [1,2] -> [2,1]",
                    new object[] { CreateLinkedList(new int[] {1, 2}) },
                    new int[] {2, 1}),

                new TestCase("Example 3: [] -> []",
                    new object[] { (ListNode)null },
                    new int[0]),

                new TestCase("Single node: [1] -> [1]",
                    new object[] { CreateLinkedList(new int[] {1}) },
                    new int[] {1})
            };
        }

        public override object ExecuteSolution(object[] inputs)
        {
            var result = ReverseList((ListNode)inputs[0]);
            return LinkedListToArray(result);
        }

        // YOUR SOLUTION GOES HERE
        public ListNode ReverseList(ListNode head)
        {
            // TODO: Implement your solution
            throw new NotImplementedException();
        }
    }
}