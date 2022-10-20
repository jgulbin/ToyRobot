using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Engine.Enums;
using ToyRobot.Engine.Interfaces;
using ToyRobot.Engine.Models;

namespace ToyRobot.Engine.Test
{
    public class RobotTest
    {

        [Fact]
        public void IsValidPlace()
        {
            //Arrange
            int x = 3;
            int y = 4;
            var location = new Location(x, y);
            var robot = new Robot();

            //Act
            robot.Place(location, Direction.East);

            //Assert
            Assert.Equal(x, robot.Location.X);
            Assert.Equal(y, robot.Location.Y);
            Assert.Equal(Direction.East, robot.Direction);
        }

        [Fact]
        public void IsValidTurnLeft()
        {
            //Arrange
            var robot = new Robot
            {
                Direction = Direction.South,
                Location = new Location(3, 1)
            };

            //Act
            robot.RotateLeft();

            //Assert
            Assert.Equal(Direction.East, robot.Direction);
        }

        [Fact]
        public void IsValidTurnRight()
        {
            //Arrange
            var robot = new Robot
            {
                Direction = Direction.South,
                Location = new Location(3, 1)
            };

            //Act
            robot.RotateRight();

            //Assert
            Assert.Equal(Direction.West, robot.Direction);
        }

        [Fact]
        public void IsValidMove()
        {
            //Arrange
            var robot = new Robot
            {
                Direction = Direction.West,
                Location = new Location(2, 1)
            };

            //Act
            var newlocation = robot.GetNextLocation();

            //Assert
            Assert.Equal(1, newlocation.X);
            Assert.Equal(1, newlocation.Y);
        }
    }
}
