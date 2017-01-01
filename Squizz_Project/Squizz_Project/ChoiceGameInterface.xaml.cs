using Squizz_Project.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace Squizz_Project
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    ///
    public sealed partial class ChoiceGameInterface : Page
    {
        // Déclarer une question et 4 propositions
        Question question;
        private Proposal proposal0;
        private Proposal proposal1;
        private Proposal proposal2;
        private Proposal proposal3;
        private const String YOU_WIN = "YOU WIN !";
        private const String YOU_LOSE = "YOU LOSE !";
        private Questions listeDeQuestion;

        public ChoiceGameInterface()
        {
            this.InitializeComponent();

            Frame root = Window.Current.Content as Frame;
            root.Navigated += OnNavigated;
            SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;

            initGame();

            // Ensuite faire une liste de questions avec une liste de proposition associé à chaque question et prendre un nombre aléatoire pour la sélection de la question
            listeDeQuestion = new Questions();
            // Remplir les champs en conséquence de la même manière que plus haut.
            // Remplacer l'evenement OK et PERDU par une nouvelle question s'il y en a une nouvelle ou alors PERDU avec un écran de perdu? à voir en fonction des interfaces déjà présentes

            // Quand tout ça marche ajouter la gestion du score

            // Coté online quand dispo
            // Connexion à la BDD pour récupérer la question numéro random ainsi que ses propositions associés et instancier les objets avec les valeurs récupérées de la BDD
            // Utiliser ensuite la meme mécanique sauf que la mise à jour des score sera faite en BDD.

            // Voir quand la partie se termine? Combien de question doit être répondu correct pour que le joueur gagne la partie et voit son score augmenté?
            // => une partie dispose de 10 questions
        }

        private void initGame()
        {
            // Instancier la question et les 4 propositions avec des valeurs en dur dans un premier temps.
            question = new Question(0, "Dishonored", "ms-appx://Squizz_Project/Assets/GamePicture/dishonored.jpg", 0);
            proposal0 = new Proposal(0, "Dishonored", true, 0);
            proposal1 = new Proposal(1, "GTA", false, 0);
            proposal2 = new Proposal(2, "Hitman", false, 0);
            proposal3 = new Proposal(3, "Skyrim", false, 0);
            // Telecharger et loader toutes les images dans le projet (pour pouvoir les charger lors de l'instanciation de l'objet)
            //OK

            // Changer l'image courante par celle de la question
            BitmapImage myBitmapImage = new BitmapImage(new Uri(question.UrlImage));
            ImageGame.Source = myBitmapImage;

            // Changer le texte des propositions par celles des 4 objets instanciés
            answerTopLeft.Content = proposal0.ProposalName;
            answerTopRight.Content = proposal1.ProposalName;
            answerBottomLeft.Content = proposal2.ProposalName;
            answerBottomRight.Content = proposal3.ProposalName;
        }

        // Ajouter un tapListener sur chaque proposition et vérifier si la proposition cliquée est la réponse dans ce cas afficher YOU WIN et mettre la case cochée en vert
        // sinon afficher YOU LOSE et mettre la case en rouge
        private void answerTopLeft_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            CheckWin(proposal0, answerTopLeft);
        }

        private void answerTopRight_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            CheckWin(proposal1, answerTopRight);
        }

        private void answerBottomLeft_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            CheckWin(proposal2, answerBottomLeft);
        }

        private void answerBottomRight_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            CheckWin(proposal3, answerBottomRight);
        }

        private async void CheckWin(Proposal proposalSelected, Button buttonProposal)
        {
            if (proposalSelected.IsAnswer)
            {
                buttonProposal.Background = new SolidColorBrush(Color.FromArgb(255, 22, 169, 49));
                var dialog = new MessageDialog(YOU_WIN);
                await dialog.ShowAsync();
                Randomizer();
            }
            else
            {
                buttonProposal.Background = new SolidColorBrush(Color.FromArgb(255, 169, 22, 22));
                var dialog = new MessageDialog(YOU_LOSE);
                await dialog.ShowAsync();
                Frame.Navigate(typeof(ScoreboardPage), null);
            }
        }

        /// <summary>
        /// Permet de switcher de type de question
        /// </summary>
        private void Randomizer()
        {
            Random rand = new Random();
            int typePartie = rand.Next(0, 2);

            if (typePartie == 0)
                Frame.Navigate(typeof(ChoiceGameInterface), null);
            else
                Frame.Navigate(typeof(WriteGameInterface), null);
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
