using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Engine.Enums;
using ToyRobot.Engine.Interfaces;
using ToyRobot.Engine.Models;

namespace ToyRobot.Engine.Handlers
{
    public class CommandHandler : ICommandHandler
    {
        private const int validPlaceCommandCount = 2;
        private const int validPlaceParamsCount = 3;
       
        public IRobot Robot { get; }
        public ITableSurface TableSurface { get; }
        public CommandHandler(IRobot robot, ITableSurface tableSurface)
        {
            Robot = robot;
            TableSurface = tableSurface;
        }

        public string ExecuteCommand(string cmd)
        {
            var command = GetCommand(cmd.Split(' '));
            if (command != Command.PLACE && Robot.Location == null) return null;
            
            switch (command)
            {
                case Command.PLACE:
                    var placement = GetPlacement(cmd.Split(' '));
                    if (TableSurface.IsLocationValid(placement.Location))
                        Robot.Place(placement.Location, placement.Direction);
                    break;
                case Command.MOVE:
                    var newLocation = Robot.GetNextLocation();
                    if
                        (TableSurface.IsLocationValid(newLocation))
                        Robot.Location = newLocation;
                    break;
                case Command.LEFT:
                    Robot.RotateLeft();
                    break;
                case Command.RIGHT:
                    Robot.RotateRight();
                    break;
                case Command.REPORT:
                    return GetOutput();
            }

            return string.Empty;

        }

        private Command GetCommand(string[] cmd)
        {
            if (!Enum.TryParse(cmd[0], true, out Command command))
                throw new ArgumentException("Invalid command.  Please try again. Valid formats: PLACE X,Y,DIRECTION|MOVE|LEFT|RIGHT|REPORT");
            return command;
        }

        private Placement GetPlacement(string[] cmd)
        {
            if(cmd.Length != validPlaceCommandCount)
                throw new ArgumentException("Invalid PLACE command parameters. Valid format: PLACE X,Y,DIRECTION");

            string[] cmdParameters = cmd[1].Split(',');

            if(cmdParameters.Length != validPlaceParamsCount)
                throw new ArgumentException("Invalid PLACE command parameters. Valid format: PLACE X,Y,DIRECTION");

            if (!int.TryParse(cmdParameters[0], out int x) || !int.TryParse(cmdParameters[1], out int y))
                throw new ArgumentException("Invalid location. X and Y must be a number. Example: PLACE 1,2,NORTH");

            if (!Enum.TryParse(cmdParameters[cmdParameters.Length - 1], true, out Direction direction))
                throw new ArgumentException("Invalid direction. Please select from one of the following directions: NORTH|EAST|SOUTH|WEST");

           return new Placement(new Location(x, y), direction);

        }

        public string GetOutput()
        {
            return string.Format("Output: {0},{1},{2}", Robot.Location.X, Robot.Location.Y, Robot.Direction.ToString().ToUpper());
        }


    }
}
