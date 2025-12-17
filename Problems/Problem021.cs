using BeetCode.Framework;
using System.Collections.Generic;

namespace BeetCode.Problems
{
    /// <summary>
    /// 21. Merge Two Sorted Lists
    /// 
    /// You are given the heads of two sorted linked lists list1 and list2.
    /// 
    /// Merge the two lists into one sorted list. The list should be made by splicing 
    /// together the nodes of the first two lists.
    /// 
    /// Return the head of the merged linked list.
    /// </summary>
    public class Problem021 : Problem
    {
        public override int Number => 21;
        public override string Title => "Merge Two Sorted Lists";
        public override string Difficulty => "Easy";
        public override string Description =>
            "You are given the heads of two sorted linked lists list1 and list2.\n\n" +
            "Merge the two lists into one sorted list. The list should be made by splicing together the nodes of the first two lists.\n\n" +
            "Return the head of the merged linked list.\n\n" +
            "Example 1:\n" +
            "Input: list1 = [1,2,4], list2 = [1,3,4]\n" +
            "Output: [1,1,2,3,4,4]\n\n" +
            "Example 2:\n" +
            "Input: list1 = [], list2 = []\n" +
            "Output: []\n\n" +
            "Example 3:\n" +
            "Input: list1 = [], list2 = [0]\n" +
            "Output: [0]\n\n" +
            "Constraints:\n" +
            "• The number of nodes in both lists is in the range [0, 50].\n" +
            "• -100 <= Node.val <= 100\n" +
            "• Both list1 and list2 are sorted in non-decreasing order.\n\n" +
            "Difficulty: Easy\n" +
            "Tags: Linked List, Recursion";

        /// <summary>
        /// Definition for singly-linked list.
        /// </summary>
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        public override List<TestCase> GetTestCases()
        {
            return new List<TestCase>
            {
                new TestCase("Example 1",
                    new object[] { 
                        CreateLinkedList(new int[] { 1, 2, 4 }),
                        CreateLinkedList(new int[] { 1, 3, 4 })
                    },
                    CreateLinkedList(new int[] { 1, 1, 2, 3, 4, 4 })),

                new TestCase("Example 2",
                    new object[] { 
                        CreateLinkedList(new int[] { }),
                        CreateLinkedList(new int[] { })
                    },
                    CreateLinkedList(new int[] { })),

                new TestCase("Example 3",
                    new object[] { 
                        CreateLinkedList(new int[] { }),
                        CreateLinkedList(new int[] { 0 })
                    },
                    CreateLinkedList(new int[] { 0 })),

                new TestCase("Single node each",
                    new object[] { 
                        CreateLinkedList(new int[] { 1 }),
                        CreateLinkedList(new int[] { 2 })
                    },
                    CreateLinkedList(new int[] { 1, 2 })),

                new TestCase("Different lengths",
                    new object[] { 
                        CreateLinkedList(new int[] { 1, 2, 3 }),
                        CreateLinkedList(new int[] { 4, 5, 6, 7, 8 })
                    },
                    CreateLinkedList(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 })),

                new TestCase("Interleaved values",
                    new object[] { 
                        CreateLinkedList(new int[] { 1, 5, 9 }),
                        CreateLinkedList(new int[] { 2, 4, 6, 8 })
                    },
                    CreateLinkedList(new int[] { 1, 2, 4, 5, 6, 8, 9 }))
            };
        }

        public override object ExecuteSolution(object[] inputs)
        {
            var list1 = (ListNode)inputs[0];
            var list2 = (ListNode)inputs[1];
            return MergeTwoLists(list1, list2);
        }

        /// <summary>
        /// YOUR SOLUTION GOES HERE!
        /// Replace the NotImplementedException with your implementation.
        /// 
        /// Approaches to consider:
        /// 1. Iterative with dummy node
        /// 2. Recursive approach
        /// 3. In-place merging
        /// 
        /// Time Complexity: O(m + n) where m and n are the lengths of the lists
        /// Space Complexity: O(1) for iterative, O(m + n) for recursive (call stack)
        /// </summary>
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            throw new NotImplementedException();
        }

        // Helper methods for creating and working with linked lists
        private ListNode CreateLinkedList(int[] values)
        {
            if (values.Length == 0) return null;
            
            ListNode head = new ListNode(values[0]);
            ListNode current = head;
            
            for (int i = 1; i < values.Length; i++)
            {
                current.next = new ListNode(values[i]);
                current = current.next;
            }
            
            return head;
        }

        private bool AreLinkedListsEqual(ListNode expected, ListNode actual)
        {
            while (expected != null && actual != null)
            {
                if (expected.val != actual.val)
                    return false;
                expected = expected.next;
                actual = actual.next;
            }
            
            return expected == null && actual == null;
        }

        private string FormatLinkedList(ListNode head)
        {
            if (head == null) return "[]";
            
            List<int> values = new List<int>();
            ListNode current = head;
            
            while (current != null)
            {
                values.Add(current.val);
                current = current.next;
            }
            
            return "[" + string.Join(", ", values) + "]";
        }
    }
}