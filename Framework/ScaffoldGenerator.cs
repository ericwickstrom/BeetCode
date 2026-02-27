using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace BeetCode.Framework
{
	public static class ScaffoldGenerator
	{
		private static readonly Dictionary<string, string> TypeMap = new()
		{
			{ "integer", "int" },
			{ "integer[]", "int[]" },
			{ "integer[][]", "int[][]" },
			{ "string", "string" },
			{ "string[]", "string[]" },
			{ "character", "char" },
			{ "character[]", "char[]" },
			{ "boolean", "bool" },
			{ "double", "double" },
			{ "long", "long" },
			{ "ListNode", "ListNode" },
			{ "TreeNode", "TreeNode" },
		};

		private class MethodInfo
		{
			public string Name { get; set; } = "";
			public string ReturnTypeLeetCode { get; set; } = "";
			public string ReturnTypeCSharp { get; set; } = "";
			public List<ParamInfo> Params { get; set; } = new();
		}

		private class ParamInfo
		{
			public string Name { get; set; } = "";
			public string LeetCodeType { get; set; } = "";
			public string CSharpType { get; set; } = "";
		}

		private class ClassInfo
		{
			public string ClassName { get; set; } = "";
			public List<ParamInfo> ConstructorParams { get; set; } = new();
			public List<ClassMethodInfo> Methods { get; set; } = new();
		}

		private class ClassMethodInfo
		{
			public string NameCamelCase { get; set; } = "";
			public string NamePascalCase { get; set; } = "";
			public List<ParamInfo> Params { get; set; } = new();
			public string ReturnTypeLeetCode { get; set; } = "";
			public string ReturnTypeCSharp { get; set; } = "";
			public bool IsVoid => ReturnTypeLeetCode == "void" || string.IsNullOrEmpty(ReturnTypeLeetCode);
		}

		public static string Generate(LeetCodeProblem problem)
		{
			string description = BuildDescription(ConvertHtmlToPlainText(problem.ContentHtml));
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

			if (problem.IsClassBased)
			{
				BuildClassBasedSections(sb, problem);
			}
			else
			{
				var methodInfo = TryParseMethodInfo(problem);
				if (methodInfo != null)
					BuildFunctionBasedSections(sb, problem, methodInfo);
				else
					BuildFallbackSections(sb, problem);
			}

			sb.AppendLine("\t}");
			sb.Append("}");
			sb.AppendLine();

			return sb.ToString();
		}

		// -----------------------------------------------------------------
		// Function-based problems (most common)
		// -----------------------------------------------------------------

		private static void BuildFunctionBasedSections(StringBuilder sb, LeetCodeProblem problem, MethodInfo methodInfo)
		{
			var htmlExamples = ExtractExamples(problem.ContentHtml);

			// --- GetTestCases ---
			sb.AppendLine("\t\tpublic override List<TestCase> GetTestCases()");
			sb.AppendLine("\t\t{");
			sb.AppendLine("\t\t\treturn new List<TestCase>");
			sb.AppendLine("\t\t\t{");

			int exampleCount = Math.Min(problem.ExampleTestcaseList.Count, htmlExamples.Count);
			for (int i = 0; i < exampleCount; i++)
			{
				string[] inputValues = problem.ExampleTestcaseList[i].Split('\n');
				string expectedOutput = htmlExamples[i].Output;

				// Convert inputs to C# literals
				var inputParts = new List<string>();
				bool inputsFailed = false;
				for (int p = 0; p < methodInfo.Params.Count && p < inputValues.Length; p++)
				{
					// For ListNode params, store as int[] in test case
					string effectiveType = methodInfo.Params[p].LeetCodeType;
					if (effectiveType == "ListNode")
						effectiveType = "integer[]";

					string converted = TryConvertValue(inputValues[p].Trim(), effectiveType);
					if (converted == null) { inputsFailed = true; break; }
					inputParts.Add(converted);
				}

				// Convert expected output to C# literal
				string returnType = methodInfo.ReturnTypeLeetCode;
				if (returnType == "ListNode")
					returnType = "integer[]";
				string expectedConverted = TryConvertValue(expectedOutput, returnType);

				if (inputsFailed || expectedConverted == null)
				{
					sb.AppendLine($"\t\t\t\tnew TestCase(\"Example {i + 1}\",");
					sb.AppendLine($"\t\t\t\t\tnew object[] {{ /* TODO: {string.Join(", ", inputValues)} */ }},");
					sb.AppendLine($"\t\t\t\t\tnull /* TODO: {expectedOutput} */),");
				}
				else
				{
					sb.AppendLine($"\t\t\t\tnew TestCase(\"Example {i + 1}\",");
					sb.AppendLine($"\t\t\t\t\tnew object[] {{ {string.Join(", ", inputParts)} }},");
					sb.AppendLine($"\t\t\t\t\t{expectedConverted}),");
				}

				if (i < exampleCount - 1)
					sb.AppendLine();
			}

			if (exampleCount == 0)
				sb.AppendLine("\t\t\t\t// TODO: Add test cases");

			sb.AppendLine();
			sb.AppendLine("\t\t\t\t// TODO: Add edge cases beyond LeetCode examples");
			sb.AppendLine("\t\t\t};");
			sb.AppendLine("\t\t}");
			sb.AppendLine();

			// --- ExecuteSolution ---
			sb.AppendLine("\t\tpublic override object ExecuteSolution(object[] inputs)");
			sb.AppendLine("\t\t{");
			for (int i = 0; i < methodInfo.Params.Count; i++)
			{
				var param = methodInfo.Params[i];
				if (param.LeetCodeType == "ListNode")
					sb.AppendLine($"\t\t\tListNode {param.Name} = CreateLinkedList((int[])inputs[{i}]);");
				else
					sb.AppendLine($"\t\t\t{param.CSharpType} {param.Name} = ({param.CSharpType})inputs[{i}];");
			}

			string callArgs = string.Join(", ", methodInfo.Params.Select(p => p.Name));
			if (methodInfo.ReturnTypeLeetCode == "ListNode")
			{
				sb.AppendLine($"\t\t\tListNode result = {methodInfo.Name}({callArgs});");
				sb.AppendLine($"\t\t\treturn LinkedListToArray(result);");
			}
			else
			{
				sb.AppendLine($"\t\t\treturn {methodInfo.Name}({callArgs});");
			}
			sb.AppendLine("\t\t}");
			sb.AppendLine();

			// --- Solution stub ---
			sb.AppendLine("\t\t// YOUR SOLUTION GOES HERE");
			string paramList = string.Join(", ", methodInfo.Params.Select(p => $"{p.CSharpType} {p.Name}"));
			sb.AppendLine($"\t\tpublic {methodInfo.ReturnTypeCSharp} {methodInfo.Name}({paramList})");
			sb.AppendLine("\t\t{");
			sb.AppendLine("\t\t\tthrow new NotImplementedException();");
			sb.AppendLine("\t\t}");
		}

		// -----------------------------------------------------------------
		// Class-based problems (e.g., KthLargest, LRUCache)
		// -----------------------------------------------------------------

		private static void BuildClassBasedSections(StringBuilder sb, LeetCodeProblem problem)
		{
			var classInfo = TryParseClassInfo(problem);
			if (classInfo == null || classInfo.Methods.Count == 0)
			{
				BuildClassBasedFallback(sb, problem);
				return;
			}

			var htmlExamples = ExtractExamples(problem.ContentHtml);
			bool isSingleMethod = classInfo.Methods.Count == 1;

			if (isSingleMethod)
				BuildSingleMethodClassSections(sb, problem, classInfo, htmlExamples);
			else
				BuildMultiMethodClassSections(sb, problem, classInfo, htmlExamples);
		}

		private static void BuildSingleMethodClassSections(StringBuilder sb, LeetCodeProblem problem,
			ClassInfo classInfo, List<(string Input, string Output)> htmlExamples)
		{
			var method = classInfo.Methods[0];

			// --- GetTestCases ---
			sb.AppendLine("\t\tpublic override List<TestCase> GetTestCases()");
			sb.AppendLine("\t\t{");
			sb.AppendLine("\t\t\treturn new List<TestCase>");
			sb.AppendLine("\t\t\t{");

			int exampleCount = Math.Min(problem.ExampleTestcaseList.Count, htmlExamples.Count);
			for (int i = 0; i < exampleCount; i++)
			{
				var parsed = ParseClassTestCase(problem.ExampleTestcaseList[i], classInfo);
				if (parsed == null) continue;

				// Convert constructor args to C# literals
				var inputParts = new List<string>();
				bool failed = false;
				for (int p = 0; p < classInfo.ConstructorParams.Count && p < parsed.ConstructorArgs.Count; p++)
				{
					string converted = TryConvertValue(parsed.ConstructorArgs[p], classInfo.ConstructorParams[p].LeetCodeType);
					if (converted == null) { failed = true; break; }
					inputParts.Add(converted);
				}

				// Collect method args into a typed array
				if (!failed && method.Params.Count == 1)
				{
					string argType = method.Params[0].LeetCodeType;
					string argCSharpType = method.Params[0].CSharpType;
					var methodArgValues = new List<string>();
					foreach (var callArgs in parsed.MethodCalls)
					{
						if (callArgs.Args.Count > 0)
						{
							string converted = TryConvertValue(callArgs.Args[0], argType);
							if (converted == null) { failed = true; break; }
							methodArgValues.Add(converted);
						}
					}
					if (!failed)
						inputParts.Add($"new {argCSharpType}[] {{ {string.Join(", ", methodArgValues)} }}");
				}

				// Parse expected output: strip leading null from "[null, 4, 5, 5, 8, 8]"
				string expectedConverted = null;
				string outputText = htmlExamples[i].Output;
				if (!failed && !string.IsNullOrEmpty(outputText))
				{
					expectedConverted = TryConvertClassExpected(outputText, method.ReturnTypeLeetCode, skipLeadingNull: true);
				}

				if (failed || expectedConverted == null)
				{
					sb.AppendLine($"\t\t\t\tnew TestCase(\"Example {i + 1}\",");
					sb.AppendLine($"\t\t\t\t\tnew object[] {{ /* TODO */ }},");
					sb.AppendLine($"\t\t\t\t\tnull /* TODO: {outputText} */),");
				}
				else
				{
					sb.AppendLine($"\t\t\t\tnew TestCase(\"Example {i + 1}\",");
					sb.AppendLine($"\t\t\t\t\tnew object[] {{ {string.Join(", ", inputParts)} }},");
					sb.AppendLine($"\t\t\t\t\t{expectedConverted}),");
				}

				if (i < exampleCount - 1)
					sb.AppendLine();
			}

			sb.AppendLine();
			sb.AppendLine("\t\t\t\t// TODO: Add edge cases beyond LeetCode examples");
			sb.AppendLine("\t\t\t};");
			sb.AppendLine("\t\t}");
			sb.AppendLine();

			// --- ExecuteSolution ---
			sb.AppendLine("\t\tpublic override object ExecuteSolution(object[] inputs)");
			sb.AppendLine("\t\t{");

			// Cast constructor args
			for (int i = 0; i < classInfo.ConstructorParams.Count; i++)
			{
				var param = classInfo.ConstructorParams[i];
				sb.AppendLine($"\t\t\t{param.CSharpType} {param.Name} = ({param.CSharpType})inputs[{i}];");
			}

			// Cast method arg array
			int methodArgIndex = classInfo.ConstructorParams.Count;
			string methodArgArrayType = method.Params[0].CSharpType;
			sb.AppendLine($"\t\t\t{methodArgArrayType}[] {method.NameCamelCase}Values = ({methodArgArrayType}[])inputs[{methodArgIndex}];");
			sb.AppendLine();

			// Create instance
			string ctorArgs = string.Join(", ", classInfo.ConstructorParams.Select(p => p.Name));
			sb.AppendLine($"\t\t\tvar obj = new {classInfo.ClassName}({ctorArgs});");

			// Loop method calls
			sb.AppendLine($"\t\t\tvar results = new {method.ReturnTypeCSharp}[{method.NameCamelCase}Values.Length];");
			sb.AppendLine($"\t\t\tfor (int i = 0; i < {method.NameCamelCase}Values.Length; i++)");
			sb.AppendLine("\t\t\t{");
			sb.AppendLine($"\t\t\t\tresults[i] = obj.{method.NamePascalCase}({method.NameCamelCase}Values[i]);");
			sb.AppendLine("\t\t\t}");
			sb.AppendLine("\t\t\treturn results;");
			sb.AppendLine("\t\t}");
			sb.AppendLine();

			// --- Solution class stub ---
			BuildClassStub(sb, classInfo);
		}

		private static void BuildMultiMethodClassSections(StringBuilder sb, LeetCodeProblem problem,
			ClassInfo classInfo, List<(string Input, string Output)> htmlExamples)
		{
			// --- GetTestCases ---
			sb.AppendLine("\t\tpublic override List<TestCase> GetTestCases()");
			sb.AppendLine("\t\t{");
			sb.AppendLine("\t\t\treturn new List<TestCase>");
			sb.AppendLine("\t\t\t{");

			int exampleCount = Math.Min(problem.ExampleTestcaseList.Count, htmlExamples.Count);
			for (int i = 0; i < exampleCount; i++)
			{
				var parsed = ParseClassTestCase(problem.ExampleTestcaseList[i], classInfo);
				if (parsed == null) continue;

				// Build method names array (skip constructor)
				var methodNames = parsed.MethodCalls.Select(c => $"\"{c.MethodName}\"");

				// Build args: constructor args individually, then method names, then args per call
				var inputParts = new List<string>();
				bool failed = false;

				// Constructor args
				for (int p = 0; p < classInfo.ConstructorParams.Count && p < parsed.ConstructorArgs.Count; p++)
				{
					string converted = TryConvertValue(parsed.ConstructorArgs[p], classInfo.ConstructorParams[p].LeetCodeType);
					if (converted == null) { failed = true; break; }
					inputParts.Add(converted);
				}

				if (!failed)
					inputParts.Add($"new string[] {{ {string.Join(", ", methodNames)} }}");

				// Args for each method call as object[][]
				if (!failed)
				{
					var callArgStrings = new List<string>();
					foreach (var call in parsed.MethodCalls)
					{
						var methodDef = classInfo.Methods.FirstOrDefault(m => m.NameCamelCase == call.MethodName);
						if (methodDef == null) { failed = true; break; }

						var argParts = new List<string>();
						for (int a = 0; a < methodDef.Params.Count && a < call.Args.Count; a++)
						{
							string converted = TryConvertValue(call.Args[a], methodDef.Params[a].LeetCodeType);
							if (converted == null) { failed = true; break; }
							argParts.Add(converted);
						}
						if (failed) break;
						callArgStrings.Add($"new object[] {{ {string.Join(", ", argParts)} }}");
					}
					if (!failed)
						inputParts.Add($"new object[][] {{ {string.Join(", ", callArgStrings)} }}");
				}

				// Expected output
				string expectedConverted = null;
				string outputText = htmlExamples[i].Output;
				if (!failed && !string.IsNullOrEmpty(outputText))
				{
					expectedConverted = TryConvertMultiMethodExpected(outputText);
				}

				if (failed || expectedConverted == null)
				{
					sb.AppendLine($"\t\t\t\tnew TestCase(\"Example {i + 1}\",");
					sb.AppendLine($"\t\t\t\t\tnew object[] {{ /* TODO */ }},");
					sb.AppendLine($"\t\t\t\t\tnull /* TODO: {outputText} */),");
				}
				else
				{
					sb.AppendLine($"\t\t\t\tnew TestCase(\"Example {i + 1}\",");
					sb.AppendLine($"\t\t\t\t\tnew object[] {{ {string.Join(", ", inputParts)} }},");
					sb.AppendLine($"\t\t\t\t\t{expectedConverted}),");
				}

				if (i < exampleCount - 1)
					sb.AppendLine();
			}

			sb.AppendLine();
			sb.AppendLine("\t\t\t\t// TODO: Add edge cases beyond LeetCode examples");
			sb.AppendLine("\t\t\t};");
			sb.AppendLine("\t\t}");
			sb.AppendLine();

			// --- ExecuteSolution ---
			sb.AppendLine("\t\tpublic override object ExecuteSolution(object[] inputs)");
			sb.AppendLine("\t\t{");

			// Cast constructor args
			for (int i = 0; i < classInfo.ConstructorParams.Count; i++)
			{
				var param = classInfo.ConstructorParams[i];
				sb.AppendLine($"\t\t\t{param.CSharpType} {param.Name} = ({param.CSharpType})inputs[{i}];");
			}

			int nextIndex = classInfo.ConstructorParams.Count;
			sb.AppendLine($"\t\t\tstring[] methods = (string[])inputs[{nextIndex}];");
			sb.AppendLine($"\t\t\tobject[][] args = (object[][])inputs[{nextIndex + 1}];");
			sb.AppendLine();

			// Create instance
			string ctorArgs = string.Join(", ", classInfo.ConstructorParams.Select(p => p.Name));
			sb.AppendLine($"\t\t\tvar obj = new {classInfo.ClassName}({ctorArgs});");
			sb.AppendLine("\t\t\tvar results = new object[methods.Length];");
			sb.AppendLine();
			sb.AppendLine("\t\t\tfor (int i = 0; i < methods.Length; i++)");
			sb.AppendLine("\t\t\t{");
			sb.AppendLine("\t\t\t\tswitch (methods[i])");
			sb.AppendLine("\t\t\t\t{");

			foreach (var method in classInfo.Methods)
			{
				sb.AppendLine($"\t\t\t\t\tcase \"{method.NameCamelCase}\":");
				if (method.IsVoid)
				{
					string args = string.Join(", ", method.Params.Select((p, idx) => $"({p.CSharpType})args[i][{idx}]"));
					sb.AppendLine($"\t\t\t\t\t\tobj.{method.NamePascalCase}({args});");
					sb.AppendLine("\t\t\t\t\t\tresults[i] = null;");
				}
				else
				{
					string args = string.Join(", ", method.Params.Select((p, idx) => $"({p.CSharpType})args[i][{idx}]"));
					sb.AppendLine($"\t\t\t\t\t\tresults[i] = obj.{method.NamePascalCase}({args});");
				}
				sb.AppendLine("\t\t\t\t\t\tbreak;");
			}

			sb.AppendLine("\t\t\t\t}");
			sb.AppendLine("\t\t\t}");
			sb.AppendLine("\t\t\treturn results;");
			sb.AppendLine("\t\t}");
			sb.AppendLine();

			// --- Solution class stub ---
			BuildClassStub(sb, classInfo);
		}

		private static void BuildClassStub(StringBuilder sb, ClassInfo classInfo)
		{
			sb.AppendLine("\t\t// YOUR SOLUTION GOES HERE");
			string ctorParams = string.Join(", ", classInfo.ConstructorParams.Select(p => $"{p.CSharpType} {p.Name}"));
			sb.AppendLine($"\t\tpublic class {classInfo.ClassName}");
			sb.AppendLine("\t\t{");
			sb.AppendLine($"\t\t\tpublic {classInfo.ClassName}({ctorParams})");
			sb.AppendLine("\t\t\t{");
			sb.AppendLine("\t\t\t\tthrow new NotImplementedException();");
			sb.AppendLine("\t\t\t}");

			foreach (var method in classInfo.Methods)
			{
				sb.AppendLine();
				string methodParams = string.Join(", ", method.Params.Select(p => $"{p.CSharpType} {p.Name}"));
				string returnType = method.IsVoid ? "void" : method.ReturnTypeCSharp;
				sb.AppendLine($"\t\t\tpublic {returnType} {method.NamePascalCase}({methodParams})");
				sb.AppendLine("\t\t\t{");
				sb.AppendLine("\t\t\t\tthrow new NotImplementedException();");
				sb.AppendLine("\t\t\t}");
			}

			sb.AppendLine("\t\t}");
		}

		private static void BuildClassBasedFallback(StringBuilder sb, LeetCodeProblem problem)
		{
			var htmlExamples = ExtractExamples(problem.ContentHtml);

			sb.AppendLine("\t\tpublic override List<TestCase> GetTestCases()");
			sb.AppendLine("\t\t{");
			sb.AppendLine("\t\t\treturn new List<TestCase>");
			sb.AppendLine("\t\t\t{");

			for (int i = 0; i < htmlExamples.Count; i++)
			{
				sb.AppendLine($"\t\t\t\t// Input: {htmlExamples[i].Input}");
				sb.AppendLine($"\t\t\t\t// Expected: {htmlExamples[i].Output}");
				sb.AppendLine($"\t\t\t\tnew TestCase(\"Example {i + 1}\",");
				sb.AppendLine($"\t\t\t\t\tnew object[] {{ /* TODO */ }},");
				sb.AppendLine($"\t\t\t\t\tnull /* TODO */),");
				sb.AppendLine();
			}

			sb.AppendLine("\t\t\t\t// TODO: Add test cases");
			sb.AppendLine("\t\t\t};");
			sb.AppendLine("\t\t}");
			sb.AppendLine();
			sb.AppendLine("\t\tpublic override object ExecuteSolution(object[] inputs)");
			sb.AppendLine("\t\t{");
			sb.AppendLine("\t\t\t// TODO: Cast inputs and call your solution");
			sb.AppendLine("\t\t\tthrow new NotImplementedException();");
			sb.AppendLine("\t\t}");
			sb.AppendLine();
			sb.AppendLine("\t\t// YOUR SOLUTION GOES HERE");
			sb.AppendLine("\t\t// TODO: Add your solution class");
		}

		// -----------------------------------------------------------------
		// Fallback (no metaData available)
		// -----------------------------------------------------------------

		private static void BuildFallbackSections(StringBuilder sb, LeetCodeProblem problem)
		{
			var examples = ExtractExamples(problem.ContentHtml);

			sb.AppendLine("\t\tpublic override List<TestCase> GetTestCases()");
			sb.AppendLine("\t\t{");
			sb.AppendLine("\t\t\treturn new List<TestCase>");
			sb.AppendLine("\t\t\t{");

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
		}

		// -----------------------------------------------------------------
		// MetaData / method signature parsing
		// -----------------------------------------------------------------

		private static MethodInfo TryParseMethodInfo(LeetCodeProblem problem)
		{
			if (string.IsNullOrEmpty(problem.MetaDataJson))
				return null;

			try
			{
				using var doc = JsonDocument.Parse(problem.MetaDataJson);
				var root = doc.RootElement;

				if (!root.TryGetProperty("name", out var nameEl) ||
					!root.TryGetProperty("params", out var paramsEl) ||
					!root.TryGetProperty("return", out var returnEl))
					return null;

				string methodNameCamel = nameEl.GetString() ?? "";
				string returnType = returnEl.GetProperty("type").GetString() ?? "";

				var info = new MethodInfo
				{
					ReturnTypeLeetCode = returnType,
					ReturnTypeCSharp = MapType(returnType),
					Name = ExtractMethodNameFromSnippet(problem.CodeSnippetCSharp)
						?? ToPascalCase(methodNameCamel),
				};

				foreach (var param in paramsEl.EnumerateArray())
				{
					// Skip language-specific params (e.g., C's array size params)
					if (param.TryGetProperty("lang", out _))
						continue;

					string paramName = param.GetProperty("name").GetString() ?? "";
					string paramType = param.GetProperty("type").GetString() ?? "";

					info.Params.Add(new ParamInfo
					{
						Name = paramName,
						LeetCodeType = paramType,
						CSharpType = MapType(paramType),
					});
				}

				return info;
			}
			catch
			{
				return null;
			}
		}

		private static string ExtractMethodNameFromSnippet(string snippet)
		{
			if (string.IsNullOrEmpty(snippet))
				return null;

			// Match "public ReturnType MethodName(" but skip "public class"
			var match = Regex.Match(snippet, @"public\s+(?!class\b)\S+\s+(\w+)\s*\(");
			return match.Success ? match.Groups[1].Value : null;
		}

		private static string ToPascalCase(string camelCase)
		{
			if (string.IsNullOrEmpty(camelCase))
				return camelCase;
			return char.ToUpper(camelCase[0]) + camelCase.Substring(1);
		}

		// -----------------------------------------------------------------
		// Class-based metaData parsing
		// -----------------------------------------------------------------

		private static ClassInfo TryParseClassInfo(LeetCodeProblem problem)
		{
			if (string.IsNullOrEmpty(problem.MetaDataJson))
				return null;

			try
			{
				using var doc = JsonDocument.Parse(problem.MetaDataJson);
				var root = doc.RootElement;

				if (!root.TryGetProperty("classname", out var classNameEl) ||
					!root.TryGetProperty("constructor", out var ctorEl) ||
					!root.TryGetProperty("methods", out var methodsEl))
					return null;

				var info = new ClassInfo
				{
					ClassName = classNameEl.GetString() ?? "",
				};

				// Parse constructor params
				if (ctorEl.TryGetProperty("params", out var ctorParams))
				{
					foreach (var param in ctorParams.EnumerateArray())
					{
						if (param.TryGetProperty("lang", out _))
							continue;
						info.ConstructorParams.Add(new ParamInfo
						{
							Name = param.GetProperty("name").GetString() ?? "",
							LeetCodeType = param.GetProperty("type").GetString() ?? "",
							CSharpType = MapType(param.GetProperty("type").GetString() ?? ""),
						});
					}
				}

				// Parse methods - also extract PascalCase names from snippet
				var snippetMethodNames = ExtractAllMethodNamesFromSnippet(problem.CodeSnippetCSharp);

				foreach (var method in methodsEl.EnumerateArray())
				{
					string nameCamel = method.GetProperty("name").GetString() ?? "";
					string returnType = "";
					if (method.TryGetProperty("return", out var retEl))
						returnType = retEl.GetProperty("type").GetString() ?? "";

					string namePascal = snippetMethodNames
						.FirstOrDefault(n => n.Equals(ToPascalCase(nameCamel), StringComparison.OrdinalIgnoreCase))
						?? ToPascalCase(nameCamel);

					var methodInfo = new ClassMethodInfo
					{
						NameCamelCase = nameCamel,
						NamePascalCase = namePascal,
						ReturnTypeLeetCode = returnType,
						ReturnTypeCSharp = MapType(returnType),
					};

					if (method.TryGetProperty("params", out var methodParams))
					{
						foreach (var param in methodParams.EnumerateArray())
						{
							if (param.TryGetProperty("lang", out _))
								continue;
							methodInfo.Params.Add(new ParamInfo
							{
								Name = param.GetProperty("name").GetString() ?? "",
								LeetCodeType = param.GetProperty("type").GetString() ?? "",
								CSharpType = MapType(param.GetProperty("type").GetString() ?? ""),
							});
						}
					}

					info.Methods.Add(methodInfo);
				}

				return info;
			}
			catch
			{
				return null;
			}
		}

		private static List<string> ExtractAllMethodNamesFromSnippet(string snippet)
		{
			var names = new List<string>();
			if (string.IsNullOrEmpty(snippet))
				return names;

			// Match all "public ReturnType MethodName(" but skip "public class" and constructors
			var matches = Regex.Matches(snippet, @"public\s+(?!class\b)(\S+)\s+(\w+)\s*\(");
			foreach (Match match in matches)
			{
				string returnType = match.Groups[1].Value;
				string name = match.Groups[2].Value;
				// Skip constructors (return type == class name pattern)
				if (returnType != name)
					names.Add(name);
			}
			return names;
		}

		// -----------------------------------------------------------------
		// Class-based test case parsing
		// -----------------------------------------------------------------

		private class ParsedClassTestCase
		{
			public List<string> ConstructorArgs { get; set; } = new();
			public List<ParsedMethodCall> MethodCalls { get; set; } = new();
		}

		private class ParsedMethodCall
		{
			public string MethodName { get; set; } = "";
			public List<string> Args { get; set; } = new();
		}

		private static ParsedClassTestCase ParseClassTestCase(string testCaseRaw, ClassInfo classInfo)
		{
			try
			{
				string[] lines = testCaseRaw.Split('\n');
				if (lines.Length < 2) return null;

				using var methodsDoc = JsonDocument.Parse(lines[0]);
				using var argsDoc = JsonDocument.Parse(lines[1]);

				var methods = methodsDoc.RootElement;
				var args = argsDoc.RootElement;

				if (methods.GetArrayLength() != args.GetArrayLength()) return null;

				var result = new ParsedClassTestCase();

				// First entry is constructor
				var ctorArgs = args[0];
				foreach (var arg in ctorArgs.EnumerateArray())
				{
					result.ConstructorArgs.Add(arg.GetRawText());
				}

				// Remaining entries are method calls
				for (int i = 1; i < methods.GetArrayLength(); i++)
				{
					var call = new ParsedMethodCall
					{
						MethodName = methods[i].GetString() ?? "",
					};
					foreach (var arg in args[i].EnumerateArray())
					{
						call.Args.Add(arg.GetRawText());
					}
					result.MethodCalls.Add(call);
				}

				return result;
			}
			catch
			{
				return null;
			}
		}

		private static string TryConvertClassExpected(string outputText, string returnTypeLeetCode, bool skipLeadingNull)
		{
			try
			{
				using var doc = JsonDocument.Parse(outputText);
				var array = doc.RootElement;
				if (array.ValueKind != JsonValueKind.Array) return null;

				var values = new List<string>();
				bool skippedFirst = false;
				foreach (var element in array.EnumerateArray())
				{
					if (skipLeadingNull && !skippedFirst)
					{
						skippedFirst = true;
						continue; // skip the null for constructor
					}

					string converted = ConvertJsonElement(element, returnTypeLeetCode);
					if (converted == null) return null;
					values.Add(converted);
				}

				string csharpType = MapType(returnTypeLeetCode);
				return $"new {csharpType}[] {{ {string.Join(", ", values)} }}";
			}
			catch
			{
				return null;
			}
		}

		private static string TryConvertMultiMethodExpected(string outputText)
		{
			try
			{
				using var doc = JsonDocument.Parse(outputText);
				var array = doc.RootElement;
				if (array.ValueKind != JsonValueKind.Array) return null;

				var values = new List<string>();
				bool skippedFirst = false;
				foreach (var element in array.EnumerateArray())
				{
					if (!skippedFirst)
					{
						skippedFirst = true;
						continue; // skip the null for constructor
					}

					if (element.ValueKind == JsonValueKind.Null)
						values.Add("null");
					else if (element.ValueKind == JsonValueKind.Number)
						values.Add(element.GetRawText());
					else if (element.ValueKind == JsonValueKind.True)
						values.Add("true");
					else if (element.ValueKind == JsonValueKind.False)
						values.Add("false");
					else if (element.ValueKind == JsonValueKind.String)
						values.Add($"\"{EscapeCSharpString(element.GetString() ?? "")}\"");
					else
						return null;
				}

				return $"new object[] {{ {string.Join(", ", values)} }}";
			}
			catch
			{
				return null;
			}
		}

		// -----------------------------------------------------------------
		// Type mapping
		// -----------------------------------------------------------------

		private static string MapType(string leetCodeType)
		{
			if (TypeMap.TryGetValue(leetCodeType, out string csharpType))
				return csharpType;

			// Handle list<X> types
			var listMatch = Regex.Match(leetCodeType, @"^list<(.+)>$");
			if (listMatch.Success)
			{
				string inner = MapType(listMatch.Groups[1].Value);
				return $"List<{inner}>";
			}

			return leetCodeType;
		}

		// -----------------------------------------------------------------
		// Value conversion (raw LeetCode values -> C# literals)
		// -----------------------------------------------------------------

		private static string TryConvertValue(string rawValue, string leetCodeType)
		{
			if (string.IsNullOrWhiteSpace(rawValue))
				return null;

			rawValue = rawValue.Trim();

			try
			{
				using var doc = JsonDocument.Parse(rawValue);
				return ConvertJsonElement(doc.RootElement, leetCodeType);
			}
			catch
			{
				return null;
			}
		}

		private static string ConvertJsonElement(JsonElement element, string leetCodeType)
		{
			switch (element.ValueKind)
			{
				case JsonValueKind.Number:
					if (leetCodeType == "long")
						return element.GetInt64().ToString() + "L";
					return element.GetRawText();

				case JsonValueKind.String:
					string strVal = element.GetString() ?? "";
					if (leetCodeType == "character")
						return $"'{strVal}'";
					return $"\"{EscapeCSharpString(strVal)}\"";

				case JsonValueKind.True:
					return "true";

				case JsonValueKind.False:
					return "false";

				case JsonValueKind.Array:
					return ConvertArray(element, leetCodeType);

				case JsonValueKind.Null:
					return "null";

				default:
					return null;
			}
		}

		private static string GetInnerType(string leetCodeType)
		{
			// integer[] -> integer, integer[][] -> integer[]
			if (leetCodeType.EndsWith("[]"))
				return leetCodeType.Substring(0, leetCodeType.Length - 2);

			// list<integer> -> integer, list<list<integer>> -> list<integer>
			var listMatch = Regex.Match(leetCodeType, @"^list<(.+)>$");
			if (listMatch.Success)
				return listMatch.Groups[1].Value;

			return leetCodeType;
		}

		private static string ConvertArray(JsonElement array, string leetCodeType)
		{
			string csharpType = MapType(leetCodeType);
			string innerLeetCodeType = GetInnerType(leetCodeType);

			var elements = new List<string>();
			foreach (var item in array.EnumerateArray())
			{
				string converted = ConvertJsonElement(item, innerLeetCodeType);
				if (converted == null)
					return null;
				elements.Add(converted);
			}

			return $"new {csharpType} {{ {string.Join(", ", elements)} }}";
		}

		// -----------------------------------------------------------------
		// HTML processing (existing, kept as-is)
		// -----------------------------------------------------------------

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

		private static string EscapeCSharpString(string s)
		{
			return s
				.Replace("\\", "\\\\")
				.Replace("\"", "\\\"")
				.Replace("\t", "\\t");
		}
	}
}
