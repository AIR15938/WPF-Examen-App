using Prism.Commands;
using Prism.Events;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.Event;
using WPF.Services;

namespace WPF.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private IEventAggregator _eventAggregator;
        private Func<IEntityDetailViewModel> _entityDetailViewModelCreator;
        private IEntityDetailViewModel _entityDetailViewModel;
        private IMessageDialog _messageDialog;

        public MainViewModel(INavigationViewModel navigationViewModel,
          Func<IEntityDetailViewModel> entityDetailViewModelCreator,
          IEventAggregator eventAggregator,
          IMessageDialog messageDialog)
        {
            _eventAggregator = eventAggregator;
            _entityDetailViewModelCreator = entityDetailViewModelCreator;
            _messageDialog = messageDialog;

            _eventAggregator.GetEvent<EntityDetailViewEvent>()
             .Subscribe(EntityDetailView);
            _eventAggregator.GetEvent<EntityDeletedEvent>()
              .Subscribe(EntityDeleted);

            CreateNewEntityCommand = new DelegateCommand(CreateNewEntityExecute);

            NavigationViewModel = navigationViewModel;
        }

        public async Task LoadAsync()
        {
            await NavigationViewModel.LoadAsync();
        }

        public ICommand CreateNewEntityCommand { get; }

        public INavigationViewModel NavigationViewModel { get; }

        public IEntityDetailViewModel EntityDetailViewModel
        {
            get { return _entityDetailViewModel; }
            private set
            {
                _entityDetailViewModel = value;
                OnPropertyChanged();
            }
        }

        private async void EntityDetailView(int? entityId)
        {
            if (EntityDetailViewModel != null && EntityDetailViewModel.HasChanges)
            {
                var result = _messageDialog.ShowOkCancelDialog("Changes are made, are you sure you want to leave?", "Question");
                if (result == MessageDialog.MessageDialogResult.Cancel)
                {
                    return;
                }
            }
            EntityDetailViewModel = _entityDetailViewModelCreator();
            await EntityDetailViewModel.LoadAsync(entityId);
        }

        private void CreateNewEntityExecute()
        {
            EntityDetailView(null);
        }

        private void EntityDeleted(int entityId)
        {
            EntityDetailViewModel = null;
        }
    }
}
