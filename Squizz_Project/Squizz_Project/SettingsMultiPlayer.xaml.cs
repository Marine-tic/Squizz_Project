using Windows.UI.Xaml.Controls;

// Pour plus d'informations sur le modèle d'élément Page vierge, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace Squizz_Project
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class SettingsMultiPlayer : Page
    {
        public SettingsMultiPlayer()
        {
            this.InitializeComponent();
        }

        private void settingsMultiPlayer_return_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(GameTypeSelectionPage), null);
        }

        private void timeSlider_ValueChanged(object sender, Windows.UI.Xaml.Controls.Primitives.RangeBaseValueChangedEventArgs e)
        {
            Slider timeSlider = sender as Slider;
            lblSliderTime.Text = timeSlider.Value.ToString();
        }
    }
}
