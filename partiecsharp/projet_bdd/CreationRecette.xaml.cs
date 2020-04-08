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

            string nomrecettee = nomrecette.Text;  //Nom saisi
            string descriptife = descriptif.Text;  //Descriptif
            float prixs = float.Parse(prix.Text);  //Prix
            string listeingrediente = ""; 
            foreach (string valeur in listBox1.Items)
            {
                string[] a=valeur.Split(":");
                string[] new_a1 = a[1].Split("-");
                listeingrediente += a[0] + " : " + new_a1[0] +" "+new_a1[1]+ " / ";  //Ajout d'un ingredient dans les listes des ingredients
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

            string requete = "Select Nom from Recette where categorie="+cat+";";   //On verifie que le nom de la recette n'existe pas deja
            MySqlCommand command1 = maConnexion.CreateCommand();
            command1.CommandText = requete;

            MySqlDataReader reader = command1.ExecuteReader();
            command1.Dispose();
            bool existe = false;

            while (reader.Read())
            {
                if (nomrecettee == reader.GetValue(0).ToString()) //La valeur 0 c'est le nom car tu select que le nom
                {
                    existe = true;
                }
            }

            if (existe == false)
            {
                string requete2 = "insert into tableprojet.recette(`Nom`,`descriptif`,`prix`,`listingredient`,`idCreateur`,`categorie`) Values(" + nomrecette + "," + descriptife + "," + prixs + "," + listeingrediente+ ClientStatic.idCreateur + cat +");";
                MySqlCommand command2 = maConnexion.CreateCommand();
                command1.CommandText = requete2;

                MySqlDataReader reader2 = command2.ExecuteReader();
                command2.Dispose();
            }
        }

        private void ajout(object sender, RoutedEventArgs e)
        {
            //VOIR SI Y A BESOIN
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
            command1.Dispose();
            


            List<List<string>> list_ingre = new List<List<string>>();
            while (reader.Read())
            {
                List<string> l = new List<string>();
                l.Add(reader.GetValue(0).ToString());
                l.Add(reader.GetValue(1).ToString());
                list_ingre.Add(l);
                ingredient.Items.Add(reader.GetValue(0).ToString());
            }

            if (this.ingredient.Text != "" && this.nombre.Text.Trim(' ') != "")
            {
                foreach (List<string> l in list_ingre)
                {
                    if (l[0] == this.ingredient.Text)
                    {
                        string cat = l[1];
                        listBox1.Items.Add(this.ingredient.Text + " : " + this.nombre.Text + "-" + cat);
                    }
                    else
                    {
                        MessageBox.Show("probleme");
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
