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

namespace GalerieArtSGIWin
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int counter = 0;

        public MainWindow()
        {
            InitializeComponent();
            {
                txtUtilisateur.Text = String.Empty;
            }
        }

        private void txtUtilisateur_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void passwordMotdePasse_PasswordChanged(object sender, RoutedEventArgs e)
        {

        }

        private void buttonQuitter_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            if ((txtUtilisateur.Text == "") || (passwordMotdePasse.Password == ""))
            {
                MessageBox.Show("L'utilisateur et un mot de passe sont requis");
            }
            if ((txtUtilisateur.Text == "SGI") && (passwordMotdePasse.Password == "admin"))
            {
                this.Hide();
                SGIArt sgiArt = new SGIArt();
                sgiArt.ShowDialog();
                
            }
            if ((txtUtilisateur.Text != "SGI") || (passwordMotdePasse.Password != "admin"))
            {
                while (counter < 3)
                {
                    MessageBox.Show("L'utilisateur ou mot de passe incorrecte");
                    counter++;
                    txtUtilisateur.Clear();
                    passwordMotdePasse.Clear();

                    if (counter < 3)
                    {
                        return;
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
