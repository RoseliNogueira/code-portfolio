using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATM
{
    class Client
    {
        string Nom = "";
        string NIP = ""; //4 caractères

        public string NomClient
        {
            get { return Nom; }
            set { Nom = value; }
        }

        public string NumNIP
        {
            get { return NIP; }
            set { NIP = value; }
        }

         public Client(string nip, string nom)
        {
            this.NIP = nip;
            this.Nom = nom;
        }
    }
}