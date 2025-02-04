using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Project
{
    class Savings : Account
    {

        private float balance;
        private double interest;

        public Savings() { }

        public Savings(float balance, int accoutNum, string fName, string lName, int idNumber, string address, DateOnly birthday) : base(fName, lName, idNumber, address, birthday)
        {
            this.balance = balance;
            if (balance <= 1000)
            {
                interest = 0.04;
            }
            if (1000 < balance && balance < 5000)
            {
                interest = 0.035;
            }
            if (5000 < balance && balance < 10000)
            {
                interest = 0.03;
            }
            if (10000 < balance && balance < 20000)
            {
                interest = 0.02;
            }
            if (balance > 20000)
            {
                interest = 0.01;
            }

        }

        public float Balance{get;set;}
  
        public void TransferToSpendings( float valeur, Spendings acc)
        {
            if (valeur<balance)
            {
                balance = balance-valeur;
                acc.Balance= acc.Balance + valeur;
            }
            else
            {
                Console.WriteLine("this account cannot transfer this amount.");
            }
        }
        public string GetBalance()
        {
            return "this is the current balance on" + FName +" "+ lName +"savings account: " +balance;
        }
          public void Deposit(float val)
        {
            balance = balance +val;
        }
        
    }
}