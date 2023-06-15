using System;

namespace ShiFumi5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Initialisation des variables
            int playerScore = 0;
            int computerScore = 0;
            int round = 1;
            bool endGame=false;

            //Présentation
            Console.WriteLine("Shi Fu Mi!\n--------------");
            Console.WriteLine("Choisir son signe et appuyer sur entrée:");
            Console.WriteLine("1 - Pierre");
            Console.WriteLine("2 - Feuille");
            Console.WriteLine("3 - Ciseaux");

            while (endGame==false)
            {
                try
                {
                    Console.WriteLine($"\n\nTour n°: {round}");
                    Console.WriteLine($"----------------");
                    //Choix joueur
                    Console.Write("Votre choix: ");
                    string playerString = Console.ReadLine();
                    int player = int.Parse(playerString);
                    Console.WriteLine(GetSign(player));

                    //Choix Ordinateur (nombre aléatoirement entre 1 et 3)
                    var computer = new Random().Next(1, 3);
                    Console.WriteLine($"\nLe choix de l'ordinateur: {GetSign(computer)}\n");


                    //Résultat
                    if (WonTheGame(player, computer))
                    {
                        Console.WriteLine("Gagné!");
                        playerScore++;
                    }
                    else if(WonTheGame(computer, player))
                    {
                        Console.WriteLine("Perdu!");
                        computerScore++;
                    }
                    else
                    {
                        Console.WriteLine("Egalité");
                    }


                    endGame = EndGame(playerScore, computerScore);
                    round++;
                }
                catch (Exception e)
                {

                    Console.WriteLine($"Erreur: {e.Message}");
                }
              
            }
        }

        /// <summary>
        /// Affiche le score et indique si la partie est terminée
        /// </summary>
        /// <param name="playerScore"></param>
        /// <param name="computerScore"></param>
        /// <returns></returns>
        public static bool EndGame(int playerScore, int computerScore)
        {
            Console.WriteLine($"Score joueur: {playerScore}");
            Console.WriteLine($"Score ordinateur: {computerScore}");

            if (playerScore == 5)
            {
                Console.WriteLine("Vous avez remporté la partie!");
                return true;
            }
            else if (computerScore == 5)
            {
                Console.WriteLine("L'ordinateur a remporté la partie!");
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Donne le signe et le valide
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string GetSign(int number)
        {
            switch (number)
            {
                case 1: return "Pierre";
                case 2: return "Feuille";
                case 3: return "Ciseaux";
                default: throw new Exception("Choix non valide");
            }
        }

        /// <summary>
        /// Quel est le joueur gagnant
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static bool WonTheGame(int first, int second)
        {
            if(first == second)
            {
                return false;
            }
            if (first == 1 && second == 3)
            {
                return true;
            }
            else if (first < second)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
