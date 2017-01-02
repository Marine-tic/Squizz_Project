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
        private double currentTimer;

        private int currentNumberQuestion;

        public WriteGameInterface()
        {
            this.InitializeComponent();
            if ((int)Application.Current.Resources["timer"] == -1)
                Application.Current.Resources["timer"] = 30.0;


            Frame root = Window.Current.Content as Frame;
            root.Navigated += OnNavigated;
            SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;

            initGame();            
            
            //Timer pour la manche
            this.NavigationCacheMode = NavigationCacheMode.Required;
            aTimer = new DispatcherTimer();
            aTimer.Interval = new TimeSpan(0, 0, 1);
            aTimer.Tick += timer_Tick;

            setTimer();


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
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            currentNumberQuestion = (int)Application.Current.Resources["compteur"];
            lblTitle.Text = "Question " + currentNumberQuestion;
        }

        /// <summary>
        /// fonction de génération aléatoire d'interface de jeu
        /// </summary>
        private void Randomizer()
        {
            Random rand = new Random();
            int typePartie = rand.Next(0, 2);

            currentNumberQuestion++;

            if (typePartie == 0)
            {
                Application.Current.Resources["compteur"] = currentNumberQuestion;
                checkBasetime();
                Frame.Navigate(typeof(ChoiceGameInterface));
                aTimer.Stop();
            }
            else
            {
                Application.Current.Resources["compteur"] = currentNumberQuestion;
                checkBasetime();
                Frame.Navigate(typeof(WriteGameInterface));
                aTimer.Stop();
            }
        }

        private void checkBasetime()
        {
            if (basetime < 30.0)
            {
                Application.Current.Resources["timer"] = 30.0;
                basetime = (double)Application.Current.Resources["timer"];
                //aTimer.Stop();
            }
        }


        #region Timer
        /// <summary>
        /// fonction asynchrone qui actionne le timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void timer_Tick(object sender, object e)
        {
            basetime = basetime - 1;
            lblTimer.Text = basetime.ToString();
            if (basetime == 0)
            {
                aTimer.Stop();
                var dialog = new MessageDialog("Perdu");
                await dialog.ShowAsync();
                Frame.Navigate(typeof(ScoreboardPage));
            }
        }

        /// <summary>
        /// on règle le timer
        /// </summary>
        private void setTimer()
        {
            basetime = (double)Application.Current.Resources["timer"];
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
                checkBasetime();
                Randomizer();
                txtPlayerAnswer.IsReadOnly = true;
                cpt++;
            }
            else
            {
                var dialog = new MessageDialog("LOSER");
                await dialog.ShowAsync();
                checkBasetime();
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
