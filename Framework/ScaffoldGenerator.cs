using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BeetCode.Framework
{
	public static class ScaffoldGenerator
	{
		public static string Generate(LeetCodeProblem problem)
		{
			string description = BuildDescription(ConvertHtmlToPlainText(problem.ContentHtml));
			var examples = ExtractExamples(problem.ContentHtml);
			string testCases = BuildTestCases(examples);
			string paddedNumber = problem.Number.ToString("D3");

			var sb = new StringBuilder();
			sb.AppendLine("using BeetCode.Framework;");
			sb.AppendLine("using System.Collections.Generic;");
			sb.AppendLine();
			sb.AppendLine("namespace BeetCode.Problems");
			sb.AppendLine("{");
			sb.AppendLine($"\tpublic class Problem{paddedNumber} : Problem");
			sb.AppendLine("\t{");
			sb.AppendLine($"\t\tpublic override int Number => {problem.Number};");
			sb.AppendLine($"\t\tpublic override string Title => \"{EscapeCSharpString(problem.Title)}\";");
			sb.AppendLine($"\t\tpublic override string Difficulty => \"{problem.Difficulty}\";");
			sb.AppendLine($"\t\tpublic override string Description =>");
			sb.Append(description);
			sb.AppendLine();
			sb.AppendLine();
			sb.AppendLine("\t\tpublic override List<TestCase> GetTestCases()");
			sb.AppendLine("\t\t{");
			sb.AppendLine("\t\t\treturn new List<TestCase>");
			sb.AppendLine("\t\t\t{");
			sb.Append(testCases);
			sb.AppendLine("\t\t\t};");
			sb.AppendLine("\t\t}");
			sb.AppendLine();
			sb.AppendLine("\t\tpublic override object ExecuteSolution(object[] inputs)");
			sb.AppendLine("\t\t{");
			sb.AppendLine("\t\t\t// TODO: Cast inputs and call your solution method");
			sb.AppendLine("\t\t\tthrow new NotImplementedException();");
			sb.AppendLine("\t\t}");
			sb.AppendLine();
			sb.AppendLine("\t\t// YOUR SOLUTION GOES HERE");
			sb.AppendLine("\t\t// TODO: Add your solution method");
			sb.AppendLine("\t\t// public ReturnType MethodName(params)");
			sb.AppendLine("\t\t// {");
			sb.AppendLine("\t\t//     throw new NotImplementedException();");
			sb.AppendLine("\t\t// }");
			sb.AppendLine("\t}");
			sb.Append("}");
			sb.AppendLine();

			return sb.ToString();
		}

		private static string ConvertHtmlToPlainText(string html)
		{
			if (string.IsNullOrEmpty(html))
				return "";

			string text = html;

			// Handle superscripts: <sup>5</sup> -> ^5
			text = Regex.Replace(text, @"<sup>(.*?)</sup>", "^$1", RegexOptions.Singleline);

			// Handle subscripts: <sub>2</sub> -> _2
			text = Regex.Replace(text, @"<sub>(.*?)</sub>", "_$1", RegexOptions.Singleline);

			// Block elements to newlines
			text = Regex.Replace(text, @"<br\s*/?>", "\n");
			text = Regex.Replace(text, @"</p>", "\n");
			text = Regex.Replace(text, @"<p>", "");
			text = Regex.Replace(text, @"</div>", "\n");
			text = Regex.Replace(text, @"<div>", "");
			text = Regex.Replace(text, @"</pre>", "\n");
			text = Regex.Replace(text, @"<pre>", "\n");

			// List items
			text = Regex.Replace(text, @"<li>", "\u2022 ");
			text = Regex.Replace(text, @"</li>", "\n");
			text = Regex.Replace(text, @"</?[ou]l>", "\n");

			// Strip remaining HTML tags
			text = Regex.Replace(text, @"<[^>]+>", "");

			// Decode HTML entities
			text = text.Replace("&nbsp;", " ");
			text = text.Replace("&lt;", "<");
			text = text.Replace("&gt;", ">");
			text = text.Replace("&amp;", "&");
			text = text.Replace("&quot;", "\"");
			text = text.Replace("&#39;", "'");
			text = text.Replace("&le;", "<=");
			text = text.Replace("&ge;", ">=");
			text = text.Replace("&times;", "x");
			text = text.Replace("&minus;", "-");

			// Collapse multiple blank lines
			text = Regex.Replace(text, @"\n{3,}", "\n\n");

			return text.Trim();
		}

		private static string BuildDescription(string plainText)
		{
			var lines = plainText.Split('\n');
			var sb = new StringBuilder();

			for (int i = 0; i < lines.Length; i++)
			{
				string line = lines[i];
				string escaped = EscapeCSharpString(line);

				bool isLast = i == lines.Length - 1;
				string suffix = isLast ? "\";" : "\\n\" +";

				sb.AppendLine($"\t\t\t\"{escaped}{suffix}");
			}

			return sb.ToString().TrimEnd('\r', '\n');
		}

		private static List<(string Input, string Output)> ExtractExamples(string html)
		{
			var examples = new List<(string Input, string Output)>();
			if (string.IsNullOrEmpty(html))
				return examples;

			// Extract Input/Output pairs from HTML
			var inputMatches = Regex.Matches(html,
				@"<strong>Input:?\s*</strong>\s*(.+?)(?=<br|</p>|</pre>|\n|<strong>)",
				RegexOptions.Singleline);

			var outputMatches = Regex.Matches(html,
				@"<strong>Output:?\s*</strong>\s*(.+?)(?=<br|</p>|</pre>|\n|<strong>)",
				RegexOptions.Singleline);

			int count = Math.Min(inputMatches.Count, outputMatches.Count);
			for (int i = 0; i < count; i++)
			{
				string input = Regex.Replace(inputMatches[i].Groups[1].Value.Trim(), @"<[^>]+>", "").Trim();
				string output = Regex.Replace(outputMatches[i].Groups[1].Value.Trim(), @"<[^>]+>", "").Trim();
				examples.Add((input, output));
			}

			return examples;
		}

		private static string BuildTestCases(List<(string Input, string Output)> examples)
		{
			var sb = new StringBuilder();

			if (examples.Count == 0)
			{
				sb.AppendLine("\t\t\t\t// TODO: Add test cases");
				return sb.ToString();
			}

			for (int i = 0; i < examples.Count; i++)
			{
				var (input, output) = examples[i];
				sb.AppendLine($"\t\t\t\t// Input: {input}");
				sb.AppendLine($"\t\t\t\t// Expected output: {output}");
				sb.AppendLine($"\t\t\t\tnew TestCase(\"Example {i + 1}\",");
				sb.AppendLine($"\t\t\t\t\tnew object[] {{ /* TODO */ }},");
				sb.AppendLine($"\t\t\t\t\tnull /* TODO */),");
				sb.AppendLine();
			}

			sb.AppendLine("\t\t\t\t// TODO: Add edge cases beyond LeetCode examples");
			return sb.ToString();
		}

		private static string EscapeCSharpString(string s)
		{
			return s
				.Replace("\\", "\\\\")
				.Replace("\"", "\\\"")
				.Replace("\t", "\\t");
		}
	}
}
