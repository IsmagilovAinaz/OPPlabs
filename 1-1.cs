using System;

namespace LAB_1
{
    class Program
    {
        static int EnterInt()
        {
            int a;
            bool ok;
            do
            {
                ok = int.TryParse(Console.ReadLine(), out a);
                if (!ok)
                {
                    Console.WriteLine("Ошибка! Введите снова");
                }
            } while (!ok);
            return a;

        }
        static void Main(string[] args)
        {
            int n, m;
            int r1;
            bool r2, r3;
            int x;
            Console.WriteLine("Введите значения n и m: ");
            Console.Write("n?: ");
            n = EnterInt();
            Console.Write("m?: ");
            m = EnterInt();
            //1
            Console.WriteLine("1) n = {0}, m = {1}", n, m);
            r1 = --m - n++;
            Console.WriteLine("--m-n++ = {0}, n = {1}, m = {2}", r1, n, m);
            //2
            r2 = m * m < n++;
            Console.WriteLine("2) m*m<n++ = {0}, n = {1}, m = {2}", r2, n, m);
            //3
            r3 = n-- > ++m;
            Console.WriteLine("3) n-->++m = {0}, n = {1}, m = {2}", r3, n, m);
            //4
            bool ok = true;
            Console.WriteLine("tg(x)-(5-x)^4");
            Console.Write("x?: ");
            do
            {
                x = EnterInt();
                if (x == 90 || x == 270)
                {
                    Console.WriteLine("Тангенс данного числа не существует, введите другое число");
                    ok = false;
                }
                else ok = true; //! Не считывался ввод, исправлено
            } while (!ok);
            double r4 = Math.Tan((x * Math.PI) / 180) - Math.Pow((5 - x), 4);
            Console.WriteLine("x = {0}, tg(x)-(5-x)^4 = {1}", x, r4);
        }
    }
}
