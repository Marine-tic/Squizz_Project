using System;
using System.Diagnostics;
using System.Threading;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
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
        }


        private void btnBack_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(GameTypeSelectionPage), this.timeSlider.Value);
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
