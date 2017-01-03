using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Squizz_Project.SquizzWebService;
// Pour plus d'informations sur le modèle d'élément Page vierge, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace Squizz_Project
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class SignUpPage : Page
    {
        DataManagementClient client = new DataManagementClient();
        public SignUpPage()
        {
            this.InitializeComponent();
        }

 

        private void btnCreation_Tapped(object sender, TappedRoutedEventArgs e)
        {
            string msg = "";
            if (txtMail.Text != "" && txtPassword.Password != "" && txtUsername.Text != "")
            {
                msg =  client.SignupPlayerAsync(txtUsername.Text, txtPassword.Password, txtMail.Text).Result;
            }
            else
            {
                msg = "1 or multiple fields are missing";
            }

            var dialog = new Windows.UI.Popups.MessageDialog(msg);
            dialog.Commands.Add(new Windows.UI.Popups.UICommand("OK") { Id = 0 });
            dialog.DefaultCommandIndex = 0;
            var result =  dialog.ShowAsync();
        }
    }
}
