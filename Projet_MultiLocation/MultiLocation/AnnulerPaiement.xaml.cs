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

namespace MultiLocation
{
    /// <summary>
    /// Logique d'interaction pour AnnulerPaiement.xaml
    /// </summary>
    public partial class AnnulerPaiement : Window
    {
        MLE6327Entities1 MaMLE6327Entities1;
        Paiement mompaiement = new Paiement();

        public AnnulerPaiement()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MaMLE6327Entities1 = new MLE6327Entities1();
            txtCodeLocation.DataContext = MaMLE6327Entities1.Paiements;
            txtDatePaiement.DataContext = MaMLE6327Entities1.Paiements;
            txtMontant.DataContext = MaMLE6327Entities1.Paiements;
            cboCodePaiement.DataContext = MaMLE6327Entities1.Paiements;
            txtDatePaiement.IsReadOnly = true;
            txtCodeLocation.IsReadOnly = true;
        }

        private void cboCodePaiement_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Paiement PaiementSelect = cboCodePaiement.SelectedItem as Paiement;

            txtCodeLocation.Text = PaiementSelect.CodeLocation.ToString();
            txtDatePaiement.Text = PaiementSelect.DatePaiement.ToString();
            txtMontant.Text = PaiementSelect.Montant.ToString();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            Paiement PaiementSelect = cboCodePaiement.SelectedItem as Paiement;

            PaiementSelect.CodePaiement = int.Parse(cboCodePaiement.Text);
            PaiementSelect.CodeLocation = int.Parse(txtCodeLocation.Text);
            PaiementSelect.DatePaiement = DateTime.Parse(txtDatePaiement.Text);
            PaiementSelect.Montant = float.Parse(txtMontant.Text);

            MaMLE6327Entities1.Paiements.ApplyCurrentValues(PaiementSelect);

            MaMLE6327Entities1.SaveChanges();

            MessageBox.Show("Modification effetue avec succès");
        }

        private void btnQuitter_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void txtMontant_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}