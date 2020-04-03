using System;
using System.Collections.Generic;
using System.Text;

namespace projet_bdd
{
    static class ClientStatic //L'avantage de cette classe c'est qu'elle est accessible interpage, du coup c'est pas mal, mais il faut appeler ClientStatic.ClientStatic1() ou ClientStatic.ClientStatic2(parametre) pour modifier ton ClientStatic, mais tu peux directement avoir tes attributs avec ClientStatic.attribut
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
            static public void ClientStatic1()
            {
            
                ClientStatic.idClient = 0;
                ClientStatic.nom = null;
                ClientStatic.prenom = null;
            ClientStatic.adresse = null;
            ClientStatic.ville = null;
            ClientStatic.d_naissance = null;
            ClientStatic.tel = 0;
            ClientStatic.mail = null;
            ClientStatic.estCreateur = false;
            ClientStatic.capitalCooks = 0;
            ClientStatic.mdp = null;
            }

            static public void ClientStatic2(int i, string n, string p, string a, string v, DateTime? d, long t, string m, bool e, int c, string mdp)
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
