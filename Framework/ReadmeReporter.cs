using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace BeetCode.Framework
{
	public static class ReadmeReporter
	{
		public static void UpdateReadme()
		{
			// Discover solved problems
			var solvedNumbers = GetSolvedProblemNumbers();

			// Load problem sets
			var problemSets = LoadProblemSets();
			var problemTags = BuildProblemTags(problemSets);

			// Find README.md
			string readmePath = FindFile("README.md");
			if (readmePath == null)
			{
				Console.WriteLine("Could not locate README.md.");
				return;
			}

			var lines = File.ReadAllLines(readmePath).ToList();

			// Track per-difficulty solved counts and totals
			string currentDifficulty = null;
			var difficultySolved = new Dictionary<string, int>();
			var difficultyTotal = new Dictionary<string, int>();
			var difficultyHeaderIndex = new Dictionary<string, int>();

			// Regex for problem lines: ✅ or - [ ] followed by number · title (possibly with trailing emoji tags)
			var problemPattern = new Regex(@"^(✅|🔲|- \[ \]) (\d+) · (.+)$");
			// Regex for difficulty headers (use alternation for supplementary Unicode emojis)
			var difficultyPattern = new Regex(@"^## (?:🟢|🟡|🔴) (Easy|Medium|Hard) \((\d+) problems — (\d+) / (\d+)\)$");
			// Collect all known set emojis for stripping
			var knownEmojis = problemSets.Select(s => s.Emoji).ToHashSet();

			// First pass: update problem lines and count per difficulty
			for (int i = 0; i < lines.Count; i++)
			{
				var diffMatch = difficultyPattern.Match(lines[i]);
				if (diffMatch.Success)
				{
					currentDifficulty = diffMatch.Groups[1].Value;
					difficultyHeaderIndex[currentDifficulty] = i;
					difficultySolved[currentDifficulty] = 0;
					difficultyTotal[currentDifficulty] = 0;
					continue;
				}

				var probMatch = problemPattern.Match(lines[i]);
				if (probMatch.Success && currentDifficulty != null)
				{
					int number = int.Parse(probMatch.Groups[2].Value);
					string rawTitle = probMatch.Groups[3].Value;

					// Strip existing emoji tags from title for idempotency
					string title = StripTrailingEmojis(rawTitle, knownEmojis);

					bool solved = solvedNumbers.Contains(number);
					string prefix = solved ? "✅" : "🔲";

					// Build tag suffix
					string tags = "";
					if (problemTags.TryGetValue(number, out var emojis))
						tags = " " + string.Join(" ", emojis);

					difficultyTotal[currentDifficulty]++;
					if (solved)
						difficultySolved[currentDifficulty]++;

					lines[i] = $"{prefix} {number} · {title}{tags}";
				}
			}

			// Update difficulty headers with counted totals
			foreach (var kvp in difficultyHeaderIndex)
			{
				string diff = kvp.Key;
				int idx = kvp.Value;
				int total = difficultyTotal.GetValueOrDefault(diff, 0);
				int solved = difficultySolved.GetValueOrDefault(diff, 0);

				string emoji = diff switch
				{
					"Easy" => "🟢",
					"Medium" => "🟡",
					"Hard" => "🔴",
					_ => ""
				};

				lines[idx] = $"## {emoji} {diff} ({total} problems — {solved} / {total})";
			}

			// Update summary section
			UpdateSummarySection(lines, solvedNumbers, problemSets);

			// Ensure a blank line between consecutive problem entries so markdown renders each on its own line
			for (int i = lines.Count - 2; i >= 0; i--)
			{
				if (problemPattern.IsMatch(lines[i]) && problemPattern.IsMatch(lines[i + 1]))
					lines.Insert(i + 1, "");
			}

			File.WriteAllLines(readmePath, lines);

			// Console output
			int totalSolved = solvedNumbers.Count;
			Console.WriteLine("README.md updated!");
			Console.WriteLine();
			Console.WriteLine($"  Total Solved: {totalSolved}");
			foreach (var set in problemSets)
			{
				int setSolved = set.Problems.Count(p => solvedNumbers.Contains(p));
				Console.WriteLine($"  {set.Emoji} {set.Name}: {setSolved} / {set.Problems.Count}");
			}
			foreach (var diff in new[] { "Easy", "Medium", "Hard" })
			{
				if (difficultyTotal.ContainsKey(diff))
					Console.WriteLine($"  {diff,-8} {difficultySolved[diff]} / {difficultyTotal[diff]}");
			}
		}

		private static void UpdateSummarySection(List<string> lines, HashSet<int> solvedNumbers, List<ProblemSet> problemSets)
		{
			// Find the summary line (either old format or new format)
			var oldSummaryPattern = new Regex(@"^\*\*Completed: \d+ / \d+\*\*$");
			var newSummaryPattern = new Regex(@"^\*\*Total Solved: \d+\*\*$");

			int summaryLineIndex = -1;
			for (int i = 0; i < lines.Count; i++)
			{
				if (oldSummaryPattern.IsMatch(lines[i]) || newSummaryPattern.IsMatch(lines[i]))
				{
					summaryLineIndex = i;
					break;
				}
			}

			if (summaryLineIndex == -1) return;

			// Find the extent of the old summary block (summary line + any table lines after it)
			int blockEnd = summaryLineIndex + 1;
			// Skip blank lines
			while (blockEnd < lines.Count && string.IsNullOrWhiteSpace(lines[blockEnd]))
				blockEnd++;
			// Skip table lines (| ... |)
			while (blockEnd < lines.Count && lines[blockEnd].StartsWith("|"))
				blockEnd++;
			// Skip trailing blank lines after table
			while (blockEnd < lines.Count && string.IsNullOrWhiteSpace(lines[blockEnd]))
				blockEnd++;

			// Build new summary block
			var summaryBlock = new List<string>();
			summaryBlock.Add($"**Total Solved: {solvedNumbers.Count}**");

			if (problemSets.Count > 0)
			{
				summaryBlock.Add("");
				summaryBlock.Add("| Set | Progress |");
				summaryBlock.Add("|-----|----------|");
				foreach (var set in problemSets)
				{
					int setSolved = set.Problems.Count(p => solvedNumbers.Contains(p));
					summaryBlock.Add($"| {set.Emoji} {set.Name} | {setSolved} / {set.Problems.Count} |");
				}
			}

			summaryBlock.Add("");

			// Replace the old block
			lines.RemoveRange(summaryLineIndex, blockEnd - summaryLineIndex);
			lines.InsertRange(summaryLineIndex, summaryBlock);
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

		private static string StripTrailingEmojis(string title, HashSet<string> knownEmojis)
		{
			string result = title.TrimEnd();
			bool changed = true;
			while (changed)
			{
				changed = false;
				foreach (var emoji in knownEmojis)
				{
					if (result.EndsWith(emoji))
					{
						result = result.Substring(0, result.Length - emoji.Length).TrimEnd();
						changed = true;
					}
				}
			}
			return result;
		}

		private static List<ProblemSet> LoadProblemSets()
		{
			string path = FindFile("ProblemSets.json");
			if (path == null)
				return new List<ProblemSet>();

			string json = File.ReadAllText(path);
			var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
			return JsonSerializer.Deserialize<List<ProblemSet>>(json, options) ?? new List<ProblemSet>();
		}

		private static Dictionary<int, List<string>> BuildProblemTags(List<ProblemSet> sets)
		{
			var tags = new Dictionary<int, List<string>>();
			foreach (var set in sets)
			{
				foreach (int problem in set.Problems)
				{
					if (!tags.ContainsKey(problem))
						tags[problem] = new List<string>();
					tags[problem].Add(set.Emoji);
				}
			}
			return tags;
		}

		private static string FindFile(string fileName)
		{
			string dir = Directory.GetCurrentDirectory();
			for (int i = 0; i < 5; i++)
			{
				string candidate = Path.Combine(dir, fileName);
				if (File.Exists(candidate))
					return candidate;
				dir = Directory.GetParent(dir)?.FullName ?? dir;
			}
			return null;
		}

		private class ProblemSet
		{
			public string Name { get; set; }
			public string Emoji { get; set; }
			public List<int> Problems { get; set; }
		}
	}
}
