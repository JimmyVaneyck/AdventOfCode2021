using AdventOfCode2021.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Days.Day3
{
    public class Day3
    {
        private static void Part1()
        {
            var lines = FileConverter.FileToStringList("Day3.txt");
            var gameRate = CalculateRatePart1(lines, true);
            var epsilonRate = CalculateRatePart1(lines, false);
            var gameRateNumber = Convert.ToInt32(gameRate, 2);
            var epsilonRateNumber = Convert.ToInt32(epsilonRate, 2);

            Console.WriteLine($"Game rate: {gameRate}\nEpsilon rate: {epsilonRate}");
            Console.WriteLine($"Game rate: {gameRateNumber}\nEpsilon rate: {epsilonRateNumber}");
            Console.WriteLine($"Total: {gameRateNumber * epsilonRateNumber}");
        }

        private static string CalculateRatePart1(List<string> binairyLines, bool gameRate)
        {
            var result = new StringBuilder();
            int indexOfBits = 0;
            int lengthOfBits = binairyLines[0].Count();

            for (int i = 0; i < lengthOfBits; i++)
            {
                int countOneBit = 0;
                int countZeroBit = 0;

                for (int j = 0; j < binairyLines.Count; j++)
                {
                    var binairyLine = binairyLines[j];
                    var bit = binairyLine[indexOfBits];
                    if (bit.Equals('0'))
                    {
                        countZeroBit++;
                    } 
                    else
                    {
                        countOneBit++;
                    }
                }

                if (gameRate)
                {
                    if (countOneBit > countZeroBit)
                    {
                        result.Append("1");
                    }
                    else
                    {
                        result.Append("0");
                    }
                }
                else
                {
                    if (countOneBit < countZeroBit)
                    {
                        result.Append("1");
                    }
                    else
                    {
                        result.Append("0");
                    }
                }

                indexOfBits++;
            }

            return result.ToString();
        }

        private static void Part2()
        {
            var lines = FileConverter.FileToStringList("Day3.txt");
            var oxygenRate = CalculateRatePart2(lines, true);
            var scrubberRate = CalculateRatePart2(lines, false);
            var oxygenRateNumber = Convert.ToInt32(oxygenRate, 2);
            var scrubberRateNumber = Convert.ToInt32(scrubberRate, 2);

            Console.WriteLine($"Oxygen generator rate: {oxygenRate}\nCO2 scrubber rate: {scrubberRate}");
            Console.WriteLine($"Oxygen generator rate: {oxygenRateNumber}\nCO2 scrubber rate: {scrubberRateNumber}");
            Console.WriteLine($"Total: {oxygenRateNumber * scrubberRateNumber}");
        }

        private static string CalculateRatePart2(List<string> binairyLines, bool oxygenRate)
        {
            int indexOfBits = 0;
            int lengthOfBits = binairyLines[0].Count();

            for (int i = 0; i < lengthOfBits; i++)
            {
                int countOneBit = 0;
                int countZeroBit = 0;

                for (int j = 0; j < binairyLines.Count; j++)
                {
                    var binairyLine = binairyLines[j];
                    var bit = binairyLine[indexOfBits];
                    if (bit.Equals('0'))
                    {
                        countZeroBit++;
                    }
                    else
                    {
                        countOneBit++;
                    }
                }

                if (oxygenRate)
                {
                    if (countOneBit > countZeroBit)
                    {
                        binairyLines = binairyLines.Where(line => line[indexOfBits].Equals('1')).ToList();
                    }
                    else if (countOneBit < countZeroBit)
                    {
                        binairyLines = binairyLines.Where(line => line[indexOfBits].Equals('0')).ToList();
                    }
                    else
                    {
                        binairyLines = binairyLines.Where(line => line[indexOfBits].Equals('1')).ToList();
                    }
                }
                else
                {
                    if (countOneBit > countZeroBit)
                    {
                        binairyLines = binairyLines.Where(line => line[indexOfBits].Equals('0')).ToList();
                    }
                    else if (countOneBit < countZeroBit)
                    {
                        binairyLines = binairyLines.Where(line => line[indexOfBits].Equals('1')).ToList();
                    }
                    else
                    {
                        binairyLines = binairyLines.Where(line => line[indexOfBits].Equals('0')).ToList();
                    }
                }

                if (binairyLines.Count == 1)
                {
                    break;
                }
                indexOfBits++;
            }

            string line = binairyLines[0];
            return line;
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
