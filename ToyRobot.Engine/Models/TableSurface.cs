using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Engine.Interfaces;

namespace ToyRobot.Engine.Models
{
    public class TableSurface : ITableSurface
    {
        public int Rows { get; }
        public int Columns { get; }

        public TableSurface(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
        }

        // Validate if location specified is within the table surface.
        public bool IsLocationValid(Location location)
        {
            return location.X < Columns && location.X >= 0 &&
                   location.Y < Rows && location.Y >= 0;
        }
    }
}
