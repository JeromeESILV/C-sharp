using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace ConsoleApp4 // Note: actual namespace depends on the project name.
{

    static class Program{
        static void Main(string[] args){
            Stocks beer = new Stocks(1, "IPA", 5.00, 500);
            Stocks beer2 = new Stocks(1, "Blonde Lager", 2.00, 500);
            Stocks cereal = new Stocks(2, "Chereos", 2.55, 200);

            Console.WriteLine(beer.Reference);
            
            cereal.newStock(250);
            Console.WriteLine(cereal.QttInStock);

            cereal.Sold(200);
            Console.WriteLine(cereal.QttInStock);
            cereal.Sold(200);
            Console.WriteLine(cereal.QttInStock);

            beer.PriceTI();
            cereal.PriceTI();

            beer.toString();
            cereal.toString();

            beer.Equals(beer2);
            beer2.Reference = 11;
            beer.Equals(beer2);

            //Bank stuff
            Console.WriteLine("\n-------------------------------------------------------------------------------------\n");
            Bank Jerome = new Bank("Jerome Dupret", 500000, false);
            Bank Deborah = new Bank("Deborah Pierre", 10000, false);

            Jerome.AccountDetails();

            Jerome.Transfer(Deborah, 420);

            Jerome.AccountDetails();
            Deborah.AccountDetails();
        }
    }
    

}