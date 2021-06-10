using System;

namespace PI_Lab_11_Poli
{
    class Program
    {
       
        /// <summary>
        /// Этот класс создаёт прямоугольник 
        /// </summary>
        /// <remarks>
        /// <para>В классе создаются поля - стороны</para>
        /// </remarks>
        class Rectangle
        {
            /// <summary>
            /// Стороны
            /// </summary>
            public int a { get; set; }
            public int b { get; set; }

            /// <summary>
            /// Конструктор прямоугольника
            /// </summary>
            /// <param name="a">Сторона а</param>
            /// <param name="b">Сторона b</param>
            public Rectangle(int a, int b)
            {
                this.a = a;
                this.b = b;
            }

            /// <summary>
            /// Пустой конструктор прямоугольника
            /// </summary>
            public Rectangle()
            {
                a = 0;
                b = 0;
            }

            ///<summary>
            ///Метод выводасторон прямоугольника в строку
            ///</summary>
            public string Print()
            {
                return ($"a = {a}, b = {b}");
            }

            ///<summary>
            ///Метод нахождения периметра
            ///</summary>
            ///<example>
            ///<code>
            /// a = 1; b= 1;
            /// Perimetr return 4;
            ///</code>
            ///</example>
            public int Perimeter => 2 * (a + b);

            //<summary>
            ///Метод нахождения площади
            /// <с>Square</с>
            /// <see cref= "Square"/>
            public int Square => a * b;

            /// <summary>
            /// Метод увеличение всех сторон на 1
            /// </summary>
            public static Rectangle operator ++(Rectangle pr1)
            {

                pr1.a++;
                pr1.b++;

                return pr1;
            }

            /// <summary>
            /// Метод уменьшения всех сторон на 1
            /// </summary>
            public static Rectangle operator --(Rectangle pr1)
            {

                pr1.a--;
                pr1.b--;

                return pr1;
            }

            /// <summary>
            /// Метод, позволяющий определить квадрат
            /// </summary>
            public static bool operator false(Rectangle pr1)
            {
                if (pr1.a != pr1.b)
                    return false;
                else
                    return true;
            }

            /// <summary>
            /// Метод, позволяющий определить квадрат
            /// </summary>
            public static bool operator true(Rectangle pr1)
            {

                if (pr1.a != pr1.b)
                    return false;
                else
                    return true;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
