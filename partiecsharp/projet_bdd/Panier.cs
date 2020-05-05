using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Navigation;
using MySql.Data.MySqlClient;

namespace projet_bdd
{
    public static class Panier
    {
        public static int idClient;
        public static float Credit;
        public static List<int> listIdRecette = new List<int>();
        public static List<(int, int)> idigrendientquantite = new List<(int, int)>();

        static public void PanierVide(int i = 0, float c = 0)
        {
            Panier.idClient = i;
            Panier.Credit = c;
            Panier.listIdRecette = new List<int>();
        }
        static public bool EstCreable()
        {
            idigrendientquantite.Clear();
            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;DATABASE=tableprojet;UID=root;PASSWORD=" + mot_de_passe.mot_dp + ";";
                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException er)
            {
                return false;
            }
            
            foreach (int x in listIdRecette)
            {
                

                string requete_entree = "Select quantite,IdIngredient1 from tableprojet.Liste_ingredient where idRecette1='" + x + "';";
                MySqlCommand command1 = maConnexion.CreateCommand();
                command1.CommandText = requete_entree;
                MySqlDataReader reader1 = command1.ExecuteReader();

                while (reader1.Read())
                {
                    bool estajoute = false;
                    for (int w = 0; w < idigrendientquantite.Count; w++)
                    {
                        if (idigrendientquantite[w].Item1 == int.Parse(reader1.GetValue(1).ToString()))
                        {
                            int caca = idigrendientquantite[w].Item2 + int.Parse(reader1.GetValue(0).ToString());
                            int idcaca = idigrendientquantite[w].Item1;
                            idigrendientquantite.Remove((idigrendientquantite[w].Item1, idigrendientquantite[w].Item2));
                            idigrendientquantite.Add((idcaca, caca));
                            estajoute = true;
                        }
                    }
                    if (!estajoute)
                    {
                        idigrendientquantite.Add((int.Parse(reader1.GetValue(1).ToString()), (int.Parse(reader1.GetValue(0).ToString()))));
                    }
                }
                command1.Dispose();
                reader1.Close();
            }
               
                foreach ((int, int) y in idigrendientquantite)
                {
                    string requete_entreeX = "SELECT s.quantiteMin,s.quantite from stock as s join Ingredient as i where i.idIngredient='" + y.Item1 + "';";
                MySqlCommand command1X = maConnexion.CreateCommand();
                    command1X.CommandText = requete_entreeX;
                    MySqlDataReader reader1X = command1X.ExecuteReader();

                    while (reader1X.Read())
                    {
                        if ((int.Parse(reader1X.GetValue(1).ToString())-y.Item2)< int.Parse(reader1X.GetValue(0).ToString())) // quantite-quantiteprise < quantitemin
                        {
                            command1X.Dispose();
                            reader1X.Close();
                            return false;
                        }
                    }
                    command1X.Dispose();
                    reader1X.Close();
                }
          
            return true;

           
        }

        static public bool Payer(int prixTotal)
        {
            if (!EstCreable()) { return false; }
            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;DATABASE=tableprojet;UID=root;PASSWORD=" + mot_de_passe.mot_dp + ";";
                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException er)
            {
                return false;
            }
            if (ClientStatic.capitalCooks - prixTotal < 0)
            {
                paiement a = new paiement();
                a.Show();
                MessageBox.Show("Tu devrais peut etre travailler plus...");
                return false;
            }
            else
            {
                string requete_entree = "UPDATE `tableprojet`.`client` SET ` `capitalCooks` ='"+ (ClientStatic.capitalCooks - prixTotal) + "' WHERE (`idClient` = '"+ClientStatic.idClient+"');";
                MySqlCommand command1 = maConnexion.CreateCommand();
                command1.CommandText = requete_entree;
                MySqlDataReader reader1 = command1.ExecuteReader();
                while (reader1.Read())
                {
                }
                MessageBox.Show("Merci pour ta commande");
                ClientStatic.capitalCooks = ClientStatic.capitalCooks - prixTotal;
                command1.Dispose();
                reader1.Close();

                maConnexion.Close();
                return true;
            }
        }

        static public bool FaitTravailCommande(int prixTotal)
        {
            if (Payer(prixTotal)) // là on a payé
            {
                MySqlConnection maConnexion = null;
                try
                {
                    string connexionString = "SERVER=localhost;PORT=3306;DATABASE=tableprojet;UID=root;PASSWORD=" + mot_de_passe.mot_dp + ";";
                    maConnexion = new MySqlConnection(connexionString);
                    maConnexion.Open();
                }
                catch (MySqlException er)
                {
                    return false;
                }
                    string requete_entree = "UPDATE `tableprojet`.`client` SET ` `capitalCooks` ='" + (ClientStatic.capitalCooks - prixTotal) + "' WHERE (`idClient` = '" + ClientStatic.idClient + "');";
                    MySqlCommand command1 = maConnexion.CreateCommand();
                    command1.CommandText = requete_entree;
                    MySqlDataReader reader1 = command1.ExecuteReader();
                    while (reader1.Read())
                    {
                    }
                    MessageBox.Show("Merci pour ta commande");
                    ClientStatic.capitalCooks = ClientStatic.capitalCooks - prixTotal;
                    command1.Dispose();
                    reader1.Close();

                    maConnexion.Close();
                    return true;
                
            }
        }

        static public void FaitTravailStock()
        {
            if (!EstCreable()) { return; }
            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;DATABASE=tableprojet;UID=root;PASSWORD=" + mot_de_passe.mot_dp + ";";
                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException er)
            {
                return;
            }

            foreach ((int, int) y in idigrendientquantite)
            {
                string requete_entree = "SELECT quantite from tableprojet.stock where idstock='"+y.Item2+"';";
                MySqlCommand command1 = maConnexion.CreateCommand();
                command1.CommandText = requete_entree;
                MySqlDataReader reader1 = command1.ExecuteReader();
                int quantiteY = 0;
                while (reader1.Read())
                {
                    quantiteY = int.Parse(reader1.GetValue(0).ToString());
                }
                command1.Dispose();
                reader1.Close(); 


                string requete_entreeX = "UPDATE `tableprojet`.`stock` SET `quantite` = '"+(quantiteY-y.Item2).ToString()+"' WHERE (`idstock` = '"+y.Item2+"');";
                MySqlCommand command1X = maConnexion.CreateCommand();
                command1X.CommandText = requete_entreeX;
                MySqlDataReader reader1X = command1X.ExecuteReader();

                while (reader1X.Read())
                {
                   
                }
                command1X.Dispose();
                reader1X.Close();
            }
            maConnexion.Close();

            


        }
    }
}
