using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClassLibraryDimineur;

namespace WpfApplicationDimineur
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int line;
        int column;
        Game g1;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Set my StackPanel Background
            //PanelGame.Background = new SolidColorBrush(Colors.GhostWhite);

            #region 10 Columns
            GameGrid.ColumnDefinitions.Add(new ColumnDefinition());
            GameGrid.ColumnDefinitions.Add(new ColumnDefinition());
            GameGrid.ColumnDefinitions.Add(new ColumnDefinition());
            GameGrid.ColumnDefinitions.Add(new ColumnDefinition());
            GameGrid.ColumnDefinitions.Add(new ColumnDefinition());
            GameGrid.ColumnDefinitions.Add(new ColumnDefinition());
            GameGrid.ColumnDefinitions.Add(new ColumnDefinition());
            GameGrid.ColumnDefinitions.Add(new ColumnDefinition());
            GameGrid.ColumnDefinitions.Add(new ColumnDefinition());
            GameGrid.ColumnDefinitions.Add(new ColumnDefinition());
            #endregion  
            #region 10 Rows
            GameGrid.RowDefinitions.Add(new RowDefinition());
            GameGrid.RowDefinitions.Add(new RowDefinition());
            GameGrid.RowDefinitions.Add(new RowDefinition());
            GameGrid.RowDefinitions.Add(new RowDefinition());
            GameGrid.RowDefinitions.Add(new RowDefinition());
            GameGrid.RowDefinitions.Add(new RowDefinition());
            GameGrid.RowDefinitions.Add(new RowDefinition());
            GameGrid.RowDefinitions.Add(new RowDefinition());
            GameGrid.RowDefinitions.Add(new RowDefinition());
            GameGrid.RowDefinitions.Add(new RowDefinition());
            #endregion
            
        }
        //btImage to set backGround Image
        private void btImage_Click(object sender, RoutedEventArgs e)
        {
            #region OpenFileDialog

            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Choisir une photo";
            op.Filter = "Images|*.jpg;*.jpeg;*.png|" + "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" + "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                imgPhoto.Source = new BitmapImage(new Uri(op.FileName));
                //MessageBox.Show("image bien sélectionné", "Information ", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            #endregion
            
            #region Background Image
            // Create Image object
            Image dynamicImage = new Image();
            dynamicImage.Height = 200;
            dynamicImage.Width = 200;
            //GameGrid.Margin = new Thickness(0, 0, 27, 0);

            // Set Image.Source  
            dynamicImage.Source = imgPhoto.Source;

            // Add Image to Grid  
            GameGrid.Children.Add(dynamicImage);
            #endregion

        }

        private void optNiv1_Checked(object sender, RoutedEventArgs e)
        {
            g1 = new Game(GameLevel.Beginner);
        }

        private void btStart_Click(object sender, RoutedEventArgs e)
        {
            line = g1.Grid.GetLength(0);
            column = g1.Grid.GetLength(1);

            //create the PanelGame Grid
            for (int i = 0; i < line; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    Button b = new Button();
                    // b.Content = string.Format("Row: {0}, Column: {1}", i, j);
                    b.Height = 25; b.Width = 25;
                    b.Background = new SolidColorBrush(Colors.PaleTurquoise);
                    Grid.SetRow(b, i);
                    Grid.SetColumn(b, j);
                    b.Content = g1.Grid[i, j].ToString();
                    GameGrid.Children.Add(b);
                }
            }
        }
    }
}
