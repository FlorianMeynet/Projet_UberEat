using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace projet_bdd
{
    /// <summary>
    /// Logique d'interaction pour CreationRecette.xaml
    /// </summary>
    public partial class CreationRecette : Window
    {
        public CreationRecette()
        {
            InitializeComponent();
        }

        private void Validation(object sender, RoutedEventArgs e)
        {
        //Création d'une nouvelle recette
        }

        private void Retour(object sender, RoutedEventArgs e)
        {
            MainWindow a = new MainWindow();
            a.Show();
            this.Close();
        }
    }
}
