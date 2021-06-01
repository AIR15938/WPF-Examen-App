using System.Threading.Tasks;

namespace WPF.ViewModel
{
    public interface INavigationViewModel
    {
        Task LoadAsync();
    }
}