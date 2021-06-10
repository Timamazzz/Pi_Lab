using System;
using System.IO;

namespace PI_Lab_2_A
{
    class Program
    {
        struct Member
        {
            public string name;
            public string surname;

            public int Running;
            public int Jump;
            public int Shooting;
            public int Swimming;

            public Member(string _name, string _surname, int _Running, int _Jump, int _Shooting, int _Swimming) : this()
            {
                this.name = _name;
                this.surname = _surname;
                this.Running = _Running;
                this.Jump = _Jump;
                this.Shooting = _Shooting;
                this.Swimming = _Swimming;

            }



            public void DisplayInfo()
            {
                Console.WriteLine($"Name: {name}  Surname: {surname} Points: {Running}, {Jump}, {Shooting}, {Swimming}");
            }
        }

        static void Read_file(Member[] vec, int N)
        {
            using (StreamReader sr = new StreamReader("Competition.txt", System.Text.Encoding.Default))
            {
                string line;
                for (int i = 0; i < N; i++)
                {
                    line = sr.ReadLine();

                    string[] subs = line.Split(' ');

                    vec[i].name = subs[0];
                    vec[i].surname = subs[1];
                    vec[i].Running = Convert.ToInt32(subs[2]);
                    vec[i].Jump = Convert.ToInt32(subs[3]);
                    vec[i].Shooting = Convert.ToInt32(subs[4]);
                    vec[i].Swimming = Convert.ToInt32(subs[5]);


                    //Console.WriteLine(line);
                }
            }
        }

        static void Print_arr(Member[] vec, int N)
        {
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine($"Участник: Name: {vec[i].name}  Surname: {vec[i].surname} Points: {vec[i].Running}, {vec[i].Jump}, {vec[i].Shooting}, {vec[i].Swimming}");
            }
        }

        static void Decision(Member[] vec, int N, ref int gold, ref int silver, ref int bronze, ref int g, ref int s, ref int b)
        {
            int Sum = 0;
            for (int i = 0; i < N; i++)
            {


                Sum += vec[i].Running + vec[i].Jump + vec[i].Shooting + vec[i].Swimming;

                if (Sum > gold)
                {
                    gold = Sum;
                    g = i;
                }

                if (Sum > silver && Sum < gold)
                {
                    silver = Sum;
                    s = i;
                }

                if (Sum > bronze && Sum < silver && Sum < gold)
                {
                    bronze = Sum;
                    b = i;
                }

                Sum = 0;


            }
        }
        static void Main(string[] args)
        {
            Console.Write("Введите количство считываемых строк: ");

            int N = Convert.ToInt32(Console.ReadLine());

            Member[] vec = new Member[N];

            int gold = 0, silver = 0, bronze = 0, g = 0, s = 0, b = 0;

            Read_file(vec, N);

            Print_arr(vec, N);

            Decision(vec, N, ref gold, ref silver, ref bronze, ref g, ref s, ref b);

            Console.WriteLine($"1 место : Name: {vec[g].name}  Surname: {vec[g].surname} Points: {vec[g].Running}, {vec[g].Jump}, {vec[g].Shooting}, {vec[g].Swimming}, Сумма баллов {gold}");
            Console.WriteLine($"2 место : Name: {vec[s].name}  Surname: {vec[s].surname} Points: {vec[s].Running}, {vec[s].Jump}, {vec[s].Shooting}, {vec[s].Swimming} Сумма баллов {silver}");
            Console.WriteLine($"3 место : Name: {vec[b].name}  Surname: {vec[b].surname} Points: {vec[b].Running}, {vec[b].Jump}, {vec[b].Shooting}, {vec[b].Swimming} Сумма баллов {bronze}");



        }
    }

}
