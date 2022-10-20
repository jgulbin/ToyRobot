using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Engine.Enums;
using ToyRobot.Engine.Models;

namespace ToyRobot.Engine.Interfaces
{
    public interface IRobot
    {
        public Location Location { get; set; }
        public Direction Direction { get; set; }
        void Place(Location location, Direction direction);
        Location GetNextLocation();
        void RotateLeft();
        void RotateRight();
        void Rotate(int rotationNumber);

    }
}
