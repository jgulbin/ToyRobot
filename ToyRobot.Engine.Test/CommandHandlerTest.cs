using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Engine.Enums;
using ToyRobot.Engine.Handlers;
using ToyRobot.Engine.Models;

namespace ToyRobot.Engine.Test
{
    public class CommandHandlerTest
    {



        [Theory]
        [InlineData("PLACE 1,2,NORTH")]
        [InlineData("MoVe")]
        [InlineData("left")]
        [InlineData("righT")]
        [InlineData("Report")]
        public void IsValidCommand(string cmd)
        {
            //Arrange
            var tableSurface = new TableSurface(5, 5);
            var robot = new Robot();
            var commandHanlder = new CommandHandler(robot, tableSurface);

            //Act
            var result = commandHanlder.ExecuteCommand(cmd);

            //Assert
            Assert.IsNotType<ArgumentException>(result);
        }


        [Theory]
        [InlineData("")]
        [InlineData("a a a")]
        [InlineData("PLACE x,y,NORTH")]
        public void IsNotValidCommand(string cmd)
        {
            //Arrange
            var tableSurface = new TableSurface(5, 5);
            var robot = new Robot();
            var commandHanlder = new CommandHandler(robot, tableSurface);

            //Act
            var argumentException =  
                Assert.Throws<ArgumentException>(() => 
                    commandHanlder.ExecuteCommand(cmd));

            //Assert
            //
            Assert.IsType<ArgumentException>(argumentException);
        }

        [Fact]
        public void IsValidPlaceCommand()
        {
            //Arrange
            var tableSurface = new TableSurface(5, 5);
            var robot = new Robot();
            var commandHanlder = new CommandHandler(robot, tableSurface);

            //Act
            commandHanlder.ExecuteCommand("PLACE 1,2,EAST");
            
            //Assert
            Assert.NotNull(robot.Location);
        }

        [Fact]
        public void IsNotValidPlaceCommand()
        {
            //Arrange
            var tableSurface = new TableSurface(5, 5);
            var robot = new Robot();
            var commandHanlder = new CommandHandler(robot, tableSurface);

            //Act
            commandHanlder.ExecuteCommand("PLACE 2,5,EAST");

            //Assert
            Assert.Null(robot.Location);
        }

        [Fact]
        public void IsValidReport()
        {
            //Arrange
            var tableSurface = new TableSurface(5, 5);
            var robot = new Robot();
            var commandHanlder = new CommandHandler(robot, tableSurface);

            //Act
            commandHanlder.ExecuteCommand("PLACE 2,1,EAST");
            commandHanlder.ExecuteCommand("MOVE");
            commandHanlder.ExecuteCommand("LEFT");
            commandHanlder.ExecuteCommand("MOVE");
            commandHanlder.ExecuteCommand("Right");
            commandHanlder.ExecuteCommand("Right");
            commandHanlder.ExecuteCommand("Move");
            commandHanlder.ExecuteCommand("Move");
            commandHanlder.ExecuteCommand("Report");

            Assert.Equal("Output: 3,0,SOUTH", commandHanlder.GetOutput());
        }

        [Fact]
        public void IsNotValidMove()
        {
            //Arrange
            var tableSurface = new TableSurface(5, 5);
            var robot = new Robot();
            var commandHanlder = new CommandHandler(robot, tableSurface);

            //Act
            commandHanlder.ExecuteCommand("PLACE 2,1,EAST");
            commandHanlder.ExecuteCommand("MOVE");
            commandHanlder.ExecuteCommand("MOVE");
            
            //all move command beyond this line will be discarded
            commandHanlder.ExecuteCommand("MOVE");
            commandHanlder.ExecuteCommand("MOVE");
            commandHanlder.ExecuteCommand("MOVE");
            

            Assert.NotEqual("Output: 7,1,EAST", commandHanlder.GetOutput());
        }
    }
}
