using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_Lab_4A
{
    public class Matrix
    {
        public int[,] IntArray = null;
        public int n = 0;
        public int m = 0;
                
        public Matrix(int _m, int _n)
        {
            m = _m;
            n = _n;
            IntArray = new int[n, m];
        }

        public Matrix()
        {
            m = 0;
            n = 0;
            IntArray = null;
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

        public int SumOfColumn(int colIndex)
        {
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += IntArray[i, colIndex];
            }
            return sum;
        }



        public static Matrix operator ++(Matrix mat)
        {
            
            for (int i = 0; i < mat.n; i++)
            {
                for (int j = 0; j < mat.m; j++)
                {
                    mat[i, j] = mat[i, j] + 1;
                }
            }
            
            return mat;
        }

        public static Matrix operator --(Matrix mat)
        {
            for (int i = 0; i < mat.n; i++)
            {
                for (int j = 0; j < mat.m; j++)
                {
                    mat[i, j] = mat[i, j] -1;
                }
            }

            return mat;
        }

        public static Matrix operator +(Matrix mat1, Matrix mat2)
        {
           
            int n = mat1.n;
            int m = mat1.m;
            Matrix result = new Matrix(n, m);
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

        public static bool operator false(Matrix mat)
        {
            int n = mat.n;
            int m = mat.m;
            if (n == m)
                return true;
            else
                return false;
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







    }
}
