using System;
//we add a refernces "ClassLibraryDimineur" to make a line between two projects
using ClassLibraryDimineur;

namespace ConsoleApplicationDimineur
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("bonjour :))");
            //on ajoute public à la classe game pour bien visualiser l'objet myGame

            Game myGame = new Game(GameLevel.Beginner);
            // Game myGame = new Game(bombs: 20, columns: 15, lines: 10);  //parametres nommés
            myGame.Bombs3 = 20;//ici on utilise "set"
            Console.WriteLine("Bombs = {0}",myGame.Bombs3); //ici on utilise "get"
            //meme enchainement avec Bombs4

            Console.WriteLine("Taille de gride = {0} ", myGame.Grid.Length);
            Console.WriteLine("Nombre de ligne = {0} ", myGame.Grid.GetLength(0));//GetLength(0) :nbr ligne; GetLength(1):nbr colones
            Console.WriteLine("Grid[0,0] = {0}", myGame.Grid[0,0]); //affichage case d'indice (0,0)

            Console.WriteLine(); Console.WriteLine("~~~~ PanelGame ~~~~"); Console.WriteLine();
            DisplayGrid(myGame.Grid);

            Console.ReadKey();


        }

        //method pour affichege matrice
        private static void DisplayGrid(byte[,] p)
        {   //for tab tab
            for (int i = 0; i < p.GetLength(0); i++)
            {
                for (int j = 0; j < p.GetLength(1); j++)
                {
                    if (p[i,j]==0) //c'est une case vide
                       Console.Write(" - ");

                    else if (p[i, j] == 9) //c'est une bombe
                        Console.Write(" * ");

                    else //c'est un chiffre entre 1 et 8
                        Console.Write(" {0} ", p[i,j] );
                }
                Console.WriteLine();//pour un bien affichage de matrice et retour à la ligne 
            }
        }
    }
}
