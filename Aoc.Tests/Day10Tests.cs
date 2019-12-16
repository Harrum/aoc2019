using System.Linq;
using Aoc.Assignments.Days.Day10;
using Aoc.Core;
using Xunit;

namespace Aoc.Tests
{
    public class Day10Tests
    {
        private readonly Day10 day10;

        public Day10Tests()
        {
            this.day10 = new Day10();
        }

        [Fact]
        public void Example1()
        {
            var input = new string[] {  ".#..#",
                                        ".....",
                                        "#####",
                                        "....#",
                                        "...##" };

            var result = this.day10.GetAsteroidsFromBestLocation(input);

            Assert.Equal(8, result);
        }
        
        [Fact]
        public void Example2()
        {
            var input = new string[] {  "......#.#.",
                                        "#..#.#....",
                                        "..#######.",
                                        ".#.#.###..",
                                        ".#..#.....",
                                        "..#....#.#",
                                        "#..#....#.",
                                        ".##.#..###",
                                        "##...#..#.",
                                        ".#....####"};

            var result = this.day10.GetAsteroidsFromBestLocation(input);

            Assert.Equal(33, result);
        }

        [Fact]
        public void Part1()
        {
            var input = InputReader.ReadStrings("../../../../Aoc.Assignments/Inputs/day10.txt").ToArray();

            var result = this.day10.GetAsteroidsFromBestLocation(input);

            Assert.Equal(329, result);
        }
    }
}