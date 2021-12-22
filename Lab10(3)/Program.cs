using System;

namespace Lab10_3_
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = 9;
            IExecutable[] trialList = new IExecutable[size];
            trialList[0] = new Trial("Tomas Anderson", 101);
            trialList[1] = new Test("Hugo Viewer", 56, 2);
            trialList[2] = new Exam("Jack London", 88, 4, "Литература");
            trialList[3] = new FinalExam("Archi Archer", 90, 5, "Математика", new DateTime(2021, 11, 9));
            trialList[4] = new FinalExam("Hu Martyn", 91, 5, "Математика", new DateTime(2020, 10, 8));
            trialList[5] = new FinalExam("Archi Archer", 90, 3, "Математика", new DateTime(2021, 11, 9));
            trialList[6] = new FinalExam("Tod Martynes", 77, 2, "Математика", new DateTime(2020, 10, 8));
            trialList[7] = new FinalExam("Jack Black", 30, 2, "Физика", new DateTime(2021, 11, 9));
            trialList[8] = new FinalExam("Jack White", 69, 4, "Физика", new DateTime(2021, 11, 9));
            foreach (var elem in trialList)
            {
                elem.Show();
                elem.Passed();
                Console.WriteLine("----------------------------");
            }

            Array.Sort(trialList); //Сортировка IComparable
            Trial stud = new Trial();
            Console.WriteLine("Отсортированный массив по результату:");
            Console.WriteLine("----------------------------");
            foreach (var elem in trialList)
            {
                stud = elem as Trial;
                Console.WriteLine($"ФИО: {stud.Name}, Результат: {stud.Result}");
            }

            Trial[] trialArr = new Trial[size];
            for(int i = 0; i < size; i++)
            {
                trialArr[i] = (Trial)trialList[i];
            }

            Console.WriteLine("----------------------------");
            Array.Sort(trialArr, new SortByName()); //Сортировка IComparable
            Console.WriteLine("\nОтсортированный массив по именам:");
            Console.WriteLine("----------------------------");
            foreach (var elem in trialArr)
            {
                stud = elem as Trial;
                Console.WriteLine($"ФИО: {stud.Name}, Результат: {stud.Result}");
            }
            Console.WriteLine("----------------------------");

            Console.WriteLine("\nКлонирование:");
            Console.WriteLine("Поверхностное:");
            Trial tr1 = new Trial("Tomas", 87);
            Trial tr1_copy = tr1;
            tr1_copy.Name = "Changed Tomas";
            tr1.Show();
            Console.WriteLine("Глубокое:");
            Trial tr2 = new Trial("Jack", 77);
            Trial tr2_clone = (Trial)tr2.Clone();
            tr2_clone.Name = "Jack Clone";
            tr2.Show();
            tr2_clone.Show();
        }
    }
}
