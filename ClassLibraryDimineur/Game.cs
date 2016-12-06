using System;

namespace ClassLibraryDimineur
{
    //internal class Game: internal c'est une classe visualisee dans le meme package seulement
    public class Game
    {
        //attributes
        private byte bombs2; //champ par deafaut est private et private pour assurer l'encapsulation

        //getter+setter <=> properties
        //getter+setter d'une façon classique
        public byte GetBOmbs2()
        { return this.bombs2; }

        //protected method càd visualisee pour la classe elle meme et ces filles
        public void SetBombs2(byte Bombs)
        { this.bombs2 = Bombs; }

        //properties (version c# 100%)
        //version compléte
        //propfull tab tab pour avoir la structure des "properties"
        private byte bombs3;

        public byte Bombs3
        {
            get { return bombs3; } //mode lecture
            set { bombs3 = value; } //mode écriture
        }

        //version auto(auto implemanted properties)
        //prop tab tab
        public byte Bombs4 { get; set; }

        //version auto private
        //propg tab tab
        public byte Bombs { get; private set; } //cette version respecte bien le principe de l'encapsulation
                                                //en donnant le droit seulement en mode lecture

        //declaration de la matrice "grid" du jeu
        public byte[,] Grid { get; private set; }

        //construct
        //ctor tab tab 
        //celui là est un instance d'instance
        public Game(byte lines, byte columns, byte bombs)
        {
            this.Grid = new byte[lines, columns];

            //controle sur le nbr des bombs si'il est supérieur a la taille du matrice 
            if (Bombs >= 1 && Bombs <= this.Grid.Length)
                this.Bombs = bombs;
            else
                this.Bombs = (byte)this.Grid.Length;//cast car int in byte impoosible

            this.Grid = new byte[lines, columns];
        }



        /// <summary>
        /// Ce constructeur permet d'initialiser la classe Game
        /// en fonction de niveau...
        /// </summary>
        /// <param name="level">represente le niveau du jeu</param>
        //2 eme constructeur qui accepte le nievau du jeu
        public Game(GameLevel level)
        {
            this.Bombs = (byte)level;//manipuler le nombre des bombes
            //manipuler le nbr de lignes et de colones de la matrice selon le niveau du jeu
            switch (level)
            {
                case GameLevel.Beginner:
                    this.Grid = new byte[9, 9];
                    break;
                case GameLevel.Inter:
                    this.Grid = new byte[16, 16];
                    break;
                case GameLevel.Advanced:
                    this.Grid = new byte[16, 30];
                    break;
                default:
                    break;
            }
            //aprés avoir choisi un niveau on remplit notre matrice à l'aide de la methode setBombs()
            setBombs();
            setDigits();
        }

        //types des levels de la jeu 


        
        #region methodes
        //methode 1 pour remplissage des bombes
        void setBombs()
        {
            //objet de la classe Random nous aide à un remplissage aléatoire
            Random rnd = new Random();
            //boucle while pour remplisssage des cases de la matrice
            int cpt = 1;
            while (cpt <= Bombs)
            {
                //rnd.Next(): methode predefinie pour chosir un i & j des chiffres aléatoires
                int i = rnd.Next(0, Grid.GetLength(0));// o pour dire nombre de lignes
                int j = rnd.Next(0, Grid.GetLength(1));// 1 pour dire nombre de colonnes
                if (Grid[i, j] != 9)
                {
                    Grid[i, j] = 9;
                    cpt++;
                }
            }
        }

        //methode 2 pour le remplissage des chifferes
        void setDigits()
        {//4 boucles de parcours
         //2 for the hole grid
         //2 for the small grid 
            for (int i = 0; i < this.Grid.GetLength(0) ; i++)
            {
                for (int j = 0; j < this.Grid.GetLength(1) ; j++)
                {
                    if (Grid[i, j] == 9)
                    {
                        for (int x = i - 1; x <= i + 1; x++)
                        {
                            for (int y = j - 1; y <= j + 1; y++)
                            {   if (x>=0 && y>=0 && x<Grid.GetLength(0) && y<Grid.GetLength(1))
                                if (Grid[x, y] != 9)
                                {
                                    Grid[x, y]++;
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion



        //even+delegate+indexers+nested classes
    }

    public enum GameLevel
    {
        //10 ,40, 99 se sont les nombres des bombes à mettre dans la matrice
        Beginner = 10,   //0 indice
        Inter = 40,     //1
        Advanced = 99  //2
    }

}
