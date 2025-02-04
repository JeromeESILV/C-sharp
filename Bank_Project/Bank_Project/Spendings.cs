using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Project
{
    class Spendings : Account
    {

        private float balance;
        private int limit;
        private float limitSpent;
        private Account acc
        {
            get { return acc; }
        }
        public Spendings() { }
        
        public Spendings (float balance, int accountNum, string fName, string lName, int idNumber, string address, DateOnly birthday ) : base( fName, lName, idNumber, address, birthday )
        {
            this.balance = balance;
            if (Balance <= 1000)
            {
                limit = 500;
            }
            if (1000 < Balance && Balance < 5000)
            {
                limit = 2000;
            }
            this.limitSpent = 0;

        }

        public float Balance{get;set;}
        public int Limit{get;set;}

        public void Transfert( float valeur, Spendings account)
        {
            int accNum = this.accountNum;
            if (valeur<balance+200)
            {
                balance = balance-valeur;
                account.Balance = valeur + account.Balance;
                
            }
            else
            {
                Console.WriteLine("this account cannot transfer this amount.");
            }
        }
        public void Save(float amount, Savings acc)
               {
            if (amount<balance)
            {
                balance = balance-amount;
                acc.Balance= acc.Balance + amount;
            }
            else
            {
                Console.WriteLine("this account cannot transfer this amount.");
            }
        }
        public void SetBalance(float value, Account A)
        {
            this.Balance = Balance + value;
        }
        public bool Spend(float value)
        {
            if (value < limit && limitSpent + value < limit)
            {
                balance = balance - value;
                limitSpent = limitSpent + value;
                return true;
            }
            else
            {
                Console.WriteLine("you ain t that rich you ve reached your limit for this month my g");
                return false;
            }
        }
         public void Deposit(float val)
        {
            this.Balance = Balance +val;
        }

    }
}