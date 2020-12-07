using System;

namespace Multidimensional_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int[,,,] array4D = new int[3, 4, 2, 3]

                {{{ {1,3,4},{1,3,4}},{ {1,3,4},{1,3,4}},{ {1,3,4},{1,3,4}},{ {1,3,4},{1,3,4}} },
                {{ {1,3,4},{1,3,4}},{ {1,3,4},{1,3,4}},{ {1,3,4},{1,3,4}},{ {1,3,4},{1,3,4}} },
                {{ {1,3,4},{1,3,4}},{ {1,3,4},{1,3,4}},{ {1,3,4},{1,3,4}},{ {1,3,4},{1,3,4}} }};

                //This finds the square of each index in the array
                for (var i = 0; i < array4D.GetLength(0); i++)
                {
                    for (var j = 0; j < array4D.GetLength(1); j++)
                    {
                        for (var k = 0; k < array4D.GetLength(2); k++)
                        {
                            for (var l = 0; l < array4D.GetLength(3); l++)
                            {
                                var values = array4D[i, j, k, l];
                                var squared = (int)Math.Pow(values, 2);

                                Console.Write($" {squared} ");
                            }
                        }
                    }
                }
                Console.ReadLine();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }


    }
}
