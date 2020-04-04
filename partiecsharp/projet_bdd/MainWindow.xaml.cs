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
            /*
           MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;DATABASE=tableprojet;UID=nom_login;PASSWORD=password_login;";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException er)
            {
                Console.WriteLine(" ErreurConnexion : " + er.ToString());
                return;
            }

            Client uti = new Client();

            string p = mail.Text;
            string requete = "SELECT * FROM client WHERE adresseEmail=="+p+";";
            
            MySqlCommand command1 = maConnexion.CreateCommand();
            command1.CommandText = requete;

            MySqlDataReader reader = command1.ExecuteReader();  //reader a les valeurs retourner par la requette
            command1.Dispose();
            
            if (mdp.Text == reader.GetValue(10).ToString())  //Verification avec le mdp
            {
                uti.IdClient = int.Parse(reader.GetValue(0).ToString());
                uti.Nom = reader.GetValue(1).ToString();
                uti.Prenom = reader.GetValue(2).ToString();
                uti.Adresse = reader.GetValue(3).ToString();
                uti.Ville = reader.GetValue(4).ToString();
                string date = reader.GetValue(5).ToString();
                string[] date1 = new string[3];
                date1 = date.Split('-');
                DateTime date2 = new DateTime(int.Parse(date1[0]), int.Parse(date1[1]), int.Parse(date1[2]));
                uti.D_naissance = date2;
                uti.Tel = int.Parse(reader.GetValue(6).ToString());
                uti.Mail = reader.GetValue(7).ToString();
                uti.EstCreateur = bool.Parse(reader.GetValue(8).ToString());
                uti.CapitalCooks = int.Parse(reader.GetValue(9).ToString());
                uti.Mdp = reader.GetValue(10).ToString();

                Acceuil page = new Acceuil();
                page.Show();
                this.Close();
            }

            else
            {
                erreur_connexion a = new erreur_connexion();
                a.Show();
            }
            */
            Acceuil page = new Acceuil();
            page.Show();
            this.Close();
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
