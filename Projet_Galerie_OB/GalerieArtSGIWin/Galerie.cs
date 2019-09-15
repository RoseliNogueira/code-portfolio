using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace GalerieArtSGIWin
{
    public class Galerie
    {
        List<Artiste> artists = new List<Artiste>();

        public void AjouterArtiste(string first, string Last, string ID)
        {
            Artiste myArtist = new Artiste(first, Last, ID);

            artists.Add(myArtist);
        }

        public string AfficherArtistes()
        {
            string result = "";
            for (int i = 0; i < artists.Count; i++)
            {
                result += artists[i].ToString();
            }
            return result;
        }

        List<Conservateur> conservateurs = new List<Conservateur>();


        public void AjouterConservateur(string first, string Last, string ID, double Commission)
        {
            Conservateur myConserv = new Conservateur(first, Last, ID, Commission);

            conservateurs.Add(myConserv);
        }

        public string AfficherConservateurs()
        {
            string result = "";
            for (int i = 0; i < conservateurs.Count; i++)
            {
                result += conservateurs[i].ToString();
            }
            return result;
        }

        List<Oeuvre> oeuvres = new List<Oeuvre>();

        public void AjouterOeuvre(string IDOeuvre, string Titre, string Annee, double Prix, double Estimation, string IDArtiste, string IDConservateur, char Etat)
        {
            Oeuvre myOeuvre = new Oeuvre(IDOeuvre, Titre, Annee, Prix, Estimation, IDArtiste, IDConservateur, Etat);

            oeuvres.Add(myOeuvre);
        }

        public string AfficherOeuvres()
        {
            string result = "";
            for (int i = 0; i < oeuvres.Count; i++)
            {
                result += oeuvres[i].ToString();
            }
            return result;
        }

        public int VendreOeuvre(string idOevre, double prix)
        {
            for (int i = 0; i < oeuvres.Count; i++) // cherche oeuvre
            {
                if (oeuvres[i].OeuvIDOeuvre == idOevre)  // trouve oeuvre
                {
                    if (oeuvres[i].OeuvEtat == 'E' && prix > oeuvres[i].OeuvEstimation) // valide les conditions
                    {
                        for (int j = 0; j < conservateurs.Count; j++) // cherche conservateur
                        {
                            if (conservateurs[j].ConservID == oeuvres[i].OeuvIDConservateur) //trouve conservateur
                            {
                                oeuvres[i].ChangerEtat('V');
                                oeuvres[i].SetPrix(prix);
                                double tauxFixe = conservateurs[j].GetTauxDeCommission();
                                double comm = oeuvres[i].CalculerCommission(prix, tauxFixe); //calcule la commission
                                conservateurs[j].SetComm(comm); //add la commission au conservateur
                                return 0; //oeuvre vendue
                            }
                        }
                    }
                    else
                    {
                        if (oeuvres[i].OeuvEtat == 'V') //utilisé pour le message
                        {
                            return 2; // oeuvre déjà vendue
                        }
                        if (prix <= oeuvres[i].OeuvEstimation) //utilisé pour le message
                        {
                            return 3; // le prix <= l'estimation
                        }
                    }
                }
            }
            return 1; // oeuvre pas trouvée
        }

        public void AfficherMenu()
        {
            Console.WriteLine("1 - Ajouter Conservateur");
            Console.WriteLine("2 - Ajouter Artiste");
            Console.WriteLine("3 - Ajouter Oeuvre");
            Console.WriteLine("4 - Afficher les Conservateurs");
            Console.WriteLine("5 - Afficher les Artistes");
            Console.WriteLine("6 - Afficher les Oeuvres");
            Console.WriteLine("7 - Vendre Oeuvres");
            Console.WriteLine("8 - Quitter");
        }

        public void Quitter()
        {
        }

        public bool ChercheIDOeuvre(string id)
        {
            for (int i = 0; i < oeuvres.Count; i++) // cherche oeuvre
            {
                if (oeuvres[i].OeuvIDOeuvre == id)  // trouve oeuvre et compare avec l'id reçu
                {
                    return true;
                }
            }
            return false;
        }

        public bool ChercheIDArtiste(string id)
        {
            for (int k = 0; k < artists.Count; k++) // cherche artists
            {
                if (artists[k].ArtistID == id) //trouve artiste et compare avec l'id reçu
                {
                    return true;
                }
            }
            return false;
        }

        public bool ChercheIDConserv(string id)
        {
            for (int j = 0; j < conservateurs.Count; j++) // cherche conservateurs
            {
                if (conservateurs[j].ConservID == id) //trouve conservateur et compare avec l'id reçu
                {
                    return true;
                }
            }
            return false;
        }

        public bool EcrireConservateurs()
        {
            FileStream fichierConserv = new FileStream("fichierConserv.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fichierConserv);

            for (int j = 0; j < conservateurs.Count; j++)
            {
                sw.WriteLine(conservateurs[j].FistName + "," + conservateurs[j].LastName + "," + conservateurs[j].ConservID + "," + conservateurs[j].ConservCommission);
            }
            
            sw.Close();
            return true;
        }

        public bool LireConservateurs()
        {
            conservateurs.Clear();
            string strLine;
            string[]strArray;
            char separateur = ',';  
            
            FileStream fichierConserv = new FileStream("fichierConserv.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fichierConserv);

            strLine = sr.ReadLine();

            while (strLine != null)
            {
                strArray = strLine.Split(separateur);
                Conservateur myConserv = new Conservateur(strArray[0], strArray[1], strArray[2], Convert.ToDouble(strArray[3]));
                conservateurs.Add(myConserv);
                strLine = sr.ReadLine();
            }

            sr.Close();
            return true;
        }
    }
}
