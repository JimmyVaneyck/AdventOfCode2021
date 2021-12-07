using AdventOfCode2021.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Days.Day2
{
    public class Day2
    {
        private static void Part1()
        {
            var lines = FileConverter.FileToStringList("Day2.txt");
            int horizontal = 0;
            int depth = 0;

            for (int i = 0; i < lines.Count; i++)
            {
                var line = lines[i];
                var splittedLine = line.Split(" ");
                var operation = splittedLine[0];
                var number = int.Parse(splittedLine[1]);

                if (operation.Contains("forward"))
                {
                    horizontal += number;
                }
                else if (operation.Contains("down"))
                {
                    depth += number;
                }
                else if (operation.Contains("up"))
                {
                    depth -= number;
                }
            }

            Console.WriteLine($"Horizontal: {horizontal} - Depth: {depth}");
            Console.WriteLine($"Total: {horizontal * depth}");
        }

        private static void Part2()
        {
            var lines = FileConverter.FileToStringList("Day2.txt");
            int horizontal = 0;
            int aim = 0;
            int depth = 0;

            for (int i = 0; i < lines.Count; i++)
            {
                var line = lines[i];
                var splittedLine = line.Split(" ");
                var operation = splittedLine[0];
                var number = int.Parse(splittedLine[1]);

                if (operation.Contains("forward"))
                {
                    horizontal += number;
                    depth += (number * aim);
                }
                else if (operation.Contains("down"))
                {
                    aim += number;
                }
                else if (operation.Contains("up"))
                {
                    aim -= number;
                }
            }

            Console.WriteLine($"Horizontal: {horizontal} - Depth: {depth}");
            Console.WriteLine($"Total: {horizontal * depth}");
        }

        public static void Run()
        {
            Console.WriteLine("Part 1");
            Part1();

            Console.WriteLine();
            Console.WriteLine("Part 2");
            Part2();
        }
    }
}
