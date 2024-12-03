# League Ranking Calculator

A production-ready, maintainable, and testable command-line application built with .NET and C# to calculate and display the ranking table for a league based on game results.

## Features

- **Command-Line Interface**: Accepts input via file or standard input.
- **Robust Parsing**: Validates and parses game results accurately.
- **Ranking Calculation**: Calculates points based on game outcomes with proper ranking.
- **Ordered Output**: Displays rankings from most to least points, handling ties appropriately.
- **Unit Testing**: Comprehensive test coverage using NUnit.

## Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/es-es/download/dotnet/8.0) or later installed on your machine.

## Project Structure

    MatchesConsole/
    ├── Program.cs
    ├── Models/
    │   └── GameResult.cs
    │   └── Team.cs
    ├── Services/
    │   ├── ILeagueService.cs
    │   └── LeagueService.cs
    ├── Utilities/
    │   └── InputParser.cs
    ├── MatchesConsole.csproj
    MatchesUnitTests
    ├── UnitTest.cs
    ├── MatchesUnitTests.csproj
    Solution.sln
    README.md

- **Program.cs:** Entry point of the application.
- **Models/GameResult.cs:** Represents a game result.
- **Models/Team.cs:** Represents a team in the league.
- **Services/ILeagueService.cs:** Interface defining ranking calculation.
- **Services/LeagueService.cs:** Implements ranking calculation logic.
- **Utilities/InputParser.cs:** Parses input lines into game results.
- **MatchesUnitTests:** Contains NUnit test project.
- **Solution.sln:** Solution file encompassing the projects.

## Usage

The application can be run either by providing a file containing game results or by inputting results directly via standard input.

**From a file**

Prepare the input file:

    dotnet run --project MatchesConsole.csproj input.txt

**From standard input**

Run the application without arguments:

    dotnet run --project MatchesConsole.csproj

## Sample input and output

**Sample Input:**

    Lions 3, Snakes 3
    Tarantulas 1, FC Awesome 0
    Lions 1, FC Awesome 1
    Tarantulas 3, Snakes 1
    Lions 4, Grouches 0

**Expected Output:**

    1. Tarantulas, 6 pts
    2. Lions, 5 pts
    3. FC Awesome, 1 pt
    3. Snakes, 1 pt
    5. Grouches, 0 pts


## Testing

The project includes unit tests using NUnit to ensure correctness and reliability.

**Running Tests**

  1. Navigate to the Test Project Directory
     
    cd MatchesUnitTests


  3. Run the Tests
     
    dotnet test

All tests should pass, confirming the application's functionality.
