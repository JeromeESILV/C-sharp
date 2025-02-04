using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp7.Pay;

namespace ConsoleApp7
{
    internal class Employee
    {

        protected int id;
        protected string name;
        protected DateOnly birthday = new();

        public Employee(int i, string n, DateOnly bd)
        {
            id = i;
            name = n;
            birthday = bd;
        }

        public int Id
        {
            get;
            set;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public DateOnly Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }

        public string Tostring()
        {
            string s;
            s = "------------------------------------------------------------\n";
            s += "Employee information :\n" + "ID number :" + id + "Fullname" + name + "Date of Birth :" + birthday ;
            s += "\n------------------------------------------------------------\n";

            return s;
        }

        public int GetSal()
        {
            int sal;

            switch (Pay.Index)
            {
                case 1:
                    salary = 3000;
                    break;
                case 2:
                    salary = 5000;
                    break;
                case 3:
                    salary = 7000;
                    break;
                case 4:
                    salary = 90000;
                    break;
            }
            return sal;
        }
    }
}