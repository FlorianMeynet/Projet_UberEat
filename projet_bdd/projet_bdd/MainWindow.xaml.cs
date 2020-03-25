using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace projet_bdd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            

        }

        private void conexion(object sender, RoutedEventArgs e)
        {
            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;DATABASE=cooking;UID=nom_login;PASSWORD=password_login;";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException er)
            {
                Console.WriteLine(" ErreurConnexion : " + er.ToString());
                return;
            }

            string p = pseudo.Text;
            string requete = "Select mdp from client where pseudo=="+p+";";

            MySqlCommand command1 = maConnexion.CreateCommand();
            command1.CommandText = requete;

            MySqlDataReader reader = command1.ExecuteReader();  //reader a les valeurs retourner par la requette

            if ((pseudo.Text=="" )|| (mdp.Text=="") || (mdp.Text != reader.GetValue(0).ToString() ))  //Verification avec le mdp
            {
                erreur_connexion a = new erreur_connexion();
                a.Show();
            }
            else
            {
                Acceuil page = new Acceuil();
                page.Show();
                this.Close();
            }
        }

        private void notyet(object sender, RoutedEventArgs e)
        {
            New_compte page = new New_compte();
            page.Show();
            this.Close();
        }

        private void leave(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
