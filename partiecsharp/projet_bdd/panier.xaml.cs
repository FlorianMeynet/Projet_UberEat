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
    /// Logique d'interaction pour panier.xaml
    /// </summary>
    public partial class panier : Window
    {
        public panier()
        {
            InitializeComponent();
            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;DATABASE=tableprojet;UID=root;PASSWORD=password_login;";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException er)
            {
                Console.WriteLine(" ErreurConnexion : " + er.ToString());
                return;
            }

            foreach(int id in Panier.listIdRecette)
            {
                string requete_recette = "SELECT Nom , prix  FROM Recette WHERE idRecette=" + id.ToString() + ";";
                MySqlCommand command_recette = maConnexion.CreateCommand();
                command_recette.CommandText = requete_recette;
                MySqlDataReader reader_recette = command_recette.ExecuteReader();
                command_recette.Dispose();

                Recette.Items.Add(reader_recette.GetValue(0).ToString());
                Prix.Items.Add(reader_recette.GetValue(1).ToString() + "₭");
                prix_tot.Text = (int.Parse(prix_tot.Text) + int.Parse(reader_recette.GetValue(1).ToString())).ToString();  //A verifier si ca marche
            }
        }

        private void Retour(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void valider_panier(object sender, RoutedEventArgs e)
        {
            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;DATABASE=tableprojet;UID=root;PASSWORD=password_login;";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException er)
            {
                Console.WriteLine(" ErreurConnexion : " + er.ToString());
                return;
            }
            int prix_totale_commande = int.Parse(prix_tot.Text);
            if (ClientStatic.capitalCooks > prix_totale_commande)
            {
                ClientStatic.capitalCooks = ClientStatic.capitalCooks - prix_totale_commande;
                
                foreach (int i in Panier.listIdRecette)
                {
                    Enlever_ingredient_dans_stock(i);
                }
                //Envoyer toutes les infos aux personnes d'apres !!
            }
            else
            {
                erreur a = new erreur();
                a.Show();
                Console.WriteLine("Trop pauvre");
            }
        }
        private void Enlever_ingredient_dans_stock(int id)
        {
            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;DATABASE=tableprojet;UID=root;PASSWORD=password_login;";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException er)
            {
                Console.WriteLine(" ErreurConnexion : " + er.ToString());
                return;
            }

            string requete_select_ingredient = "Select listingredient from recette where idRecette=" + id + ";";
            MySqlCommand command_ingredient = maConnexion.CreateCommand();
            command_ingredient.CommandText = requete_select_ingredient;
            MySqlDataReader reader_ingredient = command_ingredient.ExecuteReader();
            command_ingredient.Dispose();

            string list_ingredient = reader_ingredient.GetValue(0).ToString();
            string[] list_in = list_ingredient.Split("/");

            foreach (string ingre in list_in)
            {
                string[] i = ingre.Split(":");  // i[0] : ingredient
                string[] new_i = i[1].Split("-");  // new_i[0] : quantité   new_i[1]: unité

                string requete_select_id = "Select idIngredient from Ingredient where Nom=" + i[0] + ";";
                MySqlCommand command_id = maConnexion.CreateCommand();
                command_id.CommandText = requete_select_id;
                MySqlDataReader reader_id = command_id.ExecuteReader();
                command_id.Dispose();
                int id_in = int.Parse(reader_id.GetValue(0).ToString());

                Enelver_quantite(id_in, int.Parse(new_i[0]));  //On enleve la quantié pour chaque ingredient de la recette
            }
        }
        public void Enelver_quantite(int ingre,int quantite)
        {
            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;DATABASE=tableprojet;UID=root;PASSWORD=password_login;";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException er)
            {
                Console.WriteLine(" ErreurConnexion : " + er.ToString());
                return;
            }

            string requete_quantite = "Select quantite from stock where idIngredient=" + ingre.ToString() + ";";
            MySqlCommand command_quantite = maConnexion.CreateCommand();
            command_quantite.CommandText = requete_quantite;
            MySqlDataReader reader_quantite = command_quantite.ExecuteReader();
            command_quantite.Dispose();

            int q = int.Parse(reader_quantite.GetValue(0).ToString());
            int cequi_reste = q - quantite;

            string requete_remplacement_quantite = "UPDATE `stock` SET `quantite`=" + cequi_reste + " WHERE idIngredient=" + ingre.ToString() + ";";  //Remplacer la quantite par la nouvelle 
            MySqlCommand command_remplacement = maConnexion.CreateCommand();
            command_remplacement.CommandText = requete_remplacement_quantite;
            MySqlDataReader reader_remplacement = command_remplacement.ExecuteReader();  //Je sais pas si y a besoin ??
            command_remplacement.Dispose();
        }
    }
}
