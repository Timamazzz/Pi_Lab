using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_Lab_7_Poli
{
    class My_Rectangle
    {
        
        public int a { get; set; }

        public int b { get; set; }

        public My_Rectangle(int a, int b)
        {
            this.a = a; 
            this.b = b;
        }

        public My_Rectangle()
        {
            a = 0;
            b = 0;
        }

        public string Print()
        {
          return ($"a = {a}, b = {b}, P = {Perimeter()}");
        }

        public int Perimeter() => 2 * (a + b);
        

        public int Square() => a * b;
        

        public static My_Rectangle operator ++(My_Rectangle pr1)
        {

            pr1.a++;
            pr1.b++;

            return pr1;
        }

        public static My_Rectangle operator --(My_Rectangle pr1)
        {

            pr1.a--;
            pr1.b--;

            return pr1;
        }

        public static bool operator false(My_Rectangle pr1)
        {
            if (pr1.a != pr1.b)
                return false;
            else
                return true;
        }

        public static bool operator true(My_Rectangle pr1)
        {

            if (pr1.a != pr1.b)
                return false;
            else
                return true;
        }

       
    }
}
