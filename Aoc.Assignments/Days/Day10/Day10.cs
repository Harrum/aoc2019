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

            for (int x = 0; x < field.GetLongLength(0); x++)
            {
                for (int y = 0; y < field.GetLongLength(1); y++)
                {
                    if (field[x,y] == '#')
                    {
                        var asteroidsInVision = this.GetAsteroidsFromLocation(new Point(x,y), field);
                        highestCount = asteroidsInVision > highestCount ? asteroidsInVision : highestCount;
                        Console.Write(asteroidsInVision);
                    }
                    else
                    {
                        Console.Write('.');
                    }
                }
                Console.Write(Environment.NewLine);
            }

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

        private char[,] CreateField(string[] input)
        {
            var field = new char[input.First().Length,input.Length];

            for (int y = 0; y < input.Length; y++)
            {
                var line = input[y];
                for (int x = 0; x < line.Length; x++)
                {
                    field[y,x] = line[x];
                }
            }

            this.PrintField(field);

            return field;
        }

        private void PrintField(char[,] field)
        {
            for (int x = 0; x < field.GetLongLength(0); x++)
            {
                for (int y = 0; y < field.GetLongLength(1); y++)
                {
                    Console.Write(field[x,y]);
                }
                
                Console.Write(Environment.NewLine);
            }
        }
    }
}