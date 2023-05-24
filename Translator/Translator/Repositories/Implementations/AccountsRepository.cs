using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Translator.Models;
using Translator.Repositories.Interfaces;
using Windows.ApplicationModel;
using Windows.Storage;

namespace Translator.Repositories.Implementations
{
    public class AccountsRepository : IAccountsRepository
    {
        #region Private fields

        private readonly string ACCOUNTS_FILENAME = "accounts.json";
        private readonly string ACCOUNTS_FILE_PATH;
        private readonly JsonSerializer serializer;

        private ObservableCollection<Account> accounts;

        #endregion Private fields

        public AccountsRepository()
        {
            ACCOUNTS_FILE_PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), Uri.UnescapeDataString(Package.Current.Id.FamilyName.ToString()));
            serializer = new JsonSerializer();
        }

        #region Properties

        public ObservableCollection<Account> Accounts => accounts;

        #endregion Properties
        
        #region Public methods
        
        public async Task InitializeAsync()
        {
            accounts = await LoadAccountsAsync();
        }

        #endregion Public methods

        #region Private methods

        private async Task<ObservableCollection<Account>> LoadAccountsAsync()
        {
            var accounts = new ObservableCollection<Account>();

            try
            {
                if (Directory.Exists(ACCOUNTS_FILE_PATH))
                {
                    StorageFolder folder = await StorageFolder.GetFolderFromPathAsync(ACCOUNTS_FILE_PATH);
                    StorageFile dataFile = await folder.GetFileAsync(ACCOUNTS_FILENAME);

                    if (dataFile != null)
                    {

                        using (var stream = await dataFile.OpenStreamForReadAsync())
                        using (var sr = new StreamReader(stream))
                        using (var jsonTextReader = new JsonTextReader(sr))
                        {
                            accounts = new ObservableCollection<Account>(serializer.Deserialize<List<Account>>(jsonTextReader));
                        }
                    }
                }
            }
            catch (FileNotFoundException) { }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception when try to load accounts: {ex.Message}");
            }

            accounts.CollectionChanged += (s, e) => SaveAccountsAsync().ConfigureAwait(false);
            return accounts;
        }

        private async Task SaveAccountsAsync()
        {
            try
            {
                if (!Directory.Exists(ACCOUNTS_FILE_PATH))
                {
                    Directory.CreateDirectory(ACCOUNTS_FILE_PATH);
                }

                StorageFolder folder = await StorageFolder.GetFolderFromPathAsync(ACCOUNTS_FILE_PATH);
                StorageFile dataFile = await folder.CreateFileAsync(ACCOUNTS_FILENAME, CreationCollisionOption.ReplaceExisting);
                
                if (dataFile != null)
                {
                    using (var stream = await dataFile.OpenStreamForWriteAsync())
                    using (var sw = new StreamWriter(stream))
                    using (var jsonTextWritter = new JsonTextWriter(sw))
                    {
                        serializer.Serialize(jsonTextWritter, Accounts.ToList());
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception when try to load local accounts: {ex.Message}");
            }
        }
        
        #endregion Private methods
    }
}