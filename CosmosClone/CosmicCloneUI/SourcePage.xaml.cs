using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

using CosmosCloneCommon.Utility;

namespace CosmicCloneUI
{
    /// <summary>
    /// Interaction logic for SourcePage.xaml
    /// </summary>
    public partial class SourcePage : Page
    {
        CosmosDBHelper cosmosHelper;
        public SourcePage()
        {
            InitializeComponent();
            cosmosHelper = new CosmosDBHelper();
        }

        private void BtnTestSource(object sender, RoutedEventArgs e)
        {
            TestSourceConnection();
        }

        public bool TestSourceConnection()
        {
            ConnectionTestMsg.Text = "";
            CloneSettings.SourceSettings = new CosmosCollectionValues()
            {
                EndpointUrl = SourceURL.Text.ToString(),
                AccessKey = SourceKey.Text.ToString(),
                DatabaseName = SourceDB.Text.ToString(),
                CollectionName = SourceCollection.Text.ToString()
            };

            var result = cosmosHelper.TestSourceConnection();
            if (result.IsSuccess)
            {
                var connectionIcon = (Image)this.FindName("ConnectionIcon");
                ConnectionIcon.Source = new BitmapImage(new Uri("/Images/success.png", UriKind.Relative));
                ConnectionTestMsg.Text = "Validation Passed";
            }
            else
            {
                var connectionIcon = (Image)this.FindName("ConnectionIcon");
                ConnectionIcon.Source = new BitmapImage(new Uri("/Images/fail.png", UriKind.Relative));
                ConnectionTestMsg.Text = result.Message;
            }
            return result.IsSuccess;
        }
    }
}
