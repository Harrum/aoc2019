using System;
using System.IO;
using System.Linq;
using Aoc.Assignments.Days.Day4;
using Aoc.Core;

namespace Aoc.Assignments
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var day = new Day4();
            var input = InputReader.ReadFromStripedString("../Aoc.Assignments/Inputs/day4.txt").ToArray();

            var begin = input[0];
            var end = input[1];

            var result = day.GetPasswords(begin, end, true);

            Console.WriteLine("Value is: " + result.Count);
        }
    }
}