using System;
using System.Collections.Generic;
using System.IO;

namespace Aoc.Core
{
    public class InputReader
    {
        public static List<int> ReadAsList(string path)
        {
            var file = new FileInfo(path);

            if (!file.Exists)
            {
                throw new FileNotFoundException(file.FullName);
            }

            var lines = File.ReadAllLines(path);

            var input = new List<int>();

            foreach (var line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    var number = int.Parse(line);
                    input.Add(number);
                }
            }

            return input;
        }
    }
}
