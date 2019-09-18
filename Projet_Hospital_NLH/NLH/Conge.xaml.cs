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
    /// Logique d'interaction pour Conge.xaml
    /// </summary>
    public partial class Conge : Window
    {
        Controler c;

        public Conge()
        {
            InitializeComponent();
            c = Controler.GetInstance();

        }

        private void btnRecherche_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtidadmission.Text))
            {
                MessageBox.Show("Entrer l'ID d'admission");
            }
            else
            {
                ViewFichierAdmission fichier = c.RechercheFichierAdmission(Convert.ToInt32(txtidadmission.Text));

                if (fichier == null)
                {
                    MessageBox.Show("Cette admission a déjà une date de congé attribuée"); 
                }
                else
                {
                    txtNomPatient.Text = fichier.NomPatient;
                    txtNomPatient.IsReadOnly = true;
                    txtMedecin.Text = fichier.NomMedecin;
                    txtMedecin.IsReadOnly = true;
                    txtTypeLitOccupe.Text = fichier.TypeLit;
                    txtTypeLitOccupe.IsReadOnly = true;
                    txtLitAttribue.Text = fichier.LitAttribue;
                    txtLitAttribue.IsReadOnly = true;
                    txtDateAdmission.Text = Convert.ToString(fichier.DateAdmission);
                    txtDateAdmission.IsReadOnly = true;
                }
            }
        }

        private void btnConfirmerConge_Click(object sender, RoutedEventArgs e)
        {

            if (datePickerDateConge.SelectedDate == null)
            {
                MessageBox.Show("Sélectionne une date de congé");
            }

            else
            {
                c.DonnerConge(Convert.ToInt32(txtidadmission.Text), Convert.ToDateTime(datePickerDateConge.Text));
                MessageBox.Show("Congé attribué avec succès");
                txtidadmission.Clear();
                txtNomPatient.Clear();
                txtMedecin.Clear();
                txtTypeLitOccupe.Clear();
                txtLitAttribue.Clear();
                txtDateAdmission.Clear();
                datePickerDateConge.SelectedDate = null;
            }
            
        }

        private void btnQuitter_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void txtidadmission_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtNomPatient.Clear();
            txtMedecin.Clear();
            txtTypeLitOccupe.Clear();
            txtLitAttribue.Clear();
            txtDateAdmission.Clear();
        }        

    }
}
