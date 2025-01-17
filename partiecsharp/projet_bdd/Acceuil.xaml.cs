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
using MySql.Data.MySqlClient;

namespace projet_bdd
{
    /// <summary>
    /// Logique d'interaction pour Acceuil.xaml
    /// </summary>
    public partial class Acceuil : Window
    {
        public Acceuil()
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

        private void cree_plat(object sender, RoutedEventArgs e)
        {
            CreationRecette a = new CreationRecette();
            a.Show();
            this.Close();

        }
    }
}
