using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.Input;
using Translator.Core;
using Translator.Models;
using Translator.Repositories.Interfaces;

namespace Translator.Views
{
    public class SettingsPageViewModel : CorePageViewModel
    {
        #region Private fields

        private string apiKeyInput;
        private string accountNameInput;
        private RelayCommand goBackCommand;
        private RelayCommand addAccountCommand;
        private IAccountsRepository accountsRepository;
        private ISettingsRepository settingsRepository;

        #endregion Private fields

        public SettingsPageViewModel(IAccountsRepository accountsRepository, ISettingsRepository settingsRepository)
        {
            this.accountsRepository = accountsRepository;
            this.settingsRepository = settingsRepository;
        }

        #region Properties

        public string ApiKeyInput
        {
            get => apiKeyInput;
            set
            {
                apiKeyInput = value;
                OnPropertyChanged(nameof(ApiKeyInput));
                AddAccountCommand.NotifyCanExecuteChanged();
            }
        }

        public string AccountNameInput
        {
            get => accountNameInput;
            set
            {
                accountNameInput = value;
                OnPropertyChanged(nameof(AccountNameInput));
                AddAccountCommand.NotifyCanExecuteChanged();
            }
        }

        public ObservableCollection<Account> Accounts => accountsRepository.Accounts;

        public Account SelectedAccount
        {
            get => accountsRepository.Accounts.FirstOrDefault(a => a.ApiKey.Equals(settingsRepository.SelectedAccount?.ApiKey), null);
            set
            {
                settingsRepository.SelectedAccount = value;
                OnPropertyChanged(nameof(SelectedAccount));
            }
        }

        public bool IsAddAccountButtonEnabled => ApiKeyInput != null && ApiKeyInput.Trim() != string.Empty && AccountNameInput != null && AccountNameInput.Trim() != string.Empty && !Accounts.Select((s, e) => s.Name).Contains(AccountNameInput.Trim());

        public bool IsAccountsListViewVisible => Accounts != null && Accounts.Count > 0;

        public RelayCommand GoBackCommand
            => goBackCommand ?? (goBackCommand = new RelayCommand(() => GoBack()));

        public RelayCommand AddAccountCommand
            => addAccountCommand ?? (addAccountCommand = new RelayCommand(() => AddAccount(), () => IsAddAccountButtonEnabled));

        #endregion Properties
        
        #region Public methods

        public void RemoveAccount(string accountName)
        {
            Accounts.Remove(Accounts.FirstOrDefault(a => a.Name == accountName, null));

            if (settingsRepository.SelectedAccount == null)
            {
                SelectedAccount = accountsRepository.Accounts.FirstOrDefault();
            }

            OnPropertyChanged(nameof(Accounts));
            OnPropertyChanged(nameof(IsAccountsListViewVisible));
        }
        
        #endregion Public methods
        
        #region Private methods

        private void AddAccount()
        {
            Accounts.Add(new Account() { Name = AccountNameInput, ApiKey = ApiKeyInput });
            ApiKeyInput = string.Empty;
            AccountNameInput = string.Empty;
            OnPropertyChanged(nameof(Accounts));
            OnPropertyChanged(nameof(IsAccountsListViewVisible));
        }

        #endregion Private methods
    }
}