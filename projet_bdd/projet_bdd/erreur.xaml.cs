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
    /// Logique d'interaction pour erreur.xaml
    /// </summary>
    public partial class erreur : Window
    {
        public erreur()
        {
            InitializeComponent();
        }

        private void ok(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
