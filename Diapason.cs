using System;
using System.Collections.Generic;
using System.Text;

namespace Lab9
{
    class Diapason
    {
        private double x, y; //диапазон
        static public int count = 0; //счетчик 

        public double LeftBord//левая граница
        {
            get => x;
            set => x = value;
        }

        public double RightBord//правая граница
        {
            get => y;
            set
            {
                if (Init(x, value))
                {
                    y = value;
                }
            }
        }
        public Diapason(){//конструктор без параметров
            count++;
            x = 0;
            y = 0;
        }

        public Diapason(double x, double y) //конструктор с параметрами
        {
            count++;
            this.x = x;
            this.y = y;
        }

        ~Diapason()//деструктор
        {
            count--;
        }

        public bool Init(double x, double y)//Проверка на верность диапазона
        {
            if (x <= y)
            {
                this.x = x;
                this.y = y;
                return true;
            }
            Console.WriteLine("Правая граница меньше левой! Введите диапазон заново:");
            return false;
        }

        double EntValue()
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
        public Diapason GetDiapason()
        {
            do
            {
                Console.Write("Введите левую границу:");
                this.x = EntValue();
                Console.Write("Введите правую границу:");
                this.y = EntValue(); 
            }
            while (!Init(x, y));
            return this;
        }

        public void Print()
        {
            Console.WriteLine("Диапазон [{0}, {1}]", this.x, this.y);
        }

        public double InDiapason()
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

        public static double operator !(Diapason d) //Получение длины диапазона
        {
            double lenght = 0;
            lenght = Math.Abs(d.RightBord) - Math.Abs(d.LeftBord) + 1;//+1 т.к правая граница включительно
            return lenght;
        }

        public static Diapason operator ++(Diapason d) //Увеличение координат на +1
        {

            d.x += 1;
            d.y += 1;
            return d;
        }

        public static explicit operator int(Diapason d) //explicit явное преобразование
        {
            return (int)d.x;
        }

        public static implicit operator double(Diapason d) //implicit неявное преобразование
        {
            return d.y;
        }

        public static Diapason operator +(Diapason D, int d)
        {
            D.x += d;
            D.y += d;
            return D;
        }
        public static Diapason operator +(int d, Diapason D)
        {
            D.x += d;
            D.y += d;
            return D;
        }

        public static bool operator <(int a, Diapason d)
        {
            if (a >= d.x && a <= d.y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator >(int a, Diapason d)
        {
            if (a < d.x && a > d.y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

   

}
