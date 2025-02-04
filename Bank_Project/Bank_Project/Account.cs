using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Project
{
    public class Account
    {
        protected static int count = 1;
        protected int accountNum;
        protected string fName;
        protected string lName;
        protected int idNumber;
        protected string address;
        protected DateOnly birthday = new();
        protected bool flag;

        public Account()
        {
        }

        public Account(string fn, string ln, int idnum, string add, DateOnly bd)
        {
            //System.Threading.Interlocked.Increment(ref count);
            this.accountNum = count++;
            fName = fn;
            lName = ln;
            idNumber = idnum;
            address = add;
            birthday = bd;
            flag = false;
        }

        public int AccountNum{
            get { return accountNum; }
            set { accountNum = value; }
        }
        public string FName{
            get{return fName;}
            set{fName = value;}
        }
        public string LName{
            get{return lName;}
            set{lName = value;}
        }
        public int IdNumber{
            get{return idNumber;}
            set{idNumber = value;}
        }
        public string Address{
            get{return address;}
            set{address = value;}
        }
        public DateOnly Birthday{
            get{return birthday;}
            set{birthday = value;}
        }
        public bool Flag{
            get{return flag;}
            set{flag = value;}
        }

        public string GetAccount(){
            string s = "--------------------------------\n";

            s += "Account Number :" + accountNum + "\nAccount belonging to :" + fName + " " + LName + "\nID Number :" + IdNumber + "\nAddress :" + address + "\nBirthday : " + birthday + "\nAccount blocked? :" + flag;

            s += "\n--------------------------------\n";
            Console.WriteLine(s);
            return s;
        }
       
        
    }
}
