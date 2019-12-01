using Aoc.Assignments.Days.Day1;
using Aoc.Core;
using Xunit;

namespace Aoc.Tests
{
    public class Day1Tests
    {
        private readonly Day1 day1;

        public Day1Tests()
        {
            this.day1 = new Day1();
        }

        [Fact]
        public void PartOneExample1()
        {
            var result = this.day1.CalculateFuel(12);

            Assert.Equal(2, result);
        }

        [Fact]
        public void PartOneExample2()
        {
            var result = this.day1.CalculateFuel(14);

            Assert.Equal(2, result);
        }

        [Fact]
        public void PartOneExample3()
        {
            var result = this.day1.CalculateFuel(1969);

            Assert.Equal(654, result);
        }

        [Fact]
        public void PartOneExample4()
        {
            var result = this.day1.CalculateFuel(100756);

            Assert.Equal(33583, result);
        }

        [Fact]
        public void PartOne()
        {
            var path = System.AppDomain.CurrentDomain.BaseDirectory;
            var input = InputReader.ReadAsList("../../../../Aoc.Assignments/Inputs/day1.txt");
            var result = 0;

            foreach (var i in input)
            {
                result += this.day1.CalculateFuel(i);
            }

            Assert.Equal(3352674, result);
        }

        [Fact]
        public void PartTwoExample1()
        {
            var result = this.day1.CalculateFuelWithAddedFuel(14);

            Assert.Equal(2, result);
        }

                [Fact]
        public void PartTwoExample2()
        {
            var result = this.day1.CalculateFuelWithAddedFuel(1969);

            Assert.Equal(966, result);
        }

                [Fact]
        public void PartTwoExample3()
        {
            var result = this.day1.CalculateFuelWithAddedFuel(100756);

            Assert.Equal(50346, result);
        }
    }
}
