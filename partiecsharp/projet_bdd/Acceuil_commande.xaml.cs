﻿using System;
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
    /// Logique d'interaction pour Acceuil_commande.xaml
    /// </summary>
    public partial class Acceuil_commande : Window
    {
        public Acceuil_commande()
        {
            InitializeComponent();
        }

        private void commande(object sender, RoutedEventArgs e)
        {
            Commande a = new Commande();
            a.Show();
            this.Close();
        }

        private void retour(object sender, RoutedEventArgs e)
        {
            MainWindow a = new MainWindow();
            a.Show();
            this.Close();
        }
    }
}
