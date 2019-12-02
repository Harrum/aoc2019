using System.Linq;
using Aoc.Assignments.Days.Day2;
using Aoc.Core;
using Xunit;

namespace Aoc.Tests
{
    public class Day2Tests
    {
        private readonly Day2 day2;

        public Day2Tests()
        {
            this.day2 = new Day2();
        }

        [Fact]
        public void Example1()
        {
            var input = new[] {1,0,0,0,99};

            this.day2.SetProgram(input);

            this.day2.RestoreProgram(0);
            var result = this.day2.GetProgram();

            Assert.Equal(2, result[0]);
        }

        [Fact]
        public void Example2()
        {
            var input = new[] {2,3,0,3,99};

            this.day2.SetProgram(input);

            this.day2.RestoreProgram(0);
            var result = this.day2.GetProgram();

            Assert.Equal(6, result[3]);
        }

        [Fact]
        public void Example3()
        {
            var input = new[] {2,4,4,5,99,0};

            this.day2.SetProgram(input);

            this.day2.RestoreProgram(0);
            var result = this.day2.GetProgram();

            Assert.Equal(9801, result[5]);
        }

        [Fact]
        public void Example4()
        {
            var input = new[] {1,1,1,4,99,5,6,0,99};

            this.day2.SetProgram(input);

            this.day2.RestoreProgram(0);
            var result = this.day2.GetProgram();

            Assert.Equal(30, result[0]);
        }

        [Fact]
        public void Day1Test()
        {
            var input = InputReader.ReadFromCommaString("../../../../Aoc.Assignments/Inputs/day2.txt").ToArray();
            input[1] = 12;
            input[2] = 2;

            this.day2.SetProgram(input);

            this.day2.RestoreProgram(0);
            var result = this.day2.GetProgram();

            Assert.Equal(2890696, result[0]);
        }

        [Fact]
        public void Day2Test()
        {
            var input = InputReader.ReadFromCommaString("../../../../Aoc.Assignments/Inputs/day2.txt").ToArray();
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

            Assert.Equal(8226, result);
        }
    }
}