using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalerieArtSGIWin
{
    class Oeuvre
    {
        private string IDOeuvre = "";
        private string Titre = "";
        private string Annee = "";
        private double Prix = 0;
        private double Estimation = 0;
        private string IDArtiste = "";
        private string IDConservateur = "";
        private char Etat = 'E';

        public string OeuvIDOeuvre
        {
            get
            {
                return IDOeuvre;
            }
            set
            {
                IDOeuvre = value;
            }
        }

        public string OeuvTritre
        {
            get
            {
                return Titre;
            }
            set
            {
                Titre = value;
            }
        }

        public string OeuvAnnee
        {
            get
            {
                return Annee;
            }
            set
            {
                Annee = value;
            }
        }

        public double OeuvPrix
        {
            get
            {
                return Prix;
            }
            set
            {
                Prix = value;
            }
        }

        public double OeuvEstimation
        {
            get
            {
                return Estimation;
            }
            set
            {
                Estimation = value;
            }
        }

        public string OeuvIDArtiste
        {
            get
            {
                return IDArtiste;
            }
            set
            {
                IDArtiste = value;
            }
        }

        public string OeuvIDConservateur
        {
            get
            {
                return IDConservateur;
            }
            set
            {
                IDConservateur = value;
            }
        }

        public char OeuvEtat
        {
            get
            {
                return Etat;
            }
            set
            {
                Etat = value;
            }
        }

        public Oeuvre(string oeuvreID, string oeuvreTitre, string oeuvreAnnee, double oeuvrePrix, double oeuvreEstimation, string oeuvreIDArtiste, string oeuvreIDConservateur, char oeuvreEtat)
        {
            IDOeuvre = oeuvreID;
            Titre = oeuvreTitre;
            Annee = oeuvreAnnee;
            Prix = oeuvrePrix;
            Estimation = oeuvreEstimation;
            IDArtiste = oeuvreIDArtiste;
            IDConservateur = oeuvreIDConservateur;
            Etat = oeuvreEtat;
        }

        public override string ToString()
        {
            string oeuvreInformation = "\nIDOeuvre: " + IDOeuvre + "\nTitre: " + Titre + "\nAnnée: " + Annee + "\nPrix: " + Prix + "\nEstimation: " + Estimation + "\nIDArtiste: " + IDArtiste + "\nIDConservateur: " + IDConservateur + "\nEtat d'oeuvre: " + Etat + "\n\n";

            return oeuvreInformation;
        }

        public void ChangerEtat(char nouvelleEtat)
        {
            Etat = nouvelleEtat;
        }

        public void SetPrix(double prixPaye)
        {
            Prix = prixPaye;
        }

        public double CalculerCommission(double prix, double tauxDeComm)
        {
            return (prix - Estimation) * tauxDeComm;
        }
    }
}
