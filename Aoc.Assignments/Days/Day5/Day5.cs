using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc.Assignments.Days.Day5
{
    public class Day5
    {
        private bool loopMode;
        private int[] program;
        private Queue<int> storedValues;
        private bool isRunning;
        private int index;

        public Day5() : this(false)
        {
        }

        public Day5(bool loop)
        {
            this.loopMode = loop;
            this.index = 0;
        }

        public void SetProgram(int[] input)
        {
            this.program = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                this.program[i] = input[i];
            }
        }

        public int[] GetProgram()
        {
            return this.program;
        }

        public void SetInput(int input)
        {
            this.storedValues = new Queue<int>(new int[] {input});
        }

        public void SetMultipleInput(params int[] inputs)
        {
            this.storedValues = new Queue<int>(inputs);
        }

        public void AddInput(int input)
        {
            this.storedValues.Enqueue(input);
        }

        public int GetOutput()
        {
            return this.GetStoredValue();
        }

        public int[] GetOutputs()
        {
            return this.storedValues.ToArray();
        }

        public bool IsRunning()
        {
            return this.isRunning;
        }

        public void RestoreProgram()
        {
            this.isRunning = true;
            var opcode = this.GetOpcode(program[index]);
            var parameters = this.GetParameters(program[index]);

            var programLength = 0;
            switch (opcode)
            {
                case Opcode.Add:
                    programLength = this.AddValues(index, parameters);
                    break;
                case Opcode.Multiply:
                    programLength = this.MultiplyValues(index, parameters);
                    break;
                case Opcode.Input:
                    if (!this.storedValues.Any())
                        return;
                    else
                        programLength = this.Input(index, parameters);
                        break;
                case Opcode.Output:
                    programLength = this.Output(index, parameters);
                    if (this.loopMode)
                        return;
                    else
                        break;
                case Opcode.JumpIfTrue:
                    programLength = this.JumpIfTrue(index, parameters);
                    break;
                case Opcode.JumpIfFalse:
                    programLength = this.JumpIfFalse(index, parameters);
                    break;
                case Opcode.LessThan:
                    programLength = this.LessThan(index, parameters);
                    break;
                case Opcode.Equals:
                    programLength = this.Equals(index, parameters);
                    break;
                case Opcode.EndProgram:
                    this.isRunning = false;
                    return;
                default:
                    throw new ArgumentException("Invalid opcode: " + opcode);
            }

            this.RestoreProgram();  
        }

        private int AddValues(int index, ParameterMode[] parameters)
        {
            var value1 = this.GetParameterValue(parameters, index, 1);
            var value2 = this.GetParameterValue(parameters, index, 2);
            var position = this.GetParameterValue(parameters, index, 3, true);

            this.program[position] = value1 + value2;
            return 4;
        }

        private int MultiplyValues(int index, ParameterMode[] parameters)
        {
            var value1 = this.GetParameterValue(parameters, index, 1);
            var value2 = this.GetParameterValue(parameters, index, 2);
            var position = this.GetParameterValue(parameters, index, 3, true);

            this.program[position] = value1 * value2;
            return 4;
        }

        private int Input(int index, ParameterMode[] parameters)
        {
            var position = this.GetParameterValue(parameters, index, 1, true);
            this.program[position] = this.GetStoredValue();
            return 2;
        }

        private int Output(int index, ParameterMode[] parameters)
        {
            var value1 = this.GetParameterValue(parameters, index, 1);
            this.SetStoredValue(value1);
            // Console.WriteLine("Output is: " + value1);
            return 2;
        }

        private int JumpIfTrue(int index, ParameterMode[] parameters)
        {
            var value1 = this.GetParameterValue(parameters, index, 1);
            if (value1 == 0)
            {
                return 3;
            }
            var value2 = this.GetParameterValue(parameters, index, 2);

            return value2 - index;
        }

        private int JumpIfFalse(int index, ParameterMode[] parameters)
        {
            var value1 = this.GetParameterValue(parameters, index, 1);
            if (value1 != 0)
            {
                return 3;
            }
            var value2 = this.GetParameterValue(parameters, index, 2);

            return value2 - index;
        }

        private int LessThan(int index, ParameterMode[] parameters)
        {
            var value1 = this.GetParameterValue(parameters, index, 1);
            var value2 = this.GetParameterValue(parameters, index, 2);
            var position = this.GetParameterValue(parameters, index, 3, true);

            if (value1 < value2)
            {
                this.program[position] = 1;
            }
            else
            {
                this.program[position] = 0;
            }

            return 4;
        }

        private int Equals(int index, ParameterMode[] parameters)
        {
            var value1 = this.GetParameterValue(parameters, index, 1);
            var value2 = this.GetParameterValue(parameters, index, 2);
            var position = this.GetParameterValue(parameters, index, 3, true);

            if (value1 == value2)
            {
                this.program[position] = 1;
            }
            else
            {
                this.program[position] = 0;
            }

            return 4;
        }

        private int GetStoredValue()
        {
            return this.storedValues.Dequeue();
        }

        private void SetStoredValue(int value)
        {
            this.storedValues.Enqueue(value);
        }

        private int GetParameterValue(ParameterMode[] parameters, int index, int paramNumber, bool output = false)
        {
            if (parameters.Length == 0 || paramNumber > parameters.Length ||
                parameters[paramNumber - 1] == ParameterMode.Position)
            {
                var i = this.program[index + paramNumber]; // Use position parameters
                if (output)
                    return i;
                else
                    return this.program[i];
            }
            else if (parameters[paramNumber - 1] == ParameterMode.Immediate)
            {
                if (output)
                {
                    throw new Exception("Parameters that an instruction writes to will never be in immediate mode.");
                }
                return this.program[index + paramNumber];
            }
            else
            {
                throw new Exception("Unknow parameter: " + parameters[paramNumber - 1]);
            }
        }

        private Opcode GetOpcode(int value)
        {
            var stringValue = value.ToString();

            if (stringValue.Length < 2)
            {
                return (Opcode)value;
            }
            else
            {
                var opcode = int.Parse(stringValue.Substring(stringValue.Length - 2, 2));
                return (Opcode)opcode;
            }
        }

        private ParameterMode[] GetParameters(int value)
        {
            var stringValue = value.ToString();

            if (stringValue.Length < 2)
            {
                return new[] { ParameterMode.Position }; // Default
            }
            var parameters = stringValue.Substring(0, stringValue.Length - 2);

            if (string.IsNullOrEmpty(parameters))
            {
                return new[] { ParameterMode.Position }; // Default
            }
            else
            {
                var parameterModes = new List<ParameterMode>(parameters.Length);
                for (int i = 0; i < parameters.Length; i++)
                {
                    var param = 0;
                    if (parameters[i] == '0')
                        param = 0;
                    else if (parameters[i] == '1')
                        param = 1;
                    else
                        throw new NotSupportedException("Found invalid param value: " + parameters[i]);
                    
                    parameterModes.Insert(0, (ParameterMode)param);
                }

                return parameterModes.ToArray();
            }
        }
    }
}