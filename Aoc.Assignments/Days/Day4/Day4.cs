using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc.Assignments.Days.Day4
{
    public class Day4
    {
        public List<string> GetPasswords(int begin, int end, bool grouping = false)
        {
            var validPasswords = new List<string>();
            for (int i = begin; i < end; i++)
            {
                var number = i.ToString();
                if (this.IsValidPassword(number, grouping))
                {
                    validPasswords.Add(number);
                    Console.WriteLine(number);
                }
            }

            return validPasswords;
        }

        private bool IsValidPassword(string number, bool grouping)
        {
            if (!grouping)
            {
                return this.IsValidPassword(number);
            }
            else
            {
                return this.IsValidPasswordWithGrouping(number);
            }
        }

        private bool IsValidPassword(string number)
        {
            var equals = false;
            var groupedUp = false;
            var hasDecreased = false;

            for (int i = 0; i < number.Length - 1; i++)
            {
                var char1 = int.Parse(number[i].ToString());
                var char2 = int.Parse(number[i + 1].ToString());

                if (char1 == char2)
                {
                    equals = true;
                }

                if (char2 < char1)
                {
                    hasDecreased = true;
                }
            }

            return (equals && !hasDecreased && !groupedUp);
        }

        private bool IsValidPasswordWithGrouping(string number)
        {
            var equals = false;
            var hasDecreased = false;

            for (int i = 0; i < number.Length - 1; i++)
            {
                var char1 = int.Parse(number[i].ToString());
                var char2 = int.Parse(number[i + 1].ToString());

                if (char1 == char2)
                {
                    if (number.Count(s => int.Parse(s.ToString()) == char1) == 2)
                    {
                        equals = true;
                    }
                }

                if (char2 < char1)
                {
                    hasDecreased = true;
                    return false;
                }
            }

            return equals && !hasDecreased;
        }
    }
}