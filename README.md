# Toy Robot Simulator
Welcome to Toy Robot Simulator v1.0 

This C# .NET 6 solution is a simulator of a toy robot that moves within a 5x5 square table.The development of this project is driven by unit tests.
### Instructions
- There are no other obstructions on the table surface. The robot is free to roam around the surface of the table, but must be prevented from falling to destruction.
- Any movement that would result in the robot falling from the table must be prevented, however further valid movement commands must still be allowed.
- All commands should be discarded until a valid place command has been executed.

### Commands
All commands should provide output indicating whether or not they succeeded.
- PLACE X,Y,DIRECTION
-- X and Y are integers that indicate a location on the tabletop. DIRECTION is a string indicating which direction the robot should face. It it one of the four cardinal directions: NORTH, EAST, SOUTH or WEST.
- MOVE
-- Instructs the robot to move 1 square in the direction it is facing.
- LEFT
-- Instructs the robot to rotate 90° anticlockwise/counterclockwise.
- RIGHT
-- Instructs the robot to rotate 90° clockwise.
- REPORT
-- Outputs the robot's current location on the tabletop and the direction it is facing.

## Getting Started
---
Use these instructions to get the project up and running.
### Prerequisites
You will need .NET 6 SDK or runtime:
- [.Net 6 or later](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

### Installing
Follow these steps:
1. Clone the repository
```csharp
git clone https://github.com/jgulbin/ToyRobot.git
```
2. At the root directory, restore required packages by running:
```csharp
dotnet restore
```
3. Next, build the solution by running:
```csharp
dotnet build
```
4. Within the ToyRobot.Simulator directory:
```csharp
cd ToyRobot.Simulator
dotnet run
```

5. Within the ToyRobot.Engine.Test directory:
```csharp
cd ToyRobot.Engine.Test
dotnet test
```
