using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATM
{
    public class Compte
    {
        private string NumNIP = ""; //4 caractères
        private string NumCompte = ""; //5 caractères
        private double Solde = 0;
        private char Type = ' '; // 1 caractère  C=cheque ; E=epargne

        public string NumeroNIP
        {
            get { return NumNIP; }
            set { NumNIP = value; }
        }

        public string NumeroCompte
        {
            get { return NumCompte; }
            set { NumCompte = value; }
        }

        public double SoldeCompte
        {
            get { return Solde; }
            set { Solde = value; }
        }

        public char TypeCompte
        {
            get { return Type; }
            set { Type = value; }
        }

        public Compte()
        {
        }

        public Compte(char typeCompte, string nip, string numeroCompte, double solde)
        {
            this.Type = typeCompte;
            this.NumNIP = nip;
            this.NumCompte = numeroCompte;
            this.Solde = solde;
        }

        public double Retrait(double montant)
        {
            Solde = Solde - montant;
            return Solde;
        }

        public double Depot(double montant)
        {
            Solde = Solde + montant;
            return Solde;
        }
    }
}