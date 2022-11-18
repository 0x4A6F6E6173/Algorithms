using Algorithms.Helpers;

namespace Algorithms.Datatypes
{
    public class Matrix : IEquatable<Matrix>
    {
        #region Member Variables
        private double[,] matrix;
        private int rowSize;
        private int columnSize;
        #endregion

        #region Property
        public int RowSize { get { return rowSize; } }
        public int ColumnSize { get { return columnSize; } }
        #endregion

        #region Constructors
        public Matrix(double[,] matrix)
        {
            this.matrix = matrix;
            rowSize = matrix.GetLength(0);
            columnSize = matrix.GetLength(1);
        }

        public Matrix(int size)
        {
            matrix = new double[size, size];
            rowSize = size;
            columnSize = size;
        }

        public Matrix(int rowSize, int columnSize)
        {
            matrix = new double[rowSize, columnSize];
            this.rowSize = rowSize;
            this.columnSize = columnSize;
        }
        #endregion

        #region Public Functions
        public Matrix Transpose()
        {
            var temp = Copy();

            temp.matrix = InternalTranspose();

            return temp;
        }

        public Matrix Inverse()
        {
            // How 'bout no?

            return new Matrix(5);
        }

        public Matrix Copy()
        {
            var temp = new Matrix(rowSize, columnSize);

            for (int indexX = 0; indexX < rowSize; indexX++)
                for (int indexY = 0; indexY < columnSize; indexY++)
                    temp[indexX, indexY] = matrix[indexX, indexY];

            return temp;
        }

        public bool Equals(Matrix? other)
        {
            if (other is null)
                return false;
            var otherMatrix = other as Matrix;
            bool equalRowCount = this.rowSize == otherMatrix.rowSize;
            bool equalColumnCount = this.columnSize == otherMatrix.columnSize;
            if (!equalRowCount || !equalColumnCount)
                return false;

            for (int indexX = 0; indexX < this.rowSize; indexX++)
                for (int indexY = 0; indexY < this.columnSize; indexY++)
                    if (!DoubleComparison.CompareDoubles(this.matrix[indexX, indexY], otherMatrix.matrix[indexX, indexY]))
                        return false;

            return true;
        }

        public string ToString(int significantDigits = 3)
        {
            var columnval = new int[columnSize];

            for (int indexY = 0; indexY < columnSize; indexY++)
            {
                var largestAbsValue = 0d;
                for (int indexX = 0; indexX < rowSize; indexX++)
                {
                    var currIndexVal = Math.Abs(matrix[indexX, indexY]);
                    if (largestAbsValue < currIndexVal)
                        largestAbsValue = matrix[indexX, indexY];
                }
               
                columnval[indexY] = Math.Round(largestAbsValue, significantDigits).ToString().Length
                                    + (largestAbsValue < 0 ? 1 : 0);
            }

            Func<double, int, string> IndentNumber = (value, index) =>
            {
                var stringval = value.ToString();
                return new String(' ', columnval[index] - stringval.Length) + stringval;
            };

            string line = "";

            for (int indexX = 0; indexX < rowSize; indexX++)
            {
                if (indexX == 0)
                    line += "[";
                else
                    line += " ";

                line += "[";
                
                for (int indexY = 0; indexY < columnSize; indexY++)
                    line += $"'{ IndentNumber(matrix[indexX, indexY], indexY) }'" 
                            + (indexY < columnSize - 1 ? ", " : "");
                line += "]";
                line += (indexX < rowSize - 1 ? "," : "]");
                line += (indexX < RowSize - 1 ? "\n" : "");
            }

            return line;
        }
        #endregion

        #region Operators
        // defining [] indexing for the matrix class
        public double this[int indexX, int indexY]
        {
            get { return matrix[indexX, indexY]; }
            set { matrix[indexX, indexY] = value; }
        }

        public static Matrix operator +(in Matrix lhs, in Matrix rhs)
        {
            if (lhs.rowSize != rhs.rowSize &&
                lhs.columnSize != rhs.columnSize)
                throw new Exception($"Matrix Matrix Addition: Inequal dimension for (lhs, rhs)\n" +
                    $"- rows:    ({ lhs.rowSize }, { rhs.rowSize })\n" +
                    $"- columns: ({lhs.columnSize }, {rhs.columnSize })");

            var temp = new Matrix(lhs.rowSize, rhs.columnSize);

            for (int indexX = 0; indexX < lhs.rowSize; indexX++)
                for (int indexY = 0; indexY < lhs.columnSize; indexY++)
                    temp.matrix[indexX, indexY] = lhs.matrix[indexX, indexY] + rhs.matrix[indexX, indexY];
            return temp;
        }

        public static Matrix operator +(in Matrix lhs, int constant)
        {
            var temp = new Matrix(lhs.rowSize, lhs.columnSize);

            for (int indexX = 0; indexX < lhs.rowSize; indexX++)
                for (int indexY = 0; indexY < lhs.columnSize; indexY++)
                    temp.matrix[indexX, indexY] = lhs.matrix[indexX, indexY] + constant;

            return temp;
        }

        public static Matrix operator -(in Matrix lhs, in Matrix rhs)
        {
            if (lhs.rowSize != rhs.rowSize &&
                lhs.columnSize != rhs.columnSize)
                throw new Exception($"Matrix Matrix Subtraction: Inequal dimension for (lhs, rhs)\n" +
                    $"- rows:    ({lhs.rowSize}, {rhs.rowSize})\n" +
                    $"- columns: ({lhs.columnSize}, {rhs.columnSize})");
            
            var temp = new Matrix(lhs.rowSize, lhs.columnSize);

            for (int indexX = 0; indexX < lhs.rowSize; indexX++)
                for (int indexY = 0; indexY < lhs.columnSize; indexY++)
                    temp.matrix[indexX, indexY] = lhs.matrix[indexX, indexY] - rhs.matrix[indexX, indexY];

            return temp;
        }

        public static Matrix operator -(in Matrix lhs, int constant)
        {
            var temp = new Matrix(lhs.rowSize, lhs.columnSize);

            for (int indexX = 0; indexX < lhs.rowSize; indexX++)
                for (int indexY = 0; indexY < lhs.columnSize; indexY++)
                    temp.matrix[indexX, indexY] = lhs.matrix[indexX, indexY] - constant;

            return temp;
        }

        public static Matrix operator *(in Matrix lhs, in Matrix rhs)
        {
            if (lhs.columnSize != rhs.rowSize)
                throw new Exception($"Matrix Matrix Multiplication: " +
                    $"lhs column ({lhs.columnSize}) is inequal to rhs rows ({rhs.rowSize})");

            var temp = new Matrix(lhs.rowSize, lhs.columnSize);

            for (int indexX = 0; indexX < lhs.rowSize; indexX++)
                for (int indexY = 0; indexY < lhs.columnSize; indexY++)
                    temp.matrix[indexX, indexY] = lhs.matrix[indexX, indexY] * rhs.matrix[indexY, indexX];

            return temp;
        }

        public static Matrix operator *(in Matrix lhs, int constant)
        {
            var temp = new Matrix(lhs.rowSize, lhs.columnSize);

            for (int indexX = 0; indexX < lhs.rowSize; indexX++)
                for (int indexY = 0; indexY < lhs.columnSize; indexY++)
                    temp.matrix[indexX, indexY] = lhs.matrix[indexX, indexY] * constant;

            return temp;
        }

        public static Matrix operator /(in Matrix lhs, in Matrix rhs)
        {
            if (lhs.rowSize != rhs.rowSize &&
                lhs.columnSize != rhs.columnSize)
                throw new Exception($"Matrix Matrix Division: Inequal dimension for (lhs, rhs)\n" +
                    $"- rows:    ({lhs.rowSize}, {rhs.rowSize})\n" +
                    $"- columns: ({lhs.columnSize}, {rhs.columnSize})");

            return lhs * rhs.Inverse();
        }

        public static Matrix operator /(in Matrix lhs, int constant)
        {
            var temp = new Matrix(lhs.rowSize, lhs.columnSize);

            for (int indexX = 0; indexX < lhs.rowSize; indexX++)
                for (int indexY = 0; indexY < lhs.columnSize; indexY++)
                    temp.matrix[indexX, indexY] = lhs.matrix[indexX, indexY] / constant;

            return temp;
        }
        #endregion

        #region Private Functions
        private double[,] InternalTranspose()
        {
            var temp = new double[columnSize, rowSize];

            for (int indexX = 0; indexX < rowSize; indexX++)
                for (int indexY = 0; indexY < columnSize; indexY++)
                    temp[indexY, indexX] = matrix[indexX, indexY];

            // Swap
            (rowSize, columnSize) = (columnSize, rowSize);
            return temp;
        }
        #endregion
    }
}
