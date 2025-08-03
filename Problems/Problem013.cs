using BeetCode.Framework;
using System.Collections.Generic;

namespace BeetCode.Problems
{
    public class Problem013 : Problem
    {
        public override int Number => 13;
        public override string Title => "Roman to Integer";
        public override string Difficulty => "Easy";
        public override string Description => 
            "Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.\n\n" +
            "Symbol       Value\n" +
            "I             1\n" +
            "V             5\n" +
            "X             10\n" +
            "L             50\n" +
            "C             100\n" +
            "D             500\n" +
            "M             1000\n\n" +
            "For example, 2 is written as II in Roman numeral, just two ones added together. 12 is written as XII, which is simply X + II. The number 27 is written as XXVII, which is XX + V + II.\n\n" +
            "Roman numerals are usually written largest to smallest from left to right. However, the numeral for four is not IIII. Instead, the number four is written as IV. Because the one is before the five we subtract it making four. The same principle applies to the number nine, which is written as IX. There are six instances where subtraction is used:\n\n" +
            "• I can be placed before V (5) and X (10) to make 4 and 9.\n" +
            "• X can be placed before L (50) and C (100) to make 40 and 90.\n" +
            "• C can be placed before D (500) and M (1000) to make 400 and 900.\n\n" +
            "Given a roman numeral, convert it to an integer.\n\n" +
            "Example 1:\n" +
            "Input: s = \"III\"\n" +
            "Output: 3\n" +
            "Explanation: III = 3.\n\n" +
            "Example 2:\n" +
            "Input: s = \"LVIII\"\n" +
            "Output: 58\n" +
            "Explanation: L = 50, V= 5, III = 3.\n\n" +
            "Example 3:\n" +
            "Input: s = \"MCMXC\"\n" +
            "Output: 1990\n" +
            "Explanation: M = 1000, CM = 900, XC = 90.\n\n" +
            "Constraints:\n" +
            "• 1 <= s.length <= 15\n" +
            "• s contains only the characters ('I', 'V', 'X', 'L', 'C', 'D', 'M').\n" +
            "• It is guaranteed that s is a valid roman numeral in the range [1, 3999].";

        public override List<TestCase> GetTestCases()
        {
            return new List<TestCase>
            {
                new TestCase("Example 1 - Simple", 
                    new object[] { "III" }, 
                    3),
                
                new TestCase("Example 2 - Mixed", 
                    new object[] { "LVIII" }, 
                    58),
                
                new TestCase("Example 3 - Subtractive", 
                    new object[] { "MCMXC" }, 
                    1990),

                new TestCase("Single character", 
                    new object[] { "V" }, 
                    5),

                new TestCase("Subtractive IV", 
                    new object[] { "IV" }, 
                    4),

                new TestCase("Subtractive IX", 
                    new object[] { "IX" }, 
                    9),

                new TestCase("Subtractive XL", 
                    new object[] { "XL" }, 
                    40),

                new TestCase("Subtractive XC", 
                    new object[] { "XC" }, 
                    90),

                new TestCase("Subtractive CD", 
                    new object[] { "CD" }, 
                    400),

                new TestCase("Subtractive CM", 
                    new object[] { "CM" }, 
                    900),

                new TestCase("Complex number", 
                    new object[] { "MCDXLIV" }, 
                    1444),

                new TestCase("Large number", 
                    new object[] { "MMMCMXCIX" }, 
                    3999)
            };
        }

        public override object ExecuteSolution(object[] inputs)
        {
            return RomanToInt((string)inputs[0]);
        }

        // YOUR SOLUTION GOES HERE
        public int RomanToInt(string s)
        {
            // TODO: Implement your solution
            throw new NotImplementedException();
        }
    }
}