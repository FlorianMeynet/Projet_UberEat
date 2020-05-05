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
            pseudo.Content = ClientStatic.mail;
            Credit.Content = ClientStatic.capitalCooks.ToString();

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;DATABASE=tableprojet;UID=root;PASSWORD="+mot_de_passe.mot_dp+";";
                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException er)
            {
                MessageBox.Show(" ErreurConnexion : " + er.ToString());
                return;
            }
            
            string requete_entree = "Select Nom from recette where categorie='Entrée';";   
            MySqlCommand command1 = maConnexion.CreateCommand();
            command1.CommandText = requete_entree;
            MySqlDataReader reader1 = command1.ExecuteReader();

            while (reader1.Read())
            {
                entree.Items.Add(reader1["Nom"].ToString());  //Ajout dans la combobox des entree
            }
            command1.Dispose();
            reader1.Close();

            string requete_plat = "Select Nom from recette where categorie='Plat';";
            MySqlCommand command2 = maConnexion.CreateCommand();
            command2.CommandText = requete_plat;
            MySqlDataReader reader2 = command2.ExecuteReader();

            while (reader2.Read())
            {
                plat.Items.Add(reader2["Nom"].ToString());   //Ajout des plats dans la comboBox

            }
            command2.Dispose();
            reader2.Close();

            string requete_dessert = "Select Nom from recette where categorie='Dessert';";
            MySqlCommand command3 = maConnexion.CreateCommand();
            command3.CommandText = requete_dessert;
            MySqlDataReader reader3 = command3.ExecuteReader();

            while (reader3.Read())
            {
                dessert.Items.Add(reader3["Nom"].ToString());  //Ajout des desserts dans la comboBox

            }
            command3.Dispose();
            reader3.Close();
            
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
                return;
            }
            

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;DATABASE=tableprojet;UID=root;PASSWORD=" + mot_de_passe.mot_dp + ";";
                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException er)
            {
                Console.WriteLine(" ErreurConnexion : " + er.ToString());
            }
            MessageBox.Show(choix);
            string requete_list_ingre = "Select r.idRecette,l.idIngredient1,l.quantite from Liste_ingredient l join recette r on l.idRecette1=r.idRecette  where r.Nom='" + choix + "';";
            MySqlCommand command_list = maConnexion.CreateCommand();
            command_list.CommandText = requete_list_ingre;
            
            MySqlDataReader reader_list = command_list.ExecuteReader();

            List<string> list_ingredient = new List<string>();
            while (reader_list.Read())
            {
                list_ingredient.Add(reader_list.GetValue(1).ToString()+"-"+ reader_list.GetValue(2).ToString()); 
            }
            int id_r= int.Parse(reader_list.GetValue(0).ToString());
            reader_list.Close();
            command_list.Dispose();

            bool estStock = true;
            foreach(string id_ingre in list_ingredient)
            {
                if (Estenstock(id_ingre)==false)
                {
                    estStock = false;
                }
            }

            if(estStock == true)
            {
                Panier.listIdRecette.Add(id_r);
            }
            MessageBox.Show(Panier.listIdRecette.ToString());
            Commande new_win = new Commande();
            this.Close();
            new_win.Show();
        }
        private bool Estenstock(string nom_plat)
        {
            List<string> chaque_ingredient = new List<string>();
            string[] ingre = nom_plat.Split("-"); 

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;DATABASE=tableprojet;UID=root;PASSWORD=" + mot_de_passe.mot_dp + "; ";
                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException er)
            {
                MessageBox.Show(" ErreurConnexion : " + er.ToString());
            }

            string requete_assez_stock = "Select quantite from stock  where idIngredient=" + int.Parse(ingre[0]) + ";";
            MySqlCommand command_stock = maConnexion.CreateCommand();
            command_stock.CommandText = requete_assez_stock;
            MySqlDataReader reader_stock = command_stock.ExecuteReader();
            reader_stock.Read();
            float stock = float.Parse(reader_stock.GetValue(0).ToString());
            reader_stock.Close();
            command_stock.Dispose();
            MessageBox.Show(stock.ToString()+"   "+ingre[1]+" "+ingre[0]);
            if (stock < float.Parse(ingre[1]))
            {
                return (false);  //Manque ingredient
            }

            return (true);
            
            
            
        }
    }
}
