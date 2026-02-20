using System;
using System.IO;
using System.Text.RegularExpressions;

namespace BeetCode.Framework
{
    public static class ResetHelper
    {
        private const string SolutionMarker = "// YOUR SOLUTION GOES HERE";

        /// <summary>
        /// Resets the solution in a problem file back to throw new NotImplementedException().
        /// Replaces everything after "// YOUR SOLUTION GOES HERE" up to the last closing brace.
        /// </summary>
        public static bool ResetProblemFile(string filePath)
        {
            if (!File.Exists(filePath))
                return false;

            string content = File.ReadAllText(filePath);

            int markerIndex = content.IndexOf(SolutionMarker);
            if (markerIndex == -1)
                return false;

            // Find the method signature line after the marker
            // Pattern: find "public <return type> <MethodName>(<params>)" after the marker
            // We look for the opening brace of the method body after the marker
            int searchFrom = markerIndex + SolutionMarker.Length;

            // Find the method signature (next public method declaration after marker)
            var methodSignaturePattern = new Regex(
                @"(public\s+[\w\[\]<>, ?]+\s+\w+\s*\([^)]*\)\s*\n\s*\{)",
                RegexOptions.Singleline
            );

            var match = methodSignaturePattern.Match(content, searchFrom);
            if (!match.Success)
                return false;

            int bodyStart = match.Index + match.Length; // position right after the opening {

            // Find the matching closing brace for this method
            int braceCount = 1;
            int pos = bodyStart;
            while (pos < content.Length && braceCount > 0)
            {
                if (content[pos] == '{') braceCount++;
                else if (content[pos] == '}') braceCount--;
                pos++;
            }

            if (braceCount != 0)
                return false;

            int bodyEnd = pos - 1; // position of the closing }

            // Determine the indentation of the method body
            // Find the line start before bodyStart to get indentation
            int lineStart = content.LastIndexOf('\n', match.Index) + 1;
            string methodLine = content.Substring(lineStart, match.Index - lineStart);
            string indent = "";
            foreach (char c in methodLine)
            {
                if (c == ' ' || c == '\t') indent += c;
                else break;
            }

            // Build the replacement body
            string newBody = $"\n{indent}    // TODO: Implement your solution\n{indent}    throw new NotImplementedException();\n{indent}";

            // Replace the body content
            string newContent = content.Substring(0, bodyStart) + newBody + content.Substring(bodyEnd);

            File.WriteAllText(filePath, newContent);
            return true;
        }

        /// <summary>
        /// Finds the Problems directory relative to the executable or current directory.
        /// </summary>
        public static string FindProblemsDirectory()
        {
            // Walk up from current directory to find the Problems folder
            string dir = Directory.GetCurrentDirectory();
            for (int i = 0; i < 5; i++)
            {
                string candidate = Path.Combine(dir, "Problems");
                if (Directory.Exists(candidate))
                    return candidate;
                dir = Directory.GetParent(dir)?.FullName ?? dir;
            }
            return null;
        }

        /// <summary>
        /// Returns the file path for a given problem number.
        /// </summary>
        public static string GetProblemFilePath(string problemsDir, int number)
        {
            return Path.Combine(problemsDir, $"Problem{number:D3}.cs");
        }
    }
}
