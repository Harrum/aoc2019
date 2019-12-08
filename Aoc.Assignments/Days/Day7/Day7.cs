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
            
            var ampA = this.RunProgram(new[]{input[0], 0}, program);
            var ampB = this.RunProgram(new[]{input[1]}.Concat(ampA).ToArray(), program);
            var ampC = this.RunProgram(new[]{input[2]}.Concat(ampB).ToArray(), program);
            var ampD = this.RunProgram(new[]{input[3]}.Concat(ampC).ToArray(), program);
            var ampE = this.RunProgram(new[]{input[4]}.Concat(ampD).ToArray(), program);

            var hasOutput = true;
            var thrusterValue = 0;

            while (hasOutput)
            {
                ampA = this.RunProgram(ampE, program);
                if (!ampA.Any()) break;
                ampB = this.RunProgram(ampA, program);
                if (!ampB.Any()) break;
                ampC = this.RunProgram(ampB, program);
                if (!ampC.Any()) break;
                ampD = this.RunProgram(ampC, program);
                if (!ampD.Any()) break;
                ampE = this.RunProgram(ampD, program);
                if (!ampE.Any()) break;
                thrusterValue = ampE.First();
            }

            return thrusterValue;
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
            
            var ampA = this.RunProgram(new[]{phaseSettings[0], 0}, program).First();
            var ampB = this.RunProgram(new[]{phaseSettings[1], ampA}, program).First();
            var ampC = this.RunProgram(new[]{phaseSettings[2], ampB}, program).First();
            var ampD = this.RunProgram(new[]{phaseSettings[3], ampC}, program).First();
            var ampE = this.RunProgram(new[]{phaseSettings[4], ampD}, program).First();

            return ampE;
        }

        private int[] RunProgram(int[] inputs, int[] program)
        {
            this.ProgramThing.SetMultipleInput(inputs);
            this.ProgramThing.RestoreProgram();

            return this.ProgramThing.GetOutputs();
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