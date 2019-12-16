using System.Collections.Generic;
using System.Linq;
using Aoc.Assignments.Days.Day6;
using Aoc.Core;
using Xunit;

namespace Aoc.Tests
{
    public class Day6Tests
    {
        private readonly Day6 day6;

        public Day6Tests()
        {
            this.day6 = new Day6();
        }

        [Fact]
        public void Example1()
        {
            var input = new List<string> {"COM)B","B)C","C)D","D)E","E)F","B)G","G)H","D)I","E)J","J)K","K)L"};
            this.day6.CreateOrbitalMap(input);
            var result = this.day6.GetDirectAndIndirectOrbits();

            Assert.Equal(42, result);
        }

        [Fact]
        public void Part1()
        {
            var input = InputReader.ReadStrings("../../../../Aoc.Assignments/Inputs/day6.txt");
            this.day6.CreateOrbitalMap(input.ToList());
            var result = this.day6.GetDirectAndIndirectOrbits();

            Assert.Equal(142497, result);
        }

        [Fact]
        public void Part2Example1()
        {
            var input = new List<string> {"COM)B","B)C","C)D","D)E","E)F","B)G","G)H","D)I","E)J","J)K","K)L","K)YOU","I)SAN"};
            this.day6.CreateOrbitalMap(input);
            var result = this.day6.GetShortestRoute2("YOU", "SAN");

            Assert.Equal(4, result);
        }
        
        [Fact]
        public void Part2Example2()
        {
            var input = new List<string> {"COM)B","B)C","C)D","D)E","E)F","B)G","G)H","D)I","E)J","J)K","K)L","K)YOU","H)SAN"};
            this.day6.CreateOrbitalMap(input);
            var result = this.day6.GetShortestRoute2("YOU", "SAN");

            Assert.Equal(7, result);
        }

        [Fact]
        public void Part2Example3()
        {
            var input = new List<string> {"COM)B","B)C","C)D","D)E","E)F","B)G","G)H","D)I","E)J","J)K","K)L","H)YOU","K)SAN"};
            this.day6.CreateOrbitalMap(input);
            var result = this.day6.GetShortestRoute2("YOU", "SAN");

            Assert.Equal(7, result);
        }

        [Fact]
        public void Part2()
        {
            var input = InputReader.ReadStrings("../../../../Aoc.Assignments/Inputs/day6.txt");
            this.day6.CreateOrbitalMap(input.ToList());
            var result = this.day6.GetShortestRoute2("YOU", "SAN");

            Assert.Equal(301, result);
        }
    }
}