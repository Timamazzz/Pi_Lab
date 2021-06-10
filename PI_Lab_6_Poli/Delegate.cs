using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_Lab_5
{
    public delegate double Operation(double x);

    class Delegate
    {
        public double X;
        public double E;

        public Delegate( double X, double E)
        {
            this.X = X;
            this.E = E;
        }

        public double f1(double x) => (x - 1) * Math.Log(x + 2) - 1;

        public double f2(double x) => 2 * Math.Pow(x,3)- Math.Pow(x, 2) - 2*x + 3;

        public double df1(double x) => (x - 1) / (x + 2) + Math.Log(x + 2);

        public double df2(double x) => 6* Math.Pow(x, 2) - 2*x -2;

        public double method_N(Func<double, double> EX, Func<double, double> DF, double a, double b)
        {
            double X = b;
            double en = Math.Abs(a - b);

            Operation f = new Operation(EX);
            Operation df = new Operation(DF);

            while (en > E)
            {

                X = X - (f(X) / df(X));
                en = Math.Abs(X - b);
                b = X;

            }
                

            return X;
        }

        

        public double half_division_method(Func<double, double> EX, double a, double b)
        { 
           
            double midl_of_x = 0;
            double F_a = 0;
            double F_x = 0;

            Operation op1 = new Operation(EX);

            while (b - a > E)
            {
                F_a = op1(a);

                midl_of_x = (a + b) / 2;

                F_x = op1(midl_of_x);


                if (F_x * F_a > 0)
                {
                    a = midl_of_x;
                    F_a = F_x;
                }
                else
                {
                    b = midl_of_x;
                }
            }

            return midl_of_x;

        }

    }
    }
