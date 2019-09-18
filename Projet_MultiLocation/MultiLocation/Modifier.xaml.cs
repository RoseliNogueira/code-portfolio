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
    /// Logique d'interaction pour Modifier.xaml
    /// </summary>
    public partial class Modifier : Window
    {
        MLE6327Entities1 MaMLE6327Entities1;

        public Modifier()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MaMLE6327Entities1 = new MLE6327Entities1();
            cboCodeLocation.DataContext = MaMLE6327Entities1.Locations;
            cboCodeClient.DataContext = MaMLE6327Entities1.Clients;
            cboNIV.DataContext = MaMLE6327Entities1.Vehicules;
            cboCodeTermeLocation.DataContext = MaMLE6327Entities1.TermesLocations;
        }

        private void cboCodeLocation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Location LocSelect = cboCodeLocation.SelectedItem as Location;

            cboCodeClient.Text = LocSelect.CodeClient.ToString();
            cboNIV.Text = LocSelect.NIV.ToString();
            datePickerDateLocation.Text = LocSelect.DateDebutLocation.ToString();
            datePickerDatePremierPaiement.Text = LocSelect.DatePremierPaiement.ToString();
            txtMontant.Text = LocSelect.Montant.ToString();
            cboCodeTermeLocation.Text = LocSelect.CodeTermeLocation.ToString();
            txtPaiementMensuel.Text = LocSelect.NoPaiementMensuel.ToString();
        }

        private void btnQuitter_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click_1(object sender, RoutedEventArgs e)
        {
            Location LocSelect = (Location)cboCodeLocation.SelectedItem;

            LocSelect.CodeClient = int.Parse(cboCodeClient.Text);
            LocSelect.NIV = cboNIV.Text;
            LocSelect.DateDebutLocation = DateTime.Parse(datePickerDateLocation.Text);
            LocSelect.DatePremierPaiement = DateTime.Parse(datePickerDatePremierPaiement.Text);
            LocSelect.Montant = float.Parse(txtMontant.Text);
            LocSelect.CodeTermeLocation = int.Parse(cboCodeTermeLocation.Text);
            LocSelect.NoPaiementMensuel = int.Parse(txtPaiementMensuel.Text);

            MaMLE6327Entities1.Locations.ApplyCurrentValues(LocSelect);

            MaMLE6327Entities1.SaveChanges();

            MessageBox.Show("Modification effetue avec succès");
        }

    }
}
