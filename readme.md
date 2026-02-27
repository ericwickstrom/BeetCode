# 🐛 BeetCode

A local C# console application for practicing LeetCode problems in your own IDE. Say goodbye to LeetCode's online editor and hello to VS Code!

## ✨ Features

- **Local Development**: Write solutions in VS Code with all your favorite extensions
- **Automatic Scaffolding**: Generate new problem files directly from LeetCode data with one command
- **Automatic Testing**: Built-in test runner with formatted output
- **Problem Management**: Easy CLI commands to run, test, and manage problems
- **Solution Resetting**: Quickly reset one or all solutions back to their initial state
- **Clean Output**: Pretty-printed test results with pass/fail status

## 🚀 Quick Start

### Prerequisites
- .NET 8.0 SDK
- VS Code (recommended)

### Installation
```bash
git clone <your-repo-url>
cd BeetCode
dotnet build
```

### Usage
```bash
# Generate a new problem file from LeetCode
dotnet run -- scaffold 1

# Run tests for a specific problem
dotnet run -- test 1

# Show problem info and run tests
dotnet run -- run 1

# Show just the problem description
dotnet run -- info 1

# List all available problems and your progress
dotnet run -- list

# Reset a solution
dotnet run -- reset 1

# Show help
dotnet run -- help
```

## 📁 Project Structure

```
BeetCode/
├── Framework/
│   ├── LeetCodeClient.cs    # Fetches problem data from LeetCode
│   ├── Problem.cs           # Abstract base class for all problems
│   ├── ResetHelper.cs       # Utility for resetting solutions
│   ├── ScaffoldGenerator.cs # Generates C# boilerplate from problem data
│   ├── TestCase.cs          # Test case data structure
│   └── TestRunner.cs        # Test execution engine
├── Problems/
│   ├── Problem001.cs        # Two Sum
│   ├── Problem002.cs        # Add Two Numbers
│   └── ...                  # More problems as you add them
├── Program.cs               # CLI entry point
└── README.md               # You are here!
```

## 🎯 Adding New Problems

Want to practice a new LeetCode problem? Use the `scaffold` command:

```bash
dotnet run -- scaffold 1
```

This will automatically create a complete problem file with:
- ✅ Problem description, difficulty, and examples
- ✅ Method signature ready for your solution
- ✅ Integration into the test runner

*Note: Some problems may require manual adjustment of test cases if the data format is complex.*

## 💡 Example Workflow

1. **Scaffold a problem**: `dotnet run -- scaffold 1`
2. **Read the description**: `dotnet run -- info 1`
3. **Open the file**: Edit `Problems/Problem001.cs`
4. **Write your solution**: Replace the `NotImplementedException`
5. **Test it**: `dotnet run -- test 1`
6. **Celebrate**: 🎉 (when all tests pass)

## 🧪 Sample Output

```bash
$ dotnet run -- test 1

Running tests for Problem 1: Two Sum
--------------------------------------------------
Example 1: PASS

Example 2: PASS

Example 3: PASS

--------------------------------------------------
Results: 3/3 tests passed
All tests passed! 🎉
```

## 🛠️ Commands Reference

| Command | Description | Example |
|---------|-------------|---------|
| `scaffold <n>` | Generate problem file from LeetCode | `dotnet run -- scaffold 1` |
| `test <n>` | Run tests for a problem | `dotnet run -- test 1` |
| `run <n>` | Show info + run tests | `dotnet run -- run 1` |
| `info <n>` | Show problem description | `dotnet run -- info 1` |
| `list` | List all problems and progress | `dotnet run -- list` |
| `reset <n>` | Reset a specific solution | `dotnet run -- reset 1` |
| `reset` | Reset ALL solutions (prompts) | `dotnet run -- reset` |
| `update-data` | Refresh local LeetCode problem cache | `dotnet run -- update-data` |
| `help` | Show help message | `dotnet run -- help` |

## 🎨 Why BeetCode?

- **Your IDE, Your Rules**: Use VS Code with IntelliSense, debugging, and extensions
- **Version Control**: Track your solution progress with Git
- **Offline Practice**: No internet required once problems are set up
- **Custom Testing**: Add your own test cases beyond LeetCode examples
- **Learning Focus**: Clean, distraction-free environment for problem-solving

## 🤝 Contributing

This is a personal practice tool, but feel free to:
- Suggest new framework features
- Report bugs or improvements
- Share your favorite problem templates

## 📄 License

MIT License - Practice away! 🚀

---

**Happy Coding!** 🐛✨

*Made with ❤️ for developers who prefer their own IDE*