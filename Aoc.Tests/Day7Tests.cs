using Aoc.Assignments.Days.Day7;
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
            var phaseSettings = new int[] {4,3,2,1,0};
            var result = this.day7.CalculateMaxThrusterValue(program, phaseSettings);

            Assert.Equal(43210, result);
        }
    }
}