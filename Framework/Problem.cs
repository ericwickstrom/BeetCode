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

        private bool AreEqual(object actual, object expected)
        {
            if (actual == null && expected == null) return true;
            if (actual == null || expected == null) return false;

            // Handle arrays
            if (actual is Array actualArray && expected is Array expectedArray)
            {
                return actualArray.Cast<object>().SequenceEqual(expectedArray.Cast<object>());
            }

            return actual.Equals(expected);
        }
    }
}