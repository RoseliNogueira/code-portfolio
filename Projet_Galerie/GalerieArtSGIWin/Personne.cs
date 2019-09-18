using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalerieArtSGIWin
{
    public abstract class Personne
    {
        private string FName = "";
        private string LName = "";

        public string FistName
        {
            get
            {
                return FName;
            }
            set
            {
                FName = value;
            }
        }

        public string LastName
        {
            get
            {
                return LName;
            }
            set
            {
                LName = value;
            }
        }
        public Personne()
        {
        }

        public Personne(string First, string Last)
        {
            FName = First;
            LName = Last;
        }

        public override string ToString()
        {
            return FName + " " + LName;
        }
    }
}
