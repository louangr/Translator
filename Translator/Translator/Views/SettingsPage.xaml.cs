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
    }
}
