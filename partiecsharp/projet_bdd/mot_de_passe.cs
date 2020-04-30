using System;
using System.Collections.Generic;
using System.Text;

namespace projet_bdd
{
    public static class mot_de_passe //L'avantage de cette classe c'est qu'elle est accessible interpage, du coup c'est pas mal, mais il faut appeler ClientStatic.ClientStatic1(avec ou sans parametre)  pour modifier ton ClientStatic, mais tu peux directement avoir tes attributs avec ClientStatic.attribut
    {
        public static string mot_dp;

        static public void mot_de_passe_changement(string m)
        {
            mot_de_passe.mot_dp = m;

        }
    }
}
