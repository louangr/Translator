using Translator.Core;

namespace Translator.Views
{
    public sealed partial class HomePage : CorePage
    {
        public HomePage()
        {
            InitializeComponent();
            DataContext = App.Current.Services.GetService(typeof(HomePageViewModel));
        }

        #region Properties

        public HomePageViewModel PageViewModel
            => DataContext as HomePageViewModel;

        #endregion Properties
    }
}