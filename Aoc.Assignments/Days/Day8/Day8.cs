using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc.Assignments.Days.Day8
{
    public class Day8
    {
        private List<int[,]> Image;

        public Day8()
        {
            
        }

        public void CreateImage(int width, int height, string input)
        {
            int[] data = input.Select(c => (int)char.GetNumericValue(c)).ToArray();

            this.Image = new List<int[,]>();

            for (int a = 0; a < data.Length; a+=width*height)
            {
                var layer = new int[width, height];
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        layer[x,y] = data[a + (y * width + x)];
                    }
                }

                this.Image.Add(layer);
            }
        }

        public int[,] DecodeImage()
        {
            var width = this.Image.First().GetLongLength(0);
            var height = this.Image.First().GetLongLength(1);
            var decodedImage = new int[width, height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    decodedImage[x,y] = this.GetPixel(x,y);
                }
            }

            return decodedImage;
        }

        public int GetTheThingPart1Wants()
        {
            // This can probably more efficient.
            var layerFewest0Digits = this.Image.First(i => this.CountDigits(0, i) == this.Image.Min(l => this.CountDigits(0, l)));

            var oneDigits = this.CountDigits(1, layerFewest0Digits);
            var twoDigits = this.CountDigits(2, layerFewest0Digits);

            return oneDigits * twoDigits;
        }

        public void PrintImage(int[,] image)
        {
            var width = this.Image.First().GetLongLength(0);
            var height = this.Image.First().GetLongLength(1);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    var pixel = image[x,y];
                    this.PrintPixel(pixel);
                }

                Console.Write(Environment.NewLine);
            }
        }

        private int GetPixel(int x, int y)
        {
            var pixel = 2; // Transparant;

            foreach (var layer in this.Image)
            {
                var p = layer[x,y];
                if (p < pixel)
                {
                    pixel = p;
                    return pixel;
                }
            }

            return pixel;
        }

        private int CountDigits(int digit, int[,] input)
        {
            var digits = 0;

            foreach (var item in input)
            {
                if (item == digit)
                    digits++;
            }

            return digits;
        }

        private void PrintPixel(int pixel)
        {
            ConsoleColor color;
            switch (pixel)
            {
                case 0:
                    color = ConsoleColor.Black;
                    break;
                case 1:
                    color = ConsoleColor.White;
                    break;
                case 2:
                default:
                    color = ConsoleColor.Gray;
                    break;
            }

            Console.BackgroundColor = color;
            Console.Write(" ");
            Console.ResetColor();
        }

        public List<int[,]> GetImage()
        {
            return this.Image;
        }
    }
}