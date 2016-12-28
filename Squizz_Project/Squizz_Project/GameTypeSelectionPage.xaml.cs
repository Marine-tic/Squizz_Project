using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

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
        }

        private void SoloGame_Click(object sender, TappedRoutedEventArgs e)
        {
            // Changement d'interface vers celle du jeu 
            Frame.Navigate(typeof(ChoiceGameInterface), null);
        }
    }
}
