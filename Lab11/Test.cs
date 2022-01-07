using System;
using System.Collections.Generic;
using System.Text;

namespace Lab11
{
    public class Test: Trial
    {
        protected int mark;

        public Trial BaseTrial
        {
            get
            {
                return new Trial(name, result);//возвращает объект базового класса
            }
        }


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

        public override bool Passed()
        {
            var passed = mark >= 3;
            if (passed)
            {
                Console.WriteLine($"Тест сдан, оценка: {mark}");
            }
            else Console.WriteLine($"Тест не сдан, оценка: {mark}");
            return passed;
        }

        public override object Clone()
        {
            Test other = new Test(this.name, this.result, this.mark);
            other.IdInfo = new IdInfo(0);
            return other;
        }
    }
}
