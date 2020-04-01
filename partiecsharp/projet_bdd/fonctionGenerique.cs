using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace projet_bdd
{ 
    public static object RequeteGenerique(string table, string objet, int attribut, string cdt = "")
    {
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
            return null;
        }
        string requete = "";
        if (cdt == "")
        {
            requete = "SELECT " + objet + " FROM " + table + " WHERE " + cdt + ";";
        }
        MySqlCommand command1 = maConnexion.CreateCommand();
        command1.CommandText = requete;
        MySqlDataReader a = command1.ExecuteReader();
        command1.Dispose();
        return a.GetValue(attribut);
    }
}