using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
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
        private int currentNumberQuestion;

        public MainMenuPage()
        {
            this.InitializeComponent();
            Application.Current.Resources["timer"] = -1;

            ApplicationView.PreferredLaunchViewSize = new Size(360, 640);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(360, 640));
        }

        /// <summary>
        /// Bouton pour accéder à la sélection des modes de jeux
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Play_Click(object sender, TappedRoutedEventArgs e)
        {
          //  System.Diagnostics.Debug.WriteLine(this.ActualWidth);
          //  System.Diagnostics.Debug.WriteLine(this.ActualHeight);

            currentNumberQuestion = 1;
            Application.Current.Resources["compteur"] = currentNumberQuestion;
            Randomizer();
        }


        /// <summary>
        /// Permet de switcher de type de question
        /// </summary>
        private void Randomizer()
        {
            Random rand = new Random();
            int typePartie = rand.Next(0, 2);

            if (typePartie == 1)
            {
                Application.Current.Resources["compteur"] = currentNumberQuestion;
                Frame.Navigate(typeof(ChoiceGameInterface));
            }
            else
            {
                Application.Current.Resources["compteur"] = currentNumberQuestion;
                Frame.Navigate(typeof(WriteGameInterface));
            }
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

        private void btnSettings_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(SettingsOnePlayer), null);
        }

        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Rules), null);
        }

        private void about_click(object sender, TappedRoutedEventArgs e)
        {
            PopupTextBlock.Text =
                "Application :" + Environment.NewLine +
                "Version 0.9" + Environment.NewLine +
                "Informations légales Copyright(c) 2017 : " + Environment.NewLine +
                "Marine Landraudie,\n Glenn Le Menn,\n Valentin Léon,\n Guillaume Lombart";
            popup.IsOpen = !popup.IsOpen;
        }

        private void AppBarButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Application.Current.Resources.Remove("user");
            Frame.Navigate(typeof(ConnexionPage),null);
        }
    }
}
