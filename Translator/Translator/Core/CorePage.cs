using Microsoft.UI.Xaml.Controls;

namespace Translator.Core
{
    public class CorePage : Page
    {
        public CorePage()
        {
            Loaded += (o, i) => LoadState();
            Unloaded += (o, i) => SaveState();
        }

        #region Properties

        public virtual CorePageViewModel ViewModel
        {
            get => DataContext as CorePageViewModel;
            set => DataContext = value;
        }

        #endregion Properties

        #region Privates methods

        private void LoadState()
        {
            ViewModel?.LoadState();
        }

        private void SaveState()
        {
            ViewModel?.SaveState();
        }

        #endregion Privates methods
    }
}