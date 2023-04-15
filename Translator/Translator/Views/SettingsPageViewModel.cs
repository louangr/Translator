using CommunityToolkit.Mvvm.Input;
using Translator.Core;

namespace Translator.Views
{
    public class SettingsPageViewModel : CorePageViewModel
    {

        #region Private fields

        private RelayCommand goBackCommand;

        #endregion Private fields

        #region Properties

        public RelayCommand GoBackCommand
            => goBackCommand ?? (goBackCommand = new RelayCommand(() => GoBack()));

        #endregion Properties
    }
}