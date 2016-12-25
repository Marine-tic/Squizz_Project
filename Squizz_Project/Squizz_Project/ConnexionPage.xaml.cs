using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.ServiceModel;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Squizz_Project
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class ConnexionPage : Page
    {
        public ConnexionPage()
        {
            this.InitializeComponent();
           // ApplicationView.PreferredLaunchViewSize = new Size(360, 640);
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(400, 650));
        }

        private void btnConnexion_Click(object sender, RoutedEventArgs e)
        {
            //TODO: connexion to the DB via Web service if it exists
        }

        
        private void forgotPassword_Click(object sender, TappedRoutedEventArgs e)
        {
            // Changement d'interface pour que l'utilisateur renseigne son adresse mail
            // Page : ForgotPassword
            this.Frame.Navigate(typeof(ForgotPassword), null);

        }

        private void Connexion_Click(object sender, TappedRoutedEventArgs e)
        {
            // Redirection vers la page principale du jeu 

            // Faire un check en BDD pour savoir si l'utilisateur existe

            // Faire une check pour savoir si l'utilisateur et mot de passe correspondent
        }

        private void NewAccount_Click(object sender, TappedRoutedEventArgs e)
        {
            // Redirection vers la page de création d'utilisateur 
            this.Frame.Navigate(typeof(SignInPage), null);
        }
    }
    
}
