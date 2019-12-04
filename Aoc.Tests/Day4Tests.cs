using System.Linq;
using Aoc.Assignments.Days.Day4;
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
    }
}