using System;

namespace Morpion
{
    class Program
    {
        static char[,] grid = new char[3, 3]; // Grille de jeu
        static int turn = 0; // Compteur de tours (0 = joueur 1, 1 = joueur 2)

        static void Main(string[] args)
        {
            // Initialiser la grille avec des espaces vides
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    grid[i, j] = ' ';
                }
            }

            // Boucle principale du jeu
            while (true)
            {
                // Afficher la grille
                Console.Clear();
                DrawGrid();

                // Demander au joueur actuel de choisir une case
                Console.WriteLine("Au tour du joueur " + (turn + 1) + " de jouer.");
                Console.Write("Choisissez une ligne (1-3): ");
                int row = int.Parse(Console.ReadLine()) - 1;
                Console.Write("Choisissez une colonne (1-3): ");
                int col = int.Parse(Console.ReadLine()) - 1;

                // Vérifier si la case choisie est valide et disponible
                if (row >= 0 && row < 3 && col >= 0 && col < 3 && grid[row, col] == ' ')
                {
                    // Mettre à jour la grille en fonction du joueur actuel
                    if (turn == 0)
                    {
                        grid[row, col] = 'X';
                    }
                    else
                    {
                        grid[row, col] = 'O';
                    }

                    // Passer au tour suivant
                    turn = (turn + 1) % 2;
                }

                // Vérifier si un joueur a gagné
                if (CheckWin())
                {
                    // Afficher la grille une dernière fois
                    Console.Clear();
                    DrawGrid();

                    // Annoncer le vainqueur et quitter la boucle
                    Console.WriteLine("Le joueur " + (turn + 1) + " a gagné!");
                    break;
                }
            }

            // Attendre que l'utilisateur appuie sur une touche pour quitter
            Console.WriteLine("Appuyez sur une touche pour quitter...");
            Console.ReadKey();
        }

        static void DrawGrid()
        {
            // Dessiner la grille de jeu en utilisant des boucles et des caractères de contrôle
            Console.WriteLine("     1   2   3");
            Console.WriteLine("   +---+---+---+");
            for (int i = 0; i < 3; i++)
            {
                Console.Write(" " + (i + 1) + " ");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("| " + grid[i, j] + " ");
                }
                Console.WriteLine("|");
                Console.WriteLine("   +---+---+---+");
            }
        }

        static bool CheckWin()
        {
            // Vérifier s'il y a un alignement horizontal
            for (int i = 0; i < 3; i++)
            {
                if (grid[i, 0] != ' ' && grid[i, 0] == grid[i, 1] && grid[i, 1] == grid[i, 2])
                {
                    return true;
                }
            }

            // Vérifier s'il y a un alignement vertical
            for (int i = 0; i < 3; i++)
            {
                if (grid[0, i] != ' ' && grid[0, i] == grid[1, i] && grid[1, i] == grid[2, i])
                {
                    return true;
                }
            }

            // Vérifier s'il y a un alignement en diagonale
            if (grid[0, 0] != ' ' && grid[0, 0] == grid[1, 1] && grid[1, 1] == grid[2, 2])
            {
                return true;
            }
            if (grid[0, 2] != ' ' && grid[0, 2] == grid[1, 1] && grid[1, 1] == grid[2, 0])
            {
                return true;
            }

            // Si aucun alignement n'a été trouvé, retourner false
            return false;
        }
    }
}
