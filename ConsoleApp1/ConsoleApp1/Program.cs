using System;

namespace ConsoleApp1
{
    class Program
    {
        //définir la méthode SaisieNombre();
        //chaque exercice sera définie sous forme d'une méthode static


        static void Main(string[] args)
        {
            ConsoleKeyInfo cki;

            do
            {
                Console.Clear();
                Console.WriteLine(
                    "Menu :\n"
                        + "Exercice 1 : Draw A Line & A Matrix ...\n"
                        + "Exercice 2 : Draw A Matrix With a Diagonal ...\n"
                        + "Exercice 3 : Multiplication Table...\n"
                        + "Exercice 4 : Inverse Word...\n"
                        + "\n"
                        + "Chose Desired Exercise "
                );
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

        static void Exo1()
        {
            Console.WriteLine("Input Line Size Desired...\n");
            int LineDim = int.Parse(Console.ReadLine());

            for (int i = 0; i < LineDim; i++)
            {
                Console.Write("X");
            }
            Console.Write("\n");

            Console.WriteLine("Input Symbol For Matrix...");
            string MatSym = Console.ReadLine();
            Console.WriteLine("Input Dimention For Matrix...");
            int MatDim = int.Parse(Console.ReadLine());

            for (int i = 0; i < MatDim; i++)
            {
                for (int j = 0; j < MatDim; j++)
                {
                    Console.Write(MatSym);
                }
                Console.Write("\n");
            }
        }

        static void Exo2()
        {
            Console.WriteLine("Input Symbol For Matrix...");
            string MatSym = Console.ReadLine();
            Console.WriteLine("Input Diagonal Symbol For Matrix...");
            string MatDiag = Console.ReadLine();
            Console.WriteLine("Input Dimention For Matrix...");
            int MatDim = int.Parse(Console.ReadLine());
            Console.WriteLine("Input The Direction Of The Diagonal For Matrix(M or D)...");
            string MatDir = Console.ReadLine();

            if (MatDir == "D")
            {
                for (int i = 0; i < MatDim; i++)
                {
                    for (int j = 0; j < MatDim; j++)
                    {
                        if (i == j)
                        {
                            Console.Write(MatDiag);
                        }
                        else
                        {
                            Console.Write(MatSym);
                        }
                    }
                    Console.WriteLine("\n");
                }
            }
            if (MatDir == "M")
            {
                for (int i = 0; i < MatDim; i++)
                {
                    for (int j = 0; j < MatDim; j++)
                    {
                        if (i + j == MatDim - 1)
                        {
                            Console.Write(MatDiag);
                        }
                        else
                        {
                            Console.Write(MatSym);
                        }
                    }
                    Console.WriteLine("\n");
                }
            }
        }

        static void Exo3()
        {
            Console.WriteLine("Enter A Whole Number...");
            int Num = int.Parse(Console.ReadLine());

            for (int i = 0; i < Num; i++)
            {
                for (int j = 0; j < Num; j++)
                {
                    int mult = (i + 1) * (j + 1);
                    for (
                        int k = 0;
                        k < ((Num * Num).ToString().Length - mult.ToString().Length + 1);
                        k++
                    )
                    {
                        Console.Write(" ");
                    }
                    Console.Write(mult);
                }
                Console.Write("\n");
            }
        }

        static void Exo4()
        {
            Console.WriteLine("Enter A String To Be Inversed...");
            string str = Console.ReadLine();

            for (int i = str.Length - 1; i >= 0; i--)
            {
                Console.Write(str[i]);
            }
            Console.WriteLine("\n");
        }
    }
}
