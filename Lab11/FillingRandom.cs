using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Lab11
{
    class FillingRandom
    {
        static Random rnd = new Random();
        public string RandomizeString()
        {
            string str = "qwertyuiopasdfghjklzxcvbnm";
            int rndStr_lenght = rnd.Next(3, 20);
            string rnd_str = "";
            for(int i = 0; i < rndStr_lenght; i++)
            {
                rnd_str += str[rnd.Next(0, 26)];
            }
            return rnd_str;
        }

        public Test TestRandomizer()
        {
            Test test = new Test();
            test.Name = RandomizeString();
            test.Result = rnd.Next(0, 150);
            test.Mark = rnd.Next(0, 5);
            return test;
        }
    }
}
