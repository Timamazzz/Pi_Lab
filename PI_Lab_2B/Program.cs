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

        
     
        static void Main(string[] args)
        {
            Console.Write("Введите количство считываемых строк: ");

            int N = Convert.ToInt32(Console.ReadLine());

            Member[] vec = new Member[3];

            int gold = 0, silver = 0, bronze = 0;
            int Sum = 0;

            using (StreamReader sr = new StreamReader("Competition.txt", System.Text.Encoding.Default))
            {
                string line;
                for (int i = 0; i < N; i++)
                {
                    line = sr.ReadLine();
                    Console.WriteLine(line);

                    string[] subs = line.Split(' ');


                    Sum += Convert.ToInt32(subs[2]) + Convert.ToInt32(subs[3]) + Convert.ToInt32(subs[4]) + Convert.ToInt32(subs[5]);

                    if (Sum > gold)
                    {
                        gold = Sum;
                        vec[0].name = subs[0];
                        vec[0].surname = subs[1];
                        vec[0].Running = Convert.ToInt32(subs[2]);
                        vec[0].Jump = Convert.ToInt32(subs[3]);
                        vec[0].Shooting = Convert.ToInt32(subs[4]);
                        vec[0].Swimming = Convert.ToInt32(subs[5]);
                    }

                    if (Sum > silver && Sum < gold)
                    {
                        silver = Sum;
                        vec[1].name = subs[0];
                        vec[1].surname = subs[1];
                        vec[1].Running = Convert.ToInt32(subs[2]);
                        vec[1].Jump = Convert.ToInt32(subs[3]);
                        vec[1].Shooting = Convert.ToInt32(subs[4]);
                        vec[1].Swimming = Convert.ToInt32(subs[5]);

                    }

                    if (Sum > bronze && Sum < silver && Sum < gold)
                    {
                        bronze = Sum;
                        vec[2].name = subs[0];
                        vec[2].surname = subs[1];
                        vec[2].Running = Convert.ToInt32(subs[2]);
                        vec[2].Jump = Convert.ToInt32(subs[3]);
                        vec[2].Shooting = Convert.ToInt32(subs[4]);
                        vec[2].Swimming = Convert.ToInt32(subs[5]);
                    }

                    Sum = 0;

                   
                }
            }

            
            Console.WriteLine($"1 место : Name: {vec[0].name}  Surname: {vec[0].surname} Points: {vec[0].Running}, {vec[0].Jump}, {vec[0].Shooting}, {vec[0].Swimming}, Сумма баллов {gold}");
            Console.WriteLine($"2 место : Name: {vec[1].name}  Surname: {vec[1].surname} Points: {vec[1].Running}, {vec[1].Jump}, {vec[1].Shooting}, {vec[1].Swimming}, Сумма баллов {silver}");
            Console.WriteLine($"3 место : Name: {vec[2].name}  Surname: {vec[2].surname} Points: {vec[2].Running}, {vec[2].Jump}, {vec[2].Shooting}, {vec[2].Swimming}, Сумма баллов {bronze}");




        }
    }

}
