using System;

namespace MenuTP
{

    class Program
    {
        #region SaisieNombre
        public static int SaisieNombre()
        {
            int result;
            while (!int.TryParse(Console.ReadLine(), out result))
            { }
            return result;
        }
        #endregion

        static void Main(string[] args)
        {
            ConsoleKeyInfo cki;

            do
            {
                Console.Clear();
                Console.WriteLine("Menu :\n"
                                 + "exercice 1 : ...\n"
                                 + "exercice 2 : ...\n"
                                 + "exercice 3 : ...\n"
                                 + "exercice 4 : ...\n"
                                 + "\n"
                                 + "Sélectionnez l'exercice désiré ");
                int exo = SaisieNombre();

                switch (exo)
                {
                    case 1:
                        Console.WriteLine("La taille du tableaux?");

                        int size = int.Parse(Console.ReadLine());
                        int[] tab = new int[size];

                        Console.WriteLine("Rempliser les valeur dans le tableau...");

                        for (int i = 0; i < size; i++)
                        {
                            Console.Write("[{0}] ", i);
                            tab[i] = int.Parse(Console.ReadLine());
                        }

                        Console.WriteLine("Saisir le nombre a decaler...");
                        int val = int.Parse(Console.ReadLine());

                        DecalerTableau(tab, val);

                        break;

                        case 2:
                            Console.WriteLine("Hauteur du triangle?");
                            int n = int.Parse(Console.ReadLine());

                            afficheTriangle(n);
                        break;

                        case 3:

                        int[] arr = new int[1] {0};

                        verifTableau(arr);
                        break;



                }
                Console.WriteLine("Tapez Escape pour sortir ou un numero d exo");
                cki = Console.ReadKey();
            } while (cki.Key != ConsoleKey.Escape);

            Console.Read();
        }

        public static void DecalerTableau(int[] tab, int val)
        {
            Console.WriteLine("Tableau saisi : " + "[{0}]", string.Join(", ", tab));

            int[] tmp = new int[tab.Length];
            Array.Copy(tab, tmp, tab.Length);

            for (int i = 0; i < tab.Length; i++)
            {
                if ((i + val) >= tab.Length)
                {
                    tab[i + val - tab.Length] = tmp[i];
                }
                else
                {
                    tab[i + val] = tmp[i];
                }
            }
            Console.WriteLine("Nouveau tableau decalé : " + "[{0}]", string.Join(", ", tab));
        }

        public static void afficheTriangle(int n)
        {
            int count = 1;
            for (int i = 0; i < n; i++)
            {
                for (int sp = 0; sp < n-i-1; sp++)
                {
                    Console.Write(" ");
                }
                for(int j = 0; j < count; j++)
                {
                    Console.Write("*");
                }
                Console.Write("\n");
                count = count + 2;
            }
        }

        public static bool verifTableau (int[] tab)
        {

            int flag = 0;

            foreach (int n in tab)
            {
                if (n == 0 || n == 1)
                {
                    flag = 1;
                }
                    

                for (int i = 2; i <= n / 2; ++i)
                {

                    // if n is divisible by i, then n is not prime
                    // change flag to 1 for non-prime number
                    if (n % i == 0)
                    {
                        flag = 1;
                        break;
                    }
                }
            }

            if (flag == 0)
                Console.WriteLine("False");
                return false;
            else
                Console.WriteLine("True");
                return true;
        }

    }
}

