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
            ApplicationView.PreferredLaunchViewSize = new Size(360, 640);
            //RestServiceClient toto = new RestServiceClient();
            //string result;

            //result = toto.sayHelloTo("La cuccaracha");
            //txtUsernameConnexion.Text = result;
        }

        private void btnConnexion_Click(object sender, RoutedEventArgs e)
        {
            //WebServiceSquizz.Service1Client wololo = new WebServiceSquizz.Service1Client();
            //WebService.RestServiceClient aze = new WebService.RestServiceClient();
        }
    }
    
}
