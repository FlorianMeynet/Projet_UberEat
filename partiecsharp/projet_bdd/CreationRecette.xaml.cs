using System;
using System.Collections.Generic;
using System.Security.Cryptography;
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
    /// Logique d'interaction pour CreationRecette.xaml
    /// </summary>
    public partial class CreationRecette : Window
    {
        public CreationRecette()
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
            string requette_affichage_ingredient = "select Nom from ingredient i join stock s on s.idIngredient = i.idIngredient  where s.quantite > s.quantiteMin;";

            MySqlCommand command_affichage = maConnexion.CreateCommand();
            command_affichage.CommandText = requette_affichage_ingredient;
            MySqlDataReader reader = command_affichage.ExecuteReader();
            while (reader.Read())
            {
                ingredient.Items.Add(reader["Nom"].ToString());
            }
            command_affichage.Dispose();
        }

        private void Validation(object sender, RoutedEventArgs e)
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

            string nom_recette = nomrecette.Text.ToString();  //Nom saisi
            string descriptife = descriptif.Text.ToString();  //Descriptif
            float prixs = float.Parse(prix.Text.ToString());  //Prix
            string listeingrediente = ""; 
            foreach (string valeur in listBox1.Items)
            {
                listeingrediente += valeur + " / ";  //Ajout d'un ingredient dans les listes des ingredients
            }
            string cat="";

            if (entree.IsChecked == true)
            {
                cat ="Entrée";
            }
            else if (plat.IsChecked == true)
            {
                cat ="Plat";   
            }
            else if(dessert.IsChecked==true)
            {
                cat =  "Dessert";
            }

            string requete = "Select Nom from Recette where categorie='"+cat+"';";   //On verifie que le nom de la recette n'existe pas deja
            MySqlCommand command1 = maConnexion.CreateCommand();
            command1.CommandText = requete;

            MySqlDataReader reader = command1.ExecuteReader();
            bool existe = false;

            while (reader.Read())
            {
                if (nom_recette == reader.GetValue(0).ToString()) //La valeur 0 c'est le nom car tu select que le nom
                {
                    existe = true;
                    MessageBox.Show("Un recette avec le meme nom existe deja");
                }
            }
            command1.Dispose();

            if (existe == false)
            {
                string requete2 = "insert into tableprojet.recette(`Nom`,`descriptif`,`prix`,`listingredient`,`idCreateur`,`categorie`) Values('" +nom_recette + "','" + descriptife + "'," + prixs + ",'" + listeingrediente+"',"+ ClientStatic.idCreateur +",'"+ cat +"');";
                MessageBox.Show(requete2);
                MySqlCommand command2 = maConnexion.CreateCommand();
                command2.CommandText = requete2;

                MySqlDataReader reader2 = command2.ExecuteReader();
                command2.Dispose();
                MessageBox.Show("Merci pour la creation de la recette");
                Acceuil pa = new Acceuil();
                pa.Show();
                this.Close();

            }
        }

        private void ajout(object sender, RoutedEventArgs e)
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

            string requete = "Select Nom,categorie from Ingredient;";
            MySqlCommand command1 = maConnexion.CreateCommand();
            command1.CommandText = requete;
            MySqlDataReader reader = command1.ExecuteReader();
            
            List<List<string>> list_ingre = new List<List<string>>();
            while (reader.Read())
            {
                List<string> l = new List<string>();
                l.Add(reader.GetValue(0).ToString());
                l.Add(reader.GetValue(1).ToString());
                list_ingre.Add(l);
            }
            command1.Dispose();

            if (this.ingredient.Text != "" && this.nombre.Text.Trim(' ') != "" && this.nombre.Text.Trim(' ') != "0")
            {
                foreach (List<string> l in list_ingre)
                {
                    if (l[0] == this.ingredient.Text)
                    {
                        string cat = l[1];
                        listBox1.Items.Add(this.ingredient.Text + " : " + this.nombre.Text + "-" + cat);
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez choisir un ingrédient");
            }
        }
        private void Retour(object sender, RoutedEventArgs e)
        {
            Acceuil a = new Acceuil();
            a.Show();
            this.Close();
        }
    }
}
