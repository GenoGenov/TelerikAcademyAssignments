using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class Matrix<T> where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        #region Fields

        private const int DEFAULT_ROWS = 2;

        private const int DEFAULT_COLS = 2;

        private int col;
        private T[,] matrix;

        private int row;

        #endregion

        #region Constructors

        public Matrix(int row, int col)
        {
            this.Row = row;
            this.Col = col;
            matrix = new T[Row, Col];
        }

        public Matrix() : this(DEFAULT_ROWS, DEFAULT_COLS)
        {
        }

        #endregion

        #region Properties

        public int Col
        {
            get { return col; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("value must be atleast 1");
                }
                col = value;
            }
        }

        public int Row
        {
            get { return row; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("value must be atleast 1");
                }
                row = value;
            }
        }

        #endregion

        #region Indexer

        public T this[int i, int j]
        {
            get
            {
                if (i < 0 || j < 0 || i >= this.Row || j >= this.col)
                {
                    throw new IndexOutOfRangeException("Index was out of range");
                }
                return matrix[i, j];
            }
            set
            {
                if (i < 0 || j < 0 || i >= this.Row || j >= this.col)
                {
                    throw new IndexOutOfRangeException("Index was out of range");
                }
                matrix[i, j] = value;
            }
        }

        #endregion

        #region Operators

        public static Matrix<T> operator +(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.Row != secondMatrix.Row && firstMatrix.Col != secondMatrix.Col)
            {
                throw new ArgumentException("matrices must be of the same size");
            }

            var result = new Matrix<T>(firstMatrix.Row, firstMatrix.Col);

            for (int i = 0; i < result.Row; i++)
            {
                for (int j = 0; j < result.Col; j++)
                {
                    result[i, j] = (dynamic) firstMatrix[i, j] + (dynamic) secondMatrix[i, j];
                }
            }

            return result;
        }

        public static Matrix<T> operator -(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.Row != secondMatrix.Row && firstMatrix.Col != secondMatrix.Col)
            {
                throw new ArgumentException("matrices must be of the same size");
            }

            var result = new Matrix<T>(firstMatrix.Row, firstMatrix.Col);

            for (int i = 0; i < result.Row; i++)
            {
                for (int j = 0; j < result.Col; j++)
                {
                    result[i, j] = (dynamic) firstMatrix[i, j] - (dynamic) secondMatrix[i, j];
                }
            }

            return result;
        }

        public static Matrix<T> operator *(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.Col != secondMatrix.Row)
            {
                throw new ArgumentException("matrices must be of the same size");
            }

            var result = new Matrix<T>(firstMatrix.Row, secondMatrix.Col);

            for (int i = 0; i < result.Row; i++)
            {
                for (int j = 0; j < result.Col; j++)
                {
                    for (int k = 0; k < firstMatrix.Col; k++)
                    {
                        result[i, j] += (dynamic) firstMatrix[i, k]*secondMatrix[k, j];
                    }
                }
            }

            return result;
        }

        public static bool operator true(Matrix<T> matrix)
        {
            for (int i = 0; i < matrix.Row; i++)
            {
                for (int j = 0; j < matrix.Col; j++)
                {
                    if (!matrix[i, j].Equals(default(T)))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool operator false(Matrix<T> matrix)
        {
            for (int i = 0; i < matrix.Row; i++)
            {
                for (int j = 0; j < matrix.Col; j++)
                {
                    if (!matrix[i, j].Equals(default(T)))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        #endregion

        #region Overrides

        public override string ToString()
        {
            var result = new StringBuilder();
            for (int i = 0; i < this.Row; i++)
            {
                var temp = new StringBuilder();

                for (int j = 0; j < this.Col; j++)
                {
                    temp.Append(this.matrix[i, j] + " ");
                }
                result.AppendLine(temp.ToString().Trim());
            }
            return result.ToString().Trim() + "\n";
        }

        #endregion
    }
}