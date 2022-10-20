using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Engine.Enums;
using ToyRobot.Engine.Handlers;
using ToyRobot.Engine.Interfaces;

namespace ToyRobot.Engine.Models
{
    public class Robot : IRobot
    {
        public Location Location { get; set; }
        public Direction Direction { get; set; }
        public ITableSurface TableSurface { get; }
        public ICommandHandler CommandHandler { get; }
        public Robot(ITableSurface tableSurface, ICommandHandler commandHandler)
        {
            TableSurface = tableSurface;
            CommandHandler = commandHandler;
        }

        public string ExecuteCommand(string cmd)
        {
            var command = CommandHandler.GetCommand(cmd.Split(' '));
            if (command != Command.PLACE && Location == null) return null;

            switch (command)
            {
                case Command.PLACE:
                    var placement = CommandHandler.GetPlacement(cmd.Split(' '));
                    if (TableSurface.IsLocationValid(placement.Location))
                        Place(placement.Location, placement.Direction);
                    break;
                case Command.MOVE:
                    var newLocation = GetNextLocation();
                    if (TableSurface.IsLocationValid(newLocation))
                        Location = newLocation;
                    break;
                case Command.LEFT:
                    RotateLeft();
                    break;
                case Command.RIGHT:
                    RotateRight();
                    break;
                case Command.REPORT:
                    return GetOutput();
            }

            return string.Empty;

        }

        public string GetOutput()
        {
            return string.Format("Output: {0},{1},{2}", Location.X, Location.Y, Direction.ToString().ToUpper());
        }

        public void Place(Location location, Direction direction)
        {
            Location = location;
            Direction = direction;
        }

        public Location GetNextLocation()
        {
            var newLocation = new Location(Location.X, Location.Y);
            switch (Direction)
            {
                case Direction.North:
                    newLocation.Y = Location.Y + 1;
                    break;
                case Direction.East:
                    newLocation.X = Location.X + 1;
                    break;
                case Direction.South:
                    newLocation.Y = Location.Y - 1;
                    break;
                case Direction.West:
                    newLocation.X = Location.X - 1;
                    break;
            }

            return newLocation;
        }

        //Instructs the robot to rotate 90° anticlockwise/counterclockwise.
        public void RotateLeft()
        {
            Rotate(-1);
        }

        //Instructs the robot to rotate 90° clockwise.
        public void RotateRight()
        {
            Rotate(1);

        }
        public void Rotate(int rotationNumber)
        {
            var directions = (Direction[])Enum.GetValues(typeof(Direction));
            Direction newDirection;
            if (Direction + rotationNumber < 0)
                newDirection = directions[directions.Length - 1];
            else
            {
                var index = (int)(Direction + rotationNumber) % directions.Length;
                newDirection = directions[index];
            }
            Direction = newDirection;
        }

    }
}
