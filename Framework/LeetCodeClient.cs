using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace BeetCode.Framework
{
	public class LeetCodeProblem
	{
		public int Number { get; set; }
		public string Title { get; set; } = "";
		public string Difficulty { get; set; } = "";
		public string ContentHtml { get; set; } = "";
		public bool IsPaidOnly { get; set; }
		public string Slug { get; set; } = "";
		public string CodeSnippetCSharp { get; set; } = "";
		public string MetaDataJson { get; set; } = "";
		public List<string> ExampleTestcaseList { get; set; } = new();
		public bool IsClassBased { get; set; }
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
					string url = question.GetProperty("url").GetString() ?? "";
					string slug = ExtractSlug(url);

					var problem = new LeetCodeProblem
					{
						Number = problemNumber,
						Title = question.GetProperty("title").GetString() ?? "",
						Difficulty = question.GetProperty("difficulty").GetString() ?? "",
						ContentHtml = question.GetProperty("content").GetString() ?? "",
						IsPaidOnly = question.GetProperty("isPaidOnly").GetBoolean(),
						Slug = slug,
					};

					if (!string.IsNullOrEmpty(slug))
						FetchGraphQLData(problem, slug);

					return problem;
				}
			}

			throw new Exception($"Problem {problemNumber} not found in LeetCode data.");
		}

		private static string ExtractSlug(string url)
		{
			// https://leetcode.com/problems/two-sum/ -> two-sum
			var parts = url.TrimEnd('/').Split('/');
			return parts.Length > 0 ? parts[^1] : "";
		}

		private void FetchGraphQLData(LeetCodeProblem problem, string slug)
		{
			try
			{
				string query = "{\"query\":\"{ question(titleSlug: \\\"" + slug + "\\\") { codeSnippets { langSlug code } metaData exampleTestcaseList } }\"}";

				var request = new HttpRequestMessage(HttpMethod.Post, "https://leetcode.com/graphql");
				request.Content = new StringContent(query, Encoding.UTF8, "application/json");
				request.Headers.Add("Referer", "https://leetcode.com");
				request.Headers.Add("Origin", "https://leetcode.com");
				request.Headers.UserAgent.ParseAdd("Mozilla/5.0");

				var response = _client.SendAsync(request).GetAwaiter().GetResult();
				response.EnsureSuccessStatusCode();

				string responseJson = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
				using var responseDoc = JsonDocument.Parse(responseJson);
				var questionData = responseDoc.RootElement.GetProperty("data").GetProperty("question");

				// Extract C# code snippet
				foreach (var snippet in questionData.GetProperty("codeSnippets").EnumerateArray())
				{
					if (snippet.GetProperty("langSlug").GetString() == "csharp")
					{
						problem.CodeSnippetCSharp = snippet.GetProperty("code").GetString() ?? "";
						break;
					}
				}

				// Extract metaData
				problem.MetaDataJson = questionData.GetProperty("metaData").GetString() ?? "";

				// Determine if class-based
				if (!string.IsNullOrEmpty(problem.MetaDataJson))
				{
					using var metaDoc = JsonDocument.Parse(problem.MetaDataJson);
					problem.IsClassBased = metaDoc.RootElement.TryGetProperty("classname", out _);
				}

				// Extract example test case list
				foreach (var testCase in questionData.GetProperty("exampleTestcaseList").EnumerateArray())
				{
					problem.ExampleTestcaseList.Add(testCase.GetString() ?? "");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"⚠️  Could not fetch code snippets from LeetCode: {ex.Message}");
				Console.WriteLine("   Falling back to basic scaffold.");
			}
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
