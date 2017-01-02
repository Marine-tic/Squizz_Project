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
using Squizz_Project.Squizz_WebService;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Squizz_Project
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class ConnexionPage : Page
    {
        DataManagementClient client = new DataManagementClient();
        public ConnexionPage()
        {
            this.InitializeComponent();
            ApplicationView.PreferredLaunchViewSize = new Size(360, 640);
            //RestServiceClient toto = new RestServiceClient();
            //string result;

            //result = toto.sayHelloTo("La cuccaracha");
            //txtUsernameConnexion.Text = result;
        }

        private async void btnConnexion_Click(object sender, RoutedEventArgs e)
        {
            //WebServiceSquizz.Service1Client wololo = new WebServiceSquizz.Service1Client();
            //WebService.RestServiceClient aze = new WebService.RestServiceClient();

            String msg = "";
            if(txtUsernameConnexion.Text == "" || txtPassword.Password == "")
            {
                msg = "Username or password missing";
            }else{
                msg = client.ConnectionCheckPlayerAsync(txtUsernameConnexion.Text, txtPassword.Password).Result;
            }
            
            //this.Frame.Navigate(typeof(GameTypeSelectionPage)); 
            //btnConnexion.Content = msg; // POUR DEBUG SANS POPUP


            var dialog = new Windows.UI.Popups.MessageDialog(
                msg);

            dialog.Commands.Add(new Windows.UI.Popups.UICommand("Yes") { Id = 0 });
            dialog.Commands.Add(new Windows.UI.Popups.UICommand("No") { Id = 1 });

            if (Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily != "Windows.Mobile")
            {
                // Adding a 3rd command will crash the app when running on Mobile !!!
                dialog.Commands.Add(new Windows.UI.Popups.UICommand("Maybe later") { Id = 2 });
            }

            dialog.DefaultCommandIndex = 0;
            dialog.CancelCommandIndex = 1;

            var result = await dialog.ShowAsync();

            // PENSEZ A VOIR LA FERMETURE DE LA CONNECTION SQL 
        }

        private async void forgotten_PasswordButton_Click(object sender, RoutedEventArgs e)
        {
            String msg = "";
            msg = await client.ForgotPasswordAsync("teamsquizz@outlook.fr", 2);

            forgotten_PasswordButton.Content = msg;
        }
    }
    
}
