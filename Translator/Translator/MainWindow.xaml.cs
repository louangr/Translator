using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media.Animation;
using Newtonsoft.Json;
using Translator.Models;
using Translator.Views;

namespace Translator
{
    public sealed partial class MainWindow : Window
    {
        #region Private fields
        
        private static readonly string AZURE_LANGUAGE_RESOURCE_FILE_PATH = $"{AppDomain.CurrentDomain.BaseDirectory}PrebuiltNeuralVoicesAzureSpeech.json";
        
        #endregion Private fields

        public MainWindow()
        {
            InitializeComponent();
            Initialize();
        }

        #region Public methods

        public void Navigate(Type page, object parameter = null) => ContentFrame.Navigate(page, parameter, new EntranceNavigationTransitionInfo());

        public void GoBack() => ContentFrame.GoBack(new EntranceNavigationTransitionInfo());

        #endregion Public methods

        #region Private methods

        private void Initialize()
        {
            var streamReader = new StreamReader(AZURE_LANGUAGE_RESOURCE_FILE_PATH);
            var jsonString = streamReader.ReadToEnd();
            var prebuiltNeuralVoices = JsonConvert.DeserializeObject<List<PrebuiltNeuralVoice>>(jsonString).DistinctBy(v => v.Locale);
            Navigate(typeof(HomePage), prebuiltNeuralVoices);
        }

        #endregion Private methods
    }
}
