using Algorithms.Datatypes;
using Algorithms.Helpers;

namespace TestAlgorithms.TestDatatypes
{
    internal class Test_Matrix
    {
        [Test]
        public void Test_Matrix_Comparison_Equal_RowCount()
        {
            int columnSize = 5;
            int rowSize = 4;

            var matrixA = new Matrix(rowSize, columnSize);
            var matrixB = new Matrix(rowSize, columnSize);

            var result = matrixA.Equals(matrixB);

            Assert.That(result, Is.True);
        }

        [Test]
        public void Test_Matrix_Comparison_Equal_ColumnCount()
        {
            int columnSize = 4;
            int rowSize = 5;

            var matrixA = new Matrix(rowSize, columnSize);
            var matrixB = new Matrix(rowSize, columnSize);

            var result = matrixA.Equals(matrixB);

            Assert.That(result, Is.True);
        }

        [Test]
        public void Test_Matrix_Comparison_Identical_Matrix_Indicies()
        {
            var doubleMatrix = new double[,]
            {
                { 0d, 1d, 2d },
                { 3d, 4d, 5d },
                { 6d, 7d, 8d }
            };

            var matrixA = new Matrix(doubleMatrix);
            var matrixB = new Matrix(doubleMatrix);

            var result = matrixA.Equals(matrixB);

            Assert.That(result, Is.True);
        }

        [Test]
        public void Test_Matrix_Comparison_Inequal_RowCount()
        {
            int columnSize = 5;
            int rowSizeA = 3;
            int rowSizeB = 4;

            var matrixA = new Matrix(rowSizeA, columnSize);
            var matrixB = new Matrix(rowSizeB, columnSize);

            var result = matrixA.Equals(matrixB);

            Assert.That(result, Is.False);
        }

        [Test]
        public void Test_Matrix_Comparison_Inequal_ColumnCount()
        {
            int columnSizeA = 4;
            int columnSizeB = 5;
            int rowSize = 4;

            var matrixA = new Matrix(rowSize, columnSizeA);
            var matrixB = new Matrix(rowSize, columnSizeB);

            var result = matrixA.Equals(matrixB);

            Assert.That(result, Is.False);
        }

        [Test]
        public void Test_Matrix_Comparison_Different_Matrix_Indicies()
        {
            var doubleMatrixA = new double[,]
            {
                { 0d, 1d, 2d },
                { 3d, 4d, 5d },
                { 6d, 7d, 8d }
            };

            var doubleMatrixB = new double[,]
            {
                { 1d, 2d, 3d },
                { 4d, 5d, 6d },
                { 7d, 8d, 9d }
            };

            var matrixA = new Matrix(doubleMatrixA);
            var matrixB = new Matrix(doubleMatrixB);

            var result = matrixA.Equals(matrixB);

            Assert.That(result, Is.False);
        }

        [Test]
        public void Test_Matrix_Square_Transpose()
        {
            var test = new Matrix(new double[,]
            {
                { 1d, 2d, 3d },
                { 4d, 5d, 6d },
                { 7d, 8d, 9d }
            });

            var expected = new Matrix(new double[,]
            {
                { 1d, 4d, 7d },
                { 2d, 5d, 8d },
                { 3d, 6d, 9d }
            });

            var result = test.Transpose();

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Test_Matrix_Copy()
        {
            var expected = new Matrix(new double[,]
            {
                { 1d, 2d, 3d },
                { 4d, 5d, 6d },
                { 7d, 8d, 9d }
            });

            var result = expected.Copy();

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
