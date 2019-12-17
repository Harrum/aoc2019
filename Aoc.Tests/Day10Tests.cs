using System.Drawing;
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
        public void Example3()
        {
            var input = new string[] {
                ".#..##.###...#######",
                "##.############..##.",
                ".#.######.########.#",
                ".###.#######.####.#.",
                "#####.##.#.##.###.##",
                "..#####..#.#########",
                "####################",
                "#.####....###.#.#.##",
                "##.#################",
                "#####.##.###..####..",
                "..######..##.#######",
                "####.##.####...##..#",
                ".#####..#.######.###",
                "##...#.##########...",
                "#.##########.#######",
                ".####.#.###.###.#.##",
                "....##.##.###..#####",
                ".#.#.###########.###",
                "#.#.#.#####.####.###",
                "###.##.####.##.#..##"};

            var result = this.day10.GetAsteroidsFromBestLocation(input);

            Assert.Equal(210, result);
        }

        [Fact]
        public void Example3_1()
        {
            var input = new string[] {
                ".#..##.###...#######",
                "##.############..##.",
                ".#.######.########.#",
                ".###.#######.####.#.",
                "#####.##.#.##.###.##",
                "..#####..#.#########",
                "####################",
                "#.####....###.#.#.##",
                "##.#################",
                "#####.##.###..####..",
                "..######..##.#######",
                "####.##.####...##..#",
                ".#####..#.######.###",
                "##...#.##########...",
                "#.##########.#######",
                ".####.#.###.###.#.##",
                "....##.##.###..#####",
                ".#.#.###########.###",
                "#.#.#.#####.####.###",
                "###.##.####.##.#..##"};
            var field = this.day10.CreateField(input);
            var result = this.day10.GetAsteroidsFromLocation(new Point(11,13), field);

            Assert.Equal(210, result);
        }

        [Fact]
        public void Part1()
        {
            var input = InputReader.ReadStrings("../../../../Aoc.Assignments/Inputs/day10.txt").ToArray();

            var result = this.day10.GetAsteroidsFromBestLocation(input);

            Assert.Equal(329, result);
        }

        [Fact]
        public void Part1_1()
        {
            var input = InputReader.ReadStrings("../../../../Aoc.Assignments/Inputs/day10.txt").ToArray();
            var field = this.day10.CreateField(input);
            var result = this.day10.GetAsteroidsFromLocation(new Point(25,31), field);

            Assert.Equal(329, result);
        }

        [Fact]
        public void Part2Example1()
        {
            var input = new string[] {
                ".#..##.###...#######",
                "##.############..##.",
                ".#.######.########.#",
                ".###.#######.####.#.",
                "#####.##.#.##.###.##",
                "..#####..#.#########",
                "####################",
                "#.####....###.#.#.##",
                "##.#################",
                "#####.##.###..####..",
                "..######..##.#######",
                "####.##.####...##..#",
                ".#####..#.######.###",
                "##...#.##########...",
                "#.##########.#######",
                ".####.#.###.###.#.##",
                "....##.##.###..#####",
                ".#.#.###########.###",
                "#.#.#.#####.####.###",
                "###.##.####.##.#..##"};

            var result = this.day10.GetNthVaporizedAsteroid(1, new Point(11,13), input);

            Assert.Equal(11, result.X);
            Assert.Equal(12, result.Y);
        }

        [Fact]
        public void Part2Example2()
        {
            var input = new string[] {
                ".#..##.###...#######",
                "##.############..##.",
                ".#.######.########.#",
                ".###.#######.####.#.",
                "#####.##.#.##.###.##",
                "..#####..#.#########",
                "####################",
                "#.####....###.#.#.##",
                "##.#################",
                "#####.##.###..####..",
                "..######..##.#######",
                "####.##.####...##..#",
                ".#####..#.######.###",
                "##...#.##########...",
                "#.##########.#######",
                ".####.#.###.###.#.##",
                "....##.##.###..#####",
                ".#.#.###########.###",
                "#.#.#.#####.####.###",
                "###.##.####.##.#..##"};

            var result = this.day10.GetNthVaporizedAsteroid(200, new Point(11,13), input);

            Assert.Equal(8, result.X);
            Assert.Equal(2, result.Y);
        }

        [Fact]
        public void Part2()
        {
            var input = InputReader.ReadStrings("../../../../Aoc.Assignments/Inputs/day10.txt").ToArray();

            var result = this.day10.GetNthVaporizedAsteroid(200, new System.Drawing.Point(25,31), input);

            Assert.Equal(512, result.X * 100 + result.Y);
        }
    }
}