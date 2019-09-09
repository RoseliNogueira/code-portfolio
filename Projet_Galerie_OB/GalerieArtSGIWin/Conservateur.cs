using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalerieArtSGIWin
{
    public class Conservateur : Personne
    {
        private string ID = "";
        private double Commission = 0;
        private const double TauxDeCommission = 0.25;

        public string ConservID
        {
            get
            {
                return ID;
            }
            set
            {
                ID = value;
            }
        }

        public double ConservCommission
        {
            get
            {
                return Commission;
            }
            set
            {
                Commission = value;
            }
        }

        public Conservateur(string First, string Last, string conservID, double conservCommission)
            : base(First, Last)
        {
            ID = conservID;
            Commission = conservCommission;
        }

        public override string ToString()
        {
            string conservInformation = "\nName: " + base.FistName + " " + base.LastName + "\nConservID: " + ID + "\nConservCommission: " + Commission + "\n\n";

            return conservInformation;
        }

        public void SetComm(double nouvelleCommission)
        {
            Commission = Commission + nouvelleCommission;
        }

        public double GetTauxDeCommission()
        {
            return TauxDeCommission;
        }
    }
}
