using System;
using System.IO;
using System.Linq;
using Aoc.Assignments.Days.Day3;
using Aoc.Core;

namespace Aoc.Assignments
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var day = new Day3();
            var input = InputReader.ReadStrings("../Aoc.Assignments/Inputs/day3.txt").ToArray();

            var line1 = day.CreateWire(input[0]);
            var line2 = day.CreateWire(input[1]);

            var result = day.GetShortestDistance(line1, line2);

            Console.WriteLine("Value is: " + result);
        }
    }
}