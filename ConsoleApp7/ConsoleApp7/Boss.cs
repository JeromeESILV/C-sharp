using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    internal class Boss : Employee
    {
        private int turnover;
        private decimal percent;

        public Boss(int turnover, decimal percent)
        {
            this.turnover = turnover;
            this.percent = percent;
        }
        public int Turnover { get { return turnover; } set { turnover = value; } }
        public decimal Percent { get { return percent; } set { percent = value; } }
    }
}
