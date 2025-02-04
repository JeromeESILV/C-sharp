using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace ConsoleApp2 // Note: actual namespace depends on the project name.
{
    static class Program
    {
        public static ArrayList arr = new ArrayList();
        static void Main(string[] args)
        {
            
            ConsoleKeyInfo cki;
            do {
                Console.Clear();
                Console.WriteLine("Chose An Exercise From The Following...");
                Console.WriteLine("Exercise 1: Set Array Values... " + "\nExercise 2: Display Array Set..." + "\nExercise 3: Inverse Array... " + "\nExercise 4: Sort Array..." + "\nExercise 5: Is Array Sorted?..." + "\nExercise 6: Search Value..." + "\nExercise 7: Count Value...");

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
                    case "5":
                        Console.WriteLine(Exo5());                        
                        break;
                    case "6":
                        Console.WriteLine(Exo6());
                        break;
                    case "7":
                        Exo7();
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
            ConsoleKeyInfo cki;
            arr.Clear();
            Console.WriteLine("Insert Numbers Into Array..." + "\n ESC + Enter When done...");
            int i = 0;

            do
            {
                Console.Write("[{0}] ", i++);
                
                arr.Add(int.Parse(Console.ReadLine()));
                cki = Console.ReadKey();
                Console.WriteLine("");
            } while (cki.Key != ConsoleKey.Escape);
        }
        static void Exo2() {
            int[] tmpArr = arr.ToArray(typeof(int)) as int[];
            Console.WriteLine("Your Array : " + "[{0}]", string.Join(", ", tmpArr));
        }
        static void Exo3() {

            int[] tmpArr = arr.ToArray(typeof(int)) as int[];
            Array.Reverse(tmpArr);
            Console.WriteLine("Inversed Array : " + "[{0}]", string.Join(", ", tmpArr));
        }
        static void Exo4() {
            int[] tmpArr = arr.ToArray(typeof(int)) as int[];
            Array.Sort(tmpArr);
            Console.WriteLine("Inversed Array : " + "[{0}]", string.Join(", ", tmpArr));
        }
         static bool Exo5()
         {
            int[] tmpArr = arr.ToArray(typeof(int)) as int[];

            for (int i = 1; i < tmpArr.Length; i++)
            {
                if (tmpArr[i - 1] > tmpArr[i])
                {
                    return false;
                }
            }
            return true;
         }
        static bool Exo6() {
            int[] tmpArr = arr.ToArray(typeof(int)) as int[];

            Console.WriteLine("Set Value To Search For...");
            int info = int.Parse(Console.ReadLine());

            foreach(int i in tmpArr)
            {
                if(i == info)
                {
                    return true;
                }
            }
            return false;
        }
        static void Exo7() {
            int[] tmpArr = arr.ToArray(typeof(int)) as int[];

            Console.WriteLine("Set Value To Count ...");
            int info = int.Parse(Console.ReadLine());
            int count = 0;
            foreach (int i in tmpArr)
            {
                if (i == info)
                {
                    count++; ;
                }
            }
            Console.WriteLine("{0} Found {1} Times...", info, count);
        }

    }
}