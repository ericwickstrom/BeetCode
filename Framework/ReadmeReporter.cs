using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace BeetCode.Framework
{
	public static class ReadmeReporter
	{
		public static void UpdateReadme()
		{
			// Discover solved problems
			var solvedNumbers = GetSolvedProblemNumbers();

			// Find README.md
			string readmePath = FindReadmePath();
			if (readmePath == null)
			{
				Console.WriteLine("Could not locate README.md.");
				return;
			}

			var lines = File.ReadAllLines(readmePath).ToList();

			// Track per-difficulty solved counts and totals
			string currentDifficulty = null;
			var difficultySolved = new Dictionary<string, int>
			{
				["Easy"] = 0,
				["Medium"] = 0,
				["Hard"] = 0
			};
			var difficultyTotal = new Dictionary<string, int>();
			// Map from difficulty to the line index of its header
			var difficultyHeaderIndex = new Dictionary<string, int>();

			// Regex for problem lines: ✅ or - [ ] followed by number · title
			var problemPattern = new Regex(@"^(✅|- \[ \]) (\d+) · (.+)$");
			// Regex for difficulty headers (use alternation for supplementary Unicode emojis)
			var difficultyPattern = new Regex(@"^## (?:🟢|🟡|🔴) (Easy|Medium|Hard) \((\d+) problems — (\d+) / (\d+)\)$");
			// Regex for overall summary
			var summaryPattern = new Regex(@"^\*\*Completed: \d+ / \d+\*\*$");

			// First pass: update problem lines and count per difficulty
			for (int i = 0; i < lines.Count; i++)
			{
				var diffMatch = difficultyPattern.Match(lines[i]);
				if (diffMatch.Success)
				{
					currentDifficulty = diffMatch.Groups[1].Value;
					difficultyHeaderIndex[currentDifficulty] = i;
					difficultyTotal[currentDifficulty] = int.Parse(diffMatch.Groups[4].Value);
					continue;
				}

				var probMatch = problemPattern.Match(lines[i]);
				if (probMatch.Success && currentDifficulty != null)
				{
					int number = int.Parse(probMatch.Groups[2].Value);
					string title = probMatch.Groups[3].Value;
					bool solved = solvedNumbers.Contains(number);

					if (solved)
					{
						difficultySolved[currentDifficulty]++;
						lines[i] = $"✅ {number} · {title}";
					}
					else
					{
						lines[i] = $"- [ ] {number} · {title}";
					}
				}
			}

			int totalSolved = difficultySolved.Values.Sum();
			int totalProblems = difficultyTotal.Values.Sum();

			// Second pass: update summary and difficulty headers
			for (int i = 0; i < lines.Count; i++)
			{
				if (summaryPattern.IsMatch(lines[i]))
				{
					lines[i] = $"**Completed: {totalSolved} / {totalProblems}**";
				}
			}

			foreach (var kvp in difficultyHeaderIndex)
			{
				string diff = kvp.Key;
				int idx = kvp.Value;
				int total = difficultyTotal[diff];
				int solved = difficultySolved[diff];

				string emoji = diff switch
				{
					"Easy" => "🟢",
					"Medium" => "🟡",
					"Hard" => "🔴",
					_ => ""
				};

				lines[idx] = $"## {emoji} {diff} ({total} problems — {solved} / {total})";
			}

			File.WriteAllLines(readmePath, lines);

			// Console output
			Console.WriteLine("README.md updated!");
			Console.WriteLine();
			Console.WriteLine($"  Blind 150 Progress: {totalSolved} / {totalProblems}");
			foreach (var diff in new[] { "Easy", "Medium", "Hard" })
			{
				if (difficultyTotal.ContainsKey(diff))
					Console.WriteLine($"  {diff,-8} {difficultySolved[diff]} / {difficultyTotal[diff]}");
			}
		}

		private static HashSet<int> GetSolvedProblemNumbers()
		{
			var solved = new HashSet<int>();
			var problemTypes = Assembly.GetExecutingAssembly()
				.GetTypes()
				.Where(t => t.IsSubclassOf(typeof(Problem)) && !t.IsAbstract);

			foreach (var type in problemTypes)
			{
				var problem = (Problem)Activator.CreateInstance(type);
				if (problem.IsSolved())
				{
					solved.Add(problem.Number);
				}
			}

			return solved;
		}

		private static string FindReadmePath()
		{
			string dir = Directory.GetCurrentDirectory();
			for (int i = 0; i < 5; i++)
			{
				string candidate = Path.Combine(dir, "README.md");
				if (File.Exists(candidate))
					return candidate;
				dir = Directory.GetParent(dir)?.FullName ?? dir;
			}
			return null;
		}
	}
}
