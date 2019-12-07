namespace Aoc.Assignments.Days.Day7
{
    public class Day7
    {
        private readonly Day5.Day5 ProgramThing;

        public Day7()
        {
            this.ProgramThing = new Day5.Day5();
        }

        public int CalculateMaxThrusterValue(int[] program, int[] phaseSettings)
        {
            // Amp A
            var ampA = this.RunProgram(phaseSettings[0], 0, program);
            var ampB = this.RunProgram(phaseSettings[1], ampA, program);
            var ampC = this.RunProgram(phaseSettings[2], ampB, program);
            var ampD = this.RunProgram(phaseSettings[3], ampC, program);
            var ampE = this.RunProgram(phaseSettings[4], ampD, program);

            return ampE;
        }

        private int RunProgram(int phaseSetting, int input, int[] program)
        {
            this.ProgramThing.SetProgram(program);
            this.ProgramThing.SetInput(phaseSetting);
            this.ProgramThing.RestoreProgram();

            this.ProgramThing.SetInput(input);
            this.ProgramThing.RestoreProgram();
            return this.ProgramThing.GetOutput();
        }
    }
}