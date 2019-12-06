using System;
using System.IO;
using System.Linq;
using Aoc.Assignments.Days.Day6;
using Aoc.Core;

namespace Aoc.Assignments
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var day = new Day6();
            var input = InputReader.ReadStrings("../Aoc.Assignments/Inputs/day6.txt");

            day.CreateOrbitalMap(input.ToList());

            var result = day.GetDirectAndIndirectOrbits();

            Console.WriteLine("Value is: " + result);
        }
    }
}