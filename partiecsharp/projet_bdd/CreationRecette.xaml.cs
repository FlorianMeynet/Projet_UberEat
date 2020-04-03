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
    /// Logique d'interaction pour CreationRecette.xaml
    /// </summary>
    public partial class CreationRecette : Window
    {
        public CreationRecette()
        {
            InitializeComponent();
            for (int k = 0; k< 11; k++)
                {
                nombre.Items.Add(k.ToString());
                }


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


            string requete = "Select Nom from Recette;";
            MySqlCommand command1 = maConnexion.CreateCommand();
            command1.CommandText = requete;

            MySqlDataReader reader = command1.ExecuteReader();
            command1.Dispose();

            while (reader.Read())
            {
                if (reader.GetValue(0).ToString() != "")
                {
                    elementchoisi.Items.Add(reader.GetValue(0).ToString());
                }
            }


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


            string nomrecettee = nomrecette.Text;
            string descriptife = descriptif.Text;
            float prixs = float.Parse(prix.Text);
            string? listeingrediente = listBox1.Items.ToString(); // Il faudra verifier cette récuperation


            string requete = "Select Nom from Recette;";
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
                string requete2 = "insert into tableprojet.recette(`Nom`,`descriptif`,`prix`,`listingredient`) Values(" + nomrecette + "," + descriptife + "," + prixs + "," + listeingrediente+");";
                MySqlCommand command2 = maConnexion.CreateCommand();
                command1.CommandText = requete2;

                MySqlDataReader reader2 = command2.ExecuteReader();
                command2.Dispose();
            }
        }

        private void Retour(object sender, RoutedEventArgs e)
        {
            Acceuil a = new Acceuil();
            a.Show();
            this.Close();
        }

        private void ajout(object sender, RoutedEventArgs e)
        {
            if (this.elementchoisi.Text != "")
            {
                listBox1.Items.Add(this.elementchoisi.Text + " : " + this.nombre.Text);
            }
            else
            {
                MessageBox.Show("Veuillez choisir un ingrédient");

            }
        }


    }
}
