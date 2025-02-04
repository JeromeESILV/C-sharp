using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    internal class Laboror : Employee
    {
        private DateOnly joinedDay = new();

        public Laboror(DateOnly joinedDay)
        {
            this.joinedDay = joinedDay;
        }

        public Employee Employee { get { return employee; } }

        public DateOnly JoinedDay { get { return joinedDay; } set { joinedDay = value; } }

    }
}
