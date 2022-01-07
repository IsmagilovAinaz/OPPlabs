using System;
using System.Collections.Generic;
using System.Text;

namespace Lab11
{
    public class Exam : Test
    {
        protected string subject;
        public static int numOfPassedExelent = 0;
        public static int numOfNotPassed = 0;

        public string Subject
        {
            get => subject;
            set => subject = value;
        }

        public Exam(string _name, int _result, int _mark, string _subject) : base(_name, _result, _mark)
        {
            subject = _subject;
        }

        public Exam() : base()
        {
            subject = "";
        }

        public override void Show()
        {
            Console.WriteLine($"ФИО:{name} \nОценка за экзамен по предмету {subject}: {mark}");
        }

        public override bool Passed()
        {
            var passed = mark >= 3;
            if (passed)
            {
                Console.WriteLine($"Экзамен по предмету {subject} сдан, оценка: {mark}");
            }
            else Console.WriteLine($"Экзамен по предмету {subject} не сдан, оценка: {mark}");
            return passed;
        }

        public bool PassedOnExelent() //Число сдавших на отлично
        {
            var passedExelent = mark == 5;
            if (passedExelent) numOfPassedExelent++;
            return passedExelent;

        }

        public bool NotPassed() //Число не сдавших
        {
            var passedExelent = mark == 2;
            if (passedExelent) numOfNotPassed++;
            return passedExelent;

        }

        public bool PassedExamOnGoodMark(string _subject)
        {
            bool passed = subject == _subject && (mark == 4 || mark == 5);
            if (passed)
            {
                Console.WriteLine($"{name} оценка за предмет {_subject}: {mark}");
            }
            return passed;
        }


    }
}
