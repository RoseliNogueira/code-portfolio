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
using System.Diagnostics;
using System.IO;

namespace ATM
{
    /// <summary>
    /// Logique d'interaction pour Superviseur.xaml
    /// </summary>
    public partial class Superviseur : Window
    {
        public static GestionnaireGuichet gestionnaire = new GestionnaireGuichet();

        public Superviseur()
        {
            InitializeComponent();
            gestionnaire.LireCompte();
        }

        private void buttonPaiementdesinterets_Click(object sender, RoutedEventArgs e)
        {
            txtBoxImprimer.Clear();

            bool paiement = gestionnaire.PaiementInteret();

            if (paiement == true)
            {
                MessageBox.Show("Paiement d'intérêt sur les comptes épargne effetue avec succès");
            }
            else
            {
                MessageBox.Show("Il n'y a pas de compte épargne");
            }

        }

        private void buttonMisehorsdeservice_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void buttonRajouterargent_Click(object sender, RoutedEventArgs e)
        {
            txtBoxImprimer.Clear();
            
            bool remplir = gestionnaire.RemplirGuichet(Convert.ToDouble(gestionnaire.AfficherSoldeBanque()));

            if (remplir == true)
            {
                MessageBox.Show("Remplissage effetue avec succés. Solde du guichet: $" + gestionnaire.AfficherSoldeBanque());
            }
            else
            {
                MessageBox.Show("Operation n'a pas été effetue. Le limite pour remplissage est de $20.000. Solde du guichet: $" + gestionnaire.AfficherSoldeBanque());
            }
        }

        private void buttonImprimerrapports_Click(object sender, RoutedEventArgs e)
        {
            txtBoxImprimer.Text = "Liste des Comptes" + "\n" + "\n" + gestionnaire.ImprimerComptes();
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void buttonFermerSuperviseur_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
        }


    }
}
