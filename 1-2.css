using System;

namespace LAB_1._2
{
    class Program
    {
        static double EnterDouble()
        {
            double a;
            bool ok;
            do
            {
                ok = double.TryParse(Console.ReadLine(), out a);
                if (!ok)
                {
                    Console.WriteLine("Ошибка! Введите снова");
                }
            } while (!ok);
            return a;

        }
        static void Main(string[] args)
        {
            double x, y;
            bool r;
            Console.WriteLine("Заданная функция x = sqrt(1-y^2) \n Введите значения x и y:");
            Console.Write("x?: ");
            x = EnterDouble();
            Console.Write("y?: ");
            y = EnterDouble();
            r = Math.Pow(x, 2) + Math.Pow(y, 2) <= 1 && x >= 0 && y >= -1 && y<=1;
            Console.WriteLine(r);
        }
    }
}
