# CIS 273 Lab 2: Stacks, Queues, and Linked Lists

In this lab you will solve five small problems using stacks, queues, and linked lists. Each problem is its own console project in `Lab2.sln`. The method you need to write is already there as a stub, with a comment above it that explains what it should do.

The unit tests in `UnitTests/` decide whether your code is correct. Read the tests for a problem before you start it.

## Requirements

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- Visual Studio, VS Code with the C# Dev Kit, or Rider

## Getting started

Open `Lab2.sln` in your editor, or use the command line:

```bash
dotnet build Lab2.sln                 # build every project
dotnet test UnitTests/UnitTests.csproj  # run all the tests
```

To run the tests for one problem only:

```bash
dotnet test UnitTests/UnitTests.csproj --filter "FullyQualifiedName~ReverseFirstKTests"
```

The test classes are `BalancedParenthesesTests`, `PostfixCalculatorTests`, `ReverseFirstKTests`, `KthToLastTests`, and `PrayerSchedulerUnitTests`.

To run one test by name:

```bash
dotnet test UnitTests/UnitTests.csproj --filter "Name=Postfix3"
```

When you start, most tests will fail. That is expected. They will pass as you finish each problem.

## The problems

### 1. Balanced Parentheses (`BalancedParentheses/Program.cs`)

Write `bool IsBalanced(string s)`. It returns `true` when every opening bracket has a matching closing bracket of the same kind, and they are closed in the right order. Handle all four kinds: `( )`, `[ ]`, `{ }`, and `< >`. Ignore every other character.

### 2. Postfix Calculator (`PostfixCalculator/Program.cs`)

Write `double? Evaluate(string s)`. It evaluates an expression written in postfix notation (for example, `2 6 + 3 *` is 24). Return `null` when the expression can't be evaluated. The comment above the method lists the rules, with examples. Pay attention to the rules about whitespace, negative numbers, and division by zero.

### 3. Reverse First K (`ReverseFirstK/Program.cs`)

Write `void ReverseFirstK<T>(Queue<T> queue, int k)`. It reverses the first `k` elements of the queue and leaves the rest in order. **You may use only stacks and queues.** If `k` is larger than the queue, reverse the whole queue. Check the tests to see what should happen when `k` is negative or the queue is `null`.

### 4. Kth to Last (`KthToLast/LinkedListExtensions.cs`)

Write two extension methods on `LinkedList<T>` that return the element `k` positions from the end (`k = 0` is the last element):

- `KthToLastSinglyLinked`: treat the list as singly linked. Start at `First` and move forward only, using `Next`.
- `KthToLastDoublyLinked`: you may start at `Last` and move backward with `Previous`.

Both methods throw `IndexOutOfRangeException` when there is no element at position `k`.

### 5. Prayer Scheduler (`PrayerScheduler/PrayerScheduler.cs`)

A scheduler that keeps three groups of prayers: daily, non-daily (a queue), and answered. Make `NumDailyPrayers` and `NumNonDailyPrayers` computed properties that get their values from the daily list and the non-daily queue. That way they stay correct as long as each prayer is in the right group. Then write these methods:

- `AddPrayer`: put each prayer in the right group, and throw `DuplicateIDException` if the ID is already in use.
- `GetPrayers(n)`: return a list of prayers to pray today. Read the tests carefully. They show how daily and non-daily prayers are chosen, how the non-daily queue rotates, and how `LastPrayed` is set.
- `AnswerPrayer(id)`: find the prayer with that ID in the daily or non-daily prayers, mark it answered, and move it to `AnsweredPrayers`. When you take a prayer out of the non-daily queue, keep the rest of the queue in its original order.

## Example code: Music Playlist

`MusicPlaylist/` is the example from class. It uses a queue for the songs coming up next and a stack for the play history. It has no tests. Use it as a reference for working with `Queue<T>` and `Stack<T>`.

## Submitting

1. Make sure everything builds, and run `dotnet test UnitTests/UnitTests.csproj` to see which tests pass.
2. Commit your changes and push them to your GitHub repository.
3. Copy the repository's URL and submit it on Canvas.
