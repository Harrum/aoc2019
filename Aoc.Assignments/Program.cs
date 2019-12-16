using System;
using System.IO;
using System.Linq;
using Aoc.Assignments.Days.Day10;
using Aoc.Core;

namespace Aoc.Assignments
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var day = new Day10();
            var input = InputReader.ReadStrings("../Aoc.Assignments/Inputs/day10.txt").ToArray();

            var result = day.GetAsteroidsFromBestLocation(input);

            Console.WriteLine("Value is: " + result);
        }
    }
}