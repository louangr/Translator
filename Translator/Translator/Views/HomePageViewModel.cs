using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using Translator.Core;
using Translator.Models;
using Translator.Repositories.Interfaces;

namespace Translator.Views
{
    public class HomePageViewModel : CorePageViewModel
    {
        #region Private fields

        private static readonly string AZURE_LANGUAGE_RESOURCE_FILE_PATH = $"{AppDomain.CurrentDomain.BaseDirectory}PrebuiltNeuralVoicesAzureSpeech.json";

        private List<PrebuiltNeuralVoice> prebuiltNeuralVoices;
        private ObservableCollection<PrebuiltNeuralVoice> sourceTranslationLanguages;
        private ObservableCollection<PrebuiltNeuralVoice> targetTranslationLanguages;
        private RelayCommand navigateToSettingsPageCommand;
        private ISettingsRepository settingsRepository;

        #endregion Private fields

        public HomePageViewModel(ISettingsRepository settingsRepository)
        {
            this.settingsRepository = settingsRepository;
        }

        #region Properties

        public ObservableCollection<PrebuiltNeuralVoice> SourceTranslationLanguages
        {
            get => sourceTranslationLanguages;
            set
            {
                sourceTranslationLanguages = value;
                OnPropertyChanged(nameof(SourceTranslationLanguages));
            }
        }

        public string SourceTranslationLanguageSelected
        {
            get => settingsRepository.SourceTranslationLanguage;
            set
            {
                settingsRepository.SourceTranslationLanguage = value;
                OnPropertyChanged(nameof(SourceTranslationLanguageSelected));
            }
        }

        public ObservableCollection<PrebuiltNeuralVoice> TargetTranslationLanguages
        {
            get => targetTranslationLanguages;
            set
            {
                targetTranslationLanguages = value;
                OnPropertyChanged(nameof(TargetTranslationLanguages));
            }
        }

        public string TargetTranslationLanguageSelected
        {
            get => settingsRepository.TargetTranslationLanguage;
            set
            {
                settingsRepository.TargetTranslationLanguage = value;
                OnPropertyChanged(nameof(TargetTranslationLanguageSelected));
            }
        }

        public RelayCommand NavigateToSettingsPageCommand
            => navigateToSettingsPageCommand ?? (navigateToSettingsPageCommand = new RelayCommand(() => Navigate(typeof(SettingsPage))));

        #endregion Properties

        #region Public methods

        public override void LoadState()
        {
            base.LoadState();
            Initialize();
        }

        #endregion Public methods

        #region Private methods

        private void Initialize()
        {
            var streamReader = new StreamReader(AZURE_LANGUAGE_RESOURCE_FILE_PATH);
            string jsonString = streamReader.ReadToEnd();
            prebuiltNeuralVoices = JsonConvert.DeserializeObject<List<PrebuiltNeuralVoice>>(jsonString);
            var languages = prebuiltNeuralVoices.DistinctBy(v => v.Locale);
            SourceTranslationLanguages = new ObservableCollection<PrebuiltNeuralVoice>(languages);
            TargetTranslationLanguages = new ObservableCollection<PrebuiltNeuralVoice>(languages);
            OnPropertyChanged(nameof(SourceTranslationLanguageSelected));
            OnPropertyChanged(nameof(TargetTranslationLanguageSelected));
        }

        #endregion Private methods
    }
}