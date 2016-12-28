using System;
using Windows.UI.Core;
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
    public sealed partial class GameTypeSelectionPage : Page
    {
        public GameTypeSelectionPage()
        {
            InitializeComponent();

            Frame root = Window.Current.Content as Frame;
            root.Navigated += OnNavigated;
            SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;
        }

        private void OnBackRequested(object sender, BackRequestedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame.CanGoBack)
            {
                e.Handled = true;
                rootFrame.GoBack();
            }
        }

        private void OnNavigated(object sender, NavigationEventArgs e)
        {
            if (((Frame)sender).CanGoBack)
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            else
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
        }

        private void SoloGame_Click(object sender, TappedRoutedEventArgs e)
        {
            // Changement d'interface vers celle du jeu 
            Random rand = new Random();

            if (rand.Next(0, 2) == 0)
                Frame.Navigate(typeof(ChoiceGameInterface), null);
            else
                Frame.Navigate(typeof(WriteGameInterface), null);
        }
    }
}
