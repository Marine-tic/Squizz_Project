using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Squizz_Project.SquizzWebService;

// Pour plus d'informations sur le modèle d'élément Page vierge, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace Squizz_Project
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class ForgotPassword : Page
    {
        DataManagementClient client = new DataManagementClient();

        public ForgotPassword()
        {
            this.InitializeComponent();
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private async void SendAndReturn(object sender, TappedRoutedEventArgs e)
        {
            // Mettre en place l'envoi d'email 
            String msg = "";
            msg = await client.ForgotPasswordAsync("teamsquizz@outlook.fr", 2);
            
            // Retour vers la vu de connexion 
            this.Frame.Navigate(typeof(ConnexionPage), null);
        }
    }
}
