using System.Threading.Tasks;

namespace WPF.ViewModel
{
    public interface IEntityDetailViewModel
    {
        Task LoadAsync(int? entityId);
        bool HasChanges { get; }

    }
}