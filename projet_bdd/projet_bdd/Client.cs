using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace projet_bdd
{
    class Client
    {
        private int idClient;
        private string nom;
        private string prenom;
        private string adresse;
        private string ville;
        private DateTime? d_naissance;
        private long tel;
        private string mail;
        private bool estCreateur;
        private int capitalCooks;
        private string mdp;
        public Client()
        {
            this.idClient = 0;
            this.nom = null;
            this.prenom = null;
            this.adresse = null;
            this.ville = null;
            this.d_naissance = null;
            this.tel = 0;
            this.mail = null;
            this.estCreateur = false;
            this.capitalCooks = 0;
            this.mdp = null;
        }
         
        public Client(int i,string n, string p, string a, string v, DateTime? d,long t, string m, bool e,int c, string mdp)
        {
            this.idClient = i;
            this.nom = n;
            this.prenom = p;
            this.adresse = a;
            this.ville = v;
            this.d_naissance = d;
            this.tel = t;
            this.mail = m;
            this.estCreateur = e;
            this.capitalCooks = c;
            this.mdp = mdp;
        }
        public int IdClient
        {
            get { return (this.idClient); }
            set { this.idClient = value; }
        }
        public string Nom
        {
            get { return (this.nom); }
            set { this.nom = value; }
        }
        public string Prenom
        {
            get { return (this.prenom); }
            set { this.prenom = value; }
        }

        public string Adresse
        {
            get { return (this.adresse); }
            set { this.adresse = value; }
        }

        public string Ville
        {
            get { return (this.ville); }
            set { this.ville = value; }
        }
        public DateTime? D_naissance
        {
            get { return (this.d_naissance); }
            set { this.d_naissance = value; }
        }

        public long Tel
        {
            get { return (this.tel); }
            set { this.tel = value; }
        }

        public string Mail
        {
            get { return (this.mail); }
            set { this.mail = value; }
        }

        public bool EstCreateur
        {
            get { return (this.estCreateur); }
            set { this.estCreateur = value; }
        }

        public int CapitalCooks
        {
            get { return (this.capitalCooks); }
            set { this.capitalCooks = value; }
        }

        public string Mdp
        {
            get { return (this.mdp); }
            set { this.mdp = value; }
        }

    }
}
