using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class Matrix
    {
        private readonly int _numberOfRows;
        private readonly int _numberOfColumns;
        private int[,] _matrix;
        private readonly List<Coordinates> _coordinates = new List<Coordinates>();

        public Matrix(int numberOfRows, int numberOfColumns)
        {
            _numberOfRows = numberOfRows;
            _numberOfColumns = numberOfColumns;

            Generate();
        }





        public void FindSquare(int sideLength)
        {
            if (CheckIsThereSquare(sideLength))
            {
                PrintMatrix(FindNearestSquare(sideLength));
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("No Square found in matrix!");
                Console.ResetColor();
            }
        }


        private List<Coordinates> FindNearestSquare(int sideLength)
        {
            var nearestSquare = new List<Coordinates>();
            double nearestDistance = _numberOfRows * _numberOfColumns;
            int skip = 0;

            while (true)
            {
                var square = _coordinates.Skip(skip).Take(sideLength * sideLength);
                if (square.Count() != Math.Pow(sideLength, 2))
                    break;

                var newDistance = Math.Sqrt(Math.Pow(square.First().RowIndex, 2) + Math.Pow(square.First().ColumnIndex, 2));
                if (newDistance < nearestDistance)
                {
                    nearestDistance = newDistance;
                    nearestSquare = square.ToList();
                }

                skip += sideLength * sideLength;
            }

            return nearestSquare;
        }

        private void Generate()
        {
            _matrix = new int[_numberOfRows, _numberOfColumns];
            for (int i = 0; i < _numberOfRows; i++)
            {
                for (int j = 0; j < _numberOfColumns; j++)
                {
                    _matrix[i, j] = new Random().Next(0, 2);
                }
            }
        }


        private bool CheckIsThereSquare(int sideLength)
        {
            bool isThereSquare = false;

            for (int rowIndex = 0; rowIndex < _numberOfRows - (sideLength - 1); rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < _numberOfColumns - (sideLength - 1); columnIndex++)
                {
                    if (_matrix[rowIndex, columnIndex] == 1)
                    {
                        int cellCount = 0;

                        for (int rowChecker = rowIndex; rowChecker < rowIndex + sideLength; rowChecker++)
                        {
                            for (int columnChecker = columnIndex; columnChecker < columnIndex + sideLength; columnChecker++)
                            {
                                if (_matrix[rowChecker, columnChecker] == 1)
                                    cellCount++;
                            }

                            if (cellCount == (sideLength * sideLength))
                            {
                                isThereSquare = true;

                                AddCoordinates(sideLength, rowIndex, columnIndex);
                            }


                        }
                        cellCount = 0;
                    }

                }
            }

            return isThereSquare;
        }


        private void AddCoordinates(int sideLength, int rowIndex, int columnIndex)
        {
            for (int i = rowIndex; i < rowIndex + sideLength; i++)
            {
                for (int j = columnIndex; j < columnIndex + sideLength; j++)
                {
                    _coordinates.Add(new Coordinates() { RowIndex = i, ColumnIndex = j });
                }
            }
        }


        private void PrintMatrix(List<Coordinates> nearestSquare)
        {
            for (int i = 0; i < _numberOfRows; i++)
            {
                for (int j = 0; j < _numberOfColumns; j++)
                {
                    if (_coordinates.Any(c => c.RowIndex == i && c.ColumnIndex == j))
                    {

                        if (nearestSquare.Any(c => c.RowIndex == i && c.ColumnIndex == j))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(_matrix[i, j] + " ");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write(_matrix[i, j] + " ");
                            Console.ResetColor();
                        }
                    }
                    else
                    {
                        Console.Write(_matrix[i, j] + " ");
                    }
                }
                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("* The nearest square is highlighted with ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("'Green' ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("color.");
            Console.Write("* The all other squares are highlighted with ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("'Magenta' ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("color.");
            Console.ResetColor();
        }
    }
}
