using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class WriteGameInterface : Page
    {
        private Question question;

        public WriteGameInterface()
        {
            this.InitializeComponent();
            initGame();
        }

        private void initGame()
        {
            // Instancier la question et les 4 propositions avec des valeurs en dur dans un premier temps.
            question = new Question(1, "Scott Pilgrim The Game", "ms-appx://Squizz_Project/Assets/GamePicture/scott.jpg", 0);
            // Telecharger et loader toutes les images dans le projet (pour pouvoir les charger lors de l'instanciation de l'objet)
            //OK

            // Changer l'image courante par celle de la question
            BitmapImage myBitmapImage = new BitmapImage(new Uri(question.UrlImage));
            picImageGame.Source = myBitmapImage;

        }

        /// <summary>
        /// Bouton de validation du joueur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void validateAnswer_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (txtPlayerAnswer.Text == question.QuestionName)
            {
                var dialog = new MessageDialog("WINNER");
                await dialog.ShowAsync();
                txtPlayerAnswer.IsReadOnly = true;
            }
            else
            {
                var dialog = new MessageDialog("LOSER");
                await dialog.ShowAsync();
                txtPlayerAnswer.IsReadOnly = true;
            }

        }
    }
}
