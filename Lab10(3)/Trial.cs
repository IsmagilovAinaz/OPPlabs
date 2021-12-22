using System;
using System.Collections.Generic;
using System.Text;

namespace Lab10_3_
{
    public class Trial : IExecutable, IComparable, ICloneable
    {
        protected string name;
        protected int result;

        public string Name
        {
            get => name;
            set => name = value;
        }

        public int Result
        {
            get => result;
            set => result =  value;
        }

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

        public int CompareTo(object obj)
        {
            Trial temp = (Trial)obj;
            if (this.result > temp.result) return 1;
            if (this.result < temp.result) return -1;
            return 0;
        }

        
        virtual public void Show()
        {
            Console.WriteLine($"ФИО: {name}\nРезультат: {result}");
        }
        virtual public void Passed()
        {

        }

        public Trial ShallowCopy() //поверхностное копирование
        {
            return (Trial)this.MemberwiseClone();
        }

        public object Clone()
        {
            return new Trial("Клон" + this.name, this.result); 
        }

    }
}
