# Dependency Inversion Logger Project

## Overview

This project demonstrates the **Dependency Inversion Principle (DIP)** using a logging system in .NET.

- High-level modules (`Application`) depend only on the `ILogger` interface.
- Low-level modules (`ConsoleLogger`, `FileLogger`) implement this interface.
- This allows loggers to be swapped freely without modifying business logic.

---

## Project Structure

```
DependencyInversionLogger/
│── DependencyInversionLogger.sln
│── .editorconfig
│
├──── DependencyInversionLogger/
│       ├── ILogger.cs
│       ├── ConsoleLogger.cs
│       ├── FileLogger.cs
│       ├── Application.cs
│       └── Program.cs
│
└─── DependencyInversionLogger.Tests/
        ├── ConsoleLoggerTests.cs
        └── FileLoggerTests.cs
```

---

## How to Build and Run

From the **root folder** (`DependencyInversionLogger/`):

```bash
# Build the solution
dotnet build

# Check code formatting
dotnet format --verify-no-changes

# Run tests
dotnet test

# Run the application
dotnet run --project DependencyInversionLogger
```

- Console logs will appear in the terminal.
- File logs are written to `logs/app.log`. The program automatically creates the `logs` folder if it does not exist.

> **Tip:** You can check the log data by opening the file `logs/app.log` in any text editor after running the application.

---

## Authors

- **Kallepally Sai Kiran (112201044)** → Implemented in .NET, designed with Dependency Inversion Principle.
