using System.Collections.Generic;

namespace Aoc.Assignments.Days.Day4
{
    public class Day4
    {
        public List<string> GetPasswords(int begin, int end)
        {
            const int size = 6;
            var validPasswords = new List<string>();
            for (int i = begin; i < end - size; i++)
            {
                var number = string.Empty;
                for (int n = 0; n < size; n++)
                {
                    number += (i + n).ToString();
                } 

                if (this.IsValidPassword(number))
                {
                    validPasswords.Add(number);
                }
            }

            return validPasswords;
        }

        private bool IsValidPassword(string number)
        {
            var equals = false;
            var hasDecreased = false;

            for (int i = 0; i < number.Length - 1; i++)
            {
                var char1 = number[i];
                var char2 = number[i+1];

                if (char1 == char2)
                {
                    equals = true;
                }

                if (char2 < char1)
                {
                    hasDecreased = true;
                }
            }

            return equals && !hasDecreased;
        }
    }
}