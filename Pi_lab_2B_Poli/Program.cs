using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;

namespace Pi_lab_2B_Poli
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

            public string TextOut => $"{x};{y}";

        }

        static void Main(string[] args)
        {
            Console.Write("Введите количство считываемых строк: ");

            int N = Convert.ToInt32(Console.ReadLine());
            int i1 = 0, i2 = 0, i3 = 0, i4 = 0;
            Point? buff;

            Point?[] min1 = new Point?[4];
            Point?[] min2 = new Point?[4];

            using (StreamReader sr = new StreamReader("Input.txt", System.Text.Encoding.Default))
            {
                string line;
                for (int i = 0; i < N; i++)
                {
                    line = sr.ReadLine();

                    string[] subs = line.Split(' ');

                    Point point = new Point(Convert.ToInt32(subs[0]), Convert.ToInt32(subs[1]));

                    switch (point.Quarter)
                    {
                        case 1:
                            i1++;

                            if (!min1[0].HasValue)
                                min1[0] = point;
                            else
                            {
                                if (!min2[0].HasValue)
                                    min2[0] = point;
                                else
                                {
                                    if (point.Distance < min1[0].Value.Distance)
                                    {
                                        buff = min1[0];
                                        min1[0] = point;
                                        if (buff.Value.Distance < min2[0].Value.Distance)
                                            min2[0] = buff;
                                    }
                                    else
                                    {
                                        if (point.Distance < min2[0].Value.Distance) min2[0] = point;
                                    }
                                }
                            }
                            break;
                        case 2:
                            i2++;
                            if (!min1[1].HasValue)
                                min1[1] = point;
                            else
                            {
                                if (!min2[1].HasValue)
                                    min2[1] = point;
                                else
                                {
                                    if (point.Distance < min1[1].Value.Distance)
                                    {
                                        buff = min1[1];
                                        min1[1] = point;
                                        if (buff.Value.Distance < min2[1].Value.Distance)
                                            min2[0] = buff;
                                    }
                                    else
                                    {
                                        if (point.Distance < min2[1].Value.Distance) min2[1] = point;
                                    }
                                }
                            }
                            break;
                        case 3:
                            i3++;
                            if (!min1[2].HasValue)
                                min1[2] = point;
                            else
                            {
                                if (!min2[2].HasValue)
                                    min2[2] = point;
                                else
                                {
                                    if (point.Distance < min1[2].Value.Distance)
                                    {
                                        buff = min1[2];
                                        min1[2] = point;
                                        if (buff.Value.Distance < min2[2].Value.Distance)
                                            min2[2] = buff;
                                    }
                                    else
                                    {
                                        if (point.Distance < min2[2].Value.Distance) min2[2] = point;
                                    }
                                }
                            }
                            break;
                        case 4:
                            i4++;
                            if (!min1[3].HasValue)
                                min1[3] = point;
                            else
                            {
                                if (!min2[3].HasValue)
                                    min2[3] = point;
                                else
                                {
                                    if (point.Distance < min1[3].Value.Distance)
                                    {
                                        buff = min1[3];
                                        min1[3] = point;
                                        if (buff.Value.Distance < min2[3].Value.Distance)
                                            min2[3] = buff;
                                    }
                                    else
                                    {
                                        if (point.Distance < min2[3].Value.Distance) min2[3] = point;
                                    }
                                }
                            }
                            break;
                    }
                }
            }

            if (i1 >= i2 && i1 >= i3 && i1 >= i4) Console.WriteLine($"Четверть с максимальным количеством точек: 1");

            if (i2 >= i1 && i2 >= i3 && i2 >= i4) Console.WriteLine($"Четверть с максимальным количеством точек: 2");

            if (i3 >= i1 && i3 >= i2 && i3 >= i4) Console.WriteLine($"Четверть с максимальным количеством точек: 3");

            if (i4 >= i1 && i4 >= i2 && i4 >= i3) Console.WriteLine($"Четверть с максимальным количеством точек: 4");

            if(min1[0].HasValue && min2[0].HasValue)
                Console.WriteLine($"Точки которые находятся ближе всего к началу координат в 1 четверти: '{min1[0].Value.TextOut}','{min2[0].Value.TextOut}'");
            if (min1[1].HasValue && min2[1].HasValue)
                Console.WriteLine($"Точки которые находятся ближе всего к началу координат в 1 четверти: '{min1[1].Value.TextOut}','{min2[1].Value.TextOut}'");
            if (min1[2].HasValue && min2[2].HasValue)
                Console.WriteLine($"Точки которые находятся ближе всего к началу координат в 1 четверти: '{min1[2].Value.TextOut}','{min2[2].Value.TextOut}'");
            if (min1[3].HasValue && min2[3].HasValue)
                Console.WriteLine($"Точки которые находятся ближе всего к началу координат в 1 четверти: '{min1[3].Value.TextOut}','{min2[3].Value.TextOut}'");


        }
    }
}
