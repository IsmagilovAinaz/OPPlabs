using System;

namespace Lab5
{
    class Program
    {
        static int[][] DeleteRowsInJagArray(int[][] jagArray)
        {
            if (jagArray != null && jagArray.Length != 0)
            {
                int k, n;
                bool ok;
                Console.WriteLine("/------------Удаление строк из рваного массива------------/");
                Console.WriteLine("Всего строк в массиве: {0}", jagArray.Length);
                Console.WriteLine("Введите позицию с которой начать удаление строк: ");
                do
                {
                    ok = int.TryParse(Console.ReadLine(), out n);
                    if (n <= 0 || n > jagArray.Length)
                        ok = false;
                    if (!ok) Console.WriteLine("Введите корректную позицию");
                } while (!ok);
                Console.WriteLine("Введите количество строк для удаления: ");
                do
                {
                    ok = int.TryParse(Console.ReadLine(), out k);
                    if (k < 0)
                    {
                        Console.WriteLine("Кол-во строк не может быть меньше 0!");
                        ok = false;
                    }
                    else if (k > jagArray.Length - n + 1)
                    {
                        ok = false;
                        Console.WriteLine("Кол-во строк для удаления превышает кол-во строк с позиции N\n" +
                            "Доступное кол-во строк для удаления = {0}", jagArray.Length - n + 1);
                    }
                    if (!ok) Console.WriteLine("Введите корректную позицию");
                } while (!ok);
                int[][] jagArray2 = new int[jagArray.Length - k][];
                int ind = 0;
                for(int i = 0; i < jagArray.Length; i++)
                {
                    if (i < n - 1 || i > n + k - 2)
                    {
                        jagArray2[ind] = new int[jagArray[i].Length];
                        for (int j = 0; j < jagArray[i].Length; j++)
                        {
                            jagArray2[ind][j] = jagArray[i][j];
                        }
                        ind++;
                    }
                    else continue;
                }
                Console.WriteLine("Строки удалены!");
                return jagArray2;
            }
            else Console.WriteLine("Массив пустой, операция не возможна!");
            return jagArray;
        }
        static void PrintJagArray(int[][] jagArray)
        {
            if (jagArray == null)
                Console.WriteLine("Массив не создан!");
            else if (jagArray.Length == 0)
                Console.WriteLine("Массив пуст!");
            else
                Console.WriteLine("Элементы массива:");
            for (int i = 0; i < jagArray.Length; i++)
            {
                for (int j = 0; j < jagArray[i].Length; j++)
                {
                    Console.Write(jagArray[i][j] + "\t");
                }
                Console.WriteLine();
            }
        }
        static int[][] CreateJagArray()
        {
            int num;
            int rows, colums;
            bool ok;
            Console.WriteLine("/------------Создание рваного массива------------/");
            Console.Write("Введите кол-во строк массива: ");
            do
            {
                ok = int.TryParse(Console.ReadLine(), out rows);
                if (rows <= 0) ok = false;
                if (!ok) Console.WriteLine("Введите корректное кол-во строк массива");
            } while (!ok);
            int[][] jagArray = new int[rows][];
            for(int i = 0; i < rows; i++)
            {
                Console.Write("Введите кол-во столбцов в строке {0}: ", i + 1);
                do
                {
                    ok = int.TryParse(Console.ReadLine(), out colums);
                    if (colums <= 0) ok = false;
                    if (!ok) Console.WriteLine("Введите корректное кол-во столбцов");
                } while (!ok);
                jagArray[i] = new int[colums];
            }
            Console.Clear();
            Console.WriteLine("/------------Создание рваного массива------------/");
            Console.WriteLine("1) Создать массив вручную\n" +
                    "2) Создать с помощью ДСЧ\n" +
                    "3) Назад");
            do // Проверка на верный ввод действий
            {
                ok = int.TryParse(Console.ReadLine(), out num);
                Console.WriteLine(num);
                if (num < 1 || num > 3) ok = false;
                if (!ok) Console.WriteLine("Выбрано неверное действие");
            } while (!ok);
            switch (num)
            {
                case 1:
                    Console.WriteLine("Вводите элементы массива:");
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < jagArray[i].Length; j++)
                        {
                            Console.Write("[{0}][{1}]) ", i + 1, j + 1);
                            do
                            {
                                ok = int.TryParse(Console.ReadLine(), out jagArray[i][j]);
                                if (!ok) Console.WriteLine("Введите целое число!");
                            } while (!ok);
                        }
                    }
                    Console.Clear();
                    Console.WriteLine("Массив создан!");
                    break;
                case 2:
                    Random rnd = new Random();
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < jagArray[i].Length; j++)
                        {
                            jagArray[i][j] = rnd.Next(500);
                        }
                    }
                    Console.Clear();
                    Console.WriteLine("Массив создан!");
                    break;
                case 3:
                    Console.Clear();
                    break;
            }
            return jagArray;
        }
        static void WorkWithJagArray()
        {
            int[][] jagArray = new int[0][];
            int num;
            bool ok, exit = false;
            do
            {
                Console.WriteLine("/------------Работа с рваными массивами------------/");
                Console.WriteLine("1) Создать массив \n" +
                    "2) Напечатать массив \n" +
                    "3) Удалить K строк начиная с номера N \n" +
                    "4) Назад");
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
                        jagArray = CreateJagArray();
                        break;
                    case 2:
                        Console.Clear();
                        PrintJagArray(jagArray);
                        break;
                    case 3:
                        Console.Clear();
                        jagArray = DeleteRowsInJagArray(jagArray);
                        break;
                    case 4:
                        exit = true;
                        Console.Clear();
                        break;

                }
            } while (!exit);

        }
        static int[,] AddRowInBegining(int [,] TwoDimArray)
        {
            if (TwoDimArray != null && TwoDimArray.Length != 0)
            {
                bool ok;
                int rows = TwoDimArray.GetLength(0) + 1;
                int colums = TwoDimArray.GetLength(1);
                int[,] array = new int[rows, colums];
                int num;
                Console.WriteLine("/------------Добавление строки в начало массива------------/");
                Console.WriteLine("1) Ввести элементы вручную\n" +
                    "2) Задать случайные значения\n" +
                    "3) Назад");
                do // Проверка на верный ввод действий
                {
                    ok = int.TryParse(Console.ReadLine(), out num);
                    Console.WriteLine(num);
                    if (num < 1 || num > 3) ok = false;
                    if (!ok) Console.WriteLine("Выбрано неверное действие");
                } while (!ok);
                switch (num)
                {
                    case 1:
                        Console.WriteLine("Введите элементы новой строки");
                        for (int i = 0; i < rows; i++)
                        {
                            for (int j = 0; j < colums; j++)
                            {
                                if (i == 0)
                                {
                                    Console.Write("[{0}][{1}]: ", i + 1, j + 1);
                                    ok = int.TryParse(Console.ReadLine(), out array[i, j]);
                                    if (!ok) Console.WriteLine("Введите целое число!");
                                    Console.WriteLine();
                                }
                                else array[i, j] = TwoDimArray[i - 1, j];
                            }
                        }
                        Console.Clear();
                        Console.WriteLine("Строка добавлена!");
                        return array;
                    case 2:
                        Random rnd = new Random();
                        Console.Clear();
                        for (int i = 0; i < rows; i++)
                        {
                            for (int j = 0; j < colums; j++)
                            {
                                if (i == 0)
                                {
                                    array[i, j] = rnd.Next(500);
                                    Console.Write("[{0}][{1}]: ", i + 1, j + 1);
                                    Console.Write(array[i, j]);
                                    Console.WriteLine();
                                }
                                else array[i, j] = TwoDimArray[i - 1, j];
                            }
                        }
                        Console.WriteLine("Строка добавлена!");
                        return array;
                    case 3:
                        Console.Clear();
                        break;
                }
            }
            else Console.WriteLine("Массив пустой, операция не возможна!");
            return TwoDimArray;
        }
        static void PrintTwoDimArray(int[,] TwoDimArray)//Вывести двумерный массив
        {
            if (TwoDimArray == null)
                Console.WriteLine("Массив не создан!");
            else if (TwoDimArray.Length == 0)
                Console.WriteLine("Массив пуст!");
            else
                Console.WriteLine("Элементы массива:");
                for(int i = 0; i < TwoDimArray.GetLength(0); i++){
                    for(int j = 0; j < TwoDimArray.GetLength(1); j++){
                        Console.Write(TwoDimArray[i, j] + "\t");
                    }
                    Console.WriteLine();
                }
        }
        static int[,] CreateTwoDimArray()//Создать двумерный массив
        {
            int num;
            int rows, colums;
            bool ok;
            Console.Write("Введите кол-во строк массива: ");
            do
            {
                ok = int.TryParse(Console.ReadLine(), out rows);
                if (rows <= 0) ok = false;
                if (!ok) Console.WriteLine("Введите корректное кол-во строк массива");
            } while (!ok);
            Console.Write("Введите кол-во столбцов массива: ");
            do
            {
                ok = int.TryParse(Console.ReadLine(), out colums);
                if (colums <= 0) ok = false;
                if (!ok) Console.WriteLine("Введите корректный размер массива");
            } while (!ok);
            int[,] TwoDimArray = new int[rows, colums];
            Console.WriteLine("/------------Создание двумерного массива------------/");
            Console.WriteLine("1) Создать массив вручную\n" +
                    "2) Создать с помощью ДСЧ\n" +
                    "3) Назад");
            do // Проверка на верный ввод действий
            {
                ok = int.TryParse(Console.ReadLine(), out num);
                Console.WriteLine(num);
                if (num < 1 || num > 3) ok = false;
                if (!ok) Console.WriteLine("Выбрано неверное действие");
            } while (!ok);
            switch (num)
            {
                case 1:
                    Console.WriteLine("Вводите элементы массива:");
                    for (int i = 0; i < rows; i++)
                    {
                        for(int j = 0; j < colums; j++)
                        {
                            Console.Write("[{0}][{1}]) ", i + 1, j+1);
                            do
                            {
                                ok = int.TryParse(Console.ReadLine(), out TwoDimArray[i, j]);
                                if (!ok) Console.WriteLine("Введите целое число!");
                            } while (!ok);
                        }
                    }
                    Console.Clear();
                    Console.WriteLine("Массив создан!");
                    break;
                case 2:
                    Random rnd = new Random();
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < colums; j++)
                        {
                            TwoDimArray[i, j] = rnd.Next(500);
                        }
                    }
                    Console.Clear();
                    Console.WriteLine("Массив создан!");
                    break;
                case 3:
                    Console.Clear();
                    break;
            }
            return TwoDimArray;
        }
        static void WorkWithTwoDimArray() //Работа с двумерным массивом
        {
            int[,] TwoDimArray = new int[0, 0];
            int num;
            bool ok, exit = false;
            do
            {
                Console.WriteLine("/------------Работа с двумерными массивами------------/");
                Console.WriteLine("1) Создать массив \n" +
                    "2) Напечатать массив \n" +
                    "3) Добавить строку в начало матрицы \n" +
                    "4) Назад");
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
                        TwoDimArray = CreateTwoDimArray();
                        break;
                    case 2:
                        Console.Clear();
                        PrintTwoDimArray(TwoDimArray);
                        break;
                    case 3:
                        Console.Clear();
                        TwoDimArray = AddRowInBegining(TwoDimArray);
                        break;
                    case 4:
                        exit = true;
                        Console.Clear();
                        break;

                }
            } while (!exit);

        }
        static int[] DeleteElemInArray(int [] OneDimArray)
        {
           
            bool ok;
            int num;
            if (OneDimArray != null && OneDimArray.Length != 0)
            {
                int[] array = new int[OneDimArray.Length - 1];
                do
                {
                    Console.Write("Введите номер элемента для удаления: ");
                    ok = int.TryParse(Console.ReadLine(), out num);
                    Console.WriteLine(num);
                    if (num <= 0 || num > OneDimArray.Length) ok = false;
                    if (!ok) Console.WriteLine("Введен неверный номер, введите заново: ");
                } while (!ok);
                int counter = 0;
                for(int i = 0; i < OneDimArray.Length; i++)
                {
                    if (i == num - 1) continue;
                    array[counter] = OneDimArray[i];
                    counter++;
                }
                OneDimArray = new int[OneDimArray.Length - 1];
                array.CopyTo(OneDimArray, 0);
                Console.WriteLine("Элемент удалён!");
            } else Console.WriteLine("Массив пустой, операция не возможна!");
            return OneDimArray;
        }
        static void PrintOneDimArray(int[] OneDimArray)//Вывести одномерный массив
        {
            if (OneDimArray == null)
                Console.WriteLine("Массив не создан!");
            else if (OneDimArray.Length == 0)
                Console.WriteLine("Массив пуст!");
            else
                Console.WriteLine("Элементы массива:");
                foreach (int a in OneDimArray) {
                    Console.Write(a + " ");
                }
                Console.WriteLine();
        }
        static int [] CreateOneDimArray()//Создать одномерный массив
        {
            int num;
            int size;
            //int element;
            bool ok;
            Console.WriteLine("/------------Создание одномерного массива------------/");
            Console.Write("Введите размер массива: ");
            do
            {
                ok = int.TryParse(Console.ReadLine(), out size);
                if(size <= 0) ok = false;
                if (!ok) Console.WriteLine("Введите корректный размер массива");
            } while (!ok);
            int [] OneDimArray = new int[size];
            Console.WriteLine("1) Создать массив вручную\n" +
                    "2) Создать с помощью ДСЧ\n" +
                    "3) Назад");
                do // Проверка на верный ввод действий
                {
                    ok = int.TryParse(Console.ReadLine(), out num);
                    Console.WriteLine(num);
                    if (num < 1 || num > 3) ok = false;
                    if (!ok) Console.WriteLine("Выбрано неверное действие");
                } while (!ok);
                switch (num)
                {
                    case 1:
                        Console.WriteLine("Вводите элементы массива:");
                        for(int i = 0; i < size; i++)
                        {
                            Console.Write("{0}) ", i+1);
                            do
                            {
                                ok = int.TryParse(Console.ReadLine(), out OneDimArray[i]);
                                if (!ok) Console.WriteLine("Введите целое число!");
                            } while (!ok);
                        }
                        Console.Clear();
                        Console.WriteLine("Массив создан!");
                        break;
                    case 2:
                        Random rnd = new Random();
                        for(int i = 0; i < size; i++)
                        {
                            OneDimArray[i] = rnd.Next(500);
                        }
                        Console.Clear();
                        Console.WriteLine("Массив создан!");
                        break;
                    case 3:
                        Console.Clear();
                        break;
                }
            return OneDimArray;
        }

        static void WorkWithOneDimArray() //Работа с одномерным массивом
        {
            int[] OneDimArray = new int[0];
            int num;
            bool ok, exit = false;
            do
            {
                Console.WriteLine("/------------Работа с одномерными массивами------------/");
                Console.WriteLine("1) Создать массив \n" +
                    "2) Напечатать массив \n" +
                    "3) Удалить элемент с заданным номером \n" +
                    "4) Назад");
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
                        OneDimArray = CreateOneDimArray();
                        break;
                    case 2:
                        Console.Clear();
                        PrintOneDimArray(OneDimArray);
                        break;
                    case 3:
                        Console.Clear();
                        OneDimArray = DeleteElemInArray(OneDimArray);
                        break;
                    case 4:
                        exit = true;
                        Console.Clear();
                        break;

                }
            } while (!exit);

        }
        static void Main(string[] args)
        {
            int num;
            bool ok, exit = false ;
            do
            {
                Console.WriteLine("/------------Меню------------/");
                Console.WriteLine("1) Работа с одномерными массивами \n" +
                    "2) Работа с двумерными массивами \n" +
                    "3) Работа с рваными массивами\n" +
                    "4) Выход");
                do // Проверка на верный ввод действий
                {
                    Console.Write("->");
                    ok = int.TryParse(Console.ReadLine(), out num);
                    Console.WriteLine(num);
                    if(num < 1 || num > 4) ok = false;
                    if (!ok) Console.WriteLine("Выбрано неверное действие");
                } while (!ok);
                switch (num)
                {
                    case 1:
                        Console.Clear();
                        WorkWithOneDimArray();
                        break;
                    case 2:
                        Console.Clear();
                        WorkWithTwoDimArray();
                        break;
                    case 3:
                        Console.Clear();
                        WorkWithJagArray();
                        break;
                    case 4:
                        exit = true;
                        break;

                }
            } while (!exit);

        }
    }
}

