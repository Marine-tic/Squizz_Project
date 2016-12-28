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

        /// <summary>
        /// Bouton pour accéder à la sélection des modes de jeux
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Play_Click(object sender, TappedRoutedEventArgs e)
        {
            // Redirection vers la page du choix de type de jeu
            Frame.Navigate(typeof(GameTypeSelectionPage), null);
        }

        /// <summary>
        /// Bouton pour accéder au tableau des scores
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void scores_Tapped(object sender, TappedRoutedEventArgs e)
        {
            // Redirection vers la page du tableau des scores
            Frame.Navigate(typeof(ScoreboardPage), null);
        }
    }
}
