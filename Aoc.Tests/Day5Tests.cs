using System.Linq;
using Aoc.Assignments.Days.Day5;
using Aoc.Core;
using Xunit;

namespace Aoc.Tests
{
    public class Day5Tests
    {
        private readonly Day5 day5;

        public Day5Tests()
        {
            this.day5 = new Day5();
        }

        [Fact]
        public void Example1()
        {
            var program = new[] {3,0,4,0,99};

            this.day5.SetProgram(program);
            this.day5.SetInput(10);

            this.day5.RestoreProgram();

            var result = this.day5.GetOutput();

            Assert.Equal(10, result);
        }

        [Fact]
        public void Example2()
        {
            var program = new[] {1002,4,3,4,33};

            this.day5.SetInput(0);
            this.day5.SetProgram(program);

            this.day5.RestoreProgram();

            var result = this.day5.GetProgram();

            Assert.Equal(99, result[4]);
        }

        [Fact]
        public void Part1()
        {
            var program = InputReader.ReadFromCommaString("../../../../Aoc.Assignments/Inputs/day5.txt").ToArray();

            this.day5.SetInput(1);
            this.day5.SetProgram(program);

            this.day5.RestoreProgram();

            var result = this.day5.GetOutput();

            Assert.Equal(8332629, result);
        }

        [Fact]
        public void Part2Example1()
        {
            var program = new[] {3,9,8,9,10,9,4,9,99,-1,8};

            this.day5.SetProgram(program);
            this.day5.SetInput(8);

            this.day5.RestoreProgram();

            var result = this.day5.GetOutput();

            Assert.Equal(1, result);
        }

        [Fact]
        public void Part2Example2()
        {
            var program = new[] {3,9,8,9,10,9,4,9,99,-1,8};

            this.day5.SetProgram(program);
            this.day5.SetInput(9);

            this.day5.RestoreProgram();

            var result = this.day5.GetOutput();

            Assert.Equal(0, result);
        }

        [Fact]
        public void Part2Example3()
        {
            var program = new[] {3,9,7,9,10,9,4,9,99,-1,8};

            this.day5.SetProgram(program);
            this.day5.SetInput(7);

            this.day5.RestoreProgram();

            var result = this.day5.GetOutput();

            Assert.Equal(1, result);
        }

        [Fact]
        public void Part2Example4()
        {
            var program = new[] {3,9,7,9,10,9,4,9,99,-1,8};

            this.day5.SetProgram(program);
            this.day5.SetInput(8);

            this.day5.RestoreProgram();

            var result = this.day5.GetOutput();

            Assert.Equal(0, result);
        }

                [Fact]
        public void Part2Example5()
        {
            var program = new[] {3,3,1108,-1,8,3,4,3,99};

            this.day5.SetProgram(program);
            this.day5.SetInput(8);

            this.day5.RestoreProgram();

            var result = this.day5.GetOutput();

            Assert.Equal(1, result);
        }

        [Fact]
        public void Part2Example6()
        {
            var program = new[] {3,3,1108,-1,8,3,4,3,99};

            this.day5.SetProgram(program);
            this.day5.SetInput(9);

            this.day5.RestoreProgram();

            var result = this.day5.GetOutput();

            Assert.Equal(0, result);
        }

                [Fact]
        public void Part2Example7()
        {
            var program = new[] {3,3,1107,-1,8,3,4,3,99};

            this.day5.SetProgram(program);
            this.day5.SetInput(7);

            this.day5.RestoreProgram();

            var result = this.day5.GetOutput();

            Assert.Equal(1, result);
        }

        [Fact]
        public void Part2Example8()
        {
            var program = new[] {3,3,1107,-1,8,3,4,3,99};

            this.day5.SetProgram(program);
            this.day5.SetInput(8);

            this.day5.RestoreProgram();

            var result = this.day5.GetOutput();

            Assert.Equal(0, result);
        }

        [Fact]
        public void Part2Example9()
        {
            var program = new[] {3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9};

            this.day5.SetProgram(program);
            this.day5.SetInput(0);

            this.day5.RestoreProgram();

            var result = this.day5.GetOutput();

            Assert.Equal(0, result);
        }

        [Fact]
        public void Part2Example10()
        {
            var program = new[] {3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9};

            this.day5.SetProgram(program);
            this.day5.SetInput(8);

            this.day5.RestoreProgram();

            var result = this.day5.GetOutput();

            Assert.Equal(1, result);
        }

        [Fact]
        public void Part2Example11()
        {
            var program = new[] {3,3,1105,-1,9,1101,0,0,12,4,12,99,1};

            this.day5.SetProgram(program);
            this.day5.SetInput(0);

            this.day5.RestoreProgram();

            var result = this.day5.GetOutput();

            Assert.Equal(0, result);
        }

        [Fact]
        public void Part2Example12()
        {
            var program = new[] {3,3,1105,-1,9,1101,0,0,12,4,12,99,1};

            this.day5.SetProgram(program);
            this.day5.SetInput(8);

            this.day5.RestoreProgram();

            var result = this.day5.GetOutput();

            Assert.Equal(1, result);
        }

        [Fact]
        public void Part2Example13()
        {
            var program = new[] {3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,
                                1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,
                                999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99
                                };

            this.day5.SetProgram(program);
            this.day5.SetInput(7);

            this.day5.RestoreProgram();

            var result = this.day5.GetOutput();

            Assert.Equal(999, result);
        }

        [Fact]
        public void Part2Example14()
        {
            var program = new[] {3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,
                                1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,
                                999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99
                                };
                                
            this.day5.SetProgram(program);
            this.day5.SetInput(8);

            this.day5.RestoreProgram();

            var result = this.day5.GetOutput();

            Assert.Equal(1000, result);
        }

        [Fact]
        public void Part2Example15()
        {
            var program = new[] {3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,
                                1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,
                                999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99
                                };

            this.day5.SetProgram(program);
            this.day5.SetInput(9);

            this.day5.RestoreProgram();

            var result = this.day5.GetOutput();

            Assert.Equal(1001, result);
        }

        [Fact]
        public void Part2()
        {
            var program = InputReader.ReadFromCommaString("../../../../Aoc.Assignments/Inputs/day5.txt").ToArray();

            this.day5.SetInput(5);
            this.day5.SetProgram(program);

            this.day5.RestoreProgram();

            var result = this.day5.GetOutput();

            Assert.Equal(8805067, result);
        }
    }
}