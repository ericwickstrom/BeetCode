using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            var performanceResults = new List<(string name, long timeTicks, long memoryBytes, bool success)>();

            for (int i = 0; i < testCases.Count; i++)
            {
                var testCase = testCases[i];
                Console.Write($"{testCase.Name}: ");

                try
                {
                    // Force garbage collection for more accurate memory measurement
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();

                    var memoryBefore = GC.GetTotalMemory(false);
                    var stopwatch = Stopwatch.StartNew();

                    var result = problem.ExecuteSolution(testCase.Input);
                    
                    stopwatch.Stop();
                    var memoryAfter = GC.GetTotalMemory(false);
                    var memoryUsed = Math.Max(0, memoryAfter - memoryBefore); // Ensure non-negative

                    bool success = AreEqual(result, testCase.Expected);
                    
                    if (success)
                    {
                        Console.WriteLine($"PASS - {FormatTime(stopwatch.Elapsed)}, {FormatMemory(memoryUsed)}");
                        passed++;
                    }
                    else
                    {
                        Console.WriteLine($"FAIL - {FormatTime(stopwatch.Elapsed)}, {FormatMemory(memoryUsed)}");
                        Console.WriteLine($"  Expected: {FormatResult(testCase.Expected)}");
                        Console.WriteLine($"  Actual:   {FormatResult(result)}");
                    }

                    performanceResults.Add((testCase.Name, stopwatch.ElapsedTicks, memoryUsed, success));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR");
                    Console.WriteLine($"  Exception: {ex.Message}");
                    performanceResults.Add((testCase.Name, 0, 0, false));
                }

                Console.WriteLine();
            }

            Console.WriteLine(new string('-', 50));
            Console.WriteLine($"Results: {passed}/{total} tests passed");
            
            if (passed == total)
            {
                Console.WriteLine("All tests passed! 🎉");
            }

            // Performance Summary
            if (performanceResults.Any(r => r.success))
            {
                var successfulResults = performanceResults.Where(r => r.success).ToList();
                var totalTicks = successfulResults.Sum(r => r.timeTicks);
                var avgTicks = successfulResults.Average(r => r.timeTicks);
                var maxTicks = successfulResults.Max(r => r.timeTicks);
                var totalMemory = successfulResults.Sum(r => r.memoryBytes);

                Console.WriteLine();
                Console.WriteLine("Performance Summary:");
                Console.WriteLine($"Total Time: {FormatTime(TimeSpan.FromTicks(totalTicks))} | Avg Time: {FormatTime(TimeSpan.FromTicks((long)avgTicks))} | Max Time: {FormatTime(TimeSpan.FromTicks(maxTicks))}");
                Console.WriteLine($"Total Memory: {FormatMemory(totalMemory)}");
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

        private static string FormatTime(TimeSpan elapsed)
        {
            if (elapsed.TotalMilliseconds >= 1)
                return $"{elapsed.TotalMilliseconds:F1}ms";
            
            var totalMicroseconds = elapsed.TotalMilliseconds * 1000;
            if (totalMicroseconds >= 1)
                return $"{totalMicroseconds:F1}μs";
            
            var totalNanoseconds = elapsed.TotalMilliseconds * 1000000;
            return $"{totalNanoseconds:F0}ns";
        }

        private static string FormatMemory(long bytes)
        {
            if (bytes < 1024) return $"{bytes}B";
            if (bytes < 1024 * 1024) return $"{bytes / 1024.0:F1}KB";
            return $"{bytes / (1024.0 * 1024.0):F1}MB";
        }
    }
}