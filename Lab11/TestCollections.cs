using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Lab11
{
    public class TestCollections
    {
        public Stack<Trial> stackTrial;
        public Stack<string> stackString;
        public Dictionary<Trial, Test> dictionaryTr;
        public Dictionary<string, Test> dictionaryStr;
        public Stack<Test> stackTest;
        int sizeOfCollection = 0;

        public int Size
        {
            get => sizeOfCollection;
        }

        public TestCollections()
        {
            stackTrial = new Stack<Trial>();
            stackString = new Stack<String>();
            dictionaryTr = new Dictionary<Trial, Test>();
            dictionaryStr = new Dictionary<string, Test>();
            stackTest = new Stack<Test>();
        }

        public TestCollections(int size)
        {
            stackTrial = new Stack<Trial>(size);
            stackString = new Stack<String>(size);
            dictionaryTr = new Dictionary<Trial, Test>(size);
            dictionaryStr = new Dictionary<string, Test>(size);
            stackTest = new Stack<Test>(size);
            sizeOfCollection += size;

        }

        public void AddToCollection(int number)
        {
            if (number + sizeOfCollection <= 1000)
            {
                sizeOfCollection += number;
                for (int i = 0; i < number; i++)
                {
                    FillingRandom random = new FillingRandom();
                    Test test = (Test)random.TestRandomizer();
                    Trial trial = test.BaseTrial;
                    if (!dictionaryTr.ContainsKey(trial) && !dictionaryStr.ContainsKey(trial.Name)) //Проверка для того чтобы у каждого был уникальный ключ
                    {
                        stackTest.Push(test);
                        stackTrial.Push(trial);
                        stackString.Push(trial.Name);
                        dictionaryTr.Add(trial, test);
                        dictionaryStr.Add(trial.Name, test);
                    }
                }
            }
            else
            {
                Console.WriteLine("Введите значение <= 1000");
            }
        }

        public void DeleteFromCollection(int number)
        {
            if(number > sizeOfCollection)
            {
                Console.WriteLine("Удаление не возможно! Количество возможных удаляемых элементов:" + sizeOfCollection);
            }
            else
            {
                var new_stackTrial = new Stack<Trial>();
                var new_stackString = new Stack<String>();
                var new_dictionaryTr = new Dictionary<Trial, Test>();
                var new_dictionaryStr = new Dictionary<string, Test>();
                var stackTrial_array = stackTrial.ToArray();
                var stackString_array = stackString.ToArray();
                var deleteKeys_array = new Trial[number];
                var deleteStringKeys_array = new String[number];
                for(int i = 0; i < sizeOfCollection; i++)
                {
                    if(i > number-1)
                    {
                        new_stackTrial.Push(stackTrial_array[i]);
                        new_stackString.Push(stackString_array[i]);
                    }
                    else
                    {
                        stackTrial_array[i].Show();
                        deleteKeys_array[i] = stackTrial_array[i];
                        Console.WriteLine(stackString_array[i]);
                        deleteStringKeys_array[i] = stackString_array[i];
                    }
                }
                stackString.Clear();
                stackTrial.Clear();
                stackTrial = new Stack<Trial>(new_stackTrial);
                stackString = new Stack<String>(new_stackString);
                for (int i = 0; i < number; i++)
                {
                    dictionaryStr.Remove(deleteStringKeys_array[i]);
                    dictionaryTr.Remove(deleteKeys_array[i]);
                }
                sizeOfCollection -= number;
            }
        }

        public void TimeCalculating()
        {
            if (sizeOfCollection > 0)
            {
                bool isFound = false;
                var stackTrial_array = stackTrial.ToArray();
                var stackTest_array = stackTest.ToArray();
                var stackString_array = stackString.ToArray();
                Test firt_elemKey = (Test)dictionaryTr.First().Value.Clone();
                String fist_elemString = stackString_array[0];
                //Trial middle_elemKey = stackTest_array[sizeOfCollection / 2].BaseTrial;//

                Test middle_elemKey = null;
                int middleIndex = dictionaryTr.Count / 2;
                int index = 0;
                foreach (var item in dictionaryTr)
                {
                    if (index == middleIndex)
                    {
                        middle_elemKey = (Test)item.Value.Clone();
                        break;
                    }
                    index++;
                }


                String middle_elemString = stackString_array[sizeOfCollection / 2];
                Test last_elemKey = (Test)dictionaryTr.Last().Value.Clone();
                String last_elemString = stackString_array[sizeOfCollection - 1];
                Test nonExistElem = new Test("0", 0, 1);
                Trial nonExistElem_key = nonExistElem.BaseTrial;
                String nonExistElem_string = nonExistElem.Name;

                Stopwatch time = new Stopwatch();
                Console.WriteLine("\t\t\t-----------Работа с Stack<Trial>-----------:");
                time.Start();
                isFound = stackTrial.Contains(firt_elemKey.BaseTrial);
                time.Stop();
                if (isFound)
                {
                    Console.WriteLine("Первый Элемент найден за " + time.ElapsedTicks);
                }
                else Console.WriteLine("Элемент не найден");
                time = new Stopwatch();
                time.Start();
                isFound = stackTrial.Contains(middle_elemKey.BaseTrial);
                time.Stop();
                if (isFound)
                {
                    Console.WriteLine("Средний Элемент найден за " + time.ElapsedTicks);
                }
                else Console.WriteLine("Элемент не найден");
                time = new Stopwatch();
                time.Start();
                isFound = stackTrial.Contains(last_elemKey.BaseTrial);
                time.Stop();
                if (isFound)
                {
                    Console.WriteLine("Последний Элемент найден за " + time.ElapsedTicks);
                }
                else Console.WriteLine("Элемент не найден");
                time.Restart();
                isFound = stackTrial.Contains(nonExistElem_key);
                time.Stop();
                Console.WriteLine("Несуществующий элемент найден за " + time.ElapsedTicks);

                Console.WriteLine("\t\t\t-----------Работа с Stack<String>-----------:");
                time = new Stopwatch();
                time.Start();
                isFound = stackString.Contains(fist_elemString);
                time.Stop();
                if (isFound)
                {
                    Console.WriteLine("Первый Элемент найден за " + time.ElapsedTicks);
                }
                else Console.WriteLine("Элемент не найден");
                time = new Stopwatch();
                time.Start();
                isFound = stackString.Contains(middle_elemString);
                time.Stop();
                if (isFound)
                {
                    Console.WriteLine("Средний Элемент найден за " + time.ElapsedTicks);
                }
                else Console.WriteLine("Элемент не найден");
                time = new Stopwatch();
                time.Start();
                isFound = stackString.Contains(last_elemString);
                time.Stop();
                if (isFound)
                {
                    Console.WriteLine("Последний Элемент найден за " + time.ElapsedTicks);
                }
                else Console.WriteLine("Элемент не найден");
                time = new Stopwatch();
                time.Start();
                isFound = stackString.Contains(nonExistElem_string);
                time.Stop();
                Console.WriteLine("Несуществующий элемент найден за " + time.ElapsedTicks);

                Console.WriteLine("\t\t\t-----------Dictionary<Trial, Test>-----------:");
                time = new Stopwatch();
                time.Start();
                isFound = dictionaryTr.ContainsValue(firt_elemKey);
                time.Stop();
                if (isFound)
                {
                    Console.WriteLine("Первый Элемент найден за " + time.ElapsedTicks);
                }
                else Console.WriteLine("Элемент не найден");
                time = new Stopwatch();
                time.Start();
                isFound = dictionaryTr.ContainsValue(middle_elemKey);
                time.Stop();
                if (isFound)
                {
                    Console.WriteLine("Средний Элемент найден за " + time.ElapsedTicks);
                }
                else Console.WriteLine("Элемент не найден");
                time = new Stopwatch();
                time.Start();
                isFound = dictionaryTr.ContainsValue(last_elemKey);
                time.Stop();
                if (isFound)
                {
                    Console.WriteLine("Последний Элемент найден за " + time.ElapsedTicks);
                }
                else Console.WriteLine("Элемент не найден");
                time = new Stopwatch();
                time.Start();
                isFound = dictionaryTr.ContainsKey(nonExistElem_key);
                time.Stop();
                Console.WriteLine("Несуществующий элемент найден за " + time.ElapsedTicks);


                Console.WriteLine("\t\t\t-----------Dictionary<String, Test>-----------:");
                time = new Stopwatch();
                time.Start();
                isFound = dictionaryStr.ContainsKey(fist_elemString);
                time.Stop();
                if (isFound)
                {
                    Console.WriteLine("Первый Элемент найден за " + time.ElapsedTicks);
                }
                else Console.WriteLine("Элемент не найден");
                time = new Stopwatch();
                time.Start();
                isFound = dictionaryStr.ContainsKey(middle_elemString);
                time.Stop();
                if (isFound)
                {
                    Console.WriteLine("Средний Элемент найден за " + time.ElapsedTicks);
                }
                else Console.WriteLine("Элемент не найден");
                time = new Stopwatch();
                time.Start();
                isFound = dictionaryStr.ContainsKey(last_elemString);
                time.Stop();
                if (isFound)
                {
                    Console.WriteLine("Последний Элемент найден за " + time.ElapsedTicks);
                }
                else Console.WriteLine("Элемент не найден");
                time = new Stopwatch();
                time.Start();
                isFound = dictionaryStr.ContainsKey(nonExistElem_string);
                time.Stop();
                Console.WriteLine("Несуществующий элемент найден за " + time.ElapsedTicks);
            }
        }

    }
}
