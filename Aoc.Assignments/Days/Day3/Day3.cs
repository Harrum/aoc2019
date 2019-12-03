using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Aoc.Assignments.Days.Day3
{
    public class Day3
    {
        public int GetManhattanDistance(List<Point> list1, List<Point> list2)
        {
            var intersections = list1.Intersect(list2);

            var closestToOrigin = intersections
                .Select(p => new { Point = p, Distance2 = p.X * p.X + p.Y * p.Y })
                .Aggregate((p1, p2) => p1.Distance2 < p2.Distance2 ? p1 : p2)
                .Point;

            return closestToOrigin.X + closestToOrigin.Y;
        }
    }
}