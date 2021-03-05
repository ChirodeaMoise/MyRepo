using System;
using System.Text;

namespace numere_rationale
{
    //Chiroda Moise-Marius 
    class Rational
    {
        int a, b;

        public Rational(int nr = 0, int nm = 1)
        {
            //nr - numarator
            //nm - numitor
            a = nr; b = nm;
        }

        public static Rational operator +(Rational r1, Rational r2)
        {
            Rational r = new Rational();
            int c = cmmmc(r1.b, r2.b);
            r.b = c;
            r.a = r1.a * c / r1.b + r2.a * c / r2.b;
            return r;
        }
        public static Rational operator -(Rational r1, Rational r2)
        {
            Rational r = new Rational();
            int c = cmmmc(r1.b, r2.b);
            r.b = c;
            r.a = r1.a * c / r1.b - r2.a * c / r2.b;
            return r;
        }

        public static Rational operator *(Rational r1, Rational r2)
        {
            Rational r = new Rational();
            r.a = r1.a * r2.a;
            r.b = r1.b * r2.b;
            return r;
        }
        public static Rational operator /(Rational r1, Rational r2)
        {
            Rational r = new Rational();
            int x = r2.a;
            r2.a = r2.b;
            r2.b = x;
            r = r1 * r2;
            return r;
        }


        public void Ireductibil()
        {
            int x = cmmdc(a, b);
            a /= x; b /= x;
        }

        public static bool operator ==(Rational r1, Rational r2)
        {
            if (r1.a / r1.b == r2.a / r2.b) return true;
            return false;
        }
        public static bool operator !=(Rational r1, Rational r2)
        {
            if (r1 == r2) return false;
            return true;
        }

        public static bool operator <(Rational r1, Rational r2)
        {
            if (r1.a / r1.b < r2.a / r2.b) return true;
            return false;
        }
        public static bool operator >(Rational r1, Rational r2)
        {
            if (r1 < r2 || r1 == r2) return false;
            return true;
        }

        public static bool operator <=(Rational r1, Rational r2)
        {
            if (r1 < r2 || r1 == r2) return true;
            return false;
        }
        public static bool operator >=(Rational r1, Rational r2)
        {
            if (r1 > r2 || r1 == r2) return true;
            return false;
        }

        public static int cmmdc(int x, int y)
        {
            while (x != y)
            {
                if (x < y) y -= x;
                else x -= y;
            }
            return x;
        }
        public static int cmmmc(int x, int y)
        {
            return x * y / cmmdc(x, y);
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            s.AppendFormat("{0}/{1}", a, b);
            return s.ToString();
        }

    }


    class Program
    {
        static Random r = new Random();

        static void Main(string[] args)
        {
            //Optional sa poate marii intervalul in care sunt generate numerele.
            Rational r1 = new Rational(r.Next(10), r.Next(10));
            Rational r2 = new Rational(r.Next(10), r.Next(10));
            Console.WriteLine("#### Numere sunt generate aleator ####");
            Console.WriteLine("first number: {0}, second number: {1}", r1, r2);
            Console.WriteLine();
            Console.WriteLine("<Scaderea>  {0} - {1} = {2}", r1, r2, r1 - r2);
            Console.WriteLine("<Adunarea>   {0} + {1} = {2}", r1, r2, r1 + r2);
            Console.WriteLine("<Inmultirea> {0} * {1} = {2}", r1, r2, r1 * r2);
            Console.WriteLine("<Impartirea> {0} / {1} = {2}", r1, r2, r1 / r2);
            Rational R1 = r1; R1.Ireductibil();
            Rational R2 = r2; R2.Ireductibil();
            Console.WriteLine();
            Console.WriteLine("#### Comparatie ####");
            Console.WriteLine("{0} < {1}: {2}", r1, r2, r1 < r2);
            Console.WriteLine("{0} > {1}: {2}", r1, r2, r1 > r2);
            Console.WriteLine("{0} <= {1}: {2}", r1, r2, r1 <= r2);
            Console.WriteLine("{0} >= {1}: {2}", r1, r2, r1 >= r2);
            Console.WriteLine("{0} == {1}: {2}", r1, r2, r1 == r2);
            Console.WriteLine("{0} != {1}: {2}", r1, r2, r1 != r2);
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}