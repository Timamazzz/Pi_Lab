using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pi_Lab_4B_Poli
{
    class Rectangle
    {
        public int a { get; set; }
        public int b { get; set; }

        public Rectangle(int a, int b)
        {
            this.a = a; 
            this.b = b;
        }

        public Rectangle()
        {
            a = 0;
            b = 0;
        }

        public string Print()
        {
          return ($"a = {a}, b = {b}");
        }

        public int Perimeter => 2 * (a + b);
        

        public int Square => a * b;
        

        public static Rectangle operator ++(Rectangle pr1)
        {

            pr1.a++;
            pr1.b++;

            return pr1;
        }

        public static Rectangle operator --(Rectangle pr1)
        {

            pr1.a--;
            pr1.b--;

            return pr1;
        }

        public static bool operator false(Rectangle pr1)
        {
            if (pr1.a != pr1.b)
                return false;
            else
                return true;
        }

        public static bool operator true(Rectangle pr1)
        {

            if (pr1.a != pr1.b)
                return false;
            else
                return true;
        }
    }
}
