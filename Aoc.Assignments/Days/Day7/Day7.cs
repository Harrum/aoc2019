using System;
using System.Collections.Generic;
using System.Linq;
using Aoc.Assignments.Days.Day5;

namespace Aoc.Assignments.Days.Day7
{
    public class Day7
    {
        private IntCoder ProgramThing;

        public Day7()
        {
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
            var intCoders = new List<IntCoder>();
            for (int i = 0; i < 5; i++)
            {
                var intCoder = new IntCoder(true);
                intCoder.SetProgram(program);
                intCoder.SetMultipleInput(new[] {input[i]});
                intCoders.Add(intCoder);
            }

            var output = 0;

            var runningProgram = program;
            var index = 0;
            while (intCoders.Any())
            {
                var ic = intCoders[index];
                ic.SetProgram(runningProgram);
                ic.AddInput(output);
                ic.RestoreProgram();
                output = ic.GetOutput();
                runningProgram = ic.GetProgram();

                if (!ic.IsRunning())
                {
                    intCoders.Remove(ic);
                }

                if (index < intCoders.Count)
                    index++;
                else
                    index = 0;
            }

            return output;
        }

        public int CalculateMaxThrusterValue(int[] program)
        {
            this.ProgramThing = new IntCoder();
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