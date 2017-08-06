using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            //var filePath = args[0];               

            Sudoku sudoku = new Sudoku();
            if(sudoku.isValidSudokuSolution(@"C:/Test/Sudoku.txt"))
                Console.WriteLine("Is a valid solution");
            else
                Console.WriteLine("Not a valid solution");
            Console.Read();
        }
    }
}
