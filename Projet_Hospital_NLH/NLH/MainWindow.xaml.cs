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
using NLH_DLL;


namespace NLH
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Controler c;
        
        public MainWindow()
        {
            InitializeComponent();
            c = Controler.GetInstance();
        }

        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {

            if (c.Authentification(txtUtilisateur.Text, passwordMotdePasse.Password))
            {
                switch (c.User.IDPoste)
                {
                    case 3:
                        Administrateur Admin = new Administrateur();
                        Admin.Show();
                        break;
                    case 1:
                        Conge Doctor = new Conge();
                        Doctor.Show();
                        break;
                    case 2:
                        FichierAdmission Prep = new FichierAdmission();
                        Prep.Show();
                        break;
                }
            }
            else
            {
                MessageBox.Show("L'utilisateur ou le mot de passe n'est pas correct, s'il vous plaît essayer à nouveau");
            }
            
        }

        private void buttonQuitter_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}