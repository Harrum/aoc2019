using System.Linq;
using Aoc.Assignments.Days.Day8;
using Aoc.Core;
using Xunit;

namespace Aoc.Tests
{
    public class Day8Tests
    {
        private readonly Day8 day8;

        public Day8Tests()
        {
            this.day8 = new Day8();
        }

        [Fact]
        public void Example1()
        {
            var input = "123456789012";

            this.day8.CreateImage(3,2, input);

            var image = this.day8.GetImage();

            Assert.Equal(1, image[0][0,0]);
            Assert.Equal(6, image[0][2,1]);
            Assert.Equal(7, image[1][0,0]);
            Assert.Equal(2, image[1][2,1]);
        }

        [Fact]
        public void Part1()
        {
            var input = InputReader.ReadStrings("../../../../Aoc.Assignments/Inputs/day8.txt").First();

            this.day8.CreateImage(25, 6, input);

            var result = this.day8.GetTheThingPart1Wants();

            Assert.Equal(1572, result);
        }

        [Fact]
        public void Part2Example1()
        {
            var input = "0222112222120000";

            this.day8.CreateImage(2,2, input);

            var image = this.day8.DecodeImage();

            Assert.Equal(0, image[0,0]);
            Assert.Equal(1, image[0,1]);
            Assert.Equal(1, image[1,0]);
            Assert.Equal(0, image[1,1]);
        }

        [Fact]
        public void Part2()
        {
            var input = InputReader.ReadStrings("../../../../Aoc.Assignments/Inputs/day8.txt").First();

            this.day8.CreateImage(25, 6, input);

            var result = this.day8.DecodeImage();

            this.day8.PrintImage(result);

            // Assert Console should write KYHFE, no idea how to test test :)
        }
    }
}