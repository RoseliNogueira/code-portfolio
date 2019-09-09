using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalerieArtSGIWin
{
    public class Artiste : Personne
    {
        private string ID = "";

        public string ArtistID
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

        public Artiste(string First, string Last, string artID)
            : base(First, Last)
        {
            ID = artID;
        }

        public override string ToString()
        {
            string artistInformation = "\nName: " + base.FistName + " " + base.LastName + "\nArtistID: " + ID + "\n\n";

            return artistInformation;
        }
    }
}
