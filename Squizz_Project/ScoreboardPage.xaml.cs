using Squizz_Project.SquizzWebService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace Squizz_Project
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class ScoreboardPage : Page
    {
        DataManagementClient client = new DataManagementClient();
        ObservableCollection<SquizzWebService.Player> result = new ObservableCollection<SquizzWebService.Player>();
        public ScoreboardPage()
        {
            this.InitializeComponent();
        }

        private void btnBack_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainMenuPage), null);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Task.Run(() => getScoreList()).Wait();
            lvDataTemplates.ItemsSource = result;
        }

        private async Task getScoreList()
        {
            result = await client.GetPlayerScoreListAsync();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainMenuPage));
        }
    }
}
