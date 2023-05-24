using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Translator.Models;

namespace Translator.Repositories.Interfaces
{
    public interface IAccountsRepository
    {
        ObservableCollection<Account> Accounts { get; }
        Task InitializeAsync();
    }
}