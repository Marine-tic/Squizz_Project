using System;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace Squizz_Project
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class WriteGameInterface : Page
    {
        private Question question;

        //variable pour Timer
        private DispatcherTimer aTimer;
        private double basetime;

        private int compteurQuestion;

        public WriteGameInterface()
        {
            this.InitializeComponent();

            compteurQuestion = (int)Application.Current.Resources["compteur"];

            lblTitle.Text = compteurQuestion.ToString();

            Frame root = Window.Current.Content as Frame;
            root.Navigated += OnNavigated;
            SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;

            initGame();
        }

        private void initGame()
        {
            // Instancier la question et les 4 propositions avec des valeurs en dur dans un premier temps.
            question = new Question(1, "scott pilgrim the game", "ms-appx://Squizz_Project/Assets/GamePicture/scott.jpg", 0);
            // Telecharger et loader toutes les images dans le projet (pour pouvoir les charger lors de l'instanciation de l'objet)
            //OK

            // Changer l'image courante par celle de la question
            BitmapImage myBitmapImage = new BitmapImage(new Uri(question.UrlImage));
            picImageGame.Source = myBitmapImage;

           // this.lblTitle.Text += compteurQuestion.ToString();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var compteurString = e.Parameter as string; //on get le compteur envoyé en paramètre
            compteurQuestion = int.Parse(compteurString); //on parse le string renvoyé par le paramètre
        }


        private void Randomizer()
        {
            Random rand = new Random();
            int typePartie = rand.Next(0, 2);

            compteurQuestion++;

            if (typePartie == 0)
            {
                Frame.Navigate(typeof(ChoiceGameInterface), compteurQuestion.ToString());
            }
            else
            {
                Frame.Navigate(typeof(WriteGameInterface), compteurQuestion.ToString());
            }

            Application.Current.Resources["compteur"] = compteurQuestion;
        }

        #region Timer
        async void timer_Tick(object sender, object e)
        {
            basetime = basetime - 1;
            //lblTimer.Text = basetime.ToString();
            if (basetime == 0)
            {
                aTimer.Stop();
                var dialog = new MessageDialog("Perdu");
                await dialog.ShowAsync();
            }
        }

        private void setTimer()
        {
            basetime = 30;//(double)Application.Current.Resources["timer"];
            lblTimer.Text = basetime.ToString();
            aTimer.Start();
        }

        #endregion


        /// <summary>
        /// Bouton de validation du joueur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void validateAnswer_Tapped(object sender, TappedRoutedEventArgs e)
        {
            int cpt = 1;
            if (txtPlayerAnswer.Text.ToLower().Trim() == question.QuestionName)
            {
                var dialog = new MessageDialog("WINNER");
                await dialog.ShowAsync();
                Randomizer();
                txtPlayerAnswer.IsReadOnly = true;
                cpt++;
            }
            else
            {
                var dialog = new MessageDialog("LOSER");
                await dialog.ShowAsync();
                txtPlayerAnswer.IsReadOnly = true;
                Frame.Navigate(typeof(ScoreboardPage), null);
            }

        }

        #region BOUTON RETOUR
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
        #endregion


    }
}
