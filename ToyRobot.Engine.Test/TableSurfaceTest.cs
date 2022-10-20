using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Engine.Models;

namespace ToyRobot.Engine.Test
{
    public class TableSurfaceTest
    {
        [Theory]
        [InlineData(3, 4)]
        [InlineData(1, 2)]
        public void IsValidLocation(int x, int y)
        {
            //Arrange
            var tableSurface = new TableSurface(5, 5);
            Location location = new Location(x, y);

            //Act
            var isValid = tableSurface.IsLocationValid(location);

            //Assert
            Assert.True(isValid, "Location is not valid");
        }

        [Theory]
        [InlineData(6,3)]
        [InlineData(7, 5)]
        public void IsNotValidLocation(int x, int y)
        {
            //Arrange
            var tableSurface = new TableSurface(5, 5);
            Location location = new Location(x, y);

            //Act
            var isNotValid = tableSurface.IsLocationValid(location);

            //Assert
            Assert.False(isNotValid, "Location is valid");
        }
    }
}
