using System;

public class Matrix
{
    private int row_matrix; //number of rows for matrix
    private int column_matrix; //number of colums for matrix
    private int[,,,] matrix; //holds values of matrix itself

    //create r*c matrix and fill it with data passed to this constructor
    public Matrix(int[,,,] int_array)
    {
        matrix = int_array;
        row_matrix = matrix.GetLength(2);
        column_matrix = matrix.GetLength(3);

        Console.WriteLine("Contructor which sets matrix size {0}x{1} and fill it with initial data executed.", row_matrix, column_matrix);
    }

    //P.S: This only works for 4x4 Matrices as requested
    public void FindDeterminant()
    {
        try
        {
            if (row_matrix != column_matrix)
            {
                Console.WriteLine("The rows and columns must be equal in order to calculate the Determinant");
            }
            else
            {
                int determinant = matrix[0, 0, 0, 0] * (matrix[0, 0, 1, 1] * (matrix[0, 0, 2, 2] * matrix[0, 0, 3, 3] - matrix[0, 0, 2, 3] * matrix[0, 0, 3, 2])
                                                        - matrix[0, 0, 1, 2] * (matrix[0, 0, 2, 1] * matrix[0, 0, 3, 3] - matrix[0, 0, 2, 3] * matrix[0, 0, 3, 1])
                                                        + matrix[0, 0, 1, 3] * (matrix[0, 0, 2, 1] * matrix[0, 0, 3, 2] - matrix[0, 0, 2, 2] * matrix[0, 0, 3, 1]))
                                  - matrix[0, 0, 0, 1] * (matrix[0, 0, 1, 0] * (matrix[0, 0, 2, 2] * matrix[0, 0, 3, 3] - matrix[0, 0, 2, 3] * matrix[0, 0, 3, 2])
                                                      - matrix[0, 0, 1, 2] * (matrix[0, 0, 2, 0] * matrix[0, 0, 3, 3] - matrix[0, 0, 2, 3] * matrix[0, 0, 3, 0])
                                                      + matrix[0, 0, 1, 3] * (matrix[0, 0, 2, 0] * matrix[0, 0, 3, 2] - matrix[0, 0, 2, 2] * matrix[0, 0, 3, 0]))
                                  + matrix[0, 0, 0, 2] * (matrix[0, 0, 1, 0] * (matrix[0, 0, 2, 1] * matrix[0, 0, 3, 3] - matrix[0, 0, 2, 3] * matrix[0, 0, 3, 1])
                                                      - matrix[0, 0, 1, 1] * (matrix[0, 0, 2, 0] * matrix[0, 0, 3, 3] - matrix[0, 0, 2, 3] * matrix[0, 0, 3, 0])
                                                      + matrix[0, 0, 1, 3] * (matrix[0, 0, 2, 0] * matrix[0, 0, 3, 1] - matrix[0, 0, 2, 1] * matrix[0, 0, 3, 0]))
                                   - matrix[0, 0, 0, 3] * (matrix[0, 0, 1, 0] * (matrix[0, 0, 2, 1] * matrix[0, 0, 3, 2] - matrix[0, 0, 2, 2] * matrix[0, 0, 3, 1])
                                                       - matrix[0, 0, 1, 1] * (matrix[0, 0, 2, 0] * matrix[0, 0, 3, 2] - matrix[0, 0, 2, 2] * matrix[0, 0, 3, 0])
                                                       + matrix[0, 0, 1, 2] * (matrix[0, 0, 2, 0] * matrix[0, 0, 3, 1] - matrix[0, 0, 2, 1] * matrix[0, 0, 3, 0]));

                Console.WriteLine("\nThe Determinant of the {1}x{2} Matrix is {0}\n.", determinant, row_matrix, column_matrix);
            }
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message);
        }
    }
    public void SquareMatrix()
    {
        try
        {
            var arrayClone = (int[,,,])matrix.Clone();
            var rowCount = matrix.GetLength(2);
            int columnCount = matrix.GetLength(3);
            int cloneColumnCount = arrayClone.GetLength(3);
            if (rowCount == cloneColumnCount)
            {
                var arrayProduct = (int[,,,])matrix.Clone();
                for (var i = 0; i < rowCount; i++)
                {
                    for (var j = 0; j < cloneColumnCount; j++)
                    {
                        var sum = 0;
                        for (var k = 0; k < columnCount; k++)
                        {
                            var a = matrix[0, 0, i, k];
                            var b = arrayClone[0, 0, k, j];
                            sum += a * b;
                        }
                        arrayProduct[0, 0, i, j] = sum;
                    }
                }
                Console.WriteLine("The Square of the matrix is: ");
                Show4DMatrix(arrayProduct);
            }
            else
            {
                Console.WriteLine("The matrix must have the same number of rows as columns, in order to be squared");
            }
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message);
        }
    }
    private static void Show4DMatrix(int[,,,] array)
    {
        try
        {
            for (var i = 0; i < array.GetLength(0); i++)
            {
                Console.WriteLine(" [");
                for (var j = 0; j < array.GetLength(1); j++)
                {
                    for (var k = 0; k < array.GetLength(2); k++)
                    {
                        for (var l = 0; l < array.GetLength(3); l++)
                        {
                            Console.Write($"   { array[i, j, k, l] }");
                        }
                        Console.WriteLine();
                    }
                }
                Console.WriteLine(" ]\n");
            }
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message);
        }
    }
}

public class Program
{
    private static void Main(string[] args)
    {
        //Matrix mat3D = new Matrix(new[, , ,]
        //{{{
        //    {6, 2, 8},
        //    {2, 4, 3},
        //    {4, -1, -2}
        //}}});

        Matrix mat4D = new Matrix(new[,,,]
        {{{
            {1, 2, 1, 3},
            {2, 5, 2, 1},
            {1, 1, 3, 2},
            {4, 1, 3, 1}
        } } });



        mat4D.FindDeterminant();

        mat4D.SquareMatrix();

        //You can find the Determinant and Square of as many 4x4 Matrices as possible
        //All you have to do is to instantiate the Class Matrix as a 4 dimensional array, and call the Methods respectively.
        Console.ReadLine();

    }
}