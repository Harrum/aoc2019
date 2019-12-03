using Aoc.Assignments.Days.Day3;
using Aoc.Core;
using Xunit;

namespace Aoc.Tests
{
    public class Day3Tests
    {
        private readonly Day3 day3;

        public Day3Tests()
        {
            this.day3 = new Day3();
        }

        [Fact]
        public void Example1()
        {
            var input1 = this.day3.CreateWire("R8,U5,L5,D3");
            var input2 = this.day3.CreateWire("U7,R6,D4,L4");

            var result = this.day3.GetClosestManhattanDistance(input1, input2);

            Assert.Equal(6, result);
        }

        [Fact]
        public void Example2()
        {
            var input1 = this.day3.CreateWire("R75,D30,R83,U83,L12,D49,R71,U7,L72");
            var input2 = this.day3.CreateWire("U62,R66,U55,R34,D71,R55,D58,R83");

            var result = this.day3.GetClosestManhattanDistance(input1, input2);

            Assert.Equal(159, result);
        }

        [Fact]
        public void Example3()
        {
            var input1 = this.day3.CreateWire("R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51");
            var input2 = this.day3.CreateWire("U98,R91,D20,R16,D67,R40,U7,R15,U6,R7");

            var result = this.day3.GetClosestManhattanDistance(input1, input2);

            Assert.Equal(135, result);
        }

        [Fact]
        public void Part1()
        {
            var input = InputReader.ReadStrings("../../../../Aoc.Assignments/Inputs/day3.txt");
            var input1 = this.day3.CreateWire(input[0]);
            var input2 = this.day3.CreateWire(input[1]);

            var result = this.day3.GetClosestManhattanDistance(input1, input2);

            Assert.Equal(260, result);
        }

        [Fact]
        public void Part2Example1()
        {
            var input1 = this.day3.CreateWire("R8,U5,L5,D3");
            var input2 = this.day3.CreateWire("U7,R6,D4,L4");

            var result = this.day3.GetShortestDistance(input1, input2);

            Assert.Equal(30, result);
        }

        [Fact]
        public void Part2Example2()
        {
            var input1 = this.day3.CreateWire("R75,D30,R83,U83,L12,D49,R71,U7,L72");
            var input2 = this.day3.CreateWire("U62,R66,U55,R34,D71,R55,D58,R83");

            var result = this.day3.GetShortestDistance(input1, input2);

            Assert.Equal(610, result);
        }

        [Fact]
        public void Part2Example3()
        {
            var input1 = this.day3.CreateWire("R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51");
            var input2 = this.day3.CreateWire("U98,R91,D20,R16,D67,R40,U7,R15,U6,R7");

            var result = this.day3.GetShortestDistance(input1, input2);

            Assert.Equal(410, result);
        }

        [Fact]
        public void Part2()
        {
            var input = InputReader.ReadStrings("../../../../Aoc.Assignments/Inputs/day3.txt");
            var input1 = this.day3.CreateWire(input[0]);
            var input2 = this.day3.CreateWire(input[1]);

            var result = this.day3.GetShortestDistance(input1, input2);

            Assert.Equal(15612, result);
        }
    }
}