using Prism.Events;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using WPF.Event;
using WPF.Repositories;

namespace WPF.ViewModel
{
    public class NavigationViewModel : ViewModelBase, INavigationViewModel
    {

        private INavigationRepository _navigationRepository;
        private IEventAggregator _eventAggregator;



        public NavigationViewModel(INavigationRepository navigationRepository, 
            IEventAggregator eventAggregator)
        {
            _navigationRepository = navigationRepository;
            _eventAggregator = eventAggregator;
            Entities = new ObservableCollection<NavigationItemViewModel>();
            _eventAggregator.GetEvent<EntitySavedEvent>().Subscribe(EntitySaved);
            _eventAggregator.GetEvent<EntityDeletedEvent>().Subscribe(EntityDeleted);
        }

        public async Task LoadAsync()
        {
            var lookup = await _navigationRepository.GetEntityAsync();
            Entities.Clear();
            foreach (var item in lookup)
            {
                Entities.Add(new NavigationItemViewModel(item.Id, item.DisplayMember,
                    _eventAggregator));
            }
        }

        public ObservableCollection<NavigationItemViewModel> Entities { get; }
        private void EntityDeleted(int entityId)
        {
            var entity = Entities.SingleOrDefault(f => f.Id == entityId);
             if(entity!= null)
            {
                Entities.Remove(entity);
            }
        }

        private void EntitySaved(EntitySavedEventArgs obj)
        {
            var lookupItem = Entities.SingleOrDefault(l => l.Id == obj.Id);
            if (lookupItem == null)
            {
                Entities.Add(new NavigationItemViewModel(obj.Id, obj.DisplayMember, _eventAggregator));
            }
        }


    }
}
