using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
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
    public sealed partial class SettingsOnePlayer : Page
    {
        public SettingsOnePlayer()
        {
            this.InitializeComponent();
            this.lblSliderTime.Text = this.timeSlider.Value.ToString();
            //Frame root = Window.Current.Content as Frame;
            //root.Navigated += OnNavigated;
        }

        private void btnBack_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(GameTypeSelectionPage), null);
        }

        #region Afficher/Cacher bouton de retour + Action
        private void OnNavigated(Object sender, NavigationEventArgs e)
        {
            if (((Frame)sender).CanGoBack)
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            else
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
        }
        #endregion
    }
}
