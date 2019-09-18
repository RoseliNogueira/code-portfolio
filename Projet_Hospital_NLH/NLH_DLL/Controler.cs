using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLH_DLL
{
    public class Controler
    {
        /********************** SINGLETON PATTERN **************************/

        static private Controler instance = null; //champs du Controler qui contiendra sa propre instance

        private Controler() //Constructeur prive de la classe
        {
            nlh = new NLHEntities1();
        }

        static public Controler GetInstance() //methode qui va chercher l'instance existante de la classe
        {
            if (instance == null)
            {
                instance = new Controler();
            }
            return instance;
        }

        /***************** Champs ***********************/

        NLHEntities1 nlh;

        private Employe user; //employe qui utilise le systeme
        public Employe User
        {
            get { return user; }
            set { user = value; }
        }

        private int age;
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        private bool existpatient;
        public bool ExistPatient
        {
            get { return existpatient; }
            set { existpatient = value; }
        }

        private bool existfichier;
        public bool ExistFichier
        {
            get { return existfichier; }
            set { existfichier = value; }
        }

        /***************** Methods *********************/

        
        public ViewMedecin medecin { get; set; }
        
        
        public int CalcAge(DateTime datenaissance)
        {
            age = DateTime.Today.Year - datenaissance.Year;
            return age;
        }

        public bool Authentification(string utilisateur, string motdepasse)
        {
            bool success = false;

            List<Employe> emp = nlh.Employes.ToList<Employe>();
            int count = emp.Count;
            for (int i = 0; i < count; i++)
            {
                if (utilisateur == emp[i].Utilisateur && motdepasse == emp[i].MotdePasse)
                {
                    user = emp[i];
                    success = true;
                }
            }

            return success;
        }

        public bool AjoutEmploye(string prenom, string nomfamille, string adresse, string ville,
            string province, string codepostal, string telprinc, string telautre, DateTime datenaissance,
            string sexe, string assurancemaladie, string assurancesocial, Object departement, Object poste)
        {
            bool success = false;
                        
            try
            {
                Personne personne = new Personne();
                personne.Prenom = prenom;
                personne.NomFamille = nomfamille;
                personne.Adresse = adresse;
                personne.Ville = ville;
                personne.Province = province;
                personne.CodePostal = codepostal;
                personne.TelephonePrinc = telprinc;
                personne.TelephoneAutre = telautre;
                personne.DateNaissance = datenaissance;
                personne.Sexe = sexe;
                personne.AssuranceMaladie = assurancemaladie;

                nlh.Personnes.AddObject(personne);

                Departement d = (Departement)departement;
                Poste p = (Poste)poste;

                Employe employe = new Employe();
                employe.AssuranceSocial = assurancesocial;
                employe.IDDepartement = d.IDDepartement;
                employe.IDPoste = p.IDPoste;
                employe.Utilisateur = prenom;
                employe.MotdePasse = "12";
                employe.Status = "Active";

                
                nlh.Employes.AddObject(employe);

                nlh.SaveChanges();
                
            }
            catch(Exception)
            {
                throw;
            }

            return success;
        }

        public List<Poste> GetAllPositionForCb()
        {
            List<Poste> ls = new List<Poste>();
            ls = nlh.Postes.ToList();

            return ls;
        }

        public List<Departement> GetAllDepartementForCb()
        {
            List<Departement> lsdep = new List<Departement>();
            lsdep = nlh.Departements.ToList();
            return lsdep;
        }

        public List<ViewMedecin> Medecin()
        {
            List<ViewMedecin> lsmedecin = nlh.ViewMedecins.ToList<ViewMedecin>();

            return lsmedecin;
        }

        public Employe RechercheEmploye(int idemploye)
        {
            Object employe = null;
            Employe empsup = (Employe)employe;
            List<Employe> emp = nlh.Employes.ToList<Employe>();
            int count = emp.Count;

            try
            {                
                for (int i = 0; i < count; i++)
                {
                    if (idemploye == emp[i].IDEmploye)
                    {
                        empsup = emp[i];                        
                    }
                }                
            }
            catch (Exception)
            {
                emp = null;
            }
            return empsup;
        }

        public Personne RecherchePersonne(int idpersonne)
        {
            try
            {
                Object personne = null;
                Personne psup = (Personne)personne;

                List<Personne> p = nlh.Personnes.ToList<Personne>();
                int count = p.Count;
                for (int i = 0; i < count; i++)
                {
                    if (idpersonne == p[i].IDPersonne)
                    {
                        psup = p[i];                        
                    }
                }
                return psup;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ChangerStatus(int idemploye)
        {
            bool success = false;
            try
            {
                List<Employe> emp = nlh.Employes.ToList<Employe>();
                int count = emp.Count;
                for (int i = 0; i < count; i++)
                {
                    if (idemploye == emp[i].IDEmploye && emp[i].Status == "Active")
                    {
                        emp[i].Status = "Inactive";
                        success = true;
                        nlh.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return success;
        }

        public List<ViewLitsDepartement> GetLits()
        {
            List<ViewLitsDepartement> lslits = nlh.ViewLitsDepartements.ToList<ViewLitsDepartement>();

            return lslits;
        }

        public List<ViewLitsDepartement> GetLitsDisponibles(string typelits)
        {
            try
            {
                bool disponible = true;
                int count = GetLits().Count;
                List<ViewLitsDepartement> lslitsdispo = new List<ViewLitsDepartement>();
                List<ViewLitsDepartement> lslitsdispoPed = new List<ViewLitsDepartement>();


                //Peuple les lists avec les lits a) condition 1: disponible et type de lits b) condition 2: disponible, type de lits et enfants
                for (int i = 0; i < count; i++)
                {
                    if (GetLits()[i].Disponible == disponible && GetLits()[i].TypeLit == typelits)
                    {
                        lslitsdispo.Add(GetLits()[i]);

                        if (Convert.ToInt32(age) <= 16)
                        {
                            if (GetLits()[i].IDDepartement == 2)//code 2 Pédiatrie
                            {
                                lslitsdispoPed.Add(GetLits()[i]);
                            }

                        }
                    }
                }

                ////Libère la liste peupler pour les enfants avec les lits disponibles et au cas de n'avoir pas
                //de lits disponible au département pédiatrique il libère la liste avec tous les lits disponibles ou hôpital
                if (lslitsdispoPed.Count == 0)
                {
                    return lslitsdispo;
                }
                else
                {
                    return lslitsdispoPed;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ViewPatient RecherchePatient(string assurancemaladie)
        {
            try
            {
                Object patient = null;
                ViewPatient pat = (ViewPatient)patient;

                List<ViewPatient> vp = nlh.ViewPatients.ToList<ViewPatient>();
                int count = vp.Count;
                existpatient = false;
                for (int i = 0; i < count; i++)
                {
                    if (assurancemaladie == vp[i].AssuranceMaladie)
                    {
                        pat = vp[i];
                        existpatient = true;                        
                    }
                }
                return pat;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool AjoutFichierAdmission(int idpersonne, int idpac, string prenom, string nomfamille, string adresse, string ville,
            string province, string codepostal, string telprinc, string telautre, DateTime datenaissance, string sexe, 
            string assurancemaladie, int idemploye, int litID, DateTime dateadmission, string assuranceprivee, ViewPatient vp, string parentplusproche)
        {
            bool success = false;

            try
            {
                if (existpatient)
                {
                    Personne personne = nlh.Personnes.Single(p => p.IDPersonne == vp.IDPersonne);
                    personne.Prenom = prenom;
                    personne.NomFamille = nomfamille;
                    personne.Adresse = adresse;
                    personne.Ville = ville;
                    personne.Province = province;
                    personne.CodePostal = codepostal;
                    personne.TelephonePrinc = telprinc;
                    personne.TelephoneAutre = telautre;
                    personne.DateNaissance = datenaissance;
                    personne.Sexe = sexe;
                    personne.AssuranceMaladie = assurancemaladie;

                    nlh.Personnes.ApplyCurrentValues(personne);


                    Patient patient = nlh.Patients.Single((p => p.IDPersonne == vp.IDPersonne));
                    patient.ParentPlusProche = parentplusproche;

                    nlh.Patients.ApplyCurrentValues(patient);


                    FichierAdmission fichieradmission = new FichierAdmission();
                    fichieradmission.IDPatient = idpac;
                    fichieradmission.IDEmploye = idemploye;
                    fichieradmission.IDLit = litID;
                    fichieradmission.DateAdmission = dateadmission;
                    fichieradmission.AssurancePrivee = assuranceprivee;

                    nlh.FichierAdmissions.AddObject(fichieradmission);

                    nlh.SaveChanges();
                }

                else
                {
                    Personne personne = new Personne();
                    personne.Prenom = prenom;
                    personne.NomFamille = nomfamille;
                    personne.Adresse = adresse;
                    personne.Ville = ville;
                    personne.Province = province;
                    personne.CodePostal = codepostal;
                    personne.TelephonePrinc = telprinc;
                    personne.TelephoneAutre = telautre;
                    personne.DateNaissance = datenaissance;
                    personne.Sexe = sexe;
                    personne.AssuranceMaladie = assurancemaladie;

                    nlh.Personnes.AddObject(personne);


                    Patient patient = new Patient();
                    patient.IDPersonne = vp.IDPersonne;
                    patient.ParentPlusProche = parentplusproche;

                    nlh.Patients.AddObject(patient);


                    FichierAdmission fichieradmission = new FichierAdmission();
                    fichieradmission.IDPatient = idpac;
                    fichieradmission.IDEmploye = idemploye;
                    fichieradmission.IDLit = litID;
                    fichieradmission.DateAdmission = dateadmission;
                    fichieradmission.AssurancePrivee = assuranceprivee;

                    nlh.FichierAdmissions.AddObject(fichieradmission);

                    nlh.SaveChanges();
                }
            }

            catch (Exception)
            {
                throw; 
            }

            return success;
        }

        public bool AjoutPatient(string prenom, string nomfamille, string adresse, string ville,
            string province, string codepostal, string telprinc, string telautre, DateTime datenaissance,
            string sexe, string assurancemaladie, string parentplusproche)
        {
            bool success = true;

            try
            {
                Personne personne = new Personne();
                personne.Prenom = prenom;
                personne.NomFamille = nomfamille;
                personne.Adresse = adresse;
                personne.Ville = ville;
                personne.Province = province;
                personne.CodePostal = codepostal;
                personne.TelephonePrinc = telprinc;
                personne.TelephoneAutre = telautre;
                personne.DateNaissance = datenaissance;
                personne.Sexe = sexe;
                personne.AssuranceMaladie = assurancemaladie;

                nlh.Personnes.AddObject(personne);

                Patient patient = new Patient();
                patient.ParentPlusProche = parentplusproche;

                nlh.Patients.AddObject(patient);

                nlh.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }

            return success;
        }

        public ViewFichierAdmission RechercheFichierAdmission (int idadmission)
        {
            Object admission = null;
            ViewFichierAdmission fichier = (ViewFichierAdmission) admission;
            List<ViewFichierAdmission> vf = nlh.ViewFichierAdmissions.ToList<ViewFichierAdmission>();
            int count = vf.Count;

            try
            {                
                for (int i = 0; i < count; i++)
                {
                    if (idadmission == vf[i].IDAdmission && vf[i].DateConge == null)
                    {
                        fichier = vf[i];
                    }
                }               
            }
            catch (Exception)
            {
                fichier = null;
            }

            return fichier;
        }

        public bool DonnerConge(int idadmission, DateTime dateconge)
        {
            bool success = true;
            try
            {
                FichierAdmission fichieradmission = nlh.FichierAdmissions.Single(p => p.IDAdmission == idadmission);
                fichieradmission.DateConge = dateconge;
                nlh.FichierAdmissions.ApplyCurrentValues(fichieradmission);
                nlh.SaveChanges();
            }
            catch (Exception)
            {
                success = false;
            }
            return success;
        }

    }
}