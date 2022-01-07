using System;
using System.Collections.Generic;
using System.Text;

namespace Lab11
{

    public class SortByName : IComparer<Trial>
    {

        public int Compare(Trial ob1, Trial ob2)
        {
            if (ob1.Name.Length > ob2.Name.Length) return 1;
            if (ob1.Name.Length < ob2.Name.Length) return -1;
            return 0;
        }

    }

}
