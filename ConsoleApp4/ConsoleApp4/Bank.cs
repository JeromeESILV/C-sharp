using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace ConsoleApp4 // Note: actual namespace depends on the project name.
{

    class Bank{
        private string client;
        private decimal accountBalance;
        private bool flag;

        public Bank(string c, decimal aB, bool f)
        {
            client = c;
            accountBalance = aB;
            flag = f;
        }

        public string Client { get; set; }
        public decimal AccountBalance { get; set; }
        public bool Flag { get; set; }

        public void AccountDetails(){
            Console.WriteLine("Client First and Last Name : {0}\nAccount Balance : {1}\nFlag : {2}\n", client, accountBalance, flag);
        }
        public bool Deposit(decimal amount){
            if(flag == true){
                Console.WriteLine("Sorry Your Account Has Been Suspended Please Contact Your Account Manager For More Information...");
                return false;
            }

            accountBalance += amount;

            Console.WriteLine("New Balance : {0}", accountBalance);
            return true;
        }
        public bool Withdraw(decimal amount){
            if(flag == true){
                Console.WriteLine("Sorry Your Account Has Been Suspended Please Contact Your Account Manager For More Information...");
                return false;
            }

            if(amount > accountBalance){
                Console.WriteLine("The Ammount Wished To Be Withdrawn Exceed The Account Balance...");
                return false;
            }else{
                Console.WriteLine("New Balance : {0}", accountBalance);
                return true;
            }
        }
        public bool Transfer(Bank toAcc,decimal amount){
            if(flag == true || toAcc.flag == true){
                Console.WriteLine("Sorry Your Account, Or The Account To Transfer To, Has Been Suspended Please Contact Your Account Manager For More Information...");
                return false;
            }

            if(amount > toAcc.accountBalance){
                Console.WriteLine("The Ammount Wished To Be Transfered Exceed The Account Balance...");
                return false;
            }else{
                toAcc.accountBalance += amount;
                accountBalance -= amount;
                return true;
            }

        }
        public int TotalClient(){
            return 1;
        }
    }


}