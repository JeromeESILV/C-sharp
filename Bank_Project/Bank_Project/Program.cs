using OfficeOpenXml;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Bank_Project // Note: actual namespace depends on the project name.
{

    static class Program
    {
        static async Task Main(string[] args)
        {
            List<Account> listAcc = new List<Account>();
            List<Spendings> listSpends = new List<Spendings>();
            List<Savings> listSaves = new List<Savings>();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var file = new FileInfo(@"..\..\..\SavedAccounts.XLSX");// We start from bin>Debug>net6.0 and we go back to the main folder to access the exel file

            ConsoleKeyInfo cki;

            do
            {
                Console.Clear();
                Console.Write(" \n");
                Console.WriteLine(
  "####    ###   #   #  #   #   ####   #####   ####  #   #   ###   ####     ####   #   #" + "\n"
+ "#   #  #   #  ##  #  #  #   #    #  #      #      #   #  #   #  #   #   #    #  ##  #" + "\n"
+ "####   #####  # # #  ###    #    #  ####   #      #####  #####  ####    #    #  # # #" + "\n"
+ "#   #  #   #  #  ##  #  #   #    #  #      #      #   #  #   #  #   #   #    #  #  ##" + "\n"
+ "####   #   #  #   #  #   #   ####   #       ####  #   #  #   #  #    #   ####   #   #" + "\n"
);
                Console.WriteLine("Bank Login (1) \nClient Login (2) ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        choice = "0";
                        Console.WriteLine("Admin Password (Not yet working)");
                        Console.WriteLine("New Client (1)\nGet Account (2)\n");
                        choice = Console.ReadLine();
                        switch (choice)
                        {
                            case "1":
                                Account NewAcc = new();
                                Savings NewSavings = new();
                                Spendings NewSpendings = new();

                                Console.WriteLine("First name");
                                NewAcc.FName = Console.ReadLine();
                                NewSavings.FName = NewAcc.FName;
                                NewSpendings.FName = NewAcc.FName;
                                
                                Console.WriteLine("Last Name");
                                NewAcc.LName = Console.ReadLine();
                                NewSavings.LName = NewAcc.LName;
                                NewSpendings.LName = NewAcc.LName;

                                Console.WriteLine("ID Number");
                                NewAcc.IdNumber = int.Parse(Console.ReadLine());
                                NewSavings.IdNumber = NewAcc.IdNumber;
                                NewSpendings.IdNumber = NewAcc.IdNumber;

                                Console.WriteLine("Address");
                                NewAcc.Address = Console.ReadLine();
                                NewSavings.Address = NewAcc.Address;
                                NewSpendings.Address = NewAcc.Address;

                                Console.WriteLine("Date of Birth YYYY/MM/DD");
                                NewAcc.Birthday = DateOnly.Parse(Console.ReadLine());
                                NewSavings.Birthday = NewAcc.Birthday;
                                NewSpendings.Birthday = NewAcc.Birthday;

                                NewAcc.Flag = false;
                                NewSavings.Flag = false;
                                NewSpendings.Flag = false;


                                NewSavings.Balance = 0;
                                NewSpendings.Balance = 0;

                                listAcc.Add(NewAcc);
                                listSpends.Add(NewSpendings);
                                listSaves.Add(NewSavings);

                                await SaveExcelAccounts(listAcc, file);
                                await SaveExcelSpendings(listSpends, file);
                                await SaveExcelSavings(listSaves, file);

                                NewAcc.GetAccount();
                                break;

                            case "2":
                                List<Account> AllAccounts = await LoadAccounts(file);
                                foreach (Account ac in AllAccounts)
                                {
                                    ac.GetAccount();
                                }
                                break;

                        }
                        break;

                    case "2":
                        Console.WriteLine("User Login ");

                        Account a = new();
                        Spendings sp = new();
                        Savings sav = new();

                        Console.WriteLine("what is your account id? ");

                        float o = float.Parse(Console.ReadLine());
                        List<Account> accountsFromExcel = await LoadAccounts(file);
                        foreach (Account ac in accountsFromExcel)
                        {
                            if (ac.IdNumber == o)
                                a = ac;
                        }

                        List<Spendings> spendingsFromExcel = await LoadSpendings(file);
                        foreach (Spendings spd in spendingsFromExcel)
                        {
                            if (spd.IdNumber == o)
                                sp = spd;
                        }

                        List<Savings> savingsFromExcel = await LoadSavings(file);
                        foreach (Savings sv in savingsFromExcel)
                        {
                            if (sv.IdNumber == o)
                                sav = sv;
                        }

                        Console.WriteLine("what operation do you want to do ? ");
                        Console.WriteLine("Deposit : 0 \nmoney into your Spendings account spend: 1 \n transfer money to another account: 2\n transfer money to you savings account: 3 \n change account details: 4\n see the balance of your accounts:5 \n see your spending limit: 6");
                        string choice2 = Console.ReadLine();
                        switch (choice2) 
                        {
                             case "0":
                                Console.WriteLine("how much do you want to deposit ?");
                                float val0 = float.Parse(Console.ReadLine());
                                sp.Deposit(val0);
                                listSpends.Add(sp);
                                await SaveExcelSpendings(listSpends,file);
                                
                            break;
                            case "1":
                                Console.WriteLine("how much do you want to spend ?");
                                float val1 = float.Parse(Console.ReadLine());
                                sp.Spend(val1);
                                listSpends.Add(sp);
                                await SaveExcelSpendings(listSpends,file);
                                
                            break;

                            case "2":
                                Console.WriteLine("how much do you want to transfer and to wich account?");
                                float val2 = float.Parse(Console.ReadLine());
                                float y = float.Parse(Console.ReadLine());
                              
                                sp.Transfert(val2,sp);
                                await SaveExcelSpendings(listSpends,file);
                            break;

                            case "3":
                                Console.WriteLine("how much do you want to transfer to your savings?");
                                float val3 = float.Parse(Console.ReadLine());

                                if(sp.Spend(val3) == true)
                                {
                                    sav.Deposit(val3);
                                }

                            break;

                            case "4":
                                Console.WriteLine("what details do you want to change?");
                                Console.WriteLine("last name: 1 \naccount id:2 \naddress:3");
                                string choice3 = Console.ReadLine();
                                switch (choice3)
                                {
                                    case "1": 
                                    // Console.WriteLine("the last name was:" + LName);
                                     string newlnam = Console.ReadLine();
                                     // change lname
                                    break;
                                    case "2": 
                                    // Console.WriteLine("the id number was:" + idNumber);
                                     string newid = Console.ReadLine();
                                     // change idnumber
                                    break;
                                    case "3": 
                                     //Console.WriteLine("the address was:" + address);
                                     string newadd = Console.ReadLine();
                                     // change address
                                    break;
                                }
                                break;
                            
                            case "5":
                                Console.WriteLine("here is your account's balance");
                                sav.GetBalance();
                            break;
                            case "6":
                                Console.WriteLine("here is your spending limit");
                               //spendings.limitspent
                            break;
                             case "7":
                                Console.WriteLine("how much do you want to transfer from your savings?");
                                float val6 = float.Parse(Console.ReadLine());
                                sav.TransferToSpendings(val6,sp);
                            break;

                        }
                        break;
                    default:
                        Console.WriteLine("Nothing selected");
                        break;
                }
                Console.WriteLine("Chose Another Exercise Or Press ESC Then Enter To Leave");
                cki = Console.ReadKey();
            } while (cki.Key != ConsoleKey.Escape);

            Console.Read();
 
            await SaveExcelAccounts(listAcc, file);

        }

        private static async Task<List<Account>> LoadAccounts(FileInfo file)
        {
            List<Account> output = new();

            using var package = new ExcelPackage(file);

            await package.LoadAsync(file);

            var ws = package.Workbook.Worksheets[0];

            int row = 2;
            int col = 1;

            while (string.IsNullOrWhiteSpace(ws.Cells[row, col].Value?.ToString()) == false)
            {
                Account p = new();
                p.AccountNum = int.Parse(ws.Cells[row, col].Value.ToString());
                p.FName = ws.Cells[row, col + 1].Value.ToString();
                p.LName = ws.Cells[row, col + 2].Value.ToString();
                p.IdNumber = int.Parse(ws.Cells[row, col + 3].Value.ToString());
                p.Address = ws.Cells[row, col + 4].Value.ToString();
                p.Birthday = DateOnly.Parse(ws.Cells[row, col + 5].Value.ToString());
                p.Flag = bool.Parse(ws.Cells[row, col + 6].Value.ToString());
                output.Add(p);
                row += 1;
            }

            return output;
        }
        private static async Task<List<Spendings>> LoadSpendings(FileInfo file)
        {
            List<Spendings> output = new();

            using var package = new ExcelPackage(file);

            await package.LoadAsync(file);

            var ws = package.Workbook.Worksheets[1];
            var acWS = package.Workbook.Worksheets[0];

            int row = 2;
            int col = 1;

            while (string.IsNullOrWhiteSpace(ws.Cells[row, col].Value?.ToString()) == false)
            {
                Spendings p = new();
                p.Balance = float.Parse(ws.Cells[row, col].Value.ToString());
                p.Limit = int.Parse(ws.Cells[row, col + 1].Value.ToString());
                //p.LimitSpent = ws.Cells[row, col + 2].Value.ToString();
                p.AccountNum = int.Parse(ws.Cells[row, col+2].Value.ToString());
                p.FName = ws.Cells[row, col + 3].Value.ToString();
                p.LName = ws.Cells[row, col + 4].Value.ToString();
                p.IdNumber = int.Parse(ws.Cells[row, col + 5].Value.ToString());
                p.Address = ws.Cells[row, col + 6].Value.ToString();
                p.Birthday = DateOnly.Parse(ws.Cells[row, col + 7].Value.ToString());
                p.Flag = bool.Parse(ws.Cells[row, col + 8].Value.ToString());

                output.Add(p);
                row += 1;
            }

            return output;
        }
        private static async Task<List<Savings>> LoadSavings(FileInfo file)
        {
            List<Savings> output = new();

            using var package = new ExcelPackage(file);

            await package.LoadAsync(file);

            var ws = package.Workbook.Worksheets[0];

            int row = 2;
            int col = 1;

            while (string.IsNullOrWhiteSpace(ws.Cells[row, col].Value?.ToString()) == false)
            {
                Savings p = new();
                p.AccountNum = int.Parse(ws.Cells[row, col].Value.ToString());
                p.FName = ws.Cells[row, col + 1].Value.ToString();
                p.LName = ws.Cells[row, col + 2].Value.ToString();
                p.IdNumber = int.Parse(ws.Cells[row, col + 3].Value.ToString());
                p.Address = ws.Cells[row, col + 4].Value.ToString();
                p.Birthday = DateOnly.Parse(ws.Cells[row, col + 5].Value.ToString());
                p.Flag = bool.Parse(ws.Cells[row, col + 6].Value.ToString());
                output.Add(p);
                row += 1;
            }

            return output;
        }

        private static async Task SaveExcelAccounts(List<Account> accounts, FileInfo file)
        {

            using var package = new ExcelPackage(file);//basically a Dispose method to get rid of any useless data

            var ws = package.Workbook.Worksheets[0];
            var range = ws.Cells["A1"].LoadFromCollection(accounts, true);
            range.AutoFitColumns();


            await package.SaveAsync();
        }
        private static async Task SaveExcelSpendings(List<Spendings> accounts, FileInfo file)
        {


            using var package = new ExcelPackage(file);//basically a Dispose method to get rid of any useless data

            var ws = package.Workbook.Worksheets[1];
            var range = ws.Cells["A1"].LoadFromCollection(accounts, true);
            range.AutoFitColumns();


            await package.SaveAsync();
        }
        private static async Task SaveExcelSavings(List<Savings> accounts, FileInfo file)
        {


            using var package = new ExcelPackage(file);//basically a Dispose method to get rid of any useless data

            var ws = package.Workbook.Worksheets[2];
            var range = ws.Cells["A1"].LoadFromCollection(accounts, true);
            range.AutoFitColumns();


            await package.SaveAsync();
        }

        private static List<Account> GetSetupData()//Test method to add dummy classes
        {
            List<Account> output = new()
            {
                new Account("Jerome", "Dupret", 42069, "68 rue des ecoles", new DateOnly(1999, 08, 10)),
                new Account("Deborah", "Pierre", 69420, "68 rue des ecoles", new DateOnly(2000, 02, 18)),
            };

            return output;
        }

    }


}