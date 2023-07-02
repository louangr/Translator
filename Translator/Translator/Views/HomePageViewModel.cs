using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using Translator.Core;
using Translator.Models;
using Translator.Repositories.Interfaces;

namespace Translator.Views
{
    public class HomePageViewModel : CorePageViewModel
    {
        #region Private fields

        private ObservableCollection<PrebuiltNeuralVoice> sourceTranslationLanguages;
        private ObservableCollection<PrebuiltNeuralVoice> targetTranslationLanguages;
        private RelayCommand navigateToSettingsPageCommand;
        private RelayCommand navigateToTranslationPageCommand;
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
                NavigateToTranslationPageCommand.NotifyCanExecuteChanged();
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
                NavigateToTranslationPageCommand.NotifyCanExecuteChanged();
            }
        }

        public bool IsTranslationLanguagesSelected => !string.IsNullOrEmpty(TargetTranslationLanguageSelected) && !string.IsNullOrEmpty(SourceTranslationLanguageSelected);

        public RelayCommand NavigateToSettingsPageCommand
            => navigateToSettingsPageCommand ?? (navigateToSettingsPageCommand = new RelayCommand(() => Navigate(typeof(SettingsPage))));

        public RelayCommand NavigateToTranslationPageCommand
            => navigateToTranslationPageCommand ?? (navigateToTranslationPageCommand = new RelayCommand(() => Navigate(typeof(TranslationPage)), () => IsTranslationLanguagesSelected));

        #endregion Properties

        #region Public methods

        public override void LoadState()
        {
            base.LoadState();
            Initialize();
        }

        #endregion Public methods

        #region Private methods

        public void Initialize(List<PrebuiltNeuralVoice> prebuiltNeuralVoices = null)
        {
            if (prebuiltNeuralVoices != null)
            {
                SourceTranslationLanguages = new ObservableCollection<PrebuiltNeuralVoice>(prebuiltNeuralVoices);
                TargetTranslationLanguages = new ObservableCollection<PrebuiltNeuralVoice>(prebuiltNeuralVoices);
            }
            OnPropertyChanged(nameof(SourceTranslationLanguageSelected));
            OnPropertyChanged(nameof(TargetTranslationLanguageSelected));
        }

        #endregion Private methods
    }
}