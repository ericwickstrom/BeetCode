using BeetCode.Framework;
using System;
using System.Collections.Generic;

namespace BeetCode.Problems
{
    public class Problem252 : Problem
    {
        public override int Number => 252;
        public override string Title => "Meeting Rooms";
        public override string Difficulty => "Easy";
        public override string Description =>
            "Given an array of meeting time intervals where intervals[i] = [starti, endi], determine if a person could attend all meetings.\n\n" +
            "Example 1:\n" +
            "Input: intervals = [[0,30],[5,10],[15,20]]\n" +
            "Output: false\n\n" +
            "Example 2:\n" +
            "Input: intervals = [[7,10],[2,4]]\n" +
            "Output: true\n\n" +
            "Constraints:\n" +
            "• 0 <= intervals.length <= 10^4\n" +
            "• intervals[i].length == 2\n" +
            "• 0 <= starti < endi <= 10^6";

        public override List<TestCase> GetTestCases()
        {
            return new List<TestCase>
            {
                new TestCase("Example 1",
                    new object[] { new int[][] { new int[] {0, 30}, new int[] {5, 10}, new int[] {15, 20} } },
                    false),

                new TestCase("Example 2",
                    new object[] { new int[][] { new int[] {7, 10}, new int[] {2, 4} } },
                    true),

                new TestCase("Empty intervals",
                    new object[] { new int[][] { } },
                    true),

                new TestCase("Single meeting",
                    new object[] { new int[][] { new int[] {5, 10} } },
                    true),

                new TestCase("Back-to-back meetings (no overlap)",
                    new object[] { new int[][] { new int[] {1, 5}, new int[] {5, 10} } },
                    true),

                new TestCase("Overlapping at start",
                    new object[] { new int[][] { new int[] {1, 10}, new int[] {2, 3} } },
                    false)
            };
        }

        public override object ExecuteSolution(object[] inputs)
        {
            return new Solution().CanAttendMeetings((int[][])inputs[0]);
        }

        public class Solution
        {
            // YOUR SOLUTION GOES HERE
            public bool CanAttendMeetings(int[][] intervals)
            {
                throw new NotImplementedException();
            }
        }
    }
}
