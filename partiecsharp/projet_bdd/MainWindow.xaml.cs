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
            mot_de_passe.mot_de_passe_changement("cacaprout666");
        }

        private void conexion(object sender, RoutedEventArgs e)
        {
            
            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;DATABASE=tableprojet;UID=root;PASSWORD="+mot_de_passe.mot_dp+";convert zero datetime=True";
                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();

            }
            catch (MySqlException er)
            {
                Console.WriteLine(" ErreurConnexion : " + er.ToString());
                return;
            }
            
            if (mail.Text.Trim() != "" && mdp.Text.Trim() != "")
            {
                string p = mail.Text;
                string requete = "SELECT * FROM client WHERE client.adresseEmail='" + p + "';";

                MySqlCommand command_all = maConnexion.CreateCommand();
                command_all.CommandText = requete;

                MySqlDataReader reader = command_all.ExecuteReader();  //reader a les valeurs retourner par la requette
                reader.Read();

                if (mdp.Text == reader["motDePasse"].ToString())  //Verification avec le mdp
                {
                    ClientStatic.idClient = int.Parse(reader["idClient"].ToString());
                    ClientStatic.nom = reader["nom"].ToString();
                    ClientStatic.prenom = reader["prenom"].ToString();
                    ClientStatic.adresse = reader["adresse"].ToString();
                    ClientStatic.ville = reader["ville"].ToString();
                    DateTime date = (DateTime)reader["date_naissance"];
                    ClientStatic.d_naissance = date;
                    ClientStatic.tel = int.Parse(reader["numeroDeTelephone"].ToString());
                    ClientStatic.mail = reader["adresseEmail"].ToString();
                    ClientStatic.estCreateur = int.Parse(reader["estCreateur"].ToString());
                    ClientStatic.capitalCooks = int.Parse(reader["capitalCooks"].ToString());
                    ClientStatic.mdp = reader["motDePasse"].ToString();
                    string affichage_client = ClientStatic.affichage();
                    command_all.Dispose();
                    reader.Close();

                    if (ClientStatic.estCreateur == 1)
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
            }
            

            else
            {
                erreur_connexion a = new erreur_connexion();
                a.Show();
            }
            
        }
        private int recupt_idcreateur()
        {
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
                return(0);
            }
            
            string requete_idcreateur = "SELECT distinct idCreateur FROM createur c natural join client cl where idClient="+ ClientStatic.idClient + ";";
            MySqlCommand command_idcreateur = maConnexion.CreateCommand();
            command_idcreateur.CommandText = requete_idcreateur;

            MySqlDataReader reader = command_idcreateur.ExecuteReader();  //reader a les valeurs retourner par la requette

            int a = 0;
            if(reader.HasRows)
            {
                reader.Read();
                a = int.Parse(reader.GetValue(0).ToString());
            }
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
