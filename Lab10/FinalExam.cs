using System;
using System.Collections.Generic;
using System.Text;

namespace Lab10
{
    class FinalExam : Exam
    {
        DateTime examDate;
        public FinalExam(string _name, int _result, int _mark, string _subject, DateTime _examDate) : base(_name, _result, _mark, _subject)
        {
            examDate = _examDate;
        }

        public FinalExam() : base ()
        {
            examDate = new DateTime();
        }

        public override void Show()
        {
            Console.WriteLine($"ФИО:{name} \nОценка за итоговый экзамен по предмету {subject}: {mark}\nДата сдачи: {examDate.ToString("d")}");
        }

        public override void Passed()
        {
            var passed = mark >= 3;
            if (passed)
            {
                Console.WriteLine($"Экзамен по предмету {subject} сдан, оценка: {mark}");
            }
            else Console.WriteLine($"Экзамен по предмету {subject} не сдан, оценка: {mark}");
        }

    }
}
