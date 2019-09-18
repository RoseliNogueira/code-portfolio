using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATM
{
    public class Cheque : Compte
    {
        const double fraisPaiementFacture = 1.25;
        const double montantFactureMaximum = 0;


        public double GetFraisPaiementFacture
        {
            get { return fraisPaiementFacture; }
        }

        public Cheque()
        {
        }

         public Cheque(string nip, string numeroCompte, double solde)
            : base('C', nip, numeroCompte, solde)
        {
        }

         public double PaiementFactCheque(double montant)
         {
             SoldeCompte = ((montant + fraisPaiementFacture) - SoldeCompte);
             return SoldeCompte;
         }
    }
}
