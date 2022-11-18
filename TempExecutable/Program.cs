using Algorithms.Datatypes;
Console.OutputEncoding = System.Text.Encoding.Unicode;


List<Node<int>> nodeList = new()
{
    new(0), new(1),  new(2), new(3),
    new(4), new(5),  new(6), new(7),
    new(8), new(9), new(10), new(11)
};
DirectedDenseGraph<int> directedDenseGraph = new(nodeList);
for (int index = 0; index < nodeList.Count; index++)
    directedDenseGraph.ConnectEdges(
        index,
        new List<int> { (index + 2) % nodeList.Count, (index + 5) % nodeList.Count }
    );
directedDenseGraph.PrintGraph();

Console.WriteLine("\n\n\n");

int rowSize = 5, columnSize = 3;
var matrix = new Matrix(rowSize, columnSize);
for (int indexX = 0; indexX < rowSize; indexX++)
    for (int indexY = 0; indexY < columnSize; indexY++) 
        matrix[indexX, indexY] = -1 * (indexX^2 * columnSize + indexY*indexY);
Console.WriteLine(matrix.ToString());