using System;
using System.Collections.Generic;

namespace Lab10
{
    class Program
    {
        //Запросы:
        //Количество студентов, сдавших экзамены на отлично.
        //Количество студентов, не сдавших экзамен
        //Имена студентов, сдавших все(заданный) экзамены на отлично(хорошо и отлично).

        static void ChooseSubject(List<Trial> trialList) //Меню выбора предмета для запроса
        {
            string subject;
            int num;
            bool ok, exit = false;
            Exam exelectStud = new Exam();
            do
            {
                Console.WriteLine();
                Console.WriteLine("/Выберите предмет/");
                Console.WriteLine("1) Математика \n" +
                    "2) Литература \n" +
                    "3) Физика.\n" +
                    "4) Выход");
                do // Проверка на верный ввод действий
                {
                    Console.Write("->");
                    ok = int.TryParse(Console.ReadLine(), out num);
                    Console.WriteLine(num);
                    if (num < 1 || num > 4) ok = false;
                    if (!ok) Console.WriteLine("Выбран неверный предмет");
                } while (!ok);
                switch (num)
                {
                    case 1:
                        subject = "Математика";
                        Console.WriteLine($"Студенты сдавшие экзамен по {subject} на хорошую оценку:");
                        foreach (var elem in trialList)
                        {
                            exelectStud = elem as Exam;
                            if (exelectStud != null)
                            {
                                exelectStud.PassedExamOnGoodMark(subject);
                                
                            }
                        }
                        break;
                    case 2:
                        Console.WriteLine("Запрос 2:");
                        subject = "Литература";
                        Console.WriteLine($"Студенты сдавшие экзамен по {subject} на хорошую оценку:");
                        foreach (var elem in trialList)
                        {
                            exelectStud = elem as Exam;
                            if (exelectStud != null)
                            {
                                exelectStud.PassedExamOnGoodMark(subject);

                            }
                        }
                        break;
                    case 3:
                        Console.WriteLine("Запрос 3:");
                        subject = "Физика";
                        Console.WriteLine($"Студенты сдавшие экзамен по {subject} на хорошую оценку:");
                        foreach (var elem in trialList)
                        {
                            exelectStud = elem as Exam;
                            if (exelectStud != null)
                            {
                                exelectStud.PassedExamOnGoodMark(subject);

                            }
                        }
                        break;
                    case 4:
                        exit = true;
                        break;
                }

            } while (!exit);
        }

        static void Menu(List<Trial> trialList) //Меню запросов
        {
            int num;
            bool ok, exit = false;
            do
            {
                Console.WriteLine();
                Console.WriteLine("/------------Запросы------------/");
                Console.WriteLine("1) Количество студентов сдавщих экзамен на отлично \n" +
                    "2) Количество студентов не сдавших экзамен \n" +
                    "3) Имена студентов, сдавших заданный экзамены на хорошо или отлично.\n" +
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
                        Console.WriteLine("Запрос 1:");
                        Console.WriteLine("Количество студентов сдавших экзамен на отлично: " + Exam.numOfPassedExelent);
                        break;
                    case 2:
                        Console.WriteLine("Запрос 2:");
                        Console.WriteLine("Количество студентов не сдавших экзамен: " + Exam.numOfNotPassed);
                        break;
                    case 3:
                        Console.WriteLine("Запрос 3:");
                        ChooseSubject(trialList);
                        break;
                    case 4:
                        exit = true;
                        break;
                }

            } while (!exit);
        }

        static void Main(string[] args)
        {
            List<Trial> trialList = new List<Trial>();
            trialList.Add(new Trial("Tomas Anderson", 101));
            trialList.Add(new Test("Hugo Viewer", 56, 2));
            trialList.Add(new Exam("Jack London", 88, 4, "Литература"));
            trialList.Add(new FinalExam("Archi Archer", 90, 5, "Математика", new DateTime(2021, 11, 9)));
            trialList.Add(new FinalExam("Tod Martyn", 91, 5, "Математика", new DateTime(2020, 10, 8)));
            trialList.Add(new FinalExam("Archi Archer", 90, 3, "Математика", new DateTime(2021, 11, 9)));
            trialList.Add(new FinalExam("Tod Martyn", 77, 2, "Математика", new DateTime(2020, 10, 8)));
            trialList.Add(new FinalExam("Jack Black", 30, 2, "Физика", new DateTime(2021, 11, 9)));
            trialList.Add(new FinalExam("Jack White", 69, 4, "Физика", new DateTime(2021, 11, 9)));
            foreach (var elem in trialList)
            {
                elem.Show();
                elem.Passed();
                Console.WriteLine("----------------------------");
            }

            Console.WriteLine();

            Exam exelectStud = new Exam();
            foreach (var elem in trialList)
            {
                exelectStud = elem as Exam;
                if (exelectStud != null)
                {
                    exelectStud.PassedOnExelent();
                    exelectStud.NotPassed();
                }
            }

            Menu(trialList); //Вызов меню запросов
        }
    }
}
