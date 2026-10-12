# CW-2-s31992

A C# console application that models cargo containers and ships. The project demonstrates object-oriented programming with base classes, inheritance, interfaces, custom exceptions and method overloading.

The application creates different container types, loads and unloads cargo, and transfers containers between ships.

## Features

- Liquid, gas and refrigerated container types.
- Automatic container serial number generation.
- Container loading and unloading.
- Maximum payload validation.
- Overfill handling through a custom `OverfillException`.
- Hazard notifications through the `IHazardNotifier` interface.
- Loading limits for hazardous cargo.
- Retention of 5% of the cargo when unloading a gas container.
- Product temperature validation for refrigerated containers.
- Loading individual containers or lists of containers onto a ship.
- Removing, replacing and transferring containers between ships.
- Validation of a ship's container count and total weight limits.

## Tech Stack

- C#
- .NET 8
- Console application

## Getting Started

Requirements:

- .NET 8 SDK

From the repository root:

```bash
cd CW2
dotnet restore
dotnet run
```

The application runs the demonstration scenario defined in `Program.cs`.

## Project Structure

```text
CW2/
├── Classes/
│   ├── Container.cs
│   ├── GasContainer.cs
│   ├── LiquidContainer.cs
│   ├── RefrigeratedContainer.cs
│   └── Ship.cs
├── Exceptions/
│   └── OverfillException.cs
├── Interfaces/
│   └── IHazardNotifier.cs
├── Program.cs
└── CW2.csproj
```

## Notes

The repository does not include automated tests. The demonstration in `Program.cs` provides examples of how the classes behave.
