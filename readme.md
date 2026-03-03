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
- Problem description, difficulty, and examples
- Method signature ready for your solution
- Integration into the test runner

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

## Progress Summary

**Completed: 15 / 150**

---

## 🟢 Easy (35 problems — 15 / 35)

### Arrays & Hashing
✅ 217 · Contains Duplicate

✅ 242 · Valid Anagram

✅ 1 · Two Sum

### Two Pointers
✅ 125 · Valid Palindrome

### Sliding Window
✅ 121 · Best Time to Buy and Sell Stock

### Stack
✅ 20 · Valid Parentheses

### Binary Search
✅ 704 · Binary Search

### Linked List
✅ 206 · Reverse Linked List

✅ 141 · Linked List Cycle

✅ 21 · Merge Two Sorted Lists

### Trees
✅ 226 · Invert Binary Tree
- [ ] 104 · Maximum Depth of Binary Tree
- [ ] 543 · Diameter of Binary Tree
- [ ] 110 · Balanced Binary Tree
- [ ] 100 · Same Tree
- [ ] 572 · Subtree of Another Tree

### Heap / Priority Queue
✅ 703 · Kth Largest Element in a Stream

✅ 1046 · Last Stone Weight

### 1-D Dynamic Programming
- [ ] 70 · Climbing Stairs
- [ ] 746 · Min Cost Climbing Stairs

### Intervals
- [ ] 252 · Meeting Rooms *(Premium)*

### Math & Geometry
✅ 202 · Happy Number
- [ ] 66 · Plus One

### Bit Manipulation
✅ 136 · Single Number
- [ ] 191 · Number of 1 Bits
- [ ] 338 · Counting Bits
- [ ] 190 · Reverse Bits
- [ ] 268 · Missing Number

---

## 🟡 Medium (96 problems — 0 / 96)

### Arrays & Hashing
- [ ] 49 · Group Anagrams
- [ ] 347 · Top K Frequent Elements
- [ ] 238 · Product of Array Except Self
- [ ] 36 · Valid Sudoku
- [ ] 271 · Encode and Decode Strings *(Premium)*
- [ ] 128 · Longest Consecutive Sequence

### Two Pointers
- [ ] 167 · Two Sum II - Input Array Is Sorted
- [ ] 15 · 3Sum
- [ ] 11 · Container With Most Water

### Sliding Window
- [ ] 3 · Longest Substring Without Repeating Characters
- [ ] 424 · Longest Repeating Character Replacement
- [ ] 567 · Permutation in String

### Stack
- [ ] 155 · Min Stack
- [ ] 150 · Evaluate Reverse Polish Notation
- [ ] 22 · Generate Parentheses
- [ ] 739 · Daily Temperatures
- [ ] 853 · Car Fleet

### Binary Search
- [ ] 74 · Search a 2D Matrix
- [ ] 875 · Koko Eating Bananas
- [ ] 153 · Find Minimum in Rotated Sorted Array
- [ ] 33 · Search in Rotated Sorted Array
- [ ] 981 · Time Based Key-Value Store

### Linked List
- [ ] 143 · Reorder List
- [ ] 19 · Remove Nth Node From End of List
- [ ] 138 · Copy List With Random Pointer
- [ ] 2 · Add Two Numbers
- [ ] 287 · Find the Duplicate Number
- [ ] 146 · LRU Cache

### Trees
- [ ] 235 · Lowest Common Ancestor of BST
- [ ] 102 · Binary Tree Level Order Traversal
- [ ] 199 · Binary Tree Right Side View
- [ ] 1448 · Count Good Nodes in Binary Tree
- [ ] 98 · Validate Binary Search Tree
- [ ] 230 · Kth Smallest Element in BST
- [ ] 105 · Construct Binary Tree from Preorder and Inorder

### Tries
- [ ] 208 · Implement Trie (Prefix Tree)
- [ ] 211 · Design Add and Search Words Data Structure

### Heap / Priority Queue
- [ ] 973 · K Closest Points to Origin
- [ ] 215 · Kth Largest Element in an Array
- [ ] 621 · Task Scheduler
- [ ] 355 · Design Twitter

### Backtracking
- [ ] 46 · Permutations
- [ ] 78 · Subsets
- [ ] 39 · Combination Sum
- [ ] 90 · Subsets II
- [ ] 40 · Combination Sum II
- [ ] 79 · Word Search
- [ ] 131 · Palindrome Partitioning
- [ ] 17 · Letter Combinations of a Phone Number

### Graphs
- [ ] 200 · Number of Islands
- [ ] 133 · Clone Graph
- [ ] 695 · Max Area of Island
- [ ] 417 · Pacific Atlantic Water Flow
- [ ] 130 · Surrounded Regions
- [ ] 994 · Rotting Oranges
- [ ] 286 · Walls and Gates *(Premium)*
- [ ] 207 · Course Schedule
- [ ] 210 · Course Schedule II
- [ ] 684 · Redundant Connection
- [ ] 323 · Number of Connected Components *(Premium)*
- [ ] 261 · Graph Valid Tree *(Premium)*

### Advanced Graphs
- [ ] 1584 · Min Cost to Connect All Points
- [ ] 743 · Network Delay Time
- [ ] 787 · Cheapest Flights Within K Stops

### 1-D Dynamic Programming
- [ ] 198 · House Robber
- [ ] 213 · House Robber II
- [ ] 5 · Longest Palindromic Substring
- [ ] 647 · Palindromic Substrings
- [ ] 91 · Decode Ways
- [ ] 322 · Coin Change
- [ ] 139 · Word Break
- [ ] 300 · Longest Increasing Subsequence
- [ ] 416 · Partition Equal Subset Sum

### 2-D Dynamic Programming
- [ ] 62 · Unique Paths
- [ ] 1143 · Longest Common Subsequence
- [ ] 309 · Best Time to Buy & Sell Stock with Cooldown
- [ ] 518 · Coin Change II
- [ ] 494 · Target Sum
- [ ] 97 · Interleaving String
- [ ] 72 · Edit Distance

### Greedy
- [ ] 53 · Maximum Subarray
- [ ] 55 · Jump Game
- [ ] 45 · Jump Game II
- [ ] 134 · Gas Station
- [ ] 846 · Hand of Straights
- [ ] 1899 · Merge Triplets to Form Target Triplet
- [ ] 763 · Partition Labels
- [ ] 678 · Valid Parenthesis String

### Intervals
- [ ] 57 · Insert Interval
- [ ] 56 · Merge Intervals
- [ ] 435 · Non-Overlapping Intervals
- [ ] 253 · Meeting Rooms II *(Premium)*

### Math & Geometry
- [ ] 48 · Rotate Image
- [ ] 54 · Spiral Matrix
- [ ] 73 · Set Matrix Zeroes
- [ ] 50 · Pow(x, n)
- [ ] 43 · Multiply Strings
- [ ] 2013 · Detect Squares

### Bit Manipulation
- [ ] 371 · Sum of Two Integers
- [ ] 7 · Reverse Integer

---

## 🔴 Hard (19 problems — 0 / 19)

### Two Pointers
- [ ] 42 · Trapping Rain Water

### Sliding Window
- [ ] 76 · Minimum Window Substring
- [ ] 239 · Sliding Window Maximum

### Stack
- [ ] 84 · Largest Rectangle in Histogram

### Binary Search
- [ ] 4 · Median of Two Sorted Arrays

### Linked List
- [ ] 23 · Merge K Sorted Lists
- [ ] 25 · Reverse Nodes in K-Group

### Trees
- [ ] 124 · Binary Tree Maximum Path Sum
- [ ] 297 · Serialize and Deserialize Binary Tree

### Tries
- [ ] 212 · Word Search II

### Heap / Priority Queue
- [ ] 295 · Find Median from Data Stream

### Backtracking
- [ ] 51 · N-Queens

### Advanced Graphs
- [ ] 332 · Reconstruct Itinerary
- [ ] 778 · Swim in Rising Water
- [ ] 269 · Alien Dictionary *(Premium)*

### 2-D Dynamic Programming
- [ ] 329 · Longest Increasing Path in a Matrix
- [ ] 115 · Distinct Subsequences
- [ ] 312 · Burst Balloons
- [ ] 10 · Regular Expression Matching

### Intervals
- [ ] 1851 · Minimum Interval to Include Each Query