using System;

namespace Aoc.Assignments.Days.Day2
{
    public class Day2
    {
        private int[] program;

        public void SetProgram(int[] input)
        {
            this.program = input;
        }

        public int[] GetProgram()
        {
            return this.program;
        }

        public void RestoreProgram(int index)
        {
            var opcode = program[index];

            if (opcode == 99)
            {
                return;
            }

            if (opcode == 1)
            {
                this.AddValues(index);
                this.RestoreProgram(index + 4);
            }
            else if (opcode == 2)
            {
                this.MultiplyValues(index);
                this.RestoreProgram(index + 4);
            }
            else
            {   
                throw new ArgumentException("Invalid opcode: " + opcode);
            }          
        }

        private void AddValues(int index)
        {
            var index1 = this.program[index + 1];
            var index2 = this.program[index + 2];
            var position = this.program[index + 3];

            this.program[position] = this.program[index1] + this.program[index2];
        }

        private void MultiplyValues(int index)
        {
            var index1 = this.program[index + 1];
            var index2 = this.program[index + 2];
            var position = this.program[index + 3];

            this.program[position] = this.program[index1] * this.program[index2];
        }
    }
}