using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using Translator.Core;

namespace Translator.Views
{
    public class SettingsPageViewModel : CorePageViewModel
    {

        #region Private fields

        private string apiKeyInput;
        private string accountNameInput;
        private ObservableCollection<Tuple<string, string>> accounts;
        private RelayCommand goBackCommand;
        private RelayCommand addAccountCommand;

        #endregion Private fields

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

        public ObservableCollection<Tuple<string, string>> Accounts
        {
            get => accounts;
            set
            {
                accounts = value;
                OnPropertyChanged(nameof(Accounts));
            }
        }

        public bool IsAddAccountButtonEnabled => ApiKeyInput != null && ApiKeyInput.Trim() != string.Empty && AccountNameInput != null && AccountNameInput.Trim() != string.Empty;

        public bool IsAccountsListViewVisible => Accounts != null && Accounts.Count > 0;

        public RelayCommand GoBackCommand
            => goBackCommand ?? (goBackCommand = new RelayCommand(() => GoBack()));

        public RelayCommand AddAccountCommand
            => addAccountCommand ?? (addAccountCommand = new RelayCommand(() => AddAcount(), () => IsAddAccountButtonEnabled));

        #endregion Properties

        #region Private methods

        private void AddAcount()
        {
        }

        #endregion Private methods
    }
}