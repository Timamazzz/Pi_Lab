using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_Lab_11
{
    
    /// <summary>
    /// Этот класс создаёт матрицу
    /// </summary>
    /// <remarks>
    /// <para>В классе создаются поля - размерность матрицы и сама матрица</para>
    /// </remarks>
    public class Matrix
    {
        /// <summary>
        /// Матрица
        /// </summary>
        public int[,] IntArray = null;

        /// <summary>
        /// Строки матрицы
        /// </summary>
        public int n = 0;

        /// <summary>
        /// Столбцы матрицы
        /// </summary>
        public int m = 0;


        /// <summary>
        /// Пустой конструктор матрицы
        /// </summary>
        public Matrix()
        {
            IntArray = new int[n, m];
        }

        /// <summary>
        /// Конструктор матрицы
        /// </summary>
        public Matrix(int n, int m)
        {
            IntArray = new int[n, m];
        }

        /// <summary>
        /// Деконструктор матрицы
        /// </summary>
        ~Matrix()
        {
            IntArray = null;
            n = 0;
            m = 0;
        }

        /// <summary>
        /// Свойство получения и назначения значений матрицы
        /// </summary>
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

        ///<summary>
        ///Метод нахождения количества нулей в матрице
        ///</summary>
        ///<example>
        ///<code>
        /// int n=2, m=2;
        /// IntArray[0,0]=1;
        /// IntArray[0,1]=1;
        /// IntArray[1,0]=1;
        /// IntArray[1,1]=1;
        /// if (IntArray[i, j] == 0)  quan++;;
        /// {return quan;}
        ///</code>
        ///</example>
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

        //<summary>
        ///Метод нахождения суммы заданного столбца
        /// <с>SumOfColumn</с>
        /// <see cref= "SumOfColumn(int)"/>
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

        /// <summary>
        /// Метод увеличение всех эл-ов матрицы на 1
        /// </summary>
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

        /// <summary>
        /// Метод уменьшение всех эл-ов матрицы на 1
        /// </summary>
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
        /// <summary>
        /// Метод сложения двух матриц
        /// </summary>
        /// <param name="mat1">Первая матрица</param>
        /// <param name="mat2">Вторая матрица</param>
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


        /// <summary>
        /// Метод, позволяющий определить квадратная ли матрица 
        /// </summary>
        public static bool operator true(Matrix mat)
        {
            int n = mat.n;
            int m = mat.m;
            if (n == m)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Метод, позволяющий определить квадратная ли матрица 
        /// </summary>
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


  

}
