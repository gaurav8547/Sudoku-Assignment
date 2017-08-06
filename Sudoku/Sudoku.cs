using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class Sudoku
    {
        //set to true wen unit testing else true
        public bool ReadFromString { get; set; } 

        //function to check if sum for row is equal to 45
        //1+ ...+9 = 45
        //if sum is less than or greater than meaning number repeats and a invalid solution
        //else its valid solution
        Func<int[,], bool, bool> checkRowSum = (sudokuArray, swapRowCol) =>
        {
            bool isValid = true;
            Parallel.For(0, 9, rowIndex =>
            {
                int sum = 0;
                for (int colIndex = 0; colIndex < 9; colIndex++)
                {
                    if (swapRowCol)
                        sum += sudokuArray[rowIndex, colIndex];
                    else
                        sum += sudokuArray[colIndex, rowIndex];
                }

                isValid &= (sum == 45);                 
            });

            return isValid;
        };

        private int[,] sudokuSolution = new int[9, 9];
        public bool isValidSudokuSolution(string filePath)
        {
            //readFile and fill array with Sudoku Matrix
            CreateSudokuArrayFromFile(filePath);
            return checkRowSum(sudokuSolution, false) && checkRowSum(sudokuSolution, true);
        }
        

        private void CreateSudokuArrayFromFile(string filePath)
        {
            try
            {
                //Use generate stream method if used in unit testing
                using (StreamReader reader = ReadFromString ? (new StreamReader(GenerateStreamFromString(filePath))) : File.OpenText(filePath))
                {
                    int row = 0;
                    int col = 0;
                    char[] buffer = new char[9];

                    while (reader.Peek() > 0)
                    {
                        if (col > 8)
                        {
                            col = 0;
                            buffer = new char[9];
                            row++;
                        }

                        reader.Read(buffer, col, 1);
                        //insert to array only if read caracter is number
                        if (Char.IsDigit(buffer[col]))
                        {
                            sudokuSolution[row, col] = buffer[col] & 0x0f;
                            col++;
                        }
                        else
                            buffer = new char[9];
                    }
                }
            }
            catch (FileNotFoundException error)
            {
                Console.WriteLine(error.Message);
            }
            catch (IndexOutOfRangeException error)
            {
                Console.WriteLine(error.Message);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        public static Stream GenerateStreamFromString(string s)
        {
            try
            {
                MemoryStream stream = new MemoryStream();
                StreamWriter writer = new StreamWriter(stream);
                writer.Write(s);
                writer.Flush();
                stream.Position = 0;
                return stream;
            }
            catch {
                throw new NotImplementedException();
            }
        }
    }
}
