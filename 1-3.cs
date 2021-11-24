using System;

namespace LAB_1._3
{
    class Program
    {
        static void Main(string[] args)
        {
            float a1 = 100.0F, r1;
            float b1 = 0.001F;
            double a2 = 100.0, b2 = 0.001, r2;
            float c1, d1, e1, f1, g1, h1, i1, j1;
            double c2, d2, e2, f2, g2, h2, i2, j2;
            Console.WriteLine("Выражение ((a-b)^3-(a^3-3*(a^2)*b))/(3*a*(b^2)-b^3)");
            Console.WriteLine("Вычисления с float:");
            c1 = (float)(Math.Pow(a1 - b1, 3));
            Console.WriteLine("1) (a-b)^3 = {0}", c1);
            d1 = (float)(Math.Pow(a1, 3));
            Console.WriteLine("2) a^3 = {0}", d1);
            e1 = (float)(3 * Math.Pow(a1, 2) * b1);
            Console.WriteLine("3) 3*(a^2)*b = {0}", e1);
            f1 = (float)(3 * a1 * Math.Pow(b1, 2));
            Console.WriteLine("4) 3*a*(b^2) = {0}", f1);
            g1 = (float)Math.Pow(b1, 3);
            Console.WriteLine("5) b^3 = {0}", g1);
            h1 = (float)(d1 - e1);
            Console.WriteLine("6) a^3-3*(a^2)*b = {0}", h1);
            i1 = (float)(c1 - h1);
            Console.WriteLine("7) (a-b)^3-(a^3-3*(a^2)*b = {0}", i1);
            j1 = (float)(f1 - g1);
            Console.WriteLine("8) 3*a*(b^2)-b^3 = {0}", j1);
            r1 = (float)(i1 / j1);
            Console.WriteLine("9) ((a-b)^3-(a^3-3*(a^2)*b))/(3*a*(b^2)-b^3) = {0}", r1);

            Console.WriteLine("Вычисления с double:");
            c2 = (Math.Pow(a2 - b2, 3));
            Console.WriteLine("1) (a-b)^3 = {0}", c2);
            d2 = (Math.Pow(a2, 3));
            Console.WriteLine("2) a^3 = {0}", d2);
            e2 = (3 * Math.Pow(a2, 2) * b2);
            Console.WriteLine("3) 3*(a^2)*b = {0}", e2);
            f2 = (3 * a2 * Math.Pow(b2, 2));
            Console.WriteLine("4) 3*a*(b^2) = {0}", f2);
            g2 = Math.Pow(b2, 3);
            Console.WriteLine("5) b^3 = {0}", g2);
            h2 = d2 - e2;
            Console.WriteLine("6) a^3-3*(a^2)*b = {0}", h2);
            i2 = c2 - h2;
            Console.WriteLine("7) (a-b)^3-(a^3-3*(a^2)*b = {0}", i2);
            j2 = f2 - g2;
            Console.WriteLine("8) 3*a*(b^2)-b^3 = {0}", j2);
            r2 = i2 / j2;
            Console.WriteLine("9) ((a-b)^3-(a^3-3*(a^2)*b))/(3*a*(b^2)-b^3) = {0}", r2);
        }
    }
}
