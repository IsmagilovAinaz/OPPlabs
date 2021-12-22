using System;
using System.Collections.Generic;
using System.Text;

namespace Lab10_3_
{
    class Test: Trial
    {
        protected int mark;

        public int Mark
        {
            get => mark;
            set
            {
                if ((value >= 0) && (value <= 5)) mark = value;
                else mark = 0;
            }
        }

        public Test(string _name, int _result, int _mark) : base(_name, _result)
        {
            mark = _mark;
        }

        public Test() : base()
        {
            mark = 0;
        }

        public override void Show()
        {
            Console.WriteLine($"ФИО:{name} \nОценка за тест: {mark}");
        }

        public override void Passed()
        {
            var passed = mark >= 3;
            if (passed)
            {
                Console.WriteLine($"Тест сдан, оценка: {mark}");
            }
            else Console.WriteLine($"Тест не сдан, оценка: {mark}");
        }
    }
}
