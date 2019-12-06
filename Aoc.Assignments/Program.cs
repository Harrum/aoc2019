using System;
using System.IO;
using System.Linq;
using Aoc.Assignments.Days.Day5;
using Aoc.Core;

namespace Aoc.Assignments
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var day = new Day5();
            var input = InputReader.ReadFromCommaString("../Aoc.Assignments/Inputs/day5.txt").ToArray();

            day.SetInput(5);
            day.SetProgram(input);
            day.RestoreProgram();
            var result = day.GetOutput();

            Console.WriteLine("Value is: " + result);
        }
    }
}