using System;
using System.IO;
using System.Linq;
using Aoc.Assignments.Days.Day8;
using Aoc.Core;

namespace Aoc.Assignments
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var day = new Day8();
            var input = InputReader.ReadStrings("../Aoc.Assignments/Inputs/day8.txt").First();

            day.CreateImage(25, 6, input);

            var result = day.DecodeImage();

            day.PrintImage(result);

            //Console.WriteLine("Value is: " + result);
        }
    }
}