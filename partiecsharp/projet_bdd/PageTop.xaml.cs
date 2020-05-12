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
    /// Logique d'interaction pour PageTop.xaml
    /// </summary>
    public partial class PageTop : Window
    {
        public PageTop()
        {
            InitializeComponent();
            MySqlConnection maConnexion = null;


            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;DATABASE=peertoprint;UID=root;PASSWORD=" + mot_de_passe.mot_dp + ";";
                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException er)
            {
                MessageBox.Show(" ErreurConnexion : " + er.ToString());
                return;
            }
            string requete_affichagepseudo = "SELECT c.nom,count(co.idCommande) from commande as co JOIN client as c ON co.idClient=c.idClient  ORDER BY count(co.idCommande) DESC;";
            MySqlCommand command1 = maConnexion.CreateCommand();
            command1.CommandText = requete_affichagepseudo;
            MySqlDataReader reader = command1.ExecuteReader();
            int i = 0;
            while (reader.Read())
            {
                if (i == 0)
                {
                    nomclient1.Text = reader.GetValue(0).ToString();
                    nombreCOMMANDE1.Text += " "+reader.GetValue(1).ToString()+" fois";

                }

                if (i == 1)
                {
                    nomclient2.Text = reader.GetValue(0).ToString();
                    nombreCOMMANDE2.Text += " "+reader.GetValue(1).ToString()+" fois";

                }

                if (i == 2)
                {
                    nomclient3.Text = reader.GetValue(0).ToString();
                    nombreCOMMANDE3.Text +=" "+ reader.GetValue(1).ToString() + " fois";

                }
                i++;
            }
            reader.Close();
            command1.Dispose();

            string requete_affichagepseudoX = "SELECT r.Nom,count(lister.idRecette2) from List_recette as lister JOIN Recette as r ON r.idRecette=lister.idRecette2 ORDER BY count(listr.idRecette2) DESC;";
            MySqlCommand command1X = maConnexion.CreateCommand();
            command1X.CommandText = requete_affichagepseudoX;
            MySqlDataReader readerX = command1X.ExecuteReader();
            int ix = 0;
            while (readerX.Read())
            {
                if (ix == 0)
                {
                    nomplat1.Text = readerX.GetValue(0).ToString();
                    nombreCOMMANDE1.Text += " " + readerX.GetValue(1).ToString() + " fois";

                }

                if (ix == 1)
                {
                    nomplat2.Text = readerX.GetValue(0).ToString();
                    nombreCOMMANDE2.Text += " " + readerX.GetValue(1).ToString() + " fois";

                }

                if (ix == 2)
                {
                    nomplat3.Text = readerX.GetValue(0).ToString();
                    nombreCOMMANDE3.Text += " " + readerX.GetValue(1).ToString() + " fois";

                }
                ix++;
            }
            readerX.Close();
            command1X.Dispose();

            string requete_affichagepseudoY = "SELECT cui.Nom,count(lister.idCommande) from Cuisinier as cui JOIN Commande as lister ON cui.idCuisinier=lister.idCuisinier ORDER BY count(listr.idCommande) DESC;";
            MySqlCommand command1Y = maConnexion.CreateCommand();
            command1Y.CommandText = requete_affichagepseudoY;
            MySqlDataReader readerY = command1X.ExecuteReader();
            int iy = 0;
            while (readerY.Read())
            {
                if (iy == 0)
                {
                    cuisinierphare.Text += readerX.GetValue(0).ToString() +", créateur de "+ readerY.GetValue(1).ToString()+" recettes";


                }
                iy++;
            }
            readerY.Close();
            command1Y.Dispose();

        }
    }
}
