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
using MySql.Data.MySqlClient;

namespace projet_bdd
{ 
  
    /// <summary>
    /// Logique d'interaction pour paiement.xaml
    /// </summary>
    public partial class paiement : Window
    {
        public float rate = 42; // 1 cooks = rate euros
        public paiement()
        {
            InitializeComponent();
            tauxdechange.Text += rate.ToString();
        }

        private void Changer(object sender, RoutedEventArgs e)
        {
            
            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;DATABASE=tableprojet;UID=root;PASSWORD=" + mot_de_passe.mot_dp + ";convert zero datetime=True";
                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException er)
            {
                Console.WriteLine(" ErreurConnexion : " + er.ToString());
                return;
            }



            string requete = " UPDATE `tableprojet`.`Client` SET `capitalCooks` = '"+(ClientStatic.capitalCooks+float.Parse(quantitesouhaite.Text)) +"' WHERE(`idClient` = '"+ClientStatic.idClient+"');";
            ClientStatic.capitalCooks += int.Parse(quantitesouhaite.Text);
            MySqlCommand command1 = maConnexion.CreateCommand();
            command1.CommandText = requete;

            MySqlDataReader reader = command1.ExecuteReader();
            reader.Read();
            reader.Close();
            command1.Dispose();
            maConnexion.Close();
           

        }

        private void retour(object sender, RoutedEventArgs e)
        {

        }

        private void quantitesouhaite_TextChanged(object sender, TextChangedEventArgs e)
        {
            quantiteapayer.Text = (float.Parse(quantitesouhaite.Text) * rate).ToString();
        }

        private void quantiteapayer_TextChanged(object sender, TextChangedEventArgs e)
        {
            quantitesouhaite.Text = (float.Parse(quantiteapayer.Text) * 1/rate).ToString();
        }
    }
}
