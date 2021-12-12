using System;
using System.Collections.Generic;
using System.Text;

namespace Lab9
{
    class DiapasonArray
    {
        Diapason[] arr;
        Random rnd = new Random();
        int size;

        static public int countArr = 0;
        public Diapason this[int index]
        {
            get
            {
                return arr[index];
            }
            set
            {
                arr[index] = value;
            }
        }

        public bool ValidSize(int s)//проверка размера
        {
            if (s > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
            }
        }
        public DiapasonArray()
        {
            arr = new Diapason[0];
            countArr++;
        }
        public DiapasonArray(int n)
        {
            countArr++;
            Size = n;
            arr = new Diapason[n];
            for (int i = 0; i < n; i++)
            {
                /*arr[i].LeftBord = rnd.Next(1, 100);
                int c = rnd.Next(1, 100);
                if(c >= arr[i].LeftBord)
                {
                    arr[i].RightBord = c;
                }*/
                int a1 = rnd.Next(-255, 255);
                int a2 = rnd.Next(-255, 255);
                while (a2 < a1)
                {
                    a2 = rnd.Next(-255, 255);
                }
                arr[i] = new Diapason(a1, a2);
            }
        }
        public DiapasonArray(DiapasonArray d, int n)
        {
            d.arr = new Diapason[n];
            for(int i= 0; i < n; i++)
            {
                Console.WriteLine("Введите диапазон: ", d.arr[i].GetDiapason());
            }
        }



    }
}
