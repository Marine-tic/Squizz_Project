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

// Pour plus d'informations sur le modèle d'élément Page vierge, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace Squizz_Project
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainMenuPage : Page
    {
        public MainMenuPage()
        {
            this.InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            if (StandardPopup.IsOpen) StandardPopup.IsOpen = false;
        }

        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (StandardPopup.IsOpen == false)
            {
                StandardPopup.IsOpen = true;
                System.Diagnostics.Debug.WriteLine("coucou");
            }
            else
            {
                StandardPopup.IsOpen = false;
                System.Diagnostics.Debug.WriteLine("pas coucou");
            }

        }
    }
}
