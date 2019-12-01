using System;
using System.IO;
using Aoc.Assignments.Days.Day1;
using Aoc.Core;

namespace Aoc.Assignments
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var day1 = new Day1();
            var input = InputReader.ReadAsList("../Aoc.Assignments/Inputs/day1.txt");

            var result = 0;

            foreach (var i in input)
            {
                result += day1.CalculateFuelWithAddedFuel(i);
            }

            Console.WriteLine("Fuel is: " + result);
        }
    }
}