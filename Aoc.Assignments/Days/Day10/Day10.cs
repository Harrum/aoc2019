using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Aoc.Assignments.Days.Day10
{
    public class Day10
    {
        public int GetAsteroidsFromBestLocation(string[] input)
        {
            var field = this.CreateField(input);
            var highestCount = int.MinValue;
            var location = new Point(0,0);

            for (int x = 0; x < field.GetLongLength(0); x++)
            {
                for (int y = 0; y < field.GetLongLength(1); y++)
                {
                    if (field[x,y] == '#')
                    {
                        var asteroidsInVision = this.GetAsteroidsFromLocation(new Point(x,y), field);

                        if (asteroidsInVision > highestCount)
                        {
                            highestCount = asteroidsInVision;
                            location = new Point(x,y);
                        }
                    }
                }
            }

            Console.WriteLine("Location is: X " + location.X + " Y " + location.Y);
            return highestCount;
        }

        public int GetAsteroidsFromLocation(Point location, char[,] field)
        {
            var angles = new List<double>();
            for (int x = 0; x < field.GetLongLength(0); x++)
            {
                for (int y = 0; y < field.GetLongLength(1); y++)
                {
                    if (x == location.X && y == location.Y)
                    {
                        continue;
                    }
                    if (field[x,y] == '#')
                    {
                        var radians = Math.Atan2(y - location.Y, x - location.X);
                        var angle = radians * (180/Math.PI);
                        angles.Add(angle);
                    }
                }
            }

            return angles.Distinct().Count();
        }

        public Point GetNthVaporizedAsteroid(int n, Point location, string[] input)
        {
            var field = this.CreateField(input);

            var fieldWithAngles = this.GetAsteroidAnglesFromLocation(location, field);

            var angles = fieldWithAngles.Cast<double?>().Where(a => a.HasValue).Distinct().Select(a => a.Value).OrderBy(a => a).ToList();
            var index = angles.IndexOf(-90);
            var shots = 0;
            var lastShotAsteroid = default(Point);
            while (shots < n)
            {
                if (index >= angles.Count)
                {
                    index = 0;
                }

                var p = this.GetClosestAsteroid(location, angles.ElementAt(index), fieldWithAngles);
                index++;
                if (p.HasValue)
                {
                    shots++;
                    lastShotAsteroid = new Point(p.Value.X, p.Value.Y);
                    fieldWithAngles[lastShotAsteroid.X, lastShotAsteroid.Y] = null;
                }
            }

            return lastShotAsteroid;
        }

        private double?[,] GetAsteroidAnglesFromLocation(Point location, char[,] field)
        {
            var fieldWithAngles = new double?[field.GetLongLength(0), field.GetLongLength(1)];
            for (int x = 0; x < field.GetLongLength(0); x++)
            {
                for (int y = 0; y < field.GetLongLength(1); y++)
                {
                    if (x == 11 && y == 12)
                    {

                    }
                    if (x == location.X && y == location.Y)
                    {
                        continue;
                    }
                    if (field[x,y] == '#')
                    {
                        var radians = Math.Atan2(y - location.Y, x - location.X);
                        var angle = (radians * (180/Math.PI));
                        fieldWithAngles[x,y] = angle;
                    }
                }
            }

            return fieldWithAngles;
        }

        private Point? GetClosestAsteroid(Point location, double angle, double?[,] angleField)
        {
            var coords = new List<Point>();

            for (int x = 0; x < angleField.GetLongLength(0); x++)
            {
                for (int y = 0; y < angleField.GetLongLength(1); y++)
                {
                    if (angleField[x,y] == angle)
                    {
                        coords.Add(new Point(x,y));
                    }
                }
            }

            return this.GetClosestPoint(location, coords);
        }

        private Point? GetClosestPoint(Point location, List<Point> points)
        {
            if (!points.Any())
            {
                return null;
            }

            var closestPoint = new Point(int.MaxValue, int.MaxValue);
            var minDistance = int.MaxValue;

            foreach (var p in points)
            {
                var distance = Math.Abs(location.X - p.X) + Math.Abs(location.Y - p.Y);

                if (distance < minDistance)
                {
                    closestPoint = new Point(p.X, p.Y);
                    minDistance = distance;
                }
            }

            return closestPoint;
        }

        public char[,] CreateField(string[] input)
        {
            var field = new char[input.First().Length,input.Length];

            for (int y = 0; y < input.Length; y++)
            {
                var line = input[y];
                for (int x = 0; x < line.Length; x++)
                {
                    field[x,y] = line[x];
                }
            }

            this.PrintField(field);

            return field;
        }

        private void PrintField(char[,] field)
        {
            for (int y = 0; y < field.GetLongLength(1); y++)
            {
                for (int x = 0; x < field.GetLongLength(0); x++)
                {
                    Console.Write(field[x,y]);
                }
                
                Console.Write(Environment.NewLine);
            }
        }
    }
}