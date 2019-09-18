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
    /// Logique d'interaction pour FichierAdmission.xaml
    /// </summary>
    public partial class FichierAdmission : Window
    {
        Controler c;

        public FichierAdmission()
        {
            InitializeComponent();
            c = Controler.GetInstance();
            
            cboSexe.Items.Add("F");
            cboSexe.Items.Add("M");
            
            cboTypeLit.Items.Add("Standard");
            cboTypeLit.Items.Add("Semi-Privée");
            cboTypeLit.Items.Add("Privée");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cboLitAttribue.SelectedIndex = -1;

            cboMedecinAttribue.ItemsSource = c.Medecin();
            cboMedecinAttribue.DisplayMemberPath = "NomMedecin";
            cboMedecinAttribue.SelectedIndex = -1;
        }
        
        private void cboTypeLit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((ComboBox)sender).SelectedIndex != -1)
            {
                cboLitAttribue.ItemsSource = c.GetLitsDisponibles(cboTypeLit.SelectedItem.ToString());
                cboLitAttribue.DisplayMemberPath = "LitsAttribue";
            }
            else
            {
                cboLitAttribue.SelectedIndex = -1;
            }
                     
        }

        private void cboLitAttribue_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((ComboBox)sender).SelectedIndex != -1)
            {
                c.GetLitsDisponibles(cboTypeLit.SelectedItem.ToString());
            }
            else
            {
                cboMedecinAttribue.SelectedIndex = -1;
            }
        }

        private void datePickerDateNaissance_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {            
            c.CalcAge(Convert.ToDateTime(datePickerDateNaissance.SelectedDate));            
        }

        private void buttonQuitter_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void buttonConfirmer_Click(object sender, RoutedEventArgs e)
        {
            bool success = true;
            foreach (Control ctr in main_grid.Children)
            {
                if (ctr is TextBox)
                {
                    
                    if (string.IsNullOrEmpty(((TextBox)ctr).Text) && (string.Compare(((TextBox)ctr).Tag.ToString(),"*")==1)?true:false)
                    {
                        MessageBox.Show("S'il vous plaît, vérifie si vous avez entre toutes les informations nécessaires");
                        success = false;
                        break;
                    }
                }
                if (ctr is DatePicker)
                {
                    if (((DatePicker)ctr).SelectedDate == null)
                    {
                        MessageBox.Show("S'il vous plaît, vérifie si vous avez entre toutes les informations nécessaires");
                        success = false;
                        break;
                    }
                }
                if (ctr is ComboBox)
                {
                    if (string.IsNullOrEmpty(((ComboBox)ctr).Text))
                    {
                        MessageBox.Show("S'il vous plaît, vérifie si vous avez entre toutes les informations nécessaires");
                        success = false;
                        break;
                    }
                }
            }

            if(success)
            {
                ViewPatient patient = c.RecherchePatient(txtAssuranceMaladie.Text);

                if (c.ExistPatient == true)
                {
                    int personneID = c.RecherchePatient(txtAssuranceMaladie.Text).IDPersonne;
                    int patientID = c.RecherchePatient(txtAssuranceMaladie.Text).IDPatient;
                    int employeID = ((ViewMedecin)(cboMedecinAttribue.SelectedItem)).IDEmploye;
                    int litID = ((ViewLitsDepartement)(cboLitAttribue.SelectedItem)).IDLits;
                    ViewPatient vp = c.RecherchePatient(txtAssuranceMaladie.Text);
                    
                    c.AjoutFichierAdmission(personneID, patientID, txtPrenom.Text, txtNomFamille.Text, txtAdresse.Text, txtVille.Text, txtProvince.Text,
                        txtCodePostal.Text, txtTelPrinc.Text, txtTelAutre.Text, Convert.ToDateTime(datePickerDateNaissance.Text), cboSexe.Text,
                        txtAssuranceMaladie.Text, employeID, litID, Convert.ToDateTime(datePickerDateAdmission.Text), txtAssurancePrivee.Text, vp,
                        txtParentPlusProche.Text);

                    MessageBox.Show("Fichier d'admission ajouté avec succèss!");

                    txtAssuranceMaladie.Clear();
                    datePickerDateAdmission.SelectedDate = null;
                    txtPrenom.Clear();
                    txtNomFamille.Clear();
                    txtAdresse.Clear();
                    txtVille.Clear();
                    txtCodePostal.Clear();
                    txtProvince.Clear();
                    cboSexe.SelectedIndex = -1;
                    txtTelPrinc.Clear();
                    txtTelAutre.Clear();
                    datePickerDateNaissance.SelectedDate = null;
                    txtAssurancePrivee.Clear();
                    txtParentPlusProche.Clear();
                    cboTypeLit.SelectedIndex = -1;                    
                }
                else
                {
                    c.AjoutPatient(txtPrenom.Text, txtNomFamille.Text, txtAdresse.Text, txtVille.Text, txtProvince.Text, txtCodePostal.Text,
                        txtTelPrinc.Text, txtTelAutre.Text, Convert.ToDateTime(datePickerDateNaissance.Text), cboSexe.Text, txtAssuranceMaladie.Text,
                        txtParentPlusProche.Text);

                    patient = c.RecherchePatient(txtAssuranceMaladie.Text);

                    int personneID = c.RecherchePatient(txtAssuranceMaladie.Text).IDPersonne;
                    int patientID = c.RecherchePatient(txtAssuranceMaladie.Text).IDPatient;
                    int employeID = ((ViewMedecin)(cboMedecinAttribue.SelectedItem)).IDEmploye;
                    int litID = ((ViewLitsDepartement)(cboLitAttribue.SelectedItem)).IDLits;
                    ViewPatient vp = c.RecherchePatient(txtAssuranceMaladie.Text);

                    c.AjoutFichierAdmission(personneID, patientID, txtPrenom.Text, txtNomFamille.Text, txtAdresse.Text, txtVille.Text, txtProvince.Text,
                        txtCodePostal.Text, txtTelPrinc.Text, txtTelAutre.Text, Convert.ToDateTime(datePickerDateNaissance.Text), cboSexe.Text,
                        txtAssuranceMaladie.Text, employeID, litID, Convert.ToDateTime(datePickerDateAdmission.Text), txtAssurancePrivee.Text, vp,
                        txtParentPlusProche.Text);

                    MessageBox.Show("Fichier d'admission ajouté avec succèss!");

                    txtAssuranceMaladie.Clear();
                    datePickerDateAdmission.SelectedDate = null;
                    txtPrenom.Clear();
                    txtNomFamille.Clear();
                    txtAdresse.Clear();
                    txtVille.Clear();
                    txtCodePostal.Clear();
                    txtProvince.Clear();
                    cboSexe.SelectedIndex = -1;
                    txtTelPrinc.Clear();
                    txtTelAutre.Clear();
                    datePickerDateNaissance.SelectedDate = null;
                    txtAssurancePrivee.Clear();
                    txtParentPlusProche.Clear();
                    cboTypeLit.SelectedIndex = -1;                    
                }
            }
        }
        
        private void btnRecherche_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtAssuranceMaladie.Text))
            {
                MessageBox.Show("S'il vous plaît, entrer l'assurance maladie");
            }
            else
            {
                ViewPatient patient = c.RecherchePatient(txtAssuranceMaladie.Text);

                if (c.ExistPatient == true)
                {
                    txtPrenom.Text = patient.Prenom;
                    txtNomFamille.Text = patient.NomFamille;
                    txtAdresse.Text = patient.Adresse;
                    txtCodePostal.Text = patient.CodePostal;
                    txtVille.Text = patient.Ville;
                    txtProvince.Text = patient.Province;
                    cboSexe.Text = patient.Sexe;
                    txtTelPrinc.Text = patient.TelephonePrinc;
                    txtTelAutre.Text = patient.TelephoneAutre;
                    datePickerDateNaissance.Text = patient.DateNaissance.ToString();
                    txtParentPlusProche.Text = patient.ParentPlusProche;
                }

                else
                {
                    MessageBox.Show("Patient n'est pas trouvé, continuez à inclure les informations pour finaliser l'inclusion du patient");
                    txtAssuranceMaladie.Clear();
                    datePickerDateAdmission.SelectedDate = null;
                    txtPrenom.Clear();
                    txtNomFamille.Clear();
                    txtAdresse.Clear();
                    txtVille.Clear();
                    txtCodePostal.Clear();
                    txtProvince.Clear();
                    cboSexe.SelectedIndex = -1;
                    txtTelPrinc.Clear();
                    txtTelAutre.Clear();
                    datePickerDateNaissance.SelectedDate = null;
                    txtAssurancePrivee.Clear();
                    txtParentPlusProche.Clear();
                    cboTypeLit.SelectedIndex = -1;
                }
            }
        }
            
    }
}
