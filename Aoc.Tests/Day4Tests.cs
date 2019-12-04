using System.Linq;
using Aoc.Assignments.Days.Day4;
using Aoc.Core;
using Xunit;

namespace Aoc.Tests
{
    public class Day4Tests
    {
        private readonly Day4 day4;

        public Day4Tests()
        {
            this.day4 = new Day4();
        }

        [Fact]
        public void Example1()
        {
            var result = day4.GetPasswords(100000, 200000);

            Assert.True(result.Any(s => s == "111111"));
        }

        [Fact]
        public void Example2()
        {
            var result = day4.GetPasswords(100000, 300000);

            Assert.False(result.Any(s => s == "223450"));
        }

        [Fact]
        public void Example3()
        {
            var result = day4.GetPasswords(100000, 200000);

            Assert.False(result.Any(s => s == "123789"));
        }

        [Fact]
        public void Part1()
        {
            var input = InputReader.ReadFromStripedString("../../../../Aoc.Assignments/Inputs/day4.txt").ToArray();

            var begin = input[0];
            var end = input[1];

            var result = day4.GetPasswords(begin, end);

            Assert.Equal(1675, result.Count);
        }

        [Fact]
        public void Part2Example1()
        {
            var result = day4.GetPasswords(100000, 200000, true);

            Assert.True(result.Any(s => s == "112233"));
        }

        [Fact]
        public void Part2Example2()
        {
            var result = day4.GetPasswords(100000, 200000, true);

            Assert.False(result.Any(s => s == "123444"));
        }

        [Fact]
        public void Part2Example3()
        {
            var result = day4.GetPasswords(100000, 200000, true);

            Assert.True(result.Any(s => s == "111122"));
        }

        [Fact]
        public void Part2Test1()
        {
            var result = day4.GetPasswords(100000, 200000, true);

            Assert.False(result.Any(s => s == "114452"));
        }

        [Fact]
        public void Part2Test2()
        {
            var result = day4.GetPasswords(100000, 200000, true);

            Assert.True(result.Any(s => s == "114466"));
        }

        [Fact]
        public void Part2Test3()
        {
            var result = day4.GetPasswords(100000, 200000, true);

            Assert.False(result.Any(s => s == "123456"));
        }

        [Fact]
        public void Part2()
        {
            var input = InputReader.ReadFromStripedString("../../../../Aoc.Assignments/Inputs/day4.txt").ToArray();

            var begin = input[0];
            var end = input[1];

            var result = day4.GetPasswords(begin, end, true);

            Assert.Equal(1142, result.Count);
        }
    }
}