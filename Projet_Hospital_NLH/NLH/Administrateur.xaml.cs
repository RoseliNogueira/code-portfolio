using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using NLH_DLL;

namespace NLH
{
    /// <summary>
    /// Logique d'interaction pour Gestion.xaml
    /// </summary>
    public partial class Administrateur : Window
    {
        Controler c;
       
        public Administrateur()
        {
            InitializeComponent();

            c = Controler.GetInstance();

            cboDepartement.ItemsSource = c.GetAllDepartementForCb();
            cboDepartement.DisplayMemberPath = "NomDepartement";
            cboDepartement.SelectedIndex = -1;

            cboPoste.ItemsSource = c.GetAllPositionForCb();
            cboPoste.DisplayMemberPath = "Description";
            cboPoste.SelectedIndex = -1;

            cboSexe.Items.Add("F");
            cboSexe.Items.Add("M");
        }

        private void buttonConfirmer_Click(object sender, RoutedEventArgs e)
        {
            Object poste = cboPoste.SelectedItem;

            Object departement = cboDepartement.SelectedItem;

            if (string.IsNullOrEmpty(txtPrenom.Text) ||
                string.IsNullOrEmpty(txtNomFamille.Text) ||
                string.IsNullOrEmpty(txtAdresse.Text) ||
                string.IsNullOrEmpty(txtVille.Text) ||
                string.IsNullOrEmpty(txtProvince.Text) ||
                string.IsNullOrEmpty(txtCodePostal.Text) ||
                string.IsNullOrEmpty(txtTelPrinc.Text) ||
                //string.IsNullOrEmpty(txtTelAutre.Text) || 
                datePickerDateNaissance.SelectedDate == null ||
                string.IsNullOrEmpty(cboSexe.Text) ||
                string.IsNullOrEmpty(txtAssuranceMaladie.Text) ||
                string.IsNullOrEmpty(txtAssuranceSocial.Text) ||
                departement == null ||
                poste == null)
            {
                MessageBox.Show("S'il vous plaît, vérifie si vous avez entre toutes les informations nécessaires");
            }
            else
            {
                c.AjoutEmploye(txtPrenom.Text, txtNomFamille.Text, txtAdresse.Text, txtVille.Text, txtProvince.Text,
                txtCodePostal.Text, txtTelPrinc.Text, txtTelAutre.Text, Convert.ToDateTime(datePickerDateNaissance.Text),
                cboSexe.Text, txtAssuranceMaladie.Text, txtAssuranceSocial.Text, departement, poste);

                MessageBox.Show("Employe ajouté avec succèss!");

                txtPrenom.Clear();
                txtNomFamille.Clear();
                txtAdresse.Clear();
                txtVille.Clear();
                txtProvince.Clear();
                txtCodePostal.Clear();
                txtTelPrinc.Clear();
                txtTelAutre.Clear();
                datePickerDateNaissance.SelectedDate = null;
                cboSexe.SelectedIndex = -1;
                txtAssuranceMaladie.Clear();
                txtAssuranceSocial.Clear();
                cboPoste.SelectedIndex = -1;
                cboDepartement.SelectedIndex = -1;
            }
        }

        private void buttonQuitter_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnRecherche_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtIDEmployeSup.Text))
            {
                MessageBox.Show("Entrer l'ID de l'employé");
            }
            else
            {
                Employe employe = c.RechercheEmploye(Convert.ToInt32(txtIDEmployeSup.Text));

                if (employe == null)
                {
                    MessageBox.Show("Employé n'a pas été trouvé");
                }
                else
                {
                    txtAssuranceSocialSup.Text = employe.AssuranceSocial;
                    txtAssuranceSocialSup.IsReadOnly = true;
                    txtStatus.Text = employe.Status;
                    txtStatus.IsReadOnly = true;

                    Personne personne = c.RecherchePersonne(employe.IDPersonne);

                    txtPrenomSup.Text = personne.Prenom;
                    txtPrenomSup.IsReadOnly = true;
                    txtNomFamilleSup.Text = personne.NomFamille;
                    txtNomFamilleSup.IsReadOnly = true;
                    txtAdresseSup.Text = personne.Adresse;
                    txtAdresseSup.IsReadOnly = true;
                    txtVilleSup.Text = personne.Ville;
                    txtVilleSup.IsReadOnly = true;
                    txtProvinceSup.Text = personne.Province;
                    txtProvinceSup.IsReadOnly = true;
                    txtCodePostalSup.Text = personne.CodePostal;
                    txtCodePostalSup.IsReadOnly = true;
                    txtTelPrincSup.Text = personne.TelephonePrinc;
                    txtTelPrincSup.IsReadOnly = true;
                    txtTelAutreSup.Text = personne.TelephoneAutre;
                    txtTelAutreSup.IsReadOnly = true;
                    txtDateNaissanceSup.Text = personne.DateNaissance.ToString();
                    txtDateNaissanceSup.IsReadOnly = true;
                    txtSexeSup.Text = personne.Sexe;
                    txtSexeSup.IsReadOnly = true;
                    txtAssuranceMaladieSup.Text = personne.AssuranceMaladie;
                    txtAssuranceMaladieSup.IsReadOnly = true;
                }
            }
        }
        
        private void buttonConfirmerSup_Click(object sender, RoutedEventArgs e)
        {
            bool success = c.ChangerStatus(Convert.ToInt32(txtIDEmployeSup.Text));

            if (success)
            {
                MessageBox.Show("Employe est supprimé avec succès!");
            }
            else
            {
                MessageBox.Show("Employe a etait déjà supprimé!");
            }

            txtIDEmployeSup.Clear();
            txtPrenomSup.Clear();
            txtNomFamilleSup.Clear();
            txtAdresseSup.Clear();
            txtVilleSup.Clear();
            txtProvinceSup.Clear();
            txtCodePostalSup.Clear();
            txtTelPrincSup.Clear();
            txtTelAutreSup.Clear();
            txtDateNaissanceSup.Clear();
            txtSexeSup.Clear();
            txtAssuranceMaladieSup.Clear();
            txtAssuranceSocialSup.Clear();
            txtStatus.Clear();

        }

        private void cboDepartement_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void buttonQuitterSup_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        

        
    }
}
