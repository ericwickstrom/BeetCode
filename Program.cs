using System;
using System.Linq;
using System.Reflection;
using BeetCode.Framework;
using BeetCode.Problems;

namespace BeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                ShowHelp();
                return;
            }

            string command = args[0].ToLower();

            switch (command)
            {
                case "test":
                    if (args.Length < 2 || !int.TryParse(args[1], out int testProblemNumber))
                    {
                        Console.WriteLine("Usage: dotnet run -- test <problem_number>");
                        return;
                    }
                    RunTest(testProblemNumber);
                    break;

                case "run":
                    if (args.Length < 2 || !int.TryParse(args[1], out int runProblemNumber))
                    {
                        Console.WriteLine("Usage: dotnet run -- run <problem_number>");
                        return;
                    }
                    RunProblem(runProblemNumber);
                    break;

                case "info":
                    if (args.Length < 2 || !int.TryParse(args[1], out int infoProblemNumber))
                    {
                        Console.WriteLine("Usage: dotnet run -- info <problem_number>");
                        return;
                    }
                    ShowProblemInfo(infoProblemNumber);
                    break;

                case "list":
                    ListProblems();
                    break;

                case "help":
                    ShowHelp();
                    break;

                default:
                    Console.WriteLine($"Unknown command: {command}");
                    ShowHelp();
                    break;
            }
        }

        static void RunTest(int problemNumber)
        {
            var problem = LoadProblem(problemNumber);
            if (problem == null) return;

            TestRunner.RunTests(problem);
        }

        static void RunProblem(int problemNumber)
        {
            var problem = LoadProblem(problemNumber);
            if (problem == null) return;

            problem.DisplayProblemInfo();
            Console.WriteLine("Running solution...\n");
            TestRunner.RunTests(problem);
        }

        static void ShowProblemInfo(int problemNumber)
        {
            var problem = LoadProblem(problemNumber);
            if (problem == null) return;

            problem.DisplayProblemInfo();
        }

        static void ListProblems()
        {
            Console.WriteLine("Available Problems:");
            Console.WriteLine(new string('-', 60));
            Console.WriteLine($"{"#",-4} {"Title",-30} {"Difficulty",-10} {"Status",-8}");
            Console.WriteLine(new string('-', 60));

            var problemTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.IsSubclassOf(typeof(Problem)) && !t.IsAbstract)
                .OrderBy(t => t.Name);

            int totalProblems = 0;
            int solvedProblems = 0;

            foreach (var type in problemTypes)
            {
                var problem = (Problem)Activator.CreateInstance(type);
                bool isSolved = problem.IsSolved();
                string status = isSolved ? "✅ SOLVED" : "❌ TODO";
                
                Console.WriteLine($"{problem.Number:D3}  {problem.Title,-30} {problem.Difficulty,-10} {status}");
                
                totalProblems++;
                if (isSolved) solvedProblems++;
            }

            Console.WriteLine(new string('-', 60));
            Console.WriteLine($"Progress: {solvedProblems}/{totalProblems} problems solved ({(double)solvedProblems/totalProblems*100:F1}%)");
        }

        static Problem LoadProblem(int problemNumber)
        {
            string className = $"Problem{problemNumber:D3}";
            var type = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == className && t.IsSubclassOf(typeof(Problem)));

            if (type == null)
            {
                Console.WriteLine($"Problem {problemNumber} not found. Make sure Problem{problemNumber:D3}.cs exists.");
                return null;
            }

            return (Problem)Activator.CreateInstance(type);
        }

        static void ShowHelp()
        {
            Console.WriteLine("BeetCode - LeetCode Practice Tool");
            Console.WriteLine(new string('=', 50));
            Console.WriteLine("Usage: dotnet run -- <command> [arguments]");
            Console.WriteLine();
            Console.WriteLine("Commands:");
            Console.WriteLine("  test <number>    Run tests for problem number");
            Console.WriteLine("  run <number>     Show problem info and run tests");
            Console.WriteLine("  info <number>    Show problem description");
            Console.WriteLine("  list             List all available problems");
            Console.WriteLine("  help             Show this help message");
            Console.WriteLine();
            Console.WriteLine("Examples:");
            Console.WriteLine("  dotnet run -- test 1      # Test Problem 1 (Two Sum)");
            Console.WriteLine("  dotnet run -- run 1       # Show info and test Problem 1");
            Console.WriteLine("  dotnet run -- info 1      # Show Problem 1 description");
            Console.WriteLine("  dotnet run -- list        # List all problems");
        }
    }
}