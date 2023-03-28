﻿using System;
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

            // Services
            // services.AddSingleton(typeof(MyService));

            // ViewModels
            services.AddSingleton(typeof(HomePageViewModel));

            return services.BuildServiceProvider();
        }
    }
}