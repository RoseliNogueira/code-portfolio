using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ATM
{
    public class GestionnaireGuichet

    {

        string nipCorrect = "";

        public Compte compte;
        public Cheque cheq;
        public Epargne epargne;
        public Banque banque;

        public GestionnaireGuichet()
        {
            compte = new Compte();
            cheq = new Cheque();
            epargne = new Epargne();
            banque = new Banque();
        }

        //cree le compte banque pour contrôler le solde
        Banque compteB = new Banque(); 
        private Banque GenererCompteBanque()
        {
            compteB = new Banque("D001", "00001", 5000);

            return compteB;
        }

        //cree les comptes chèque (list)
        List<Cheque> comptesC = new List<Cheque>();
        private List<Cheque> GenererComptesCheque()
        {
            comptesC.Add(new Cheque("0001", "10101", 1500));
            comptesC.Add(new Cheque("0002", "10102", 1500));
           
            return comptesC;
        }

        //cree les comptes épargne (list)
        List<Epargne> comptesE = new List<Epargne>();
        private List<Epargne> GenererComptesEpargne()
        {
            comptesE.Add(new Epargne("0001", "20100", 4500));
            comptesE.Add(new Epargne("0004", "20101", 4500));
            
            return comptesE;
        }

        //Si n'existe pas le fichier est cree en contenat tous les comptes (chèque, èpargne et banque)
        List<Compte> comptes = new List<Compte>();
        public bool EcrireComptes()
        {
            if (!File.Exists("Comptes.txt"))
            {
                FileStream fichierCompte = new FileStream("Comptes.txt", FileMode.Create);
                StreamWriter sw = new StreamWriter(fichierCompte);

                comptes.Add(GenererCompteBanque());
                comptes.AddRange(GenererComptesCheque());
                comptes.AddRange(GenererComptesEpargne());

                for (int j = 0; j < comptes.Count; j++)
                {
                    sw.WriteLine(comptes[j].TypeCompte + ";" + comptes[j].NumeroNIP + ";" + comptes[j].NumeroCompte + ";" + comptes[j].SoldeCompte);
                }

                sw.Close();
            }
            return true;
        }

        //Lire le fichier Comptes.txt
        public bool LireCompte()
        {
            string strLine;
            string[] strArray;
            char separateur = ';';
            comptesC.Clear();
            comptesE.Clear();

            FileStream fichierCompte = new FileStream("Comptes.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fichierCompte);

            strLine = sr.ReadLine();
            while (strLine != null)
            {
                strArray = strLine.Split(separateur);

                if (strArray[0] == "B")
                {
                    Compte compteBanque = new Banque();
                    compteBanque.NumeroNIP = strArray[1];
                    compteBanque.NumeroCompte = strArray[2];
                    compteBanque.SoldeCompte = Convert.ToDouble(strArray[3]);
                    compteBanque.TypeCompte = 'B';
                    compteB = (Banque)compteBanque;
                }
                else if (strArray[0] == "C")
                {
                    Compte compteCheque = new Cheque(strArray[1], strArray[2], Convert.ToDouble(strArray[3]));
                    compteCheque.TypeCompte = 'C';
                    comptesC.Add((Cheque)compteCheque);
                }
                else if (strArray[0] == "E")
                {
                    Compte compteEpargne = new Epargne(strArray[1], strArray[2], Convert.ToDouble(strArray[3]));
                    compteEpargne.TypeCompte = 'E';
                    comptesE.Add((Epargne)compteEpargne);
                }

                strLine = sr.ReadLine();
            }

            sr.Close();
            return true;
        }

        //cree le list client 
        List<Client> clients = new List<Client>();

        //adicione les clients dans le list
        private List<Client> GenererClients()
        {
            clients.Add(new Client("0001", "Roseli"));
            clients.Add(new Client("0002", "Vinicius"));
            clients.Add(new Client("0003", "Marcelo"));
            clients.Add(new Client("0004", "Valdete"));
            clients.Add(new Client("D001", "Korben Dallas"));
           
            return clients;
        }

        //cree le fichier Client.txt en contenat tous les clients
        public bool EcrireClient()
        {
            FileStream fichierClient = new FileStream("Clients.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fichierClient);

            List<Client> listeDeClients = GenererClients();

            for (int j = 0; j < listeDeClients.Count; j++)
            {
                sw.WriteLine(listeDeClients[j].NomClient + "," + listeDeClients[j].NumNIP);
            }

            sw.Close();
            return true;
        }

        //salve les infos dans le fichier Comptes.txt
        public bool SaveComptes()
        {
            FileStream fichierCompte = new FileStream("Comptes.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fichierCompte);

            sw.WriteLine(compteB.TypeCompte + ";" + compteB.NumeroNIP + ";" + compteB.NumeroCompte + ";" + compteB.SoldeCompte);

            for (int j = 0; j < comptesC.Count; j++)
            {
                if (comptesC[j].TypeCompte == 'C')
                {
                    sw.WriteLine(comptesC[j].TypeCompte + ";" + comptesC[j].NumeroNIP + ";" + comptesC[j].NumeroCompte + ";" + comptesC[j].SoldeCompte);
                }
            }

            for (int j = 0; j < comptesE.Count; j++)
            {
                if (comptesE[j].TypeCompte == 'E')
                {
                    sw.WriteLine(comptesE[j].TypeCompte + ";" + comptesE[j].NumeroNIP + ";" + comptesE[j].NumeroCompte + ";" + comptesE[j].SoldeCompte);
                }
            }

            sw.Close();
            return true;
        }

        //valide l'utilisateur en utilisant le NIP et le nom reçu avec les infos contenant dans la liste Clients.txt
        public bool ValiderUtilisateur(string nom, string nip)
        {
            bool Valide = false;

            foreach (var client in clients)
            {
                if (nom == client.NomClient && nip == client.NumNIP)
                {
                    Valide = true;
                    nipCorrect = client.NumNIP;
                    break;
                }
            }
            return Valide;
        }

        //affiche le solde du guichet
        public string AfficherSoldeBanque()
        {
            string soldeBanque = "";
            soldeBanque += compteB.SoldeCompte;
            return soldeBanque;
        }

        //valide le NIP et affiche le solde du compte chèque
        public double AfficherSoldeCompteC(string nip)
        {
            double soldeC = 0;

            for (int i = 0; i < comptesC.Count; i++)
            {
                if (comptesC[i].NumeroNIP == nip) // valide le PIN
                {
                    soldeC = comptesC[i].SoldeCompte;
                    return soldeC;
                }
            }
            return 0;
        }

        //valide le NIP et affiche le solde du compte épargne
        public double AfficherSoldeCompteE(string nip)
        {
            double soldeE = 0;

            for (int j = 0; j < comptesE.Count; j++)
            {
                if (comptesE[j].NumeroNIP == nip) // valide le PIN
                {
                    soldeE = comptesE[j].SoldeCompte;
                    return soldeE;
                }
            }
            return 0;
        }


        public int RetraitCheque(string nip, double montant)
        {
            for (int i = 0; i < comptesC.Count; i++)
            {
                if (comptesC[i].NumeroNIP == nip) //valide le PIN
                {
                    if (comptesC[i].SoldeCompte >= montant) // valide le PIN et vérifie si le solde de compte est suffisant
                    {
                        if ((compteB.SoldeCompte - montant) >= 0) // vérifie s'il y a d'argent suffisant dans le guichet 
                        {
                            if (montant % 10 == 0) // vérifie si le montant est multiple de 10
                            {
                                if (montant <= 1000)// vérifie si le montant est <= au maximun permis par retrait
                                {
                                    comptesC[i].SoldeCompte = (comptesC[i].SoldeCompte - montant); //déduit le montant du retrait du compte en question
                                    compteB.SoldeCompte = (compteB.SoldeCompte - montant);//déduit le montant du retrait du solde du guichet
                                    SaveComptes(); //sauvegarder les altérations
                                    return 0; //retrait été efetue avec succès
                                }
                                else
                                {
                                    return 2; //Valeur superieur à maximum permit
                                }
                            }
                            else
                            {
                                return 3; //montant ne sont pas des multiples de 10
                            }
                        }
                        else
                        {
                            return 4; //Le montant demandé est superieur au montant disponible dans le guichet
                        }
                    }
                    else
                    {
                        return 1; //Solde insuffisant
                    }
                }
            }
            return 5;  //compte pas trouve
        }

        public int RetraitEpargne(string nip, double montant)
        {
            for (int i = 0; i < comptesE.Count; i++)
            {
                if (comptesE[i].NumeroNIP == nip) //valide le PIN
                {
                    if (comptesE[i].SoldeCompte >= montant) // valide le PIN et vérifie si le solde de compte est suffisant
                    {
                        if ((compteB.SoldeCompte - montant) >= 0) // vérifie s'il y a d'argent suffisant dans le guichet 
                        {
                            if (montant % 10 == 0) // vérifie si le montant est multiple de 10
                            {
                                if (montant <= 1000)// vérifie si le montant est <= au maximun permis par retrait
                                {
                                    comptesE[i].SoldeCompte = (comptesE[i].SoldeCompte - montant); //déduit le montant du retrait du compte en question
                                    compteB.SoldeCompte = (compteB.SoldeCompte - montant);//déduit le montant du retrait du solde du guichet
                                    SaveComptes();//sauvegarde les altérations
                                    return 0; //retrait été efetue avec succès
                                }
                                else
                                {
                                    return 2; //Valeur superieur à maximum permit
                                }
                            }
                            else
                            {
                                return 3; //montant ne sont pas des multiples de 10
                            }
                        }
                        else
                        {
                            return 4; //Le montant demandé est superieur au montant disponible dans le guichet
                        }
                    }
                    else
                    {
                        return 1; //Solde insuffisant
                    }
                }
            }
            return 5; //compte pas trouve
        }

        public int DepotCheque(string nip, double montant)
        {
            for (int i = 0; i < comptesC.Count; i++) // cherche le compte
            {
                if (comptesC[i].NumeroNIP == nip) //valide le PIN
                {
                    comptesC[i].SoldeCompte = comptesC[i].SoldeCompte + montant;//somme le montant du dépôt à compte en question
                    SaveComptes();//sauvegarde les altérations
                    return 1; //dépôt efetue avec succès
                }
            }
            return 0; //compte pas trouve
        }

        public int DepotEpargne(string nip, double montant)
        {
            for (int i = 0; i < comptesE.Count; i++) // cherche le compte
            {
                if (comptesE[i].NumeroNIP == nip)//valide le PIN
                {
                    comptesE[i].SoldeCompte = comptesE[i].SoldeCompte + montant;//somme le montant du dépôt à compte en question
                    SaveComptes();//sauvegarde les altérations
                    return 1; //dépôt efetue avec succès
                }
            }
            return 0; //compte pas trouve
        }

        public int PaiementFacture(string nip, double montant)
        {
            for (int i = 0; i < comptesC.Count; i++) //cherche le compte
            {
                if (comptesC[i].NumeroNIP == nip)//valide le PIN
                {
                    if (montant <= 10000)//vérifie si le montant est <= au maximun permis par paiement
                    {
                        if (comptesC[i].SoldeCompte >= (montant + cheq.GetFraisPaiementFacture))//vérifie si il y a d'argent suffisant dans le compte
                        {
                            comptesC[i].SoldeCompte = (comptesC[i].SoldeCompte - cheq.PaiementFactCheque(montant));//déduit le montant du paiement du compte en question
                            SaveComptes();//sauvegarde les altérations
                            return 0; //Paiement effectué avec succès
                        }
                        else
                        {
                            return 1; //Solde du compte insufisant
                        }
                    }
                    else
                    {
                        return 2; //Valeur superieur à maximum permit
                    }
                }
            }
            return 3; //compte pas trouve
        }

        public int TransfertFonds(string nip, double montant, char typeCompte)
        {
            if (typeCompte == 'C') //identifie le type du compte
            {
                for (int i = 0; i < comptesC.Count; i++)//cherche le compte
                {
                    if (comptesC[i].NumeroNIP == nip)//valide le PIN
                    {
                        if (montant <= 100000)//vérifie si le montant est <= au maximun permis par transfert
                        {
                            if (comptesC[i].SoldeCompte >= montant)//vérifie si il y a d'argent suffisant dans le compte
                            {
                                comptesC[i].SoldeCompte = (comptesC[i].SoldeCompte - montant);//déduit le montant du transfert à compte en question
                                for (int j = 0; j < comptesE.Count; j++)//cherche le compte de destine
                                {
                                    if (comptesE[j].NumeroNIP == nip)//valide le PIN du compte que va reçoit le montant
                                    {
                                        comptesE[j].SoldeCompte = (comptesE[j].SoldeCompte + montant);//somme le montant du transfert à compte en question
                                        SaveComptes();//sauvegarde les altérations
                                        return 0; //Transfert effectué du compte chèque vers le compte épargne avec succès
                                    }
                                }
                            }
                            else
                            {
                                return 1; //Solde insufisante
                            }
                        }
                        else
                        {
                            return 2; //Valeur superieur à maximum permis
                        }
                    }
                }
                return 3; //compte pas trouve
            }
            else if (typeCompte == 'E')//identifie le type du compte
            {
                for (int i = 0; i < comptesE.Count; i++)//cherche le compte
                {
                    if (comptesE[i].NumeroNIP == nip)//valide le PIN
                    {
                        if (montant <= 100000)//vérifie si le montant est <= au maximun permis par transfert
                        {
                            if (comptesE[i].SoldeCompte >= montant)//vérifie si il y a d'argent suffisant dans le compte
                            {
                                comptesE[i].SoldeCompte = (comptesE[i].SoldeCompte - montant);//déduit le montant du transfert à compte en question
                                for (int j = 0; j < comptesC.Count; j++)//cherche le compte de destine
                                {
                                    if (comptesC[j].NumeroNIP == nip)//valide le PIN du compte que va reçoit le montant
                                    {
                                        comptesC[j].SoldeCompte = (comptesC[j].SoldeCompte + montant);//somme le montant du transfert à compte en question
                                        SaveComptes();//sauvegarde les altérations
                                        return 0; //Transfert effectué du compte épargne vers le compte chèque avec succès
                                    }
                                }
                            }
                            else
                            {
                                return 1; //Solde insuffisante
                            }
                        }
                        else
                        {
                            return 2; //Valeur superieur à maximum permis
                        }
                    }
                }
            }
            return 3; //compte pas trouve
        }

        public bool 
            PaiementInteret()
        {

            if (comptesE.Count> 0)// pendant qu'il y a compte
            {
                for (int i = 0; i < comptesE.Count; i++)
                {
                    comptesE[i].SoldeCompte = comptesE[i].SoldeCompte + (((comptesE[i].SoldeCompte * 0.01) / 365) / 100);//aplique les intérêts sur les comptes épargne
                }
                SaveComptes();//sauvegarde les infos
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemplirGuichet(double solde)
        {
            if (compteB.SoldeCompte <= 15000)//condition de remplissage <= $20.000
            {
                compteB.SoldeCompte = banque.Remplissage(solde);//remplis le guichet
                SaveComptes();//sauvegarde les infos
                return true;
            }
            else
            {
                return false;
            }
        }

        public string ImprimerComptes()
        {
            string result;
            string strLine;
            string[] strArray;
            string[] strArrayResult;
            char separateur = ';';

            FileStream fichierCompte = new FileStream("Comptes.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fichierCompte);

            FileStream fichierCompteImprimer = new FileStream("ComptesImprimer.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fichierCompteImprimer);

            strLine = sr.ReadLine();
            while (strLine != null)
            {
                strArray = strLine.Split(separateur);

                if (strArray[0] == "C")
                {
                    sw.WriteLine("Compte Chèque Numéro : " + strArray[2] + ";" + " -- Solde Compte : $" + Convert.ToDouble(strArray[3]));
                }
                else if (strArray[0] == "E")
                {
                    sw.WriteLine("Compte Épargne Numéro : " + strArray[2] + ";" + " -- Solde Compte : $" + Convert.ToDouble(strArray[3]));
                }

                else if (strArray[0] == "B")
                {
                    sw.WriteLine("Guichet ATM Numéro : " + strArray[2] + ";" + " -- Solde du guichet : $" + Convert.ToDouble(strArray[3]));
                }                

                strLine = sr.ReadLine();
            }
            sw.Close();
            sr.Close();

            FileStream fichierCompteImprimerOuvrir = new FileStream("ComptesImprimer.txt", FileMode.Open);
            StreamReader st = new StreamReader(fichierCompteImprimerOuvrir);

            strLine = st.ReadLine();
            result = "";
            while (strLine != null)
            {
                strArrayResult = strLine.Split(separateur);
                result += strArrayResult[0];
                result += strArrayResult[1];
                result += "\n";

                strLine = st.ReadLine();
            }
            st.Close();
            return result;
        }
    }
}