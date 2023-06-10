using Translator.Core;

namespace Translator.Views
{
    public sealed partial class TranslationPage : CorePage
    {
        public TranslationPage()
        {
            InitializeComponent();
            DataContext = App.Current.Services.GetService(typeof(TranslationPageViewModel));
        }

        #region Properties

        public TranslationPageViewModel PageViewModel
            => DataContext as TranslationPageViewModel;

        #endregion Properties
    }
}
