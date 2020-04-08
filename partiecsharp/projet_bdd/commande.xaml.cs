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
    /// Logique d'interaction pour Commande.xaml
    /// </summary>
    public partial class Commande : Window
    {
        public Commande()
        {
            InitializeComponent();

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;DATABASE=tableprojet;UID=root;PASSWORD=4F10e6bff@;";
                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException er)
            {
                Console.WriteLine(" ErreurConnexion : " + er.ToString());
                return;
            }

            
            string requete_entree = "Select Nom from Recette where categorie=Entrée;";   
            MySqlCommand command1 = maConnexion.CreateCommand();
            command1.CommandText = requete_entree;
            MySqlDataReader reader1 = command1.ExecuteReader();
            command1.Dispose();

            while (reader1.Read())
            {
                entree.Items.Add(reader1.GetValue(0).ToString());  //Ajout dans la combobox des entree
            }


            string requete_plat = "Select Nom from Recette where categorie=Plat;";
            MySqlCommand command2 = maConnexion.CreateCommand();
            command2.CommandText = requete_plat;
            MySqlDataReader reader2 = command2.ExecuteReader();
            command1.Dispose();

            while (reader2.Read())
            {
                plat.Items.Add(reader2.GetValue(0).ToString());   //Ajout des plats dans la comboBox
            }


            string requete_dessert = "Select Nom from Recette where categorie=Dessert;";
            MySqlCommand command3 = maConnexion.CreateCommand();
            command3.CommandText = requete_dessert;
            MySqlDataReader reader3 = command3.ExecuteReader();
            command1.Dispose();

            while (reader3.Read())
            {
                dessert.Items.Add(reader3.GetValue(0).ToString());  //Ajout des desserts dans la comboBox
            }

            pseudo.Text = ClientStatic.mail;
            Credit.Text = ClientStatic.capitalCooks.ToString();

        }

        private void retour(object sender, RoutedEventArgs e)
        {
            Acceuil a = new Acceuil();
            a.Show();
            this.Close();
        }
        private void afficher_panier(object sender, RoutedEventArgs e)
        {
            panier a = new panier();
            a.Show();
        }

        private void deco_Click(object sender, RoutedEventArgs e)
        {
            MainWindow a = new MainWindow();
            a.Show();
            this.Close();
        }

        private void Confirmer(object sender, RoutedEventArgs e)
        {
            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;DATABASE=tableprojet;UID=root;PASSWORD=4F10e6bff@;";
                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException er)
            {
                Console.WriteLine(" ErreurConnexion : " + er.ToString());
                return;
            }


            string entreee = dessert.Text;
            string plate = plat.Text;
            string desserte = dessert.Text;

            string requete = "Select Nom from Cuisine;";
            MySqlCommand command1 = maConnexion.CreateCommand();
            command1.CommandText = requete;

            MySqlDataReader reader = command1.ExecuteReader();
            command1.Dispose();
            bool enreste = false;

            //Il faut alors tchecker pour le plat l'entree et le dessert si il est en stock, puis faire un message d'erreur si il est en stock ou pas en fonction du produit. Puis gerer le stocj avec la table cuisine
            
        }
    }
}
