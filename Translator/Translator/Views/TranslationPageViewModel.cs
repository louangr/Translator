using CommunityToolkit.Mvvm.Input;
using Translator.Core;

namespace Translator.Views
{
    public class TranslationPageViewModel : CorePageViewModel
    {
        #region Private fields
        
        private RelayCommand goBackCommand;

        #endregion Private fields
        
        public TranslationPageViewModel() { }

        #region Properties
        
        public RelayCommand GoBackCommand
            => goBackCommand ?? (goBackCommand = new RelayCommand(() => GoBack()));

        #endregion Properties
    }
}