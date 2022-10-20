using ToyRobot.Engine.Handlers;
using ToyRobot.Engine.Interfaces;
using ToyRobot.Engine.Models;

namespace ToyRobot.Simulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var description = @"
**********************************************************************
*                                                                    *
*                        WELCOME!                                    *
*                 TOY ROBOT SIMULATOR v1.0                           *  
*                                                                    *
**********************************************************************

Instructions:

1. Place the toy robot on a 5 x 5 square tabletop
    using the following command:

    PLACE X,Y,DIRECTION 
      -  where X and Y are integers that indicate a location 
         on the tabletop and DIRECTION is a string indicating 
         which direction the robot should face (must be either 
         NORTH, SOUTH, EAST or WEST)
         Example: PLACE 1,3,NORTH

2. When the toy robot is placed, you can enter the following commands:
                
    REPORT – Shows the current status of the toy. 
    LEFT   – turns the toy 90 degrees left.
    RIGHT  – turns the toy 90 degrees right.
    MOVE   – Moves the toy 1 unit in the facing direction.
   
 3. EXIT  – to exit the Toy Robot Simulator.

ENTER A COMMAND:";

            ITableSurface tableSurface = new TableSurface(5, 5);
            IRobot robot = new Robot();
            ICommandHandler commandHandler = new CommandHandler(robot, tableSurface);

            var stopApplication = false;
            Console.WriteLine(description);
             
            while (!stopApplication)
            {
                var command = Console.ReadLine();
                if (String.IsNullOrEmpty(command)) continue;

                if (command.ToLower() == "exit")
                {
                    stopApplication = true;
                }
                else
                {
                    try
                    {
                        var result = commandHandler.ExecuteCommand(command);
                        if (!String.IsNullOrEmpty(result))
                            Console.WriteLine(result);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}