using System;
using System.IO;
using System.Linq;
using Aoc.Assignments.Days.Day2;
using Aoc.Core;

namespace Aoc.Assignments
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var day2 = new Day2();
            var input = InputReader.ReadFromCommaString("../Aoc.Assignments/Inputs/day2.txt").ToArray();

            var result = 0;

            for (int noun = 0; noun < 100; noun++)
            {
                for (int verb = 0; verb < 100; verb++)
                {
                    var tempInput = input.Select(i => i).ToArray();
                    tempInput[1] = noun;
                    tempInput[2] = verb;
                    day2.SetProgram(tempInput);
                    day2.RestoreProgram(0);
                    var output = day2.GetProgram()[0];

                    if (output == 19690720)
                    {
                        result = 100 * noun + verb;
                    }
                }
            }

            Console.WriteLine("Value is: " + result);
        }
    }
}