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
    /// Logique d'interaction pour SGIArt.xaml
    /// </summary>
    public partial class SGIArt : Window
    {
        string prenomConserv = "";
        string nomConserv = "";
        string idConserv = "";
        string prenomArt = "";
        string nomArt = "";
        string idArt = "";
        string titreOeuv = "";
        string idOeuv = "";
        string anneeOeuv = "";
        double valeurOeuv = 0;
        char etat = ' ';
        bool IDTrouver;
 

        public static Galerie gal = new Galerie();
        

        public SGIArt()
        {
            InitializeComponent();
            radioExposee.IsChecked = true;
        }

        private void buttonAjouterConserv_Click(object sender, RoutedEventArgs e)
        {
            
            prenomConserv = txtPrenomConserv.Text;
            nomConserv = txtNomConserv.Text;
            idConserv = txtIDConserv.Text;

            
            if (prenomConserv == "")
            {
                MessageBox.Show("Le champ Prénom doit être rempli pour que le conservateur soit ajouté.");
                return;
            }
            if (nomConserv == "")
            {
                MessageBox.Show("Le champ Nom doit être rempli pour que le conservateur soit ajouté.");
                return;
            }
            if (idConserv == "")
            {
                MessageBox.Show("Le champ ID doit être rempli pour que le conservateur soit ajouté.");
                return;
            }

            IDTrouver = gal.ChercheIDConserv(idConserv);
            if (IDTrouver == false)
            {
                gal.AjouterConservateur(prenomConserv, nomConserv, idConserv, 0);
            }
            else 
            {
                MessageBox.Show("Existe déjà un conservateur associé à cet ID");
                txtIDConserv.Clear();
                return;
            }

            txtPrenomConserv.Clear();
            txtNomConserv.Clear();
            txtIDConserv.Clear();
        }

        private void buttonAjouterArt_Click(object sender, RoutedEventArgs e)
        {
            prenomArt = txtPrenomArt.Text;
            nomArt = txtNomArt.Text;
            idArt = txtIDArt.Text;

            if (prenomArt == "")
            {
                MessageBox.Show("Le champ Prénom doit être rempli pour que l'artiste soit ajouté.");
                return;
            }
            if (nomArt == "")
            {
                MessageBox.Show("Le champ Nom doit être rempli pour que l'artiste soit ajouté.");
                return;
            }
            if (idArt == "")
            {
                MessageBox.Show("Le champ ID doit être rempli pour que l'artiste soit ajouté.");
                return;
            }

            IDTrouver = gal.ChercheIDArtiste(idArt);
            if (IDTrouver == false)
            {
                gal.AjouterArtiste(prenomArt, nomArt, idArt);
            }
            else
            {
                MessageBox.Show("Existe déjà un artiste associé à cet ID");
                txtIDArt.Clear();
                return;
            }

            txtPrenomArt.Clear();
            txtNomArt.Clear();
            txtIDArt.Clear();
        }

        private void buttonAfficherArt_Click(object sender, RoutedEventArgs e)
        {
            textBoxAfficherResult.Text = "Liste des Artistes" + "\n" + gal.AfficherArtistes();
        }

        private void buttonArtisteOeuvre_Click(object sender, RoutedEventArgs e)
        {
            textBoxAfficherResult.Text = "Liste des Artistes" + "\n" + gal.AfficherArtistes();
        }

        private void buttonAfficherConserv_Click(object sender, RoutedEventArgs e)
        {
            textBoxAfficherResult.Text = "Liste des Conservateurs" + "\n" + gal.AfficherConservateurs();
        }

        private void buttonConservsOeuvre_Click(object sender, RoutedEventArgs e)
        {
            textBoxAfficherResult.Text = "Liste des Conservateurs" + "\n" + gal.AfficherConservateurs();
        }

        private void buttonListeOeuvres_Click(object sender, RoutedEventArgs e)
        {
            textBoxAfficherResult.Text = "Liste des Oeuvres" + "\n" + gal.AfficherOeuvres();
        }

        private void buttonAjouterOeuvre_Click(object sender, RoutedEventArgs e)
        {
            idOeuv = txtIDOeuvre.Text;
            titreOeuv = txtTitreOeuvre.Text;
            anneeOeuv = txtAnneeOeuvre.Text;

            try
            {
                valeurOeuv = Convert.ToDouble(txtValeurOeuvre.Text);
            }
            catch
            {
                MessageBox.Show("Le champ Valeur estimée doit être rempli avec une valeur.");
                txtValeurOeuvre.Clear();
                return;
            }

            idArt = txtIDArtOeuvre.Text;
            idConserv = txtIDConservOeuvre.Text;
            SetEtat();

            if (idOeuv == "")
            {
                MessageBox.Show("Le champ ID doit être rempli pour que l'oeuvre soit ajouté.");
                return;
            }
            if (titreOeuv == "")
            {
                MessageBox.Show("Le champ Titre doit être rempli pour que l'oeuvre soit ajouté.");
                return;
            }
            if (anneeOeuv == "")
            {
                MessageBox.Show("Le champ Année doit être rempli pour que l'oeuvre soit ajouté.");
                return;
            }

            if (idArt == "")
            {
                MessageBox.Show("Le champ ID Artiste doit être rempli pour que l'oeuvre soit ajouté.");
                return;
            }

            if (idConserv == "")
            {
                MessageBox.Show("Le champ ID Conservateur doit être rempli pour que l'oeuvre soit ajouté.");
                return;
            }

            bool IDTrouver = gal.ChercheIDOeuvre(idOeuv);
            if (IDTrouver == true)
            {
                MessageBox.Show("Existe déjà un oeuvre associé à cet ID");
                txtIDOeuvre.Clear();
                return;
            }

            IDTrouver = gal.ChercheIDArtiste(idArt);
            if (IDTrouver == false)
            {
                MessageBox.Show("L'artiste n'a pas été trouvé");
                txtIDArt.Clear();
                return;
            }

            IDTrouver = gal.ChercheIDConserv(idConserv);
            if (IDTrouver == false)
            {
                MessageBox.Show("Le conservateur n'a pas été trouvé");
                txtIDConservOeuvre.Clear();
                return;
            }
            
            gal.AjouterOeuvre(idOeuv, titreOeuv, anneeOeuv, 0, valeurOeuv, idArt, idConserv, etat);
            txtIDOeuvre.Clear();
            txtTitreOeuvre.Clear();
            txtAnneeOeuvre.Clear();
            txtValeurOeuvre.Clear();
            txtIDArtOeuvre.Clear();
            txtIDConservOeuvre.Clear();
        }

        private void SetEtat()
        {
            if (radioExposee.IsChecked == true)
            {
                etat = 'E';
            }
            if (radioEntreposee.IsChecked == true)
            {
                etat = 'N';
            }
        }

        private void buttonFermer_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void buttonSauvegConserv_Click(object sender, RoutedEventArgs e)
        {
            gal.EcrireConservateurs();
            MessageBox.Show("Les conservateurs étés sauvegardés avec succès");
        }

        private void txtNomArt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtPrenomArt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtPrenomConserv_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void buttonVendreOeuvre_Click(object sender, RoutedEventArgs e)
        {
            Vendreuneoeuvre vendreuneOeuvre = new Vendreuneoeuvre ();
            vendreuneOeuvre.ShowDialog();
        }

        private void buttonOuvrirConserv_Click(object sender, RoutedEventArgs e)
        {
            gal.LireConservateurs();
            MessageBox.Show("L'archive ouverte avec succès");
        }

        private void radioExposee_Checked(object sender, RoutedEventArgs e)
        {

        }

    }
}