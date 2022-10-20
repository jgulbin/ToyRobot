using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Engine.Models;

namespace ToyRobot.Engine.Interfaces
{
    public interface ITableSurface
    {
        bool IsLocationValid(Location location);
    }
}
