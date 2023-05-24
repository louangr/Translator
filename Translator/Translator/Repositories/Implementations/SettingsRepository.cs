using System;
using System.Diagnostics;
using Newtonsoft.Json;
using Translator.Models;
using Translator.Repositories.Interfaces;
using Windows.ApplicationModel;
using Windows.Management.Core;

namespace Translator.Repositories.Implementations
{
    public class SettingsRepository : ISettingsRepository
    {
        #region Publics Properties

        public string SourceTranslationLanguage
        {
            get => TryGetLocalValue(nameof(SourceTranslationLanguage), string.Empty);
            set => TrySetLocalValue(nameof(SourceTranslationLanguage), value);
        }

        public string TargetTranslationLanguage
        {
            get => TryGetLocalValue(nameof(TargetTranslationLanguage), string.Empty);
            set => TrySetLocalValue(nameof(TargetTranslationLanguage), value);
        }

        public Account SelectedAccount
        {
            get
            {
                var json = TryGetLocalValue(nameof(SelectedAccount), string.Empty);

                if (!string.IsNullOrEmpty(json))
                {
                    return JsonConvert.DeserializeObject<Account>(json);
                }

                return null;
            }
            set
            {
                TrySetLocalValue(nameof(SelectedAccount), JsonConvert.SerializeObject(value));
            }
        }

        #endregion Publics Properties

        #region Private Methods

        private T TryGetLocalValue<T>(string key, T defaultValue)
        {
            try
            {
                object tValue;

                if (!ApplicationDataManager.CreateForPackageFamily(Package.Current.Id.FamilyName).LocalSettings.Values.TryGetValue(key, out tValue))
                {
                    return defaultValue;
                }

                return (T)tValue;
            }
            catch
            {
                return defaultValue;
            }
        }

        private void TrySetLocalValue<T>(string key, T value)
        {
            try
            {
                var appData = ApplicationDataManager.CreateForPackageFamily(Package.Current.Id.FamilyName);

                if (appData.LocalSettings.Values.ContainsKey(key))
                {
                    appData.LocalSettings.Values[key] = value;
                }
                else
                {
                    appData.LocalSettings.Values.Add(key, value);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        #endregion Private Methods
    }
}