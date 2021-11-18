using System;

namespace Lab6
{
    class Program
    {
        static string ReplaceFirstLast(string str)
        {
            if (str.Length == 0 || str == null)
            {
                Console.WriteLine("Строка пустая!");
            }
            else
            {
                Console.WriteLine("/------------Перестановка места первого слова и последнего------------/");
                try
                {
                    string[] subStr = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (subStr.GetLength(0) > 1)
                    {
                        int firstInd = 0;
                        int lastInd = subStr.GetLength(0) - 1;
                        string firstWord = subStr[firstInd];
                        string lastWord = subStr[lastInd];
                        foreach (var s in subStr)
                        {
                            if (firstWord == "," || firstWord == ";" || firstWord == ":" || firstWord == "!" || firstWord == "." || firstWord == "?")
                            {
                                firstInd++;
                                firstWord = subStr[firstInd];
                            }
                            if (lastWord == "," || lastWord == ";" || lastWord == ":" || lastWord == "!" || lastWord == "." || lastWord == "?")
                            {
                                lastInd--;
                                lastWord = subStr[lastInd];
                            }
                        }
                        char last_char1 = ' ';
                        char last_char2 = ' ';
                        last_char1 = lastWord[lastWord.Length - 1];
                        last_char2 = firstWord[firstWord.Length - 1];
                        if (last_char1 == '!' || last_char1 == '?' || last_char1 == '.' || last_char1 == ',' || last_char1 == ';' || last_char1 == ':')
                        {
                            lastWord = lastWord.TrimEnd(last_char1);
                            if (last_char2 == '!' || last_char2 == '?' || last_char2 == '.' || last_char2 == ',' || last_char2 == ';' || last_char2 == ':')
                            {
                                firstWord = firstWord.TrimEnd(last_char2);
                                Console.WriteLine("Первое слово: " + firstWord);
                                Console.WriteLine("Последнее слово: " + lastWord);
                                firstWord += last_char1; //Добавление последнего символа к первому слову
                                lastWord += last_char2; //Добавление последнего символа к второму слову
                            }
                            else
                            {
                                Console.WriteLine("Первое слово: " + firstWord);
                                Console.WriteLine("Последнее слово: " + lastWord);
                                firstWord += last_char1;
                            }
                        }
                        else if (last_char2 == '!' || last_char2 == '?' || last_char2 == '.' || last_char2 == ',' || last_char2 == ';' || last_char2 == ':')
                        {
                            firstWord = firstWord.TrimEnd(last_char2);
                            Console.WriteLine("Первое слово: " + firstWord);
                            Console.WriteLine("Последнее слово: " + lastWord);
                            lastWord += last_char2;
                        }
                        subStr[firstInd] = lastWord;
                        subStr[lastInd] = firstWord;
                        str = String.Join(' ', subStr);
                        Console.WriteLine("Строка после перестановки: " + str);
                        return str;
                    }

                }
                catch
                {
                    Console.WriteLine("Возникло исключение!");
                }
            }
            return str;
        }
        static void PrintString(string str)
        {
            if(str.Length == 0 || str == null)
            {
                Console.WriteLine("Строка пустая!");
            }
            else
            {
                Console.WriteLine("/------------Вывод строки------------/");
                Console.WriteLine(str);
            }
        }
        static string WriteString()
        {
            string str;
            Console.WriteLine("/------------Ввод строки------------/");
            try
            {
                Console.Write("Введите текст: ");
                str = Console.ReadLine();
                string newStr = "";
                foreach (var s in str)
                {
                    //;: /!?
                    if (s==',' || s==';' || s ==':' || s=='!' || s=='.' || s=='?')
                        //Добавление пробела после знаков препинания
                    {
                        newStr = newStr + s + ' ';
                    }
                    else
                    {
                        newStr += s;
                    }
                }
                string[] subStr = newStr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                newStr = String.Join(' ', subStr);

                return newStr;
            }
            catch
            {
                Console.WriteLine("Возникло исключение при вводе строки! Введите строку заново");
                return WriteString();
            }
        }
        static void WorkWithString()
        {
            string str = "";
            int num;
            bool ok, exit = false;
            do
            {
                Console.WriteLine("/------------Работа со строками------------/");
                Console.WriteLine("1) Ввести строку \n" +
                    "2) Напечатать строку \n" +
                    "3) Поменять местами первое слово и последнее  \n" +
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
                        str = WriteString();
                        break;
                    case 2:
                        Console.Clear();
                        PrintString(str);
                        break;
                    case 3:
                        Console.Clear();
                        str = ReplaceFirstLast(str);
                        break;
                    case 4:
                        exit = true;
                        Console.Clear();
                        break;

                }
            } while (!exit);

        }
        static int[ , ] DeleteColumn(int [ , ] twoDimArray)
        {
            if (twoDimArray != null && twoDimArray.Length != 0)
            {
                int min = twoDimArray[0, 0];
                int columnNum = 0;
                //Нахождение минимального элемента
                for (int i = 0; i < twoDimArray.GetLength(0); i++)
                {
                    for (int j = 0; j < twoDimArray.GetLength(1); j++)
                    {
                        if (twoDimArray[i, j] < min)
                        {
                            min = twoDimArray[i, j];
                        }
                    }
                }
                int[,] newArr = new int[twoDimArray.GetLength(0), twoDimArray.GetLength(1) - 1];
                //Нахождение номера столбца с первым вхождение минимального элемента
                for (int i = 0; i < twoDimArray.GetLength(0); i++)
                {
                    for (int j = 0; j < twoDimArray.GetLength(1); j++)
                    {
                        if (twoDimArray[i, j] == min)
                        {
                            columnNum = j;
                        }
                    }
                }
                Console.WriteLine("Минимальный элемент = {0}, номер столбца = {1}", min, columnNum + 1);
                int k = 0;
                for (int i = 0; i < twoDimArray.GetLength(0); i++)
                {
                    for (int j = 0; j < twoDimArray.GetLength(1); j++)
                    {
                        if (j != columnNum)
                        {
                            newArr[i, k] = twoDimArray[i, j];
                            k++;
                        }
                    }
                    k = 0;
                }
                Console.WriteLine("Столбец {0} удален", columnNum + 1);
                return newArr;
            }
            else Console.WriteLine("Массив пустой, операция не возможна!");
            return twoDimArray;
        }
        static void PrintTwoDimArray(int[,] TwoDimArray)//Вывести двумерный массив
        {
            if (TwoDimArray == null)
                Console.WriteLine("Массив не создан!");
            else if (TwoDimArray.Length == 0)
                Console.WriteLine("Массив пуст!");
            else
                Console.WriteLine("Элементы массива:");
            for (int i = 0; i < TwoDimArray.GetLength(0); i++)
            {
                for (int j = 0; j < TwoDimArray.GetLength(1); j++)
                {
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
                        for (int j = 0; j < colums; j++)
                        {
                            Console.Write("[{0}][{1}]) ", i + 1, j + 1);
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
                    "3) Удалить первый столбец с минимальным элементом  \n" +
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
                        TwoDimArray = DeleteColumn(TwoDimArray);
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
            bool ok, exit = false;
            do
            {
                Console.WriteLine("/------------Меню------------/");
                Console.WriteLine("1) Работа с двумерными массивами \n" +
                    "2) Работа со строками\n" +
                    "3) Выход");
                do // Проверка на верный ввод действий
                {
                    Console.Write("->");
                    ok = int.TryParse(Console.ReadLine(), out num);
                    Console.WriteLine(num);
                    if (num < 1 || num > 3) ok = false;
                    if (!ok) Console.WriteLine("Выбрано неверное действие");
                } while (!ok);
                switch (num)
                {
                    case 1:
                        Console.Clear();
                        WorkWithTwoDimArray();
                        break;
                    case 2:
                        Console.Clear();
                        WorkWithString();
                        break;
                    case 3:
                        exit = true;
                        break;

                }
            } while (!exit);

        }
    }
}
