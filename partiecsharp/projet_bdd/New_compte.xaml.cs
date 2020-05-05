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
                string connexionString = "SERVER=localhost;PORT=3306;DATABASE=tableprojet;UID=root;PASSWORD=" + mot_de_passe.mot_dp + ";convert zero datetime=True";
                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException er)
            {
                Console.WriteLine(" ErreurConnexion : " + er.ToString());
                return;
            }

            string requete = "Select adresseEmail from client;";

            MySqlCommand command1 = maConnexion.CreateCommand();
            command1.CommandText = requete;

            MySqlDataReader reader = command1.ExecuteReader();
            bool existe = false;
            while (reader.Read())   
            {   

                if (email.Text==reader.GetValue(0).ToString())
                {
                    erreur_mail pa = new erreur_mail();
                    pa.Show();
                    existe = false;
                    return;
                }
            }
            command1.Dispose();

            if (existe == false)
            {
                
                string name = nom.Text;
                string pre = prenom.Text;
                string adr = adresse.Text;
                string v = ville.Text;
                DateTime? d = date.SelectedDate;
                string date_nai = d.Value.Year.ToString() +"-" + d.Value.Month.ToString() + "-" + d.Value.Day.ToString(); //Gerer le faite que c'est year-day-month 
                
                MessageBox.Show(date_nai);
                string t = tel.Text;
                bool? estcreateur = createur.IsChecked;
                bool estcreateur1 = true;

                if (estcreateur==false || estcreateur == null)
                {
                    estcreateur1 = false;
                }
                
                string p = email.Text;
                string m = mdp.Text;

                string insertTable = " insert into tableprojet.client (`nom`,`prenom`,`adresse`,`ville`,`date_naissance`,`numeroDeTelephone`,`adresseEmail`,`estCreateur`,`capitalCooks`,`motDePasse`) Values ('" + name + "','" + pre + "','" + adr + "','" + v + "','" + date_nai + "'," + t + ",'" + p + "'," + estcreateur1.ToString() + "," + "0" + ",'" + m+"');";
                MySqlCommand command3 = maConnexion.CreateCommand();
                command3.CommandText = insertTable;
                MessageBox.Show(insertTable);

                MySqlDataReader reader3 = command3.ExecuteReader();

                command3.Dispose();
                MessageBox.Show("Merci pour la creation de la recette");
                
                Creation_ok a = new Creation_ok();
                a.Show();
                this.Close();
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
