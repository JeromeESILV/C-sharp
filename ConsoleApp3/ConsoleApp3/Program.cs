using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace ConsoleApp3 // Note: actual namespace depends on the project name.
{
    public class error : Exception
    {
        public error()
        {

        }
    }
    static class Program
    {
        public static ArrayList arr = new ArrayList();
        static void Main(string[] args)
        {
            
            ConsoleKeyInfo cki;
            do {
                Console.Clear();
                Console.WriteLine("Chose An Exercise From The Following...");
                Console.WriteLine("Exercise 1: Is This A Palindrome?... " + "\nExercise 2: Prime Numbers..." + "\nExercise 3: Sum Array... " + "\nExercise 4: Magic Square...");

                string exo = Console.ReadLine();
                switch (exo)
                {
                    case "1":
                        Exo1();
                        break;
                    case "2":
                        Exo2();
                        break;
                    case "3":
                        Exo3();
                        break;
                    case "4":
                        Exo4();
                        break;
                    
                    default:
                        Console.WriteLine("No exercise selected");
                        break;
                }
                Console.WriteLine("Chose Another Exercise Or Press ESC Then Enter To Leave");
                cki = Console.ReadKey();
            } while (cki.Key != ConsoleKey.Escape);

            Console.Read();
        }

        static void Exo1() {
            arr.Clear();
            Console.WriteLine("What Word To Check?...");
            arr.Add(Console.ReadLine());
            string tmpArr = arr[0].ToString();

            for(int i = 0; i < tmpArr.Length/2; i++)
            {
                if (tmpArr[i] != tmpArr[tmpArr.Length-1-i])
                {
                    Console.WriteLine("Not A Palindrome...");
                    return;
                }
            }
            Console.WriteLine("{0} Is A Palindrome...", tmpArr);
        }
        static void Exo2() {
            arr.Clear();
            Console.WriteLine("How Many Prime Numbers Do You Want To Display?...");
            int prime = 1;

            try
            {
                prime = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Not A Number Try Again...");
                Exo2();
            }

            int count = 0;
            int dsp = 2;
            int flag;
            Console.Clear();
            Console.WriteLine("Writing The First {0} Prime Numbers:", prime);
            do
            {
                flag = 1;
                for(int i = 2; i <= dsp/2; i++)
                {
                    if (dsp % i == 0)
                    {
                        flag = 0;
                        break;
                    }
                }
                if(flag == 1)
                {
                    Console.WriteLine(" {0} ", dsp);
                    count++;
                }
                dsp++;

            } while (count != prime);
        }
        static void Exo3() {
            Console.WriteLine("What Size Matrix Are You Additioning?" + "\nNumber of Rows:");
            int row = 0;
            int clm = 0;
            try
            {
                row = int.Parse(Console.ReadLine());
                Console.WriteLine("Number of Columns: ");
                clm = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Not A Number Try Again...");
                Exo3();
            }

            int[,] arr1 = new int[row,clm];
            int[,] arr2 = new int[row, clm];
            try
            {
                for (int r = 0; r < row; r++)
                {
                    for(int c = 0; c < clm; c++)
                    {
                        Console.WriteLine("Array 1 [Row {0}, Column {1}] : ", r+1, c+1);
                        if((arr1[r, c] = int.Parse(Console.ReadLine())) == null)
                        {
                            error e1 = new error();
                        }
                    }
                }
                Console.WriteLine("---------");
                for (int r = 0; r < row; r++)
                {
                    for (int c = 0; c < clm; c++)
                    {
                        Console.WriteLine("Array 2 [Row {0}, Column {1}] : ", r + 1, c + 1);
                        if ((arr2[r, c] = int.Parse(Console.ReadLine())) == null)
                        {
                            error e1 = new error();
                        }
                    }
                }

            }
            catch (error e1)
            {
                Console.WriteLine("Error Please Insert Only Whole Numbers...");
                Exo3();
            }

            Console.WriteLine("Summed Array...");
            for(int r = 0; r < row; r++)
            {
                for( int c = 0; c < clm; c++)
                {
                    Console.Write("{0} ", arr1[r , c] + arr2[r , c]);
                }
                Console.WriteLine("");
            }
            
        }
        static void Exo4() {
            Console.WriteLine("What Size Square?");
            int size = int.Parse(Console.ReadLine());
            int[,] arr = new int[size, size];
            try
            {
                for (int r = 0; r < size; r++)
                {
                    for (int c = 0; c < size; c++)
                    {
                        Console.WriteLine("Array 1 [Row {0}, Column {1}] : ", r + 1, c + 1);
                        if ((arr[r, c] = int.Parse(Console.ReadLine())) == null)
                        {
                            error e1 = new error();
                        }
                    }
                }
            }
            catch (error e1)
            {
                Console.WriteLine("Error Please Insert Only Whole Numbers...");
                Exo4();
            }
            int[] A1 = new int[size], A2 = new int[size], D1 = new int[size], D2 = new int[size];
            for(int r = 0; r < size; r++)//Row check
            {
                for (int c = 0; c < size; c++)
                {
                    if(r == c)
                    {
                        D1[c] = arr[r,c];
                    }
                    if(r == size - c - 1)
                    {
                        D2[c] = arr[r, c];
                    }
                    if(r%2  == 0)
                    {
                        A1[c] = arr[r, c];
                    }
                    if(r%2 != 0)
                    {
                        A2[c] = arr[r, c];
                    }
                }
                if (r % 2 != 0)
                {
                    if(A1.Sum() != A2.Sum())
                    {
                        Console.WriteLine("Not A Magic Squre!!!" + "\nTry Again? (y/n)");
                        string usr = Console.ReadLine();
                        if(usr == "y")
                        {
                            Console.Clear();
                            Exo4();
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }

            if (D1.Sum() != D2.Sum())//Diagonal check
            {
                Console.WriteLine("Not A Magic Squre!!!" + "\nTry Again? (y/n)");
                string usr = Console.ReadLine();
                if (usr == "y")
                {
                    Console.Clear();
                    Exo4();
                }
                else
                {
                    return;
                }
            }

            for (int r = 0; r < size; r++)//Columb check
            {
                for (int c = 0; c < size; c++)
                {

                    if (r % 2 == 0)
                    {
                        A1[c] = arr[c, r];
                    }
                    if (r % 2 != 0)
                    {
                        A2[c] = arr[c, r];
                    }
                }
                if (r % 2 != 0)
                {
                    if (A1.Sum() != A2.Sum())
                    {
                        Console.WriteLine("Not A Magic Squre!!!" + "\nTry Again? (y/n)");
                        string usr = Console.ReadLine();
                        if (usr == "y")
                        {
                            Console.Clear();
                            Exo4();
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }

            Console.WriteLine("Magic Square Detected!!!");

        }

    }
}