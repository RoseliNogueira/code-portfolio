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
using System.Globalization;

namespace ATM
{
    /// <summary>
    /// Logique d'interaction pour GuichetATM.xaml
    /// </summary>
    public partial class GuichetATM : Window
    {

        string input = "";
        string nipValide = "";
        double montant = 0;
        int retMsg = 0;
        

        public GestionnaireGuichet gestionnaire = new GestionnaireGuichet();
        

        public GuichetATM(string nip)
        {
            InitializeComponent();
            this.nipValide = nip;
            gestionnaire.EcrireComptes();
            gestionnaire.LireCompte();
            txtPaveNumerique.Focus();
            
        }

        private void buttonNumero1_Click(object sender, RoutedEventArgs e)
        {
            this.txtPaveNumerique.Text = "";
            input += "1";
            this.txtPaveNumerique.Text += input;
        }

        private void buttonNumero2_Click(object sender, RoutedEventArgs e)
        {
            this.txtPaveNumerique.Text = "";
            input += "2";
            this.txtPaveNumerique.Text += input;
        }

        private void buttonNumero3_Click(object sender, RoutedEventArgs e)
        {
            this.txtPaveNumerique.Text = "";
            input += "3";
            this.txtPaveNumerique.Text += input;
        }

        private void buttonNumero4_Click(object sender, RoutedEventArgs e)
        {
            this.txtPaveNumerique.Text = "";
            input += "4";
            this.txtPaveNumerique.Text += input;
        }

        private void buttonNumero5_Click(object sender, RoutedEventArgs e)
        {
            this.txtPaveNumerique.Text = "";
            input += "5";
            this.txtPaveNumerique.Text += input;
        }

        private void buttonNumero6_Click(object sender, RoutedEventArgs e)
        {
            this.txtPaveNumerique.Text = "";
            input += "6";
            this.txtPaveNumerique.Text += input;
        }

        private void buttonNumero7_Click(object sender, RoutedEventArgs e)
        {
            this.txtPaveNumerique.Text = "";
            input += "7";
            this.txtPaveNumerique.Text += input;
        }

        private void buttonNumero8_Click(object sender, RoutedEventArgs e)
        {
            this.txtPaveNumerique.Text = "";
            input += "8";
            this.txtPaveNumerique.Text += input;
        }

        private void buttonNumero9_Click(object sender, RoutedEventArgs e)
        {
            this.txtPaveNumerique.Text = "";
            input += "9";
            this.txtPaveNumerique.Text += input;
        }

        private void buttonAC_Click(object sender, RoutedEventArgs e)
        {
            input = "";
            txtPaveNumerique.Clear();
        }

        private void buttonNumero0_Click(object sender, RoutedEventArgs e)
        {
            this.txtPaveNumerique.Text = "";
            input += "0";
            this.txtPaveNumerique.Text += input;
        }

        private void buttonPoint_Click(object sender, RoutedEventArgs e)
        {
            if (txtPaveNumerique.Text.Trim() == string.Empty)
            {
                input += "0.";
                this.txtPaveNumerique.Text += input;
            }
            else if (!txtPaveNumerique.Text.Contains('.'))
            {
                this.txtPaveNumerique.Text = "";
                input += ".";
                this.txtPaveNumerique.Text += input;
            }
        }

        private void txtPaveNumerique_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void buttonSoumettre_Click(object sender, RoutedEventArgs e)
        {
            if ((txtPaveNumerique.Text.Trim() == string.Empty) || (Convert.ToDouble(txtPaveNumerique.Text) == 0))
            {
                MessageBox.Show("S'il vous plaît, insère une valeur");
                input = "";
                txtPaveNumerique.Clear();

                return;
            }

            MessageBoxResult dialogue;
            double montantDisponible = 0;

            //vérifie si une transaction est un compte était choisie
            if ((radioButtonDepot.IsChecked == true || radioButtonRetrait.IsChecked == true || radioButtonTransfert.IsChecked == true || radioButtonPaiement.IsChecked == true) && (radioButtonCheque.IsChecked == true || radioButtonEpargne.IsChecked == true))
            {
                if ((radioButtonRetrait.IsChecked == true) && (radioButtonCheque.IsChecked == true))
                {
                    montant = double.Parse(txtPaveNumerique.Text, CultureInfo.InvariantCulture);

                    retMsg = gestionnaire.RetraitCheque(nipValide, montant);

                    switch (retMsg)
                    {
                        case 0: MessageBox.Show("Le retrait été efetue avec succès. Solde du compte: $" + gestionnaire.AfficherSoldeCompteC(nipValide));
                            break;
                        case 1: MessageBox.Show("Solde du compte insuffisant");
                            break;
                        case 2: MessageBox.Show("Valeur supérieur au maximum permis");
                            break;
                        case 3: MessageBox.Show("Le montant n'est pas de multiple de 10");
                            break;
                        case 4: dialogue = MessageBox.Show("Désole! Le montant demandé est supérieur au montant disponible dans le guichet. Le montant disponible est $" + gestionnaire.AfficherSoldeBanque() + ". Voulez-vous retirer toute l'argent disponible?", "S'il vous plaît repondez", MessageBoxButton.YesNo);
                            if (dialogue == MessageBoxResult.Yes)
                            {
                                montantDisponible = Convert.ToDouble(gestionnaire.AfficherSoldeBanque());
                                gestionnaire.RetraitCheque(nipValide, montantDisponible);
                                goto case 0;
                            }
                            else if (dialogue == MessageBoxResult.No)
                            {
                                break;
                            }
                            break;
                        case 5: MessageBox.Show("Le compte n'a pas été trouvé");
                            break;

                    }
                    input = "";
                    txtPaveNumerique.Clear();
                }
            }
            else
            {
                MessageBox.Show("Il faut choisir une transaction et un compte");
            }

            if ((radioButtonRetrait.IsChecked == true) && (radioButtonEpargne.IsChecked == true))
            {
                montant = double.Parse(txtPaveNumerique.Text, CultureInfo.InvariantCulture);

                retMsg = gestionnaire.RetraitEpargne(nipValide, montant);

                switch (retMsg)
                    {
                        case 0: MessageBox.Show("Le retrait été efetue avec succès. Solde du compte: $" + gestionnaire.AfficherSoldeCompteE(nipValide));
                            break;
                        case 1: MessageBox.Show("Solde du compte insuffisant");
                            break;
                        case 2: MessageBox.Show("Valeur supérieur au maximum permis");
                            break;
                        case 3: MessageBox.Show("Le montant n'est pas de multiple de 10");
                            break;
                        case 4: dialogue = MessageBox.Show("Désole! Le montant demandé est supérieur au montant disponible dans le guichet. Le montant disponible est $" + gestionnaire.AfficherSoldeBanque() + ". Voulez-vous retirer toute l'argent disponible?", "S'il vous plaît repondez", MessageBoxButton.YesNo);
                            if (dialogue == MessageBoxResult.Yes)
                            {
                                montantDisponible = Convert.ToDouble(gestionnaire.AfficherSoldeBanque());
                                gestionnaire.RetraitCheque(nipValide, montantDisponible);
                                goto case 0;
                            }
                            else if (dialogue == MessageBoxResult.No)
                            {
                                break;
                            }
                            break;
                        case 5: MessageBox.Show("Le compte n'a pas été trouvé");
                            break;

                    }
                    input = "";
                    txtPaveNumerique.Clear();
                }

            if ((radioButtonDepot.IsChecked == true) && (radioButtonCheque.IsChecked == true))
            {
                montant = double.Parse(txtPaveNumerique.Text, CultureInfo.InvariantCulture);

                retMsg = gestionnaire.DepotCheque(nipValide, montant);
                
                if (retMsg == 1)
                {
                    MessageBox.Show("Le dépôt été efetue avec succès. Solde du compte: $" + gestionnaire.AfficherSoldeCompteC(nipValide));
                }
                else if (retMsg == 0)
                {
                    MessageBox.Show("Le dépôt n'a pas été efetue avec succès");
                }
              
                input = "";
                txtPaveNumerique.Clear();
            }

            if ((radioButtonDepot.IsChecked == true) && (radioButtonEpargne.IsChecked == true))
            {
                montant = double.Parse(txtPaveNumerique.Text, CultureInfo.InvariantCulture);

                retMsg = gestionnaire.DepotEpargne(nipValide, montant);

                if (retMsg == 1)
                {
                    MessageBox.Show("Le dépôt été efetue avec succès. Solde du compte: $" + gestionnaire.AfficherSoldeCompteE(nipValide));
                }
                else if (retMsg == 0)
                {
                    MessageBox.Show("Le dépôt n'a pas été efetue avec succès");
                }

                input = "";
                txtPaveNumerique.Clear();
            }

            if ((radioButtonPaiement.IsChecked == true) && (radioButtonEpargne.IsChecked == true))
            {
                MessageBox.Show("L'opération autorisée seulement à partir du compte chèque");
            }   
            else if ((radioButtonPaiement.IsChecked == true) && (radioButtonCheque.IsChecked == true))
            {
                montant = double.Parse(txtPaveNumerique.Text, CultureInfo.InvariantCulture);

                retMsg = gestionnaire.PaiementFacture(nipValide, montant);

                switch (retMsg)
                {
                    case 0: MessageBox.Show("Paiement effectué avec succès. Solde du compte chèque: $" + gestionnaire.AfficherSoldeCompteC(nipValide));
                        break;
                    case 1: MessageBox.Show("Solde du compte insuffisant");
                        break;
                    case 2: MessageBox.Show("Valeur supérieur au maximum permis");
                        break;
                    case 3: MessageBox.Show("Le compte n'a pas été trouvé");
                        break;
                }
                input = "";
                txtPaveNumerique.Clear();
            }

            if ((radioButtonTransfert.IsChecked == true) && (radioButtonCheque.IsChecked == true))
            {
                montant = double.Parse(txtPaveNumerique.Text, CultureInfo.InvariantCulture);

                retMsg = gestionnaire.TransfertFonds(nipValide, montant, 'C');

                switch (retMsg)
                {
                    case 0: MessageBox.Show("Transfert effectué du compte chèque vers le compte épargne avec succès. Solde du compte chèque: $" + gestionnaire.AfficherSoldeCompteC(nipValide));
                        break;
                    case 1: MessageBox.Show("Solde du compte insuffisant");
                        break;
                    case 2: MessageBox.Show("Valeur supérieur au maximum permis de $100.000");
                        break;
                    case 3: MessageBox.Show("Le compte n'a pas été trouvé");
                        break;
                }
                input = "";
                txtPaveNumerique.Clear();
            }

            if ((radioButtonTransfert.IsChecked == true) && (radioButtonEpargne.IsChecked == true))
            {
                montant = double.Parse(txtPaveNumerique.Text, CultureInfo.InvariantCulture);

                retMsg = gestionnaire.TransfertFonds(nipValide, montant, 'E');

                switch (retMsg)
                {
                    case 0: MessageBox.Show("Transfert effectué du compte chèque vers le compte épargne avec succès. Solde du compte chèque: $" + gestionnaire.AfficherSoldeCompteE(nipValide));
                        break;
                    case 1: MessageBox.Show("Solde du compte insuffisant");
                        break;
                    case 2: MessageBox.Show("Valeur supérieur au maximum permis de $100.000");
                        break;
                    case 3: MessageBox.Show("Le compte n'a pas été trouvé");
                        break;
                }
                input = "";
                txtPaveNumerique.Clear();
            }
        }

        private void buttonFermer_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            //MainWindow mainWindow = new MainWindow();
            //mainWindow.ShowDialog();
        }

        private void radioButtonCheque_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void radioButtonDepot_Checked(object sender, RoutedEventArgs e)
        {
            radioButtonCheque.IsChecked = true;
        }

        private void radioButtonRetrait_Checked(object sender, RoutedEventArgs e)
        {
            radioButtonCheque.IsChecked = true;
        }
    }
}
