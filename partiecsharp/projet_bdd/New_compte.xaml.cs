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

            string requete = "Select email from client;";

            MySqlCommand command1 = maConnexion.CreateCommand();
            command1.CommandText = requete;

            MySqlDataReader reader = command1.ExecuteReader();
            command1.Dispose();
            bool existe = false;
            while (reader.Read())   
            {   

                if (email.Text==reader.GetValue(0).ToString())
                {
                    erreur_mail pa = new erreur_mail();
                    pa.Show();
                    existe = false;
                }
                
            }
            if (existe == false)
            {
                Creation_ok a = new Creation_ok();
                a.Show();
                this.Close();
                string name = nom.Text;
                string pre = prenom.Text;
                string adr = adresse.Text;
                string v = ville.Text;
                DateTime? d = date.SelectedDate;
                string t = tel.Text;
                bool? estcreateur = createur.IsChecked;
                bool estcreateur1 = true;
                if (estcreateur==false || estcreateur == null)
                {
                    estcreateur1 = false;
                }
                
                string p = email.Text;
                string m = mdp.Text;


                string insertTable = " insert into tableprojet.client (`nom`,`prenom`,`adresse`,`ville`,`date_naissance`,`numeroDeTelephone`,`adresseEmail`,`estCreateur`,`capitalCooks`,`motDePasse`) Values (" + name + "," + pre + "," + adr + "," + v + "," + d + "," + t + "," + p + "," + estcreateur1.ToString() + "," + "0" + "," + m;
                MySqlCommand command3 = maConnexion.CreateCommand();
                command3.CommandText = insertTable;
                try
                {
                    command3.ExecuteNonQuery();
                }
                catch (MySqlException er)
                {
                    Console.WriteLine(" ErreurConnexion : " + er.ToString());
                    Console.ReadLine();
                    return;
                }

            }
            
        }

        private void retour(object sender, RoutedEventArgs e)
        {
            MainWindow a = new MainWindow();
            a.Show();
            this.Close();
        }

        
    }
}
