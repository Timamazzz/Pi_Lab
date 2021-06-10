using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;

namespace Pi_lab_2A_Poli
{
    class Program
    {
        struct Point
        {
            public int x;
            public int y;
           
            public Point(int X, int Y) 
            {
                x = X;
                y = Y;
            }

            public int Quarter
            {
                get
                {
                    if (x > 0)
                        if (y > 0) 
                            return 1;
                        else 
                            return 4;
                    else
                        if (y > 0) 
                            return 2;
                        else 
                            return 3;
                }
                 
            }

            public double Distance => Math.Sqrt((x - 0) * (x - 0) + (y - 0) * (y - 0));

            public  string TextOut => $"{x};{y}";

        }

        static int Max_quarter(Point[] vec, int N)
        {
            int i1 = 0, i2 = 0, i3 = 0, i4 = 0;

            for (int i = 0; i < N; i++) 
            {
                switch (vec[i].Quarter)
                {
                    case 1:
                        i1++;
                        break;
                    case 2:
                        i2++;
                        break;
                    case 3:
                        i3++;
                        break;
                    case 4:
                        i4++;
                        break;
                }
            }

            if (i1 >= i2 && i1 >= i3 && i1 >= i4) return 1;

            if (i2 >= i1 && i2 >= i3 && i2 >= i4) return 2;

            if (i3 >= i1 && i3 >= i2 && i3 >= i4) return 3;

            if (i4 >= i1 && i4 >= i2 && i4 >= i3) return 4;

            return 0;
        }



        static void Search_min(Point[] vec, int N, int quarter)
        {
            
            int j = 0;
            for (int i = 0; i < N; i++)
            {
                if (vec[i].Quarter == quarter)
                    j++;
            }

            Point[] q = new Point[j];
            j = 0;

            for (int i = 0; i < N; i++)
            {
                if (vec[i].Quarter == quarter)
                {
                    q[j] = vec[i];
                    j++;
                }
            }

            int min1 = 0, min2 = 0;

            if (q[0].Distance < q[1].Distance)
            {
                min1 = 0;
                min2 = 1;
            }
            else
            {
                min1 = 1;
                min2 = 0;
            }

            int buff;
            for (int i = 2; i < q.Length; i++)
            {
                if (q[i].Distance < q[min1].Distance)
                {
                    buff = min1;
                    min1 = i;
                    if (q[buff].Distance < q[min2].Distance)
                        min2 = buff;
                }
                else
                {
                    if (q[i].Distance < q[min2].Distance) min2 = i;
                }
            }

            Console.WriteLine($"Точки которые находятся ближе всего к началу координат в {quarter} четверти: '{q[min1].TextOut}','{q[min2].TextOut}'");

        }


        static void Read_file(Point[] vec, int N)
        {
            using (StreamReader sr = new StreamReader("Input.txt", System.Text.Encoding.Default))
            {
                string line;
                for (int i = 0; i < N; i++)
                {
                    line = sr.ReadLine();

                    string[] subs = line.Split(' ');

                    vec[i].x = Convert.ToInt32(subs[0]);
                    vec[i].y = Convert.ToInt32(subs[1]);

                }
            }
        }


        static void Main(string[] args)
        {
            Console.Write("Введите количство считываемых строк: ");

            int N = Convert.ToInt32(Console.ReadLine());

            Point[] vec = new Point[N];

            Read_file(vec, N);

            Console.WriteLine($"Четверть с максимальным количеством точек: {Max_quarter(vec, N)}");

            Search_min(vec, N, 1);
            Search_min(vec, N, 2);
            Search_min(vec, N, 3);
            Search_min(vec, N, 4);

        }
    }
}
