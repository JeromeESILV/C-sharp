using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    internal class Pay : Employee
    {
        private int index;

        public Pay(int ind, int identity, string n, DateOnly bd) : base(identity, n, bd)
        {
            id = identity;
            name = n;
            birthday = bd;

            this.index = ind;

        }

        public int Index
        {
            get { return index; }
            set { index = value; }
        }
    }
}
