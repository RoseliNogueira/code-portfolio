using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATM
{
    public class Banque : Compte
    {
        const double montantMaximum = 0;
        const double montantRemplissage = 5000;

         public Banque(string nip, string numeroCompte, double solde)
            : base('B', nip, numeroCompte, solde)
        {

        }

         public Banque()
         {
         }

         public double Remplissage(double solde)
         {
             solde = (solde + montantRemplissage);
             return solde;
         }

    }
}
