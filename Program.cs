using System;

namespace Lab9
{
    class Program
    {
        static double EntValue()
        {
            double a;
            bool ok;
            do
            {
                ok = Double.TryParse(Console.ReadLine(), out a);
                if (!ok)
                {
                    Console.Write("Введён неверный тип данных! Пвоторите ввод:");
                }
            } while (!ok);
            return a;
        }
        static double InDiapason(double x, double y)
        {
            double n;
            Console.Write("Введите число:");
            n = EntValue();
            if (n >= x && n <= y)
            {
                Console.WriteLine("Число принадлежит диапазону [{0}, {1}]", x, y);
            }
            else
            {
                Console.WriteLine("Число не принадлежит диапазону [{0}, {1}]", x, y);
            }
            return n;

        }
        static void Main(string[] args)
        {/*
            Diapason d = new Diapason();
            Console.WriteLine("Левая граница: " + d.LeftBord);
            Console.WriteLine("Правая граница: " + d.RightBord);
            d.Print();
            d++;
            d.Print();
            Console.WriteLine();

            Diapason d1 = new Diapason(5, 10);
            Console.WriteLine("Левая граница: " + d1.LeftBord);
            Console.WriteLine("Правая граница: " + d1.RightBord);
            d1.Print();
            Console.WriteLine("Длина диапазона: " + !d1);
            int c = 4;
            Console.WriteLine("Предлежность числа {0} диапазону: {1} ",c, c < d1);
            Console.WriteLine();

            Diapason d2 = new Diapason();
            d2.GetDiapason();
            d2.Print();
            double n = InDiapason(d2.LeftBord, d2.RightBord);//Использование статич функции
            n = d2.InDiapason();//Использование метода класса
            int a = (int)d2;
            Console.WriteLine("Целая часть координаты x: " + a);
            double b = d2;
            Console.WriteLine("Координата y: " + b);
            Console.WriteLine("\nКоличество созданных объектов: " + Diapason.count);
            d2 += 5;
            Console.WriteLine("Увеличение координат диапазона на int d");
            d2.Print();
            d2 = 5 + d2;
            Console.WriteLine("Увеличение координат диапазона на int d");
            d2.Print();*/
            DiapasonArray d = new DiapasonArray();
            Diapason d1 = new Diapason(5, 10);
            d[0] = d1;
            d[1] = d1;
            d[2] = d1;
            d[3] = d1;
            d[4] = d1;
            for (int i = 0; i < 5; i++)
            {
                d[i].Print();
            }


        }

    }
}
