using Prism.Commands;
using Prism.Events;
using System.Windows.Input;
using WPF.Event;

namespace WPF.ViewModel
{
    public class NavigationItemViewModel : ViewModelBase
    {
        private string _displayMember;
        private IEventAggregator _eventAggregator;

        public NavigationItemViewModel(int id, string displayMember, IEventAggregator eventAggregator)
        {
            Id = id;
            DisplayMember = displayMember;
            _eventAggregator = eventAggregator;
            EntityIdDetailViewCommand = new DelegateCommand(OnEntityDetailView);
        }

        public int Id { get; }

        public string DisplayMember
        {
            get { return _displayMember; }
            set
            {
                _displayMember = value;
                OnPropertyChanged();
            }
        }

        public ICommand EntityIdDetailViewCommand { get; }

        private void OnEntityDetailView()
        {
            _eventAggregator.GetEvent<EntityDetailViewEvent>()
                .Publish(Id);
        }
        
    }
}
