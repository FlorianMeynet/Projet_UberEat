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

            while (reader1.Read())
            {
                entree.Items.Add(reader1.GetValue(0).ToString());  //Ajout dans la combobox des entree
            }
            command1.Dispose();
            reader1.Close();


            string requete_plat = "Select Nom from Recette where categorie=Plat;";
            MySqlCommand command2 = maConnexion.CreateCommand();
            command2.CommandText = requete_plat;
            MySqlDataReader reader2 = command2.ExecuteReader();
            

            while (reader2.Read())
            {
                plat.Items.Add(reader2.GetValue(0).ToString());   //Ajout des plats dans la comboBox
            }
            command2.Dispose();
            reader2.Close();

            string requete_dessert = "Select Nom from Recette where categorie=Dessert;";
            MySqlCommand command3 = maConnexion.CreateCommand();
            command3.CommandText = requete_dessert;
            MySqlDataReader reader3 = command3.ExecuteReader();
            

            while (reader3.Read())
            {
                dessert.Items.Add(reader3.GetValue(0).ToString());  //Ajout des desserts dans la comboBox
            }
            command3.Dispose();
            reader3.Close();

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

        private void ajouter_commande(object sender, RoutedEventArgs e)
        {
            string choix_entree = entree.Text;
            string choix_plat = plat.Text;
            string choix_dessert = dessert.Text;
            string choix_boisson = Boissons.Text;
            string choix="";
            if(choix_entree != "Choisir une entrée")
            {
                choix = choix_entree;
            }
            else if(choix_plat != "Choisir un plat")
            {
                choix = choix_plat;
            }
            else if (choix_dessert != "Choisir un dessert")
            {
                choix = choix_dessert;
            }
            else if (choix_boisson != "Choisir une boisson")
            {
                choix = choix_boisson;
            }
            else
            {
                Console.WriteLine("erreur rien n'est choisi");
                erreur pb = new erreur();
                pb.Show();
            }


            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;DATABASE=tableprojet;UID=root;PASSWORD=mdp;";
                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException er)
            {
                Console.WriteLine(" ErreurConnexion : " + er.ToString());
            }

            string requete_list_ingre = "Select idRecette,listingredient,idCreateur from Recette where Nom=" + choix + ";";
            MySqlCommand command_list = maConnexion.CreateCommand();
            command_list.CommandText = requete_list_ingre;
            
            MySqlDataReader reader_list = command_list.ExecuteReader();
            command_list.Dispose();
            string list_ingredient = reader_list.GetValue(1).ToString();
            int id = int.Parse(reader_list.GetValue(0).ToString());
            if (Estenstock(list_ingredient))
            {
                Panier.listIdRecette.Add(id);  //Ajouter dans le panier
                //Gerer le fait que on enleve du stock ici ou seulement lors de la commande
            }
        }
        private bool Estenstock(string nom_plat)
        {
            string[] list_in=nom_plat.Split("/");
            List<List<string>> list_recup = new List<List<string>>();
            foreach (string ingre in list_in)
            {
                List<string> chaque_ingredient = new List<string>();
                string[] i = ingre.Split(":");  // i[0] : ingredient
                chaque_ingredient.Add(i[0]);
                string[] new_i = i[1].Split("-");  // new_i[0] : quantité   new_i[1]: unité
                chaque_ingredient.Add(new_i[0]);
                chaque_ingredient.Add(new_i[1]);
                list_recup.Add(chaque_ingredient); //A la fin on a une liste de tous les ingredients
            }

            //Connexion a la base
            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;DATABASE=tableprojet;UID=root;PASSWORD=mdp;";
                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException er)
            {
                Console.WriteLine(" ErreurConnexion : " + er.ToString());
            }

            foreach (List<string> l in list_recup)
            {
                string requete_assez_stock = "Select s.quantite from stock s join ingredient i on i.idIngredient=s.idIngredient where i.Nom=" + l[0] + ";";
                MySqlCommand command_stock = maConnexion.CreateCommand();

                MySqlDataReader reader_stock = command_stock.ExecuteReader();
                command_stock.Dispose();
                int stock = int.Parse(reader_stock.GetValue(0).ToString());
                if (stock < int.Parse(l[1]))
                {
                    return (false);
                }
            }
            return(true);  //On a un stock de chaque ingredient
        }
    }
}
