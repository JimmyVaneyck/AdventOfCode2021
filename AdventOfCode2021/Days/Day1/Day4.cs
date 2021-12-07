using AdventOfCode2021.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Days.Day4
{
    public class Day4
    {
        private static void Part1()
        {
            var lines = FileConverter.FileToStringList("Day4.txt");

            var bingoNumbers = lines[0].Split(',');
            lines = lines.GetRange(1, lines.Count - 1);
            var matrixes = new List<List<List<string>>>();
            var matrix = new List<List<string>>();

            for (int i = 1; i < lines.Count; i++)
            {
                if (lines[i].Equals("") || i == lines.Count())
                {
                    matrixes.Add(matrix);
                    matrix = new List<List<string>>();
                } 
                else
                {
                    var line = lines[i];                   
                    var splitted = line.Split(' ').ToList();
                    splitted.RemoveAll(s => s.Equals(""));
                  
                    matrix.Add(splitted);
                }
            }

            var lastNumberWin = -1;
            var turnsTowin = -1;
            var indexOfWinMatrix = -1;
            var matrixWin = new List<List<string>>();
            var matrixWinFull = new List<List<string>>();
            var matrixOfWinner = new List<List<string>>();

            for (int i = 0; i < matrixes.Count; i++)
            {
                var currentMatrix = matrixes[i];
                matrixOfWinner = GetEmptyMatrix();
                int index = 0;
                turnsTowin = 0;

                while (index < bingoNumbers.Length)
                {
                    var currentNumbers = bingoNumbers.ToList().GetRange(index, 5);

                    currentNumbers.ForEach(number =>
                    {
                        if (currentMatrix[0].Contains(number))
                        {
                            var indexOfNumber = currentMatrix[0].IndexOf(number);
                            var row = matrixOfWinner[0].ToArray();
                            row[indexOfNumber] = number;
                            matrixOfWinner[0] = row.ToList();
                        }
                        if (matrixOfWinner[1].Contains(number))
                        {
                            var indexOfNumber = currentMatrix[1].IndexOf(number);
                            var row = matrixOfWinner[1].ToArray();
                            row[indexOfNumber] = number;
                            matrixOfWinner[1] = row.ToList();
                        }
                        if (currentMatrix[2].Contains(number))
                        {
                            var indexOfNumber = currentMatrix[2].IndexOf(number);
                            var row = matrixOfWinner[2].ToArray();
                            row[indexOfNumber] = number;
                            matrixOfWinner[2] = row.ToList();
                        }
                        if (currentMatrix[3].Contains(number))
                        {
                            var indexOfNumber = currentMatrix[3].IndexOf(number);
                            var row = matrixOfWinner[3].ToArray();
                            row[indexOfNumber] = number;
                            matrixOfWinner[3] = row.ToList();
                        }
                        if (currentMatrix[4].Contains(number))
                        {
                            var indexOfNumber = currentMatrix[4].IndexOf(number);
                            var row = matrixOfWinner[4].ToArray();
                            row[indexOfNumber] = number;
                            matrixOfWinner[4] = row.ToList();
                        }

                        bool foundWin = LookForRowOrColumn(matrixOfWinner);

                        if (foundWin)
                        {
                            if (turnsTowin == -1 || turnsTowin < index)
                            {
                                lastNumberWin = int.Parse(number);
                                turnsTowin = index;
                                matrixWin = matrixOfWinner;
                                matrixWinFull = currentMatrix;
                                index = bingoNumbers.Length;
                            }
                        }
                    });

                    index += 5;
                }
            }

            Console.WriteLine($"{matrixWin[0][0]} {matrixWin[0][1]} {matrixWin[0][2]} {matrixWin[0][3]} {matrixWin[0][4]}");
            Console.WriteLine($"{matrixWin[1][0]} {matrixWin[1][1]} {matrixWin[1][2]} {matrixWin[1][3]} {matrixWin[1][4]}");
            Console.WriteLine($"{matrixWin[2][0]} {matrixWin[2][1]} {matrixWin[2][2]} {matrixWin[2][3]} {matrixWin[2][4]}");
            Console.WriteLine($"{matrixWin[3][0]} {matrixWin[3][1]} {matrixWin[3][2]} {matrixWin[3][3]} {matrixWin[3][4]}");
            Console.WriteLine($"{matrixWin[4][0]} {matrixWin[4][1]} {matrixWin[4][2]} {matrixWin[4][3]} {matrixWin[4][4]}");
            Console.WriteLine(lastNumberWin);
            Console.WriteLine($"{matrixWinFull[0][0]} {matrixWinFull[0][1]} {matrixWinFull[0][2]} {matrixWinFull[0][3]} {matrixWinFull[0][4]}");
            Console.WriteLine($"{matrixWinFull[1][0]} {matrixWinFull[1][1]} {matrixWinFull[1][2]} {matrixWinFull[1][3]} {matrixWinFull[1][4]}");
            Console.WriteLine($"{matrixWinFull[2][0]} {matrixWinFull[2][1]} {matrixWinFull[2][2]} {matrixWinFull[2][3]} {matrixWinFull[2][4]}");
            Console.WriteLine($"{matrixWinFull[3][0]} {matrixWinFull[3][1]} {matrixWinFull[3][2]} {matrixWinFull[3][3]} {matrixWinFull[3][4]}");
            Console.WriteLine($"{matrixWinFull[4][0]} {matrixWinFull[4][1]} {matrixWinFull[4][2]} {matrixWinFull[4][3]} {matrixWinFull[4][4]}");
        }

        private static bool LookForRowOrColumn(List<List<string>> matrix)
        {
            bool win = false;
            int colHitZero = 0;
            int colHitOne = 0;
            int colHitTwo = 0;
            int colHitThree = 0;
            int colHitFour = 0;

            for (int row = 0; row < matrix.Count; row++)
            {
                int hits = 0;
                var rowMatrix = matrix[row];

                for (int col = 0; col < rowMatrix.Count; col++)
                {
                    if (!rowMatrix[col].Contains("-1"))
                    {
                        hits++;

                        if (row == 0)
                            colHitZero++;
                        if (row == 1)
                            colHitOne++;
                        if (row == 2)
                            colHitTwo++;
                        if (row == 3)
                            colHitThree++;
                        if (row == 4)
                            colHitFour++;
                    }
                }

                if (hits == 5)
                {
                    win = true;
                    break;
                }
            }

            if (colHitZero == 5 || colHitOne == 5 || colHitTwo == 5 || colHitThree == 5 || colHitFour == 5)
            {
                win = true;
            }

            return win;
        }

        private static List<List<string>> GetEmptyMatrix()
        {
            var matrix = new List<List<string>>();
            matrix.Add("-1 -1 -1 -1 -1".Split(" ").ToList());
            matrix.Add("-1 -1 -1 -1 -1".Split(" ").ToList());
            matrix.Add("-1 -1 -1 -1 -1".Split(" ").ToList());
            matrix.Add("-1 -1 -1 -1 -1".Split(" ").ToList());
            matrix.Add("-1 -1 -1 -1 -1".Split(" ").ToList());
            return matrix;
        }

        private static string CalculateRatePart1(List<string> binairyLines, bool gameRate)
        {
            return "";
        }

        public static void Run()
        {
            Console.WriteLine("Part 1");
            Part1();

            Console.WriteLine();
            Console.WriteLine("Part 2");
        }
    }
}
