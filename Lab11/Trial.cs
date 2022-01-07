using System;
using System.Collections.Generic;
using System.Text;

namespace Lab11
{
    public class Trial : IExecutable, IComparable, ICloneable
    {
        protected string name;
        protected int result;
        public IdInfo IdInfo;


        public string Name
        {
            get => name;
            set => name = value;
        }

        public int Result
        {
            get => result;
            set
            {
                if (value >= 0)
                {
                    result = value;
                }
                else
                {
                    result = 0;
                }
            }
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
        virtual public bool Passed()
        {
            return false;
        }

        public Trial ShallowCopy() //поверхностное копирование
        {
            return (Trial)this.MemberwiseClone();
        }

        public virtual object Clone()
        {
            Trial other = new Trial(this.name, this.result);
            other.IdInfo = new IdInfo(0);
            return other; 
        }

        public override bool Equals(object obj)
        {
            Trial temp = (Trial)obj;
            return this.Name == temp.Name &&
                   this.Result == temp.Result;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

    }
    public class IdInfo
    {
        public int IdNumber;

        public IdInfo(int IdNumber)
        {
            this.IdNumber = IdNumber;
        }
    }
}
