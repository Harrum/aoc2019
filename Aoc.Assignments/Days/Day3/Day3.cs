using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Aoc.Assignments.Days.Day3
{
    public class Day3
    {
        public int GetClosestManhattanDistance(List<Point> list1, List<Point> list2)
        {
            var intersections = list1.Intersect(list2);

            var distances = new List<int>();
            foreach (var item in intersections)
            {
                distances.Add(this.GetManhattenDistance(item));
            }

            return distances.Min();
        }

        public int GetShortestDistance(List<Point> list1, List<Point> list2)
        {
            var intersections = list1.Intersect(list2);

            var distances = new List<int>();
            foreach (var item in intersections)
            {
                var distance1 = this.GetDistance(item, list1);
                var distance2 = this.GetDistance(item, list2);
                distances.Add(distance1 + distance2);
            }

            return distances.Min();
        }

        public List<Point> CreateWire(string input)
        {
            var coords = input.Split(',');

            var current = new Point(0,0);

            var points = new List<Point>();
            foreach (var coord in coords)
            {
                var dir = coord.Substring(0, 1);
                var length = int.Parse(coord.Remove(0, 1));

                for (int i = 0; i < length; i++)
                {
                    if (dir == "R")
                    {
                        current = new Point(current.X + 1, current.Y);
                    }
                    if (dir == "L")
                    {
                        current = new Point(current.X - 1, current.Y);
                    }
                    if (dir == "D")
                    {
                        current = new Point(current.X, current.Y - 1);
                    }
                    if (dir == "U")
                    {
                        current = new Point(current.X, current.Y + 1);
                    }

                    points.Add(new Point(current.X, current.Y));
                }
            }

            return points;
        }

        private int GetManhattenDistance(Point point)
        {
            return System.Math.Abs(point.X) + System.Math.Abs(point.Y);
        }

        private int GetDistance(Point intersection, List<Point> points)
        {
            var totalDist = 0;

            foreach (var point in points)
            {
                totalDist++;

                if (point.X == intersection.X && point.Y == intersection.Y)
                {
                    return totalDist;
                }
            }

            return totalDist;
        }
    }
}