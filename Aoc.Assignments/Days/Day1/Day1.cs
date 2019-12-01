using System.Collections.Generic;
using System.IO;
using Aoc.Core;

namespace Aoc.Assignments.Days.Day1
{
    public class Day1
    {
        public int CalculateFuel(int mass)
        {
            return ((int)mass / 3) - 2;
        }

        public int CalculateFuelWithAddedFuel(int mass)
        {
            var fuel = this.CalculateFuel(mass);

            if (fuel > 0)
            {
                return fuel + this.CalculateFuelWithAddedFuel(fuel);
            }
            else
            {
                return 0;
            }
        }
    }
}