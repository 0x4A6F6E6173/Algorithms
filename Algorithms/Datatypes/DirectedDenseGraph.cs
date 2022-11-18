namespace Algorithms.Datatypes
{
    public class DirectedDenseGraph<T>
    {
        #region MemberVariables
        private int matrixSize;
        private List<Node<T>> nodeList;
        private int[,] nodeArcIncidenceMatrix;
        #endregion

        #region Propreties
        public int[,] NodeArcIncidenceMatrix
        {
            get => nodeArcIncidenceMatrix;
        }

        public List<Node<T>> NodeList
        {
            get => nodeList;
        }
        #endregion

        #region Constructor
        public DirectedDenseGraph()
        {
            int matrixSize = 10; // Arbitrary default value
            nodeList = new List<Node<T>>();
            nodeArcIncidenceMatrix = new int[matrixSize, matrixSize];
        }

        public DirectedDenseGraph(List<Node<T>> nodeList)
        {
            this.nodeList = nodeList;
            matrixSize = nodeList.Count * 2; // Overhead
            nodeArcIncidenceMatrix = new int[matrixSize, matrixSize];
        }
        #endregion

        #region PublicMemberFunctions
        public void AddNode(Node<T> vertex)
        {
            nodeList.Add(vertex);

            // If the matrix is full then double it's size
            if (nodeList.Count == matrixSize)
                ExpandIncidenceMatrix();
        }

        public void AddNodes(List<Node<T>> verticies)
        {
            nodeList.AddRange(verticies);
            
            // If the matrix is full then double it's size
            if (nodeList.Count == matrixSize)
                ExpandIncidenceMatrix();
        }

        public void ConnectEdge(int vertexFrom, int vertexTo)
        {
            nodeArcIncidenceMatrix[vertexFrom, vertexTo] = 1;
        }

        public void ConnectWeightedEdge(int vertexFrom, int vertexTo, int weight)
        {
            nodeArcIncidenceMatrix[vertexFrom, vertexTo] = weight;
        }

        public void ConnectEdges(int vertexFrom, List<int> verticiesTo)
        {
            foreach (int vertexTo in verticiesTo)
                nodeArcIncidenceMatrix[vertexFrom, vertexTo] = 1;
        }

        public void ConnectWeightedEdges(int vertexFrom, List<int> verticiesTo, List<int> edgeWeights)
        {
            for (int vertexIndex = 0; vertexIndex < verticiesTo.Count; vertexIndex++)
                nodeArcIncidenceMatrix[vertexFrom, verticiesTo[vertexIndex]] = edgeWeights[vertexIndex];
        }

        public void PrintGraph(int internalSeperator = 5)
        {
            var thickCross = "╋";
            var thinCross = "┼";
            var thickVerticalCross = "╂";
            var thickHorizontalCross = "┿";
            var thickHorizontalLine = "━";
            char charThickHorizontalLine = '━';
            var thinHorizontalLine = "─";
            char charThinHorizontalLine = '─';
            var thickVerticalLine = "┃";
            var thinVerticalLine = "│";


            int nodeCount = nodeList.Count;
            Func<int, int> computeDigits = x => ((int)Math.Floor(x == 0 ? 0 : Math.Log10(x))) + 1;
            int digitCount = computeDigits(nodeCount);
            Func<int, string> indentNumber = x => new String(' ', digitCount - computeDigits(x)) + x.ToString();
            
            Console.WriteLine($"Full matrix size: [{ matrixSize }]");
            string lineOutput = new string('x', digitCount) + " ";
            bool firstSeperator = true;
            for (int columnIndex = 0; columnIndex < nodeCount; columnIndex++)
            {
                bool needVerticalSeperator = columnIndex % internalSeperator == 0;
                if (needVerticalSeperator && firstSeperator)
                {
                    lineOutput += thickVerticalLine;
                    firstSeperator = false;
                }
                else if (needVerticalSeperator && !firstSeperator)
                    lineOutput += " " + thinVerticalLine;
                lineOutput += " " + indentNumber(columnIndex);
            }
            firstSeperator = true;
            Console.WriteLine(lineOutput);

            bool firstThickBorder = true;
            for (int rowIndex = 0; rowIndex < nodeCount; rowIndex++)
            {
                bool needHorizontalSeperator = rowIndex % internalSeperator == 0;
                if (firstThickBorder && needHorizontalSeperator)
                {
                    lineOutput = new string(charThickHorizontalLine, digitCount);
                    firstThickBorder = false;
                    bool firstThickCross = true;
                    for (int columnIndex = 0; columnIndex < nodeCount; columnIndex++)
                    {
                        bool columnCross = columnIndex % internalSeperator == 0;
                        if (columnCross && firstThickCross)
                        {
                            lineOutput += thickHorizontalLine;
                            lineOutput += thickCross;
                            firstThickCross = false;
                        } 
                        else if (columnCross && !firstThickCross)
                        {
                            lineOutput += thickHorizontalLine;
                            lineOutput += thickHorizontalCross;
                        }

                        lineOutput += new String(charThickHorizontalLine, digitCount + 1);
                    }

                    Console.WriteLine(lineOutput);
                }
                else if (!firstThickBorder && needHorizontalSeperator)
                {
                    lineOutput = new string(charThinHorizontalLine, digitCount);
                    bool firstThickCross = true;
                    for (int columnIndex = 0; columnIndex < nodeCount; columnIndex++)
                    {
                        bool columnCross = columnIndex % internalSeperator == 0;
                        if (columnCross && firstThickCross)
                        {
                            lineOutput += thinHorizontalLine;
                            lineOutput += thickVerticalCross;
                            firstThickCross = false;
                        }
                        else if (columnCross && !firstThickCross)
                        {
                            lineOutput += thinHorizontalLine;
                            lineOutput += thinCross;
                        }

                        lineOutput += new String(charThinHorizontalLine, digitCount + 1);
                    }

                    Console.WriteLine(lineOutput);
                }

                lineOutput = indentNumber(rowIndex);
                for (int columnIndex = 0; columnIndex < nodeCount; columnIndex++)
                {
                    bool needVerticalSeperator = columnIndex % internalSeperator == 0;
                    if (needVerticalSeperator && firstSeperator)
                    {
                        lineOutput += " ";
                        lineOutput += thickVerticalLine;
                        firstSeperator = false;
                    }
                    else if (needVerticalSeperator && !firstSeperator)
                    {
                        lineOutput += " ";
                        lineOutput += thinVerticalLine;
                    }
                    lineOutput += " " + indentNumber(nodeArcIncidenceMatrix[rowIndex, columnIndex]);
                }
                firstSeperator = true;
                Console.WriteLine(lineOutput);
            }
        }
        #endregion

        #region PrivateMemberFunctions
        private void ExpandIncidenceMatrix()
        {
            matrixSize *= 2;        // Increase the size overhead
            var newMatrix = new int[matrixSize, matrixSize];
            for (int vertexFromIndex = 0; vertexFromIndex < nodeArcIncidenceMatrix.Length; vertexFromIndex++)
                for (int vertexToIndex = 0; vertexToIndex < nodeArcIncidenceMatrix.Length; vertexToIndex++)
                    newMatrix[vertexFromIndex, vertexToIndex] =
                    nodeArcIncidenceMatrix[vertexFromIndex, vertexToIndex];
            nodeArcIncidenceMatrix = newMatrix;
        }

        private void ShrinkIncidenceMatrix()
        {

        }
        #endregion
    }
}