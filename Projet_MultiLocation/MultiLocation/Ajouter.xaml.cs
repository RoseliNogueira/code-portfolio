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
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Ajouter : Window
    {
        MLE6327Entities1 MaMLE6327Entities1;
        
        public Ajouter()
        {
            InitializeComponent();           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MaMLE6327Entities1 = new MLE6327Entities1();
            cboCodeClient.DataContext = MaMLE6327Entities1.Clients;            
            cboNIV.DataContext = MaMLE6327Entities1.Vehicules;
            cboCodeTermeLocation.DataContext = MaMLE6327Entities1.TermesLocations;
        }
        
        private void cboCodeTermeLocation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cboCodeTermeLocation.SelectedIndex.ToString())
            {
                case "0": txtNPaiementMensuel.Text = "36";
                    break;
                case "1": txtNPaiementMensuel.Text = "12";
                    break;
                case "2": txtNPaiementMensuel.Text = "24";
                    break;
                case "3": txtNPaiementMensuel.Text = "48";
                    break;
                case "4": txtNPaiementMensuel.Text = "12";
                    break;
            }
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            Location malocation = new Location();
            malocation.CodeClient = Convert.ToInt32(cboCodeClient.Text);
            malocation.NIV = cboNIV.Text;
            malocation.DateDebutLocation = Convert.ToDateTime(datePickerDateLocation.Text);
            malocation.DatePremierPaiement = Convert.ToDateTime(datePickerDatePaiement.Text);
            malocation.Montant = float.Parse(txtMontant.Text);
            malocation.CodeTermeLocation = Convert.ToInt32(cboCodeTermeLocation.Text);
            malocation.NoPaiementMensuel = Convert.ToInt32(txtNPaiementMensuel.Text);

            MaMLE6327Entities1.Locations.AddObject(malocation);

            MaMLE6327Entities1.SaveChanges();

            MessageBox.Show("La location était ajoutée avec succès");

        }

        private void cboNIV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void datePickerDateLocation_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime dt = (DateTime)datePickerDateLocation.SelectedDate;
            datePickerDatePaiement.SelectedDate = dt.AddMonths(1);
        }

        private void datePickerDatePaiement_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtMontant_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtNPaiementMensuel_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        
        private void btnQuitter_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
