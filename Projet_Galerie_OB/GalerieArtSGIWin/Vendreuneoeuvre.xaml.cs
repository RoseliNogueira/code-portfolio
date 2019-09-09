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

namespace GalerieArtSGIWin
{
    /// <summary>
    /// Logique d'interaction pour Vendreuneoeuvre.xaml
    /// </summary>
    public partial class Vendreuneoeuvre : Window
    {

        string idOeuvreVendre = "";
        double prixvente = 0;

        public Vendreuneoeuvre()
        {
            InitializeComponent();
        }

        private void buttonVendre_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                idOeuvreVendre = txtIDOeuvVendre.Text;
                prixvente = Convert.ToDouble(txtPrixVente.Text);
            }
            catch
            {
                MessageBox.Show("Les champs doivent être remplis pour que la vente soit complétée.");
                return;
            }

            int retourneCode = SGIArt.gal.VendreOeuvre(idOeuvreVendre, prixvente);
            if (retourneCode == 0)
            {
                MessageBox.Show("L'oeuvre vendue, felicitation!");
                this.Close();
            }
            if (retourneCode == 1)
            {
                MessageBox.Show("L'oeuvre n'a pas été trouvée ou l'oeuvre est Entreposée");
                return;
            }
            if (retourneCode == 2)
            {
                MessageBox.Show("Désole! Cet oeuvre est déjà vendue.");
                return;
            }
            if (retourneCode == 3)
            {
                MessageBox.Show("Le prix est inferieur à la valeur de l'oeuvre");
                return;
            }

        }

        private void buttonAnnuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
    }
}
