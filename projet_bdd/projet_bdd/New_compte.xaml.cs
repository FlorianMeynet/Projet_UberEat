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
    /// Logique d'interaction pour New_compte.xaml
    /// </summary>
    public partial class New_compte : Window
    {
        public New_compte()
        {
            InitializeComponent();
        }

        private void creation(object sender, RoutedEventArgs e)
        {
            //if(tous est validé)
            Creation_ok a = new Creation_ok();
            a.Show();
            this.Close();

        }

       public void UpdateBdd(string adressedelabdd)
        {
            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = adressedelabdd;

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
            string requete = "SELECT DISTINCT pseudo FROM personne "; //  On a dit sur le pseudo
            MySqlCommand command1 = maConnexion.CreateCommand();
            command1.CommandText = requete;
            MySqlDataReader reader = command1.ExecuteReader();
            command1.Dispose();
            // if pseudo is in reader, on continue et on l'insert


            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            string insertTable = "RequeteSQLpourinsererdanslatable";
            MySqlCommand command3 = maConnexion.CreateCommand();
            command3.CommandText = insertTable;
            try
            {
                command3.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                Console.ReadLine();
                return;
            }

            command3.Dispose();
        }

        private void retour(object sender, RoutedEventArgs e)
        {
            MainWindow a = new MainWindow();
            a.Show();
            this.Close();
        }
    }
}
