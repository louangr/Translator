using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using Translator.Core;

namespace Translator.Views
{
    public sealed partial class SettingsPage : CorePage
    {
        public SettingsPage()
        {
            InitializeComponent();
            DataContext = App.Current.Services.GetService(typeof(SettingsPageViewModel));
        }

        #region Properties

        public SettingsPageViewModel PageViewModel
            => DataContext as SettingsPageViewModel;

        #endregion Properties

        #region Private methods

        private void TrashButtonClick(object sender, RoutedEventArgs e) => PageViewModel.RemoveAccount((string)(sender as Button).CommandParameter);
        
        #endregion Private methods
    }
}
