using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATM
{
    public class Epargne : Compte
    {
        const double tauxInteret = 0;

        public Epargne()
        {
        }

        public Epargne(string nip, string numeroCompte, double solde)
            : base('E', nip, numeroCompte, solde)
        {
        }

    }
}
