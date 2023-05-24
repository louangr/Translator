using System;
using Microsoft.UI.Xaml;
using Translator.Core;
using Translator.Repositories.Implementations;
using Translator.Repositories.Interfaces;
using Translator.Strings;
using Translator.Views;

namespace Translator
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            InitializeComponent();
            Services = IoCInitializer.ConfigureServices();
            (Services.GetService(typeof(IAccountsRepository)) as IAccountsRepository).InitializeAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the current <see cref="App"/> instance in use
        /// </summary>
        public new static App Current => (App)Application.Current;

        /// <summary>
        /// Gets the <see cref="IServiceProvider"/> instance to resolve application services.
        /// </summary>
        public IServiceProvider Services;

        public Window MainWindow { get; private set; }

        /// <summary>
        /// Invoked when the application is launched.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            MainWindow = new MainWindow();
            MainWindow.Title = LocalizedStrings.GetString("AppName");

            MainWindow.Activate();
        }
    }
}
