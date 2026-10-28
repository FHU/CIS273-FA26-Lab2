# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

CIS 273 (Data Structures) Lab 2: a .NET solution of small console projects exercising stacks, queues, and linked lists. Most methods are **stubs that students implement** (e.g. `IsBalanced` returns `false`, `Evaluate` returns `null`, `ReverseFirstK` is empty with step-by-step hint comments). The unit tests define the expected behavior, so read them before implementing anything.

Projects in `Lab2.sln`:

| Project | Covered by UnitTests? |
|---|---|
| PrayerScheduler | yes (`PrayerSchedulerUnitTests`) |
| PostfixCalculator | yes (`PostfixCalculatorTests`) |
| BalancedParentheses | yes (`BalancedParenthesesTests`) |
| ReverseFirstK | yes (`ReverseFirstKTests`) |
| MusicPlaylist | no (in-class example) |
| KthToLast | yes (`KthToLastTests`) |

All projects target **net10.0** and are `Exe` with implicit usings and nullable enabled. There are no external dependencies besides MSTest in UnitTests.

## Commands

```bash
dotnet build Lab2.sln                                   # build everything
dotnet test UnitTests/UnitTests.csproj                  # run all tests
dotnet test UnitTests/UnitTests.csproj --filter "FullyQualifiedName~ReverseFirstKTests"       # one class
dotnet test UnitTests/UnitTests.csproj --filter "FullyQualifiedName~PrayerSchedulerUnitTests" # note: "UnitTests" suffix
dotnet test UnitTests/UnitTests.csproj --filter "Name=Postfix3"                               # one test
dotnet run --project KthToLast                          # run a console project
```

Tests use MSTest 4 (`Assert.ThrowsExactly<T>`, `CollectionAssert`). ReverseFirstKTests uses `Assert.Throws<T>` instead, which also passes for subclasses. `UnitTests/Usings.cs` holds the global `using` for MSTest.

## Architecture Notes

- **Static-method projects** (PostfixCalculator, BalancedParentheses, ReverseFirstK): the logic lives as `public static` methods on `Program` in `Program.cs`, and the tests call them as `Program.Method(...)`. Keep these signatures: `double? Evaluate(string)` (null means invalid; tokens are split on any whitespace, negative operands like `-3` are allowed, and division by zero returns Infinity/NaN rather than null), `bool IsBalanced(string)`, `void ReverseFirstK<T>(Queue<T>, int k)`. ReverseFirstK may use only stacks and queues. If k > count, reverse the whole queue. The stub's comment says k < 0 should do nothing, but the tests expect `ArgumentException` for k < 0 and `ArgumentNullException` for a null queue. `IsBalanced` also treats `<` `>` as a bracket pair (Parentheses12–14).
- **PrayerScheduler**: the class `PrayerScheduler` has the same name as its namespace, so tests write `PrayerScheduler.PrayerScheduler`. Its state:
  - `DailyPrayers` (List)
  - a private `Queue<Prayer>` exposed as `NonDailyPrayers` (a `ToList()` copy, so mutating it does nothing)
  - `AnsweredPrayers`
  - `NumDailyPrayers` and `NumNonDailyPrayers`, which are get-only auto-properties (`{get;}`), so they can't be assigned outside the constructor. The tests expect them to track the current daily and non-daily counts.

  Expected behavior, inferred from the tests:
  - `AddPrayer` sends prayers with `IsAnswered == true` to `AnsweredPrayers` and the rest to daily or non-daily. It throws `DuplicateIDException` when the ID is already in use.
  - `GetPrayers(n)` returns **all** daily prayers, even when there are more than n, and then fills the rest of the n slots from the front of the non-daily queue. Those non-daily prayers then rotate to the back of the queue, and the list wraps around (it can repeat a prayer) when n is larger than the supply (TestAllTogether). GetPrayers must also set `LastPrayed`.
  - `AnswerPrayer(id)` is a stub. It should find the prayer in the daily or non-daily prayers, mark it answered, and move it to `AnsweredPrayers`. The counts must drop to match (TestGetPrayersAndAnswer, TestAllTogether), and the rest of the non-daily queue should stay in its original order.
- **KthToLast**: `LinkedList<T>` extension methods in `LinkedListExtensions.cs`. Both are stubs. The singly-linked version may only walk forward from `First` via `Next`. Both throw `IndexOutOfRangeException` when k < 0 or k >= Count (including an empty list).
- **MusicPlaylist**: `MusicPlayer` uses a `Queue<Song>` for up-next and a `Stack<Song>` for history. It uses queue rotation to put songs back at the front and for shuffle.
