using AdventOfCode2021.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Days.Day1
{
    public class Day1
    {
        private static void CountIncreases()
        {
            var numbers = FileConverter.FileToIntList("Day1.txt");
            int increases = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                if (i != 0)
                {
                    var previousNumber = numbers[i - 1];
                    var currentNumber = numbers[i];

                    if (currentNumber > previousNumber)
                    {
                        increases++;
                    }
                }
            }

            Console.WriteLine(increases);
        }

        private static void CountIncreasesThreeMeasurements()
        {
            var numbers = FileConverter.FileToIntList("Day1.txt");
            int increases = 0;

            for (int i = 0; i < numbers.Count - 3; i++)
            {
                int previousSum = numbers[i] + numbers[i + 1] + numbers[i + 2];
                int currentSum = numbers[i + 1] + numbers[i + 2] + numbers[i + 3];

                if (currentSum > previousSum)
                {
                    increases++;
                }
            }

            Console.WriteLine(increases);
        }

        public static void Run()
        {
            Console.WriteLine("Part 1");
            CountIncreases();

            Console.WriteLine();
            Console.WriteLine("Part 2");
            CountIncreasesThreeMeasurements();
        }
    }
}
