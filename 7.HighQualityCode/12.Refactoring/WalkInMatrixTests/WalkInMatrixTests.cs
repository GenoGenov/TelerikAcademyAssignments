using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WalkInMatrix;

namespace WalkInMatrixTests
{
    [TestClass]
    public class WalkInMatrixTests
    {
        [TestMethod]
        public void MatrixShouldBeBiggerThanOne()
        {
            Console.SetIn(new StringReader("1"));
            var sw = new StringWriter();
            Console.SetOut(sw);
            RotatingWalkDemo.ReadMatrixDimensions();
            Assert.AreEqual("You haven't entered a correct number", sw.ToString().Trim());

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InputArrayShouldBeMatrix_TestFill()
        {
            var matrix = new int[4, 5];
            int x = 0;
            int y = 0;
            RotatingWalkInMatrix.FillAvailableCellsOnCurrentPath(matrix, 0, 0, ref x, ref y);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InputArrayShouldBeMatrix_TestCell()
        {
            var matrix = new int[4, 5];
            int x = 0;
            int y = 0;
            RotatingWalkInMatrix.FindNextAvailableCell(matrix, out x, out y);
        }

        //Some space that i cant't find is breaking the test....
        [TestMethod]
        public void MethodShouldCorrectlyTraverseMatrix()
        {
            Console.SetIn(new StringReader("6"));
            var sw = new StringWriter();
            Console.SetOut(sw);
            int n = RotatingWalkDemo.ReadMatrixDimensions();
            int[,] matrix = new int[n, n];
            RotatingWalkDemo.TraverseMatrix(matrix, n);
            RotatingWalkDemo.PrintMatrix(matrix);
            Assert.AreEqual("1 16 17 18 19 20\n 15  2 27 28 29 21\n 14 31  3 26 30 22\n 13 36 32  4 25 23\n 12 35 34 33  5 24\n 11 10  9  8  7  6", sw.ToString().Trim());

        }

    }
}
