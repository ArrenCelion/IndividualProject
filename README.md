# Individual Project
A project made for the course "Projektledning & Agila metoder" which consists of a solution with 4 distinct projects (1 main menu, and 3 modular projects made so they can easily be extracted)

## Trello-board

[Trello](https://trello.com/invite/b/681a4adb3d54ee59949e60ca/ATTI9415e769bad798b277df1407bb006d24538CDC3F/inlamningsuppgift-console)

## Overview

This solution is a modular, multi-project .NET 9 console application suite featuring:
- **CalculatorApp**: Perform and manage advanced calculations.
- **ShapesApp**: Calculate and manage geometric shapes.
- **RockPaperScissorApp**: Play and track Rock, Paper, Scissors games.
- **TripleProject**: A main entry point for launching and integrating the above modules.
- **Commons**: Shared utilities and UI components.
- **Services**: Business logic and strategies for calculations and shapes.
- **DataAccessLayer**: Entity Framework Core data models and context.

All projects use a clean architecture approach, dependency injection (Autofac), and Spectre.Console for a rich terminal UI.
CalculatorApp and ShapesApp utilises the Strategy Pattern for easier scalability

---

## Features

- **CalculatorApp**:  
  - Addition, subtraction, multiplication, division, modulus, square root.
  - Calculation history: view, update, delete.
  - Input validation and error handling.

- **ShapesApp**:  
  - Calculate area and circumference for various shapes.
  - Manage and view shape calculation history.

- **RockPaperScissorApp**:  
  - Play against the computer.
  - Track game history and statistics.

- **TripleProject**:  
  - Unified main menu to access all modules.

- **Commons**:  
  - Menu display, input helpers, and shared UI logic.

---

## Project Structure

- **App Projects**: Contain entry points, controllers, and menu logic.
- **Services**: Business logic, calculation strategies, and interfaces.
- **DataAccessLayer**: Models, DTOs, and EF Core context.
- **Commons**: Shared UI and utility classes.

---

## Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- Visual Studio 2022 or later (recommended)

### Build & Run

1. Download the ZIP file from GitHub and extract it.

2. Open the solution file
- Open `IndividualProject.sln` in Visual Studio

3. Restore NuGet packages
- Right-click on the solution in Solution Explorer
- Select "Restore NuGet Packages"

4. Configure the database
- Update the connection string in `appsettings.json` with your database settings

5. Start the project
- Press F5 or click "Start" in Visual Studio
- Alternatively, run from terminal:
```bash
dotnet run
```

---

## Usage

- **Navigation:** Use arrow keys and Enter to select menu options.
- **Calculator:** Choose an operation, enter numbers, and manage history.
- **Shapes:** Select a shape, input dimensions, and view results/history.
- **Rock, Paper, Scissors:** Play rounds and view statistics.

---


## Technologies Used

- .NET 9 / C# 13
- Spectre.Console
- Entity Framework Core
- Autofac (Dependency Injection)

---

## Authors

Contributors names and contact info

Rut Frisk 
[@ArrensDesign](https://www.instagram.com/arrensdesign/)

## Version History

* 0.1
    * Initial Release

## Acknowledgments

- [Spectre.Console](https://spectreconsole.net/)
- .NET and open-source community
