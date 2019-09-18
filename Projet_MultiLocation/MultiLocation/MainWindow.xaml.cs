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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MultiLocation
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            Ajouter ajouter = new Ajouter();
            ajouter.Show();
        }

        private void btnModifier_Click(object sender, RoutedEventArgs e)
        {
            Modifier modifier = new Modifier();
            modifier.ShowDialog();
        }

        private void btnAnnulerPaiement_Click(object sender, RoutedEventArgs e)
        {
            AnnulerPaiement annulerpaiement = new AnnulerPaiement();
            annulerpaiement.ShowDialog();
        }

        private void btnQuitter_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
