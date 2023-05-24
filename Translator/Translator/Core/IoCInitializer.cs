using System;
using Microsoft.Extensions.DependencyInjection;
using Translator.Repositories.Implementations;
using Translator.Repositories.Interfaces;
using Translator.Views;

namespace Translator.Core
{
    public class IoCInitializer
    {
        public static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // Repositories
            services.AddSingleton<ISettingsRepository, SettingsRepository>();
            services.AddSingleton<IAccountsRepository, AccountsRepository>();

            // Services
            // services.AddSingleton(typeof(MyService));

            // ViewModels
            services.AddSingleton(typeof(HomePageViewModel));
            services.AddSingleton(typeof(SettingsPageViewModel));

            return services.BuildServiceProvider();
        }
    }
}