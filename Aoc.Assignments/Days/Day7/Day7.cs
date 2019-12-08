using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc.Assignments.Days.Day7
{
    public class Day7
    {
        private readonly Day5.Day5 ProgramThing;

        public Day7()
        {
            this.ProgramThing = new Day5.Day5();
        }

        public int CalculateMaxThrusterValue(int[] program)
        {
            var maxValue = int.MinValue;

            var phaseSettings = this.GeneratePhaseSettings();

            foreach (var settings in phaseSettings)
            {
                var thrusterValue = this.CalculateThrusterValue(program, settings);
                if (thrusterValue > maxValue)
                {
                    maxValue = thrusterValue;
                }
            }

            return maxValue;
        }

        public int CalculateThrusterValue(int[] program, int[] phaseSettings)
        {
            this.ProgramThing.SetProgram(program);
            
            var ampA = this.RunProgram(phaseSettings[0], 0, program);
            var ampB = this.RunProgram(phaseSettings[1], ampA, program);
            var ampC = this.RunProgram(phaseSettings[2], ampB, program);
            var ampD = this.RunProgram(phaseSettings[3], ampC, program);
            var ampE = this.RunProgram(phaseSettings[4], ampD, program);

            return ampE;
        }

        private int RunProgram(int phaseSetting, int input, int[] program)
        {
            this.ProgramThing.SetMultipleInput(phaseSetting, input);
            this.ProgramThing.RestoreProgram();

            return this.ProgramThing.GetOutput();
        }

        private List<int[]> GeneratePhaseSettings()
        {
            var phaseSettings = new List<int[]>();

            // Yo dawg...
            for (int a = 0; a <= 4; a++)
            {
                for (int b = 0; b <= 4; b++)
                {
                    for (int c = 0; c <= 4; c++)
                    {
                        for (int d = 0; d <= 4; d++)
                        {
                            for (int e = 0; e <= 4; e++)
                            {
                                var settings = new int[] {a,b,c,d,e};
                                if (settings.Distinct().Count() == 5)
                                {
                                    phaseSettings.Add(settings);
                                }
                            }
                        }
                    }
                }
            }

            return phaseSettings;
        }
    }
}