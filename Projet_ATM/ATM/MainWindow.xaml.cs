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
using System.IO;

namespace ATM
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public Banque banque = new Banque();
        public GestionnaireGuichet gestionnaire = new GestionnaireGuichet();
        
        int counter = 0;

        public MainWindow()
        {
            InitializeComponent();
            txtUtilisateur.Text = String.Empty;
            gestionnaire.EcrireClient();
            txtUtilisateur.Focus();
        }

        public bool LireClient()
        {
            bool Lu = false;

            FileStream fichierClient = new FileStream("Clients.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fichierClient);

            if (sr != null)
            {
                Lu = true;
            }

            sr.Close();
            return Lu;
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            
            if ((txtUtilisateur.Text == "") || (passPIN.Password == ""))
            {
                MessageBox.Show("S'il vous plaît entre l'utilisateur et le PIN");
            }

            while ((counter < 2) && (gestionnaire.ValiderUtilisateur(txtUtilisateur.Text, passPIN.Password) == false))
                {
                    MessageBox.Show("S'il vous plaît, essaye a nouveau");
                    counter++;
                    txtUtilisateur.Clear();
                    passPIN.Clear();
                    return;
                }

                if (counter == 2)
                {
                    MessageBox.Show("S'il vous plaît essaye d'utiliser le guichet ATM plus tard");
                    Environment.Exit(0);
                }
                else if ((txtUtilisateur.Text == "Korben Dallas") || (passPIN.Password == "D001"))
                {
                    this.Close();
                    Superviseur superviseur = new Superviseur();
                    superviseur.ShowDialog();
                }
                else
                {
                    
                    GuichetATM guichetATM = new GuichetATM(passPIN.Password);
                    guichetATM.ShowDialog();
                    
                }
          }

        private void btnAnuller_Click(object sender, RoutedEventArgs e)
        {
            txtUtilisateur.Clear();
            passPIN.Clear();
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
