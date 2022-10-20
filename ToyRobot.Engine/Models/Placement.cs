using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Engine.Enums;

namespace ToyRobot.Engine.Models
{
    public class Placement
    {
        public Location Location { get; set; }
        public Direction Direction { get; set; }

        public Placement(Location location, Direction direction)
        {
            Location = location;
            Direction = direction;
        }
    }
}
