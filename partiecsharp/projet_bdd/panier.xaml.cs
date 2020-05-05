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
                string connexionString = "SERVER=localhost;PORT=3306;DATABASE=tableprojet;UID=root;PASSWORD=" + mot_de_passe.mot_dp + ";convert zero datetime=True";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException er)
            {
                Console.WriteLine(" ErreurConnexion : " + er.ToString());
                return;
            }
            List<int> liste = Panier.listIdRecette;
            if (liste == null)
            {
                Recette.Items.Add("Panier vide");
            }
            else
            {

                foreach (int id in liste)
                {
                    string requete_recette = "SELECT Nom , prix  FROM Recette WHERE idRecette=" + id.ToString() + ";";
                    MySqlCommand command_recette = maConnexion.CreateCommand();
                    command_recette.CommandText = requete_recette;
                    MySqlDataReader reader_recette = command_recette.ExecuteReader();
                    reader_recette.Read();
                    Recette.Items.Add(reader_recette.GetValue(0).ToString());
                    Prix.Items.Add(reader_recette.GetValue(1).ToString() + "₭");
                    MessageBox.Show(prix_tot.Text.ToString() + "  " + reader_recette.GetValue(1).ToString());
                    int prix_t = int.Parse(prix_tot.Text.ToString()) + (int.Parse(reader_recette.GetValue(1).ToString()));
                    prix_tot.Text = prix_t.ToString();
                    reader_recette.Close();
                    command_recette.Dispose();
                }
            }
        }


        private void Retour(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void valider_panier(object sender, RoutedEventArgs e)
        {
            if (Panier.FaitTravailCommande(int.Parse(prix_tot.Text)))
            {
                MessageBox.Show("Merci pour votre achat, vous serez livré dans les plus brefs délais");

            }
            Panier.PanierVide();
        }
    }
}
