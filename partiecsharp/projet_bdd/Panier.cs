using System;
using System.Collections.Generic;
using System.Text;

namespace projet_bdd
{
    public static class Panier
    {
        public static int idClient;
        public static float Credit;
        public static List<int> listIdRecette = new List<int>();

        static public void PanierVide(int i = 0, float c = 0, List<int> l = null)
        {
            Panier.idClient = i;
            Panier.Credit = c;
            Panier.listIdRecette = l;
        }
    }
}
