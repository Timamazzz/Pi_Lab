using System;

namespace PI_Lab_3
{

    public class Matrix
    {
        public int[,] IntArray = null;
        public int n = 0;
        public int m = 0;

        public Matrix()
        {
            IntArray = new int[n, m];
        }

        public Matrix(int n, int m)
        {
            IntArray = new int[n, m];
        }

        ~Matrix()
        {
            IntArray = null;
            n = 0;
            m = 0;
        }

        public int this[int rowIndex, int columnIndex]
        {
            get
            {
                return IntArray[rowIndex, columnIndex];
            }
            set
            {
                IntArray[rowIndex, columnIndex] = value;
            }
        }

        public int ZeroQuantity()
        {
            
            
                int quan = 0;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (IntArray[i, j] == 0)
                        {
                            quan++;
                        }
                    }
                }
                return quan;
            
        }

        public void InputFromKeyboard()
        {
            Console.Write("Enter matrix's rows : ");
            n = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter matrix's columns: ");
            m = Convert.ToInt32(Console.ReadLine());

            IntArray = new int[n, m];

            Console.WriteLine("Enter matrix's elements");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.WriteLine("Enter element {0},{1}", i, j);
                    IntArray[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
        }

        public void PrintMatrix()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(IntArray[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public int SumOfColumn(int colIndex)
        {
            if (colIndex <= 0 && colIndex >= m)
            {
                Console.WriteLine($"The {colIndex} column does not exist");
                return 0;
            }
            else
            {
                int sum = 0;
                for (int i = 0; i < n; i++)
                {
                    sum += IntArray[i, colIndex];
                }
                return sum;
            }
        }

        public static Matrix operator ++(Matrix mat)
        {
            int n = mat.n;
            int m = mat.m;
            int[,] intArray = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    intArray[i, j] = mat[i, j]++;
                }
            }
            Matrix result = new Matrix();
            result.IntArray = intArray;
            result.n = n;
            return result;
        }

        public static Matrix operator --(Matrix mat)
        {
            int n = mat.n;
            int m = mat.m;
            int[,] intArray = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    intArray[i, j] = mat[i, j]--;
                }
            }
            Matrix result = new Matrix();
            result.IntArray = intArray;
            result.n = n;
            result.m = m;
            return result;
        }

        public static Matrix operator +(Matrix mat1, Matrix mat2)
        {
            Matrix result = new Matrix();
            int n = mat1.n;
            int m = mat1.m;
            int[,] intArray = new int[n, m];

            if (mat1.n != mat2.n && mat1.m != mat2.m)
            {
                Console.WriteLine($"The dimensions of the matrices are not equal");
                result.IntArray = intArray;
                result.n = 0;
                result.m = 0;
                return result;
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        intArray[i, j] = mat1[i, j] + mat2[i, j];
                    }
                }
                result.IntArray = intArray;
                result.n = n;
                result.m = m;
                return result;
            }
        }

       

        public static bool operator true(Matrix mat)
        {
            int n = mat.n;
            int m = mat.m;
            if (n == m)
                return true;
            else
                return false;
        }

        public static bool operator false(Matrix mat)
        {
            int n = mat.n;
            int m = mat.m;
            if (n == m)
                return true;
            else
                return false;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Matrix array1 = new Matrix();
            Matrix array2 = new Matrix();
            Matrix array3 = new Matrix();
            


            array1.InputFromKeyboard();
            array2.InputFromKeyboard();
            Console.WriteLine();

            Console.WriteLine($"Matrix1");
            array1.PrintMatrix();
            Console.WriteLine();

            Console.WriteLine($"Matrix2");
            array2.PrintMatrix();
            Console.WriteLine();

            Console.WriteLine($"The sum of the second column of the matrix 1: { array1.SumOfColumn(0)}");
            Console.WriteLine();

            Console.WriteLine($"The sum of the second column of the matrix 2: { array2.SumOfColumn(1)}");
            Console.WriteLine();

            Console.WriteLine($"The number of zeros in the 1 matrix: {array1.ZeroQuantity()}");
            Console.WriteLine();

            Console.WriteLine("array1+array2");
            array3 = array1 + array2;
            array3.PrintMatrix();
            Console.WriteLine();

            if (array1)
                Console.WriteLine("The matrix 1 is a square");
            else
                Console.WriteLine("The matrix 1 is a not square");
            Console.WriteLine();

            Console.WriteLine($"array1++");
            array3 = array1++;
            array3.PrintMatrix();
            Console.WriteLine();

            Console.WriteLine($"array2--");
            array3 = array2--;
            array3.PrintMatrix();
        }
    }
}
