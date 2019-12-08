using System;
using System.IO;
using System.Linq;
using Aoc.Assignments.Days.Day7;
using Aoc.Core;

namespace Aoc.Assignments
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var day = new Day7();
            var input = InputReader.ReadFromCommaString("../Aoc.Assignments/Inputs/day7.txt").ToArray();

            var result = day.CalculateMaxThrusterValue(input);

            Console.WriteLine("Value is: " + result);
        }
    }
}