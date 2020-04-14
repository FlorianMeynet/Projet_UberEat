using System;
using System.Collections.Generic;
using System.Text;

namespace projet_bdd
{
    public static class ClientStatic //L'avantage de cette classe c'est qu'elle est accessible interpage, du coup c'est pas mal, mais il faut appeler ClientStatic.ClientStatic1(avec ou sans parametre)  pour modifier ton ClientStatic, mais tu peux directement avoir tes attributs avec ClientStatic.attribut
    {
        public static int idClient;
        public static string nom;
        public static string prenom;
        public static string adresse;
        public static string ville;
        public static DateTime? d_naissance;
        public static long tel;
        public static string mail;
        public static int estCreateur;
        public static int capitalCooks;
        public static string mdp;
        public static int idCreateur;
        static public void ClientStatic1(int i=0, string n=null, string p=null, string a=null, string v=null, DateTime? d=null, long t=0, string m=null, int e=0, int c=0, string mdp=null,int idcreateur=0)
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
        ClientStatic.idCreateur = idcreateur;
        }
        static public string affichage()
        {
            return (ClientStatic.idClient.ToString() + " " + ClientStatic.nom + " " + ClientStatic.prenom + " "+ ClientStatic.prenom + " "+ ClientStatic.adresse + " "+ ClientStatic.ville + " "+ ClientStatic.d_naissance.ToString() + " "+ ClientStatic.tel.ToString() + " "+ ClientStatic.mail + " "+ ClientStatic.estCreateur.ToString() + " "+ ClientStatic.capitalCooks.ToString() + " " + ClientStatic.mdp);
        }

    }
}
