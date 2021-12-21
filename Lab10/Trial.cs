using System;
using System.Collections.Generic;
using System.Text;

namespace Lab10
{
    class Trial
    {
        protected string name;
        protected int result;

        public Trial(string _name, int _result)
        {
            this.name = _name;
            this.result = _result;
        }

        public Trial()
        {
            name = "";
            result = 0;
        }
        
        virtual public void Show()
        {
            Console.WriteLine($"ФИО: {name}\nРезультат: {result}");
        }
        virtual public void Passed()
        {

        }

    }
}
