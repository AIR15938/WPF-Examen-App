using System.Collections.Generic;
using System.Threading.Tasks;
using WPF.Model;

namespace WPF.Repositories
{
    public interface INavigationRepository
    {
        Task<IEnumerable<LookupItem>> GetEntityAsync();
    }
}