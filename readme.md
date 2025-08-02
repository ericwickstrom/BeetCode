# 🐛 BeetCode

A local C# console application for practicing LeetCode problems in your own IDE. Say goodbye to LeetCode's online editor and hello to VS Code!

## ✨ Features

- **Local Development**: Write solutions in VS Code with all your favorite extensions
- **Automatic Testing**: Built-in test runner with formatted output
- **Problem Management**: Easy CLI commands to run, test, and manage problems
- **Extensible Framework**: Add new problems with a simple, consistent structure
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
# Run tests for a specific problem
dotnet run -- test 1

# Show problem info and run tests
dotnet run -- run 1

# Show just the problem description
dotnet run -- info 1

# List all available problems
dotnet run -- list

# Show help
dotnet run -- help
```

## 📁 Project Structure

```
BeetCode/
├── Framework/
│   ├── Problem.cs          # Abstract base class for all problems
│   ├── TestCase.cs         # Test case data structure
│   └── TestRunner.cs       # Test execution engine
├── Problems/
│   ├── Problem001.cs       # Two Sum
│   ├── Problem002.cs       # Add Two Numbers
│   └── ...                 # More problems as you add them
├── Program.cs              # CLI entry point
└── README.md              # You are here!
```

## 🎯 Adding New Problems

Want to practice a new LeetCode problem? Just ask me to generate it! For example:

```
"Hey Claude, generate Problem002.cs for Add Two Numbers"
```

I'll create a complete problem file with:
- ✅ Problem description and examples
- ✅ Method signature ready for your solution
- ✅ Test cases from LeetCode examples
- ✅ Framework integration

## 💡 Example Workflow

1. **Pick a problem**: `dotnet run -- list`
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
| `test <number>` | Run tests for a problem | `dotnet run -- test 1` |
| `run <number>` | Show info + run tests | `dotnet run -- run 1` |
| `info <number>` | Show problem description | `dotnet run -- info 1` |
| `list` | List all problems | `dotnet run -- list` |
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