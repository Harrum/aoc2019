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
            this.ProgramThing = new Day5.Day5(true);
        }

        public int CalculateMaxThrusterValueWithFeedbackLoop(int[] program)
        {
            var maxValue = int.MinValue;

            var phaseSettings = this.GeneratePhaseSettings(5, 9);

            foreach (var settings in phaseSettings)
            {
                var thrusterValue = this.CalculateThrusterValueWithFeedbackLoop(program, settings);
                if (thrusterValue > maxValue)
                {
                    maxValue = thrusterValue;
                }
            }

            return maxValue;
        }

        public int CalculateThrusterValueWithFeedbackLoop(int[] program, int[] input)
        {
            this.ProgramThing.SetProgram(program);
            
            var ampA = 0;
            var ampB = 0;
            var ampC = 0;
            var ampD = 0;
            var ampE = 0;

            var Day5[] = new Day5.Day5[5];

            while (hasOutput)
            {
                ampA = this.RunProgram(new[]{input[0], 0}, program);
                ampB = this.RunProgram(new[]{input[1]}.Concat(ampA).ToArray(), program);
                ampC = this.RunProgram(new[]{input[2]}.Concat(ampB).ToArray(), program);
                ampD = this.RunProgram(new[]{input[3]}.Concat(ampC).ToArray(), program);
                ampE = this.RunProgram(new[]{input[4]}.Concat(ampD).ToArray(), program);
            }

            return ampE;
        }

        public int CalculateMaxThrusterValue(int[] program)
        {
            var maxValue = int.MinValue;

            var phaseSettings = this.GeneratePhaseSettings(0, 4);

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
            
            var ampA = this.RunProgram(new[]{phaseSettings[0], 0}, program);
            var ampB = this.RunProgram(new[]{phaseSettings[1], ampA}, program);
            var ampC = this.RunProgram(new[]{phaseSettings[2], ampB}, program);
            var ampD = this.RunProgram(new[]{phaseSettings[3], ampC}, program);
            var ampE = this.RunProgram(new[]{phaseSettings[4], ampD}, program);

            return ampE;
        }

        private int RunProgram(int[] inputs, int[] program)
        {
            this.ProgramThing.SetMultipleInput(inputs);
            this.ProgramThing.RestoreProgram();

            return this.ProgramThing.GetOutput();
        }

        private List<int[]> GeneratePhaseSettings(int start, int end)
        {
            var phaseSettings = new List<int[]>();

            // Yo dawg...
            for (int a = start; a <= end; a++)
            {
                for (int b = start; b <= end; b++)
                {
                    for (int c = start; c <= end; c++)
                    {
                        for (int d = start; d <= end; d++)
                        {
                            for (int e = start; e <= end; e++)
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