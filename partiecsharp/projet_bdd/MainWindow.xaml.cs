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
            ClientStatic.ClientStatic1();
            Panier.PanierVide();
        }

        private void conexion(object sender, RoutedEventArgs e)
        {
            
            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;DATABASE=tableprojet;UID=root;PASSWORD=password_login;";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException er)
            {
                Console.WriteLine(" ErreurConnexion : " + er.ToString());
                return;
            }

            string p = mail.Text;
            string requete = "SELECT * FROM client WHERE adresseEmail="+p+";";
            
            MySqlCommand command1 = maConnexion.CreateCommand();
            command1.CommandText = requete;

            MySqlDataReader reader = command1.ExecuteReader();  //reader a les valeurs retourner par la requette
            
            if (mdp.Text == reader.GetValue(10).ToString())  //Verification avec le mdp
            {
                ClientStatic.idClient = int.Parse(reader.GetValue(0).ToString());
                ClientStatic.nom = reader.GetValue(1).ToString();
                ClientStatic.prenom = reader.GetValue(2).ToString();
                ClientStatic.adresse = reader.GetValue(3).ToString();
                ClientStatic.ville = reader.GetValue(4).ToString();
                string date = reader.GetValue(5).ToString();
                string[] date1 = new string[3];
                date1 = date.Split('-');
                DateTime date2 = new DateTime(int.Parse(date1[0]), int.Parse(date1[1]), int.Parse(date1[2]));
                ClientStatic.d_naissance = date2;
                ClientStatic.tel = int.Parse(reader.GetValue(6).ToString());
                ClientStatic.mail = reader.GetValue(7).ToString();
                ClientStatic.estCreateur = bool.Parse(reader.GetValue(8).ToString());
                ClientStatic.capitalCooks = int.Parse(reader.GetValue(9).ToString());
                ClientStatic.mdp = reader.GetValue(10).ToString();

                if (ClientStatic.estCreateur == true)
                {
                    ClientStatic.idCreateur = recupt_idcreateur();
                    Acceuil page = new Acceuil();
                    page.Show();
                    this.Close();
                }
                else
                {
                    Acceuil_commande page = new Acceuil_commande();
                    page.Show();
                    this.Close();
                }   
            }

            else
            {
                erreur_connexion a = new erreur_connexion();
                a.Show();
            }
            command1.Dispose();
            reader.Close();
        }
        private int recupt_idcreateur()
        {
            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;DATABASE=tableprojet;UID=root;PASSWORD=password_login;";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException er)
            {
                Console.WriteLine(" ErreurConnexion : " + er.ToString());
                return(0);
            }
            
            string requete = "SELECT idCreateur FROM createur c natural join client cl where idClient="+ClientStatic.idClient;
            MySqlCommand command1 = maConnexion.CreateCommand();
            command1.CommandText = requete;

            MySqlDataReader reader = command1.ExecuteReader();  //reader a les valeurs retourner par la requette
            command1.Dispose();
            int a =int.Parse(reader.GetValue(0).ToString());
            command1.Dispose();
            reader.Close();

            return (a);

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
