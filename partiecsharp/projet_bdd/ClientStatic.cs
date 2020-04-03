using System;
using System.Collections.Generic;
using System.Text;

namespace projet_bdd
{
    static class ClientStatic //L'avantage de cette classe c'est qu'elle est accessible interpage, du coup c'est pas mal, mais il faut appeler ClientStatic.ClientStatic1(avec ou sans parametre)  pour modifier ton ClientStatic, mais tu peux directement avoir tes attributs avec ClientStatic.attribut
    {
            public static int idClient;
            public static string nom;
            public static string prenom;
            public static string adresse;
            public static string ville;
            public static DateTime? d_naissance;
            public static long tel;
            public static string mail;
            public static bool estCreateur;
            public static int capitalCooks;
            public static string mdp;

            static public void ClientStatic1(int i=0, string n=null, string p=null, string a=null, string v=null, DateTime? d=null, long t=0, string m=null, bool e=false, int c=0, string mdp=null)
            {
            ClientStatic.idClient = i;
            ClientStatic.nom = n;
            ClientStatic.prenom = p;
            ClientStatic.adresse = a;
            ClientStatic.ville = v;
            ClientStatic.d_naissance = d;
            ClientStatic.tel = t;
            ClientStatic.mail = m;
            ClientStatic.estCreateur = e;
            ClientStatic.capitalCooks = c;
            ClientStatic.mdp = mdp;
            }
        }
}
