using System.Diagnostics;
namespace TicTacToe
{
    internal class TicTacToe
    {
        public static void Main()
        {

            string[][] Tablo = new string[3][];
            Tablo[0] = new string[3] { "   |", "   |", "   |" };
            Tablo[1] = new string[3] { "   |", "   |", "   |" };
            Tablo[2] = new string[3] { "   |", "   |", "   |" };
            string choix;
            string choix2;
            string joueur_X = " X |";
            string joueur_O = " O |";
            bool entrée_correcte = false;
            bool joueur_1Win = false;
            bool joueur_2Win = false;
            int compteur = 0;
            string state;


            //fonction to display the bordgame
            void boardgame()
            {
                Console.WriteLine("                                               --TIC TAC TOC--");
                Console.WriteLine(String.Format("{0,-40}", $"{state}") + "          A   B   C          ");
                Console.Write("                                               1|");
                foreach (string n in Tablo[0])
                {
                    Console.Write(n);
                }
                Console.WriteLine(" ");
                Console.Write("                                               2|");
                foreach (string n in Tablo[1])
                {
                    Console.Write(n);
                }
                Console.WriteLine(" ");
                Console.Write("                                               3|");
                foreach (string n in Tablo[2])
                {
                    Console.Write(n);
                }
                Console.WriteLine("");
                Console.WriteLine("");
            }

            //fontion saisie sans faille Joueur 1
            string SSF1()
            {
                choix = Console.ReadLine();
                while (choix != "A1" && choix != "A2" && choix != "A3" && choix != "B1" && choix != "B2" && choix != "B3" && choix != "C1" && choix != "C2" && choix != "C3")
                {
                    Console.WriteLine("Entrée incorrecte");
                    choix = Console.ReadLine();
                }
                return choix;
            }

            //fontion saisie sans faille joueur 2
            string SSF2()
            {
                choix2 = Console.ReadLine();
                while (choix2 != "A1" && choix2 != "A2" && choix2 != "A3" && choix2 != "B1" && choix2 != "B2" && choix2 != "B3" && choix2 != "C1" && choix2 != "C2" && choix2 != "C3")
                {
                    Console.WriteLine("Entrée incorrecte");
                    choix2 = Console.ReadLine();
                }
                return choix2;
            }

            //fonction de la victoire joueur 1
            void WinJ1()
            {
                if ((Tablo[0][0] == joueur_X && Tablo[0][1] == joueur_X && Tablo[0][2] == joueur_X) || (Tablo[1][0] == joueur_X && Tablo[1][1] == joueur_X && Tablo[1][2] == joueur_X) ||
                    (Tablo[2][0] == joueur_X && Tablo[2][1] == joueur_X && Tablo[2][2] == joueur_X) || (Tablo[0][0] == joueur_X && Tablo[1][0] == joueur_X && Tablo[2][0] == joueur_X) ||
                    (Tablo[0][1] == joueur_X && Tablo[1][1] == joueur_X && Tablo[2][1] == joueur_X) || (Tablo[0][2] == joueur_X && Tablo[1][2] == joueur_X && Tablo[2][2] == joueur_X) ||
                    (Tablo[0][0] == joueur_X && Tablo[1][1] == joueur_X && Tablo[2][2] == joueur_X) || (Tablo[0][2] == joueur_X && Tablo[1][1] == joueur_X && Tablo[2][0] == joueur_X))
                {
                    joueur_1Win = true;
                    state = "Joueur 1 à gagné!";
                }

            }

            //Fonction de la victoire joueur 2
            void WinJ2()
            {
                if ((Tablo[0][0] == joueur_O && Tablo[0][1] == joueur_O && Tablo[0][2] == joueur_O) || (Tablo[1][0] == joueur_O && Tablo[1][1] == joueur_O && Tablo[1][2] == joueur_O) ||
                    (Tablo[2][0] == joueur_O && Tablo[2][1] == joueur_O && Tablo[2][2] == joueur_O) || (Tablo[0][0] == joueur_O && Tablo[1][0] == joueur_O && Tablo[2][0] == joueur_O) ||
                    (Tablo[0][1] == joueur_O && Tablo[1][1] == joueur_O && Tablo[2][1] == joueur_O) || (Tablo[0][2] == joueur_O && Tablo[1][2] == joueur_O && Tablo[2][2] == joueur_O) ||
                    (Tablo[0][0] == joueur_O && Tablo[1][1] == joueur_O && Tablo[2][2] == joueur_O) || (Tablo[0][2] == joueur_O && Tablo[1][1] == joueur_O && Tablo[2][0] == joueur_O))
                {
                    joueur_2Win = true;
                    state = "Joueur 2 à gagné!";
                }

            }

            //fonction optimization switch
            void optimusPrime(int a, int b)
            {
                if (Tablo[a][b] != joueur_X && Tablo[a][b] != joueur_O)
                {
                    Tablo[a][b] = joueur_X;
                    compteur++;
                    entrée_correcte = true;
                }
                else
                {
                    Console.WriteLine("Entrée incorrecte");
                    entrée_correcte = false;
                }
            }

            void optimusPrime2(int a, int b)
            {
                if (Tablo[a][b] != joueur_X && Tablo[a][b] != joueur_O)
                {
                    Tablo[a][b] = joueur_O;
                    compteur++;
                    entrée_correcte = true;
                }
                else
                {
                    Console.WriteLine("Entrée incorrecte");
                    entrée_correcte = false;
                }
            }




            Stopwatch stopwatch = Stopwatch.StartNew();

            bool serieux_affiche = false;
            bool msg2_affiche = false;

            bool stop = false;

            Console.WriteLine("Bienvenue au Tic Tac Toe etc...");
            Console.WriteLine("Appuie sur C pour commencer a jouer !");

            while (!stop)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    ConsoleKey key = keyInfo.Key;

                    if (key == ConsoleKey.C)
                        stop = true;

                }
                else
                {
                    if (stopwatch.ElapsedMilliseconds > 5000 && !serieux_affiche)
                    {
                        Console.Clear();
                        Console.WriteLine("Sérieux ?");
                        serieux_affiche = true;
                    }
                    if (stopwatch.ElapsedMilliseconds > 8000 && !msg2_affiche)
                    {
                        Console.Clear();
                        Console.WriteLine("Allez on joue !");
                        msg2_affiche = true;
                    }
                }
            }

            while (!joueur_1Win && !joueur_2Win && compteur < 9)
            {
                state = "Joueur 1";
                Console.Clear();
                boardgame();
                entrée_correcte = false;
                while (!entrée_correcte)
                {
                    switch (SSF1())
                    {
                        case "A1":
                            optimusPrime(0, 0);
                            break;
                        case "A2":
                            optimusPrime(1, 0);
                            break;
                        case "A3":
                            optimusPrime(2, 0);
                            break;
                        case "B1":
                            optimusPrime(0, 1);
                            break;
                        case "B2":
                            optimusPrime(1, 1);
                            break;
                        case "B3":
                            optimusPrime(2, 1);
                            break;
                        case "C1":
                            optimusPrime(0, 2);
                            break;
                        case "C2":
                            optimusPrime(1, 2);
                            break;
                        case "C3":
                            optimusPrime(2, 2);
                            break;
                    }
                }
                WinJ1();
                Console.Clear();
                boardgame();

                if (!joueur_1Win)
                {
                    state = "Joueur 2";
                    Console.Clear();
                    boardgame();
                    entrée_correcte = false;
                    while (!entrée_correcte && compteur < 9)
                    {
                        switch (SSF2())
                        {
                            case "A1":
                                optimusPrime2(0, 0);
                                break;
                            case "A2":
                                optimusPrime2(1, 0);
                                break;
                            case "A3":
                                optimusPrime2(2, 0);
                                break;
                            case "B1":
                                optimusPrime2(0, 1);
                                break;
                            case "B2":
                                optimusPrime2(1, 1);
                                break;
                            case "B3":
                                optimusPrime2(2, 1);
                                break;
                            case "C1":
                                optimusPrime2(0, 2);
                                break;
                            case "C2":
                                optimusPrime2(1, 2);
                                break;
                            case "C3":
                                optimusPrime2(2, 2);
                                break;
                        }
                    }
                    WinJ2();
                    Console.Clear();
                    boardgame();
                }

                if (compteur == 9)
                {
                    state = "Partie nul! Vous êtes poches...";
                    Console.Clear();
                    boardgame();
                }
            }
        }
    }
}