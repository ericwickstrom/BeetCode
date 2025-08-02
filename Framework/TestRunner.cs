using System;
using System.Collections.Generic;
using System.Linq;

namespace BeetCode.Framework
{
    public static class TestRunner
    {
        public static void RunTests(Problem problem)
        {
            Console.WriteLine($"Running tests for Problem {problem.Number}: {problem.Title}");
            Console.WriteLine(new string('-', 50));

            var testCases = problem.GetTestCases();
            int passed = 0;
            int total = testCases.Count;

            for (int i = 0; i < testCases.Count; i++)
            {
                var testCase = testCases[i];
                Console.Write($"{testCase.Name}: ");

                try
                {
                    var result = problem.ExecuteSolution(testCase.Input);
                    bool success = AreEqual(result, testCase.Expected);
                    
                    if (success)
                    {
                        Console.WriteLine("PASS");
                        passed++;
                    }
                    else
                    {
                        Console.WriteLine("FAIL");
                        Console.WriteLine($"  Expected: {FormatResult(testCase.Expected)}");
                        Console.WriteLine($"  Actual:   {FormatResult(result)}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR");
                    Console.WriteLine($"  Exception: {ex.Message}");
                }

                Console.WriteLine();
            }

            Console.WriteLine(new string('-', 50));
            Console.WriteLine($"Results: {passed}/{total} tests passed");
            
            if (passed == total)
            {
                Console.WriteLine("All tests passed! 🎉");
            }
        }

        private static bool AreEqual(object actual, object expected)
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

        private static string FormatResult(object result)
        {
            if (result == null) return "null";
            
            if (result is Array array)
            {
                return "[" + string.Join(", ", array.Cast<object>()) + "]";
            }

            return result.ToString();
        }
    }
}