using System.Collections.Generic;
using System.Linq;
using Microsoft.UI.Xaml.Navigation;
using Translator.Core;
using Translator.Models;

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

        #region Public methods

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var param = e.NavigationMode == NavigationMode.Back ? null : (e.Parameter as IEnumerable<PrebuiltNeuralVoice>).ToList();
            PageViewModel.Initialize(param);
        }

        #endregion Public methods
    }
}