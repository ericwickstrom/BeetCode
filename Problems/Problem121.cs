using BeetCode.Framework;
using System.Collections.Generic;

namespace BeetCode.Problems
{
    public class Problem121 : Problem
    {
        public override int Number => 121;
        public override string Title => "Best Time to Buy and Sell Stock";
        public override string Difficulty => "Easy";
        public override string Description =>
            "You are given an array prices where prices[i] is the price of a given stock on the ith day.\n\n" +
            "You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.\n\n" +
            "Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.\n\n" +
            "Example 1:\n" +
            "Input: prices = [7,1,5,3,6,4]\n" +
            "Output: 5\n" +
            "Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.\n" +
            "Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.\n\n" +
            "Example 2:\n" +
            "Input: prices = [7,6,4,3,1]\n" +
            "Output: 0\n" +
            "Explanation: In this case, no transactions are done and the max profit = 0.\n\n" +
            "Constraints:\n" +
            "• 1 <= prices.length <= 10^5\n" +
            "• 0 <= prices[i] <= 10^4";

        public override List<TestCase> GetTestCases()
        {
            return new List<TestCase>
            {
                new TestCase("Example 1 - Normal case",
                    new object[] { new int[] {7, 1, 5, 3, 6, 4} },
                    5),

                new TestCase("Example 2 - Decreasing prices",
                    new object[] { new int[] {7, 6, 4, 3, 1} },
                    0),

                new TestCase("Single element",
                    new object[] { new int[] {1} },
                    0),

                new TestCase("Two elements - profit",
                    new object[] { new int[] {1, 5} },
                    4),

                new TestCase("Two elements - no profit",
                    new object[] { new int[] {5, 1} },
                    0),

                new TestCase("All same prices",
                    new object[] { new int[] {3, 3, 3, 3} },
                    0),

                new TestCase("Increasing prices",
                    new object[] { new int[] {1, 2, 3, 4, 5} },
                    4),

                new TestCase("Large profit at end",
                    new object[] { new int[] {2, 4, 1, 16, 3} },
                    15),

                new TestCase("Minimum at beginning",
                    new object[] { new int[] {1, 7, 2, 8, 3} },
                    7),

                new TestCase("Zero prices",
                    new object[] { new int[] {0, 6, 7, 1, 3} },
                    7)
            };
        }

        public override object ExecuteSolution(object[] inputs)
        {
            return MaxProfit((int[])inputs[0]);
        }

        // YOUR SOLUTION GOES HERE
        public int MaxProfit(int[] prices)
        {
            if(prices == null || prices.Length < 2) return 0;

            int low = int.MaxValue;
            int profit = int.MinValue;

            foreach(int i in prices)
            {
                if(i < low) 
                    low = i;      
                int newProfit = i - low;
                if(newProfit > profit)
                    profit = newProfit;
            }

            return profit;
        }
    }
}