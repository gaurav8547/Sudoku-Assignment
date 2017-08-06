using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SudokuUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        string validSudokuSolution, invalidSquare, invalidRow, invalidColumn;
        Sudoku.Sudoku sudoku = new Sudoku.Sudoku();

        [TestMethod]
        public void isValidSudokuSolution_Pass()
        {
            bool valid = sudoku.isValidSudokuSolution(validSudokuSolution);

            Assert.AreEqual(valid, true);
        }

        [TestMethod]
        public void isValidSudokuSolution_FailSquare()
        {
            bool invalid = sudoku.isValidSudokuSolution(invalidSquare);

            Assert.AreEqual(invalid, false);
        }

        [TestMethod]
        public void isValidSudokuSolution_FailRow()
        {
            bool invalid = sudoku.isValidSudokuSolution(invalidRow);

            Assert.AreEqual(invalid, false);
        }

        [TestMethod]
        public void isValidSudokuSolution_FailColumn()
        {
            bool invalid = sudoku.isValidSudokuSolution(invalidColumn);

            Assert.AreEqual(invalid, false);
        }

        [TestMethod]
        public void isValidSudokuSolution_FailforEmptyFile()
        {
            bool invalid = sudoku.isValidSudokuSolution("");

            Assert.AreEqual(invalid, false);
        }

        [TestInitialize]
        public void setData()
        {
            sudoku.ReadFromString = true;

            validSudokuSolution = "534678912\n" +

                    "672195348\n" +

                    "198342567\n" +

                    "859761423\n" +

                    "426853791\n" +

                    "713924856\n" +

                    "961537284\n" +

                    "287419635\n" +

                    "345286179\n";


            invalidSquare = "534678912\n" +

                    "652197348\n" +

                    "198342567\n" +

                    "859761423\n" +

                    "426853791\n" +

                    "713924856\n" +

                    "961537284\n" +

                    "287419635\n" +

                    "345286179\n";

            invalidRow = "534678812\n" +

                    "652197348\n" +

                    "198342567\n" +

                    "859761423\n" +

                    "426853791\n" +

                    "713924856\n" +

                    "961537284\n" +

                    "287419635\n" +

                    "345286179\n";

            invalidColumn = "534678812\n" +

                        "652197348\n" +

                        "198342567\n" +

                        "859761423\n" +

                        "426853791\n" +

                        "713924856\n" +

                        "961573284\n" +

                        "287419635\n" +

                        "345286179\n";
        }
    }
}
