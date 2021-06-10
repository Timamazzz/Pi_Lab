using System;
using System.IO;
using System.Linq;

namespace PI_Lab_2A_Albert
{
    class Program
    {
        struct Blank
        {
            public string Party;

            public int Region;

            public Blank(string party, int region)
            {
                this.Party = party;
                this.Region = region;
            }

        }

        static void Read_file(Blank[] vec, int N)
        {
            using (StreamReader sr = new StreamReader("Input.txt", System.Text.Encoding.Default))
            {
                string line;
                for (int i = 0; i < N; i++)
                {
                    line = sr.ReadLine();

                    string[] subs = line.Split(' ');

                    vec[i].Party = subs[0];
                    vec[i].Region = Convert.ToInt32(subs[1]);
                }
            }
        }

        static void Print_arr(Blank[] vec, int N)
        {
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine($"Имя партии: {vec[i].Party},  Номер участка: {vec[i].Region}");
            }
        }

        static void Min_region(Blank[] vec)
        {
            int[] r_count = new int[10] {0,0,0,0,0,0,0,0,0,0};

            for (int i = 0; i < vec.Length; i++)
            {
                switch (vec[i].Region)
                {
                    case 1:
                        r_count[0]++;
                        break;
                    case 2:
                        r_count[1]++;
                        break;
                    case 3:
                        r_count[2]++;
                        break;
                    case 4:
                        r_count[3]++;
                        break;
                    case 5:
                        r_count[4]++;
                        break;
                    case 6:
                        r_count[5]++;
                        break;
                    case 7:
                        r_count[6]++;
                        break;
                    case 8:
                        r_count[7]++;
                        break;
                    case 9:
                        r_count[8]++;
                        break;
                    case 10:
                        r_count[9]++;
                        break;
                }
            }

            Console.WriteLine($"\nУчастки с самой низкой посещаемостью:\n");

            int idx0 = Array.IndexOf(r_count, r_count.Min());
            Console.WriteLine($"1-ый участок:{idx0+1}, Количество посещений {r_count[idx0]}");
            r_count[idx0] = int.MaxValue;
           

            int idx1 = Array.IndexOf(r_count, r_count.Min());
            Console.WriteLine($"2-ой участок:{idx1+1}, Количество посещений {r_count[idx1]}");
            r_count[idx1] = int.MaxValue;
            

            int idx2 = Array.IndexOf(r_count, r_count.Min());
            Console.WriteLine($"3-ий участок:{idx2+1}, Количество посещений {r_count[idx2]}");
            r_count[idx2] = int.MaxValue;
           
        }

        static void Main(string[] args)
        {
            Console.Write("Введите количство считываемых строк: ");

            int N = Convert.ToInt32(Console.ReadLine());

            Blank[] vec = new Blank[N];

            Read_file(vec, N);

            Print_arr(vec, N);

            Min_region(vec);
        }
    }
}
