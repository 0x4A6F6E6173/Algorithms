namespace Algorithms.Datatypes
{
    public class UndirectedDenseGraph<T>
    {
        #region MemberVariables
        int matrixSize;
        List<Node<T>> nodeList;
        int[][] nodeArcIncidenceMatrix;
        #endregion

        #region Constructor
        public UndirectedDenseGraph()
        {
            nodeList = new List<Node<T>>();
        }
        #endregion

        #region PublicMemberFunctions


        #endregion

        #region PrivateMemberFunctions
        private void ExpandIncidenceMatrix()
        {
            matrixSize *= 2;        // Increase the size overhead
            var newMatrix = CreateIncidenceMatrix();
            for (int vertexIndex = 0; vertexIndex < nodeArcIncidenceMatrix.Length; vertexIndex++)
                Array.Copy(nodeArcIncidenceMatrix[vertexIndex],
                           newMatrix[vertexIndex],
                           nodeArcIncidenceMatrix[vertexIndex].Length);

            nodeArcIncidenceMatrix = newMatrix;
        }

        private int[][] CreateIncidenceMatrix()
        {
            var matrix = new int[matrixSize][];
            for (int index = 0; index < matrixSize; index++)
            {
                matrix[index] = new int[matrixSize - index];
            }

            return matrix;
        }
        #endregion
    }
}
