using System;
using System.Collections;
namespace PI_Lab_1._2
{
    class Program
    {
        static void Print_Matrix(double[,] a)
        {
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                    Console.Write($"{ a[i, j],10:f}");
                Console.WriteLine();
            }
        }
        static void Make_Matrix(double[,] Matr)
        {
        
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {

                    Matr[i, j] = (Math.Sin(j) + Math.Exp(Math.Sin(i))) * Math.Cos(j);
                }
            }
        }
        static void Decision(double[,] Matr, ref double S, ref int c)
        {
            int counter = 0;
            double Sum = 0;

            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    if (i > j && Matr[i, j]>0)
                    {
                        Sum += Matr[i, j];
                        counter++;
                    }
                    
                }
            }
            Console.Write( $" ");
        }
        static void Main(string[] args)
        {
            double[,] Matr = new double[11, 11];
            double S = 0;
            int c = 0;
            Make_Matrix(Matr);
            Decision(Matr, ref S, ref c);
            Console.Write($"Сумма положительных элементов, находящихся под главной диагонлью: {S,0:f} Их количество: {c} ");
            Console.WriteLine();
            Print_Matrix(Matr);
        }
    }
}
