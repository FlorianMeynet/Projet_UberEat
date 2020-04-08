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
    /// Logique d'interaction pour panier.xaml
    /// </summary>
    public partial class panier : Window
    {
        public panier()
        {
            InitializeComponent();
        }

        private void Retour(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void valider_panier(object sender, RoutedEventArgs e)
        {
            //Traiter les infos commander
        }
    }
}
