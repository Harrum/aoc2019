namespace Aoc.Assignments.Days.Day5
{
    public enum Opcode
    {
        Unkown = 0,
        Add = 1,
        Multiply = 2,
        Input = 3,
        Output = 4,

        JumpIfTrue = 5,
        JumpIfFalse = 6,
        LessThan = 7,
        Equals = 8,
        EndProgram = 99
    }
}