using System;
using System.Diagnostics;

namespace Lab11
{
    class Program
    {
        static int EntSize()
        {
            int size;
            bool ok;
            do
            {
                ok = int.TryParse(Console.ReadLine(), out size);
                if (!ok)
                {
                    Console.Write("Введён неверный тип данных! Повторите ввод:");
                }
                if (size <= 0)
                {
                    ok = false;
                    Console.Write("Размер меньше или равен нулю, повторите ввод:");
                }
            } while (!ok);
            return size;
        }
        
        static void Main(string[] args)
        {
            TestCollections testing = new TestCollections();
            int size;
            int num;
            bool ok, exit = false;
            do
            {
                Console.WriteLine("/------------Меню------------/");
                Console.WriteLine("1) Добавить \n" +
                    "2) Удалить \n" +
                    "3) Время поиска элементов \n" +
                    "4) Выход");
                do // Проверка на верный ввод действий
                {
                    Console.Write("->");
                    ok = int.TryParse(Console.ReadLine(), out num);
                    Console.WriteLine(num);
                    if (num < 1 || num > 4) ok = false;
                    if (!ok) Console.WriteLine("Выбрано неверное действие");
                } while (!ok);
                switch (num)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Введите кол-во элементов для добавления:");
                        size = EntSize();
                        testing.AddToCollection(size);
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Введите кол-во элементов для удаления:");
                        size = EntSize();
                        testing.DeleteFromCollection(size);
                        break;
                    case 3:
                        Console.Clear();
                        testing.TimeCalculating();
                        break;
                    case 4:
                        exit = true;
                        break;

                }
            } while (!exit);
        }
    }
}
