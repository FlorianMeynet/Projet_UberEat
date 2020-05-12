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
                string requete_entree = "UPDATE `tableprojet`.`client` SET `capitalCooks` ="+ (ClientStatic.capitalCooks - prixTotal) + " WHERE (`idClient` = "+ClientStatic.idClient+");";
                MySqlCommand command1 = maConnexion.CreateCommand();
                command1.CommandText = requete_entree;
                MySqlDataReader reader1 = command1.ExecuteReader();
                
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
                int w = 0;
                string requete_entreeX = "SELECT count(*) from tableprojet.Cuisinier";
                MySqlCommand command1X = maConnexion.CreateCommand();
                command1X.CommandText = requete_entreeX;
                MySqlDataReader reader1X = command1X.ExecuteReader();
                while (reader1X.Read())
                {
                    Random val = new Random();
                    w = val.Next(1, int.Parse(reader1X.GetValue(0).ToString()));
                }

                command1X.Dispose();
                reader1X.Close();
                string date_now = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
                string requete_entree = "INSERT INTO `tableprojet`.`commande` (`idClient`, `date_commande`, `idCuisinier`) VALUES ("+ClientStatic.idClient+", '"+ date_now + "', "+w+");";
				MySqlCommand command1 = maConnexion.CreateCommand();
				command1.CommandText = requete_entree;
				MySqlDataReader reader1 = command1.ExecuteReader();
				
				MessageBox.Show("Merci pour ta commande");
				ClientStatic.capitalCooks = ClientStatic.capitalCooks - prixTotal;
				command1.Dispose();
				reader1.Close();

				maConnexion.Close();

                int idcommande = 0;
                string requete_entreeW = "SELECT count(*) from tableprojet.Cuisinier";
                MySqlCommand command1W = maConnexion.CreateCommand();
                command1W.CommandText = requete_entreeW;
                MySqlDataReader reader1W = command1W.ExecuteReader();
                while (reader1W.Read())
                {
                    idcommande = int.Parse(reader1W.GetValue(0).ToString());
                }

                command1W.Dispose();
                reader1W.Close();
                List<(int, int)> listeparcequeflorianestlourd = new List<(int, int)>();
                foreach ( int x in Panier.listIdRecette)
                {
                    bool existe = false;
                    for (int po=0;po<listeparcequeflorianestlourd.Count;po++)
                    {
                        
                        if (listeparcequeflorianestlourd[po].Item1==x)
                        {
                            int a = listeparcequeflorianestlourd[po].Item2;
                            int id = listeparcequeflorianestlourd[po].Item1;
                            listeparcequeflorianestlourd.Remove((id, a));
                            listeparcequeflorianestlourd.Add((id, a + 1));
                            existe = true;
                        }
                        
                    }
                    if (!existe)
                    {
                        listeparcequeflorianestlourd.Add((x, 1));
                    }
                }

                foreach ((int,int) valuedezfqe in listeparcequeflorianestlourd)
                {
                    string requete_entreeZ = "INSERT INTO `tableprojet`.`list_recette` (`idRecette2`, `idCommande2`, `quantite`) VALUES('"+ valuedezfqe.Item1+ "', '"+idcommande+"', '"+ valuedezfqe.Item2+ "');";
                    MySqlCommand command1Z = maConnexion.CreateCommand();
                    command1Z.CommandText = requete_entreeZ;
                    MySqlDataReader reader1Z = command1Z.ExecuteReader();
                    command1Z.Dispose();
                    reader1Z.Close();
                }
				
				int nombrecommande = 0;
                string requete_entreeA = "SELECT nombre_commande from tableprojet.Cuisinier where idCuisinier="+w+";";
                MySqlCommand command1A = maConnexion.CreateCommand();
                command1A.CommandText = requete_entreeA;
                MySqlDataReader reader1A = command1X.ExecuteReader();
                while (reader1A.Read())
                {
                    nombrecommande = int.Parse(reader1A.GetValue(0).ToString());
                }

                command1A.Dispose();
                reader1A.Close();
				
				string requete_entreeB = "UPDATE `tableprojet`.`Cuisinier` SET ` `nombre_commande` ='"+(nombrecommande+1).ToString()+ "' WHERE (`idCuisinier` = '"+w+"');";
                MySqlCommand command1B = maConnexion.CreateCommand();
                command1B.CommandText = requete_entreeB;
                MySqlDataReader reader1B = command1B.ExecuteReader();
                
				command1B.Dispose();
                reader1B.Close();
                return (true);
            }
            else { return false; }
            return false;
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
