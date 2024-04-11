// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

using CosmosCloneCommon.Utility;

namespace CosmicCloneUI
{
    /// <summary>
    /// Interaction logic for DestinationPage.xaml
    /// </summary>
    public partial class DestinationPage : Page
    {
        CosmosDBHelper cosmosHelper;
        public DestinationPage()
        {
            InitializeComponent();
            cosmosHelper = new CosmosDBHelper();
        }

        private void BtnTestTarget(object sender, RoutedEventArgs e)
        {
            TestDestinationConnection();
        }

        public bool TestDestinationConnection()
        {
            ConnectionTestMsg.Text = "";
            CloneSettings.TargetSettings = new CosmosCollectionValues()
            {
                EndpointUrl = TargetURL.Text.ToString(),
                AccessKey = TargetKey.Text.ToString(),
                DatabaseName = TargetDB.Text.ToString(),
                CollectionName = TargetCollection.Text.ToString()
            };

            var result = cosmosHelper.TestTargetConnection();
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
