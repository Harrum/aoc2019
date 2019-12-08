using System.Linq;
using Aoc.Assignments.Days.Day7;
using Aoc.Core;
using Xunit;

namespace Aoc.Tests
{
    public class Day7Tests
    {
        private readonly Day7 day7;

        public Day7Tests()
        {
            this.day7 = new Day7();
        }

        [Fact]
        public void Example1()
        {
            var program = new int[] {3,15,3,16,1002,16,10,16,1,16,15,15,4,15,99,0,0};
            var result = this.day7.CalculateMaxThrusterValue(program);

            Assert.Equal(43210, result);
        }

        [Fact]
        public void Example2()
        {
            var program = new int[] {3,23,3,24,1002,24,10,24,1002,23,-1,23,101,5,23,23,1,24,23,23,4,23,99,0,0};
            var result = this.day7.CalculateMaxThrusterValue(program);

            Assert.Equal(54321, result);
        }

        [Fact]
        public void Example3()
        {
            var program = new int[] {3,31,3,32,1002,32,10,32,1001,31,-2,31,1007,31,0,33,1002,33,7,33,1,33,31,31,1,32,31,31,4,31,99,0,0,0};
            var result = this.day7.CalculateMaxThrusterValue(program);

            Assert.Equal(65210, result);
        }

        [Fact]
        public void Part1()
        {
            var program = InputReader.ReadFromCommaString("../../../../Aoc.Assignments/Inputs/day7.txt").ToArray();
            var result = this.day7.CalculateMaxThrusterValue(program);

            Assert.Equal(46248, result);
        }

        [Fact]
        public void Part2Example1()
        {
            var program = new int[] {3,26,1001,26,-4,26,3,27,1002,27,2,27,1,27,26,27,4,27,1001,28,-1,28,1005,28,6,99,0,0,5};
            var phaseSettings = new int[] {9,8,7,6,5};
            var result = this.day7.CalculateThrusterValueWithFeedbackLoop(program, phaseSettings);

            Assert.Equal(139629729, result);
        }
    }
}