using System;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media.Animation;
using Translator.Views;

namespace Translator
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Navigate(typeof(HomePage));
        }

        #region Public methods

        public void Navigate(Type page, object parameter = null) => ContentFrame.Navigate(page, parameter, new EntranceNavigationTransitionInfo());

        public void GoBack() => ContentFrame.GoBack(new EntranceNavigationTransitionInfo());

        #endregion Public methods
    }
}
