using System.Collections.Generic;

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
    }
}