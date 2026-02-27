using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;

namespace BeetCode.Framework
{
	public class LeetCodeProblem
	{
		public int Number { get; set; }
		public string Title { get; set; } = "";
		public string Difficulty { get; set; } = "";
		public string ContentHtml { get; set; } = "";
		public string ExampleTestcases { get; set; } = "";
		public bool IsPaidOnly { get; set; }
	}

	public class LeetCodeClient : IDisposable
	{
		private const string DataUrl = "https://leetcode-api-pied.vercel.app/data/leetcode_questions.json";
		private readonly HttpClient _client;

		public LeetCodeClient()
		{
			_client = new HttpClient();
			_client.Timeout = TimeSpan.FromSeconds(60);
		}

		public LeetCodeProblem FetchProblem(int problemNumber)
		{
			string cachePath = GetCachePath();
			string json = LoadOrDownloadCache(cachePath);

			using var doc = JsonDocument.Parse(json);
			var root = doc.RootElement;

			foreach (var item in root.EnumerateArray())
			{
				var question = item.GetProperty("data").GetProperty("question");
				string frontendId = question.GetProperty("questionFrontendId").GetString() ?? "";

				if (frontendId == problemNumber.ToString())
				{
					return new LeetCodeProblem
					{
						Number = problemNumber,
						Title = question.GetProperty("title").GetString() ?? "",
						Difficulty = question.GetProperty("difficulty").GetString() ?? "",
						ContentHtml = question.GetProperty("content").GetString() ?? "",
						IsPaidOnly = question.GetProperty("isPaidOnly").GetBoolean(),
					};
				}
			}

			throw new Exception($"Problem {problemNumber} not found in LeetCode data.");
		}

		public void UpdateCache()
		{
			string cachePath = GetCachePath();
			Console.WriteLine("Downloading LeetCode problem data...");
			DownloadCache(cachePath);
			Console.WriteLine($"✅ Cache updated ({new FileInfo(cachePath).Length / 1024 / 1024}MB)");
		}

		private string LoadOrDownloadCache(string cachePath)
		{
			if (File.Exists(cachePath))
				return File.ReadAllText(cachePath);

			Console.WriteLine("First run — downloading LeetCode problem data (this may take a moment)...");
			DownloadCache(cachePath);
			return File.ReadAllText(cachePath);
		}

		private void DownloadCache(string cachePath)
		{
			string dir = Path.GetDirectoryName(cachePath)!;
			if (!Directory.Exists(dir))
				Directory.CreateDirectory(dir);

			var response = _client.GetAsync(DataUrl).GetAwaiter().GetResult();
			response.EnsureSuccessStatusCode();

			string json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
			File.WriteAllText(cachePath, json);
		}

		private static string GetCachePath()
		{
			string dir = ResetHelper.FindProblemsDirectory();
			if (dir != null)
			{
				// Store cache alongside the Problems directory
				string root = Path.GetDirectoryName(dir)!;
				return Path.Combine(root, "Framework", "leetcode_data.json");
			}

			// Fallback to current directory
			return Path.Combine(Directory.GetCurrentDirectory(), "leetcode_data.json");
		}

		public void Dispose()
		{
			_client.Dispose();
		}
	}
}
