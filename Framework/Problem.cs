using System.Collections.Generic;
using System.Linq;

namespace BeetCode.Framework
{
    public abstract class Problem
    {
        public abstract int Number { get; }
        public abstract string Title { get; }
        public abstract string Difficulty { get; }
        public abstract string Description { get; }

        public abstract List<TestCase> GetTestCases();
        public abstract object ExecuteSolution(object[] inputs);

        public void DisplayProblemInfo()
        {
            Console.WriteLine($"Problem {Number}: {Title}");
            Console.WriteLine($"Difficulty: {Difficulty}");
            Console.WriteLine();
            Console.WriteLine(Description);
            Console.WriteLine();
        }

        public bool IsSolved()
        {
            try
            {
                var testCases = GetTestCases();
                if (testCases.Count == 0) return false;

                foreach (var testCase in testCases)
                {
                    var result = ExecuteSolution(testCase.Input);
                    bool success = AreEqual(result, testCase.Expected);
                    if (!success) return false;
                }
                return true;
            }
            catch (NotImplementedException)
            {
                return false;
            }
            catch
            {
                return false;
            }
        }

        protected virtual bool AreEqual(object actual, object expected)
        {
            if (actual == null && expected == null) return true;
            if (actual == null || expected == null) return false;

            // Handle ListNode comparisons
            if (actual is ListNode actualList && expected is ListNode expectedList)
            {
                return AreLinkedListsEqual(actualList, expectedList);
            }

            // Handle TreeNode comparisons
            if (actual is TreeNode actualTree && expected is TreeNode expectedTree)
            {
                return AreTreesEqual(actualTree, expectedTree);
            }

            // Handle arrays
            if (actual is Array actualArray && expected is Array expectedArray)
            {
                return actualArray.Cast<object>().SequenceEqual(expectedArray.Cast<object>());
            }

            return actual.Equals(expected);
        }

        // Helper method for comparing linked lists
        private bool AreLinkedListsEqual(ListNode list1, ListNode list2)
        {
            while (list1 != null && list2 != null)
            {
                if (list1.val != list2.val)
                    return false;
                list1 = list1.next;
                list2 = list2.next;
            }
            
            // Both should be null at the end
            return list1 == null && list2 == null;
        }

        private bool AreTreesEqual(TreeNode node1, TreeNode node2)
        {
            if (node1 == null && node2 == null) return true;
            if (node1 == null || node2 == null) return false;
            return node1.val == node2.val
                && AreTreesEqual(node1.left, node2.left)
                && AreTreesEqual(node1.right, node2.right);
        }

        // Helper method to create a binary tree from level-order array
        protected TreeNode? CreateTree(int?[] values)
        {
            if (values == null || values.Length == 0 || values[0] == null) return null;

            TreeNode root = new TreeNode(values[0].Value);
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int i = 1;

            while (i < values.Length && queue.Count > 0)
            {
                TreeNode current = queue.Dequeue();

                if (i < values.Length && values[i] != null)
                {
                    current.left = new TreeNode(values[i].Value);
                    queue.Enqueue(current.left);
                }
                i++;

                if (i < values.Length && values[i] != null)
                {
                    current.right = new TreeNode(values[i].Value);
                    queue.Enqueue(current.right);
                }
                i++;
            }

            return root;
        }

        // Helper method to convert linked list to array for display
        protected int[] LinkedListToArray(ListNode head)
        {
            if (head == null) return new int[0];

            List<int> values = new List<int>();
            ListNode current = head;

            while (current != null)
            {
                values.Add(current.val);
                current = current.next;
            }

            return values.ToArray();
        }

        // Helper method to create linked list from array
        protected ListNode? CreateLinkedList(int[] values)
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
    }
}